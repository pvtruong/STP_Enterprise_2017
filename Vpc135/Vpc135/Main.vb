Imports Clsql
Imports ClsControl2
Imports ClsControl2.PropertyOfForm
Imports ClsLookup
Imports ClsSV31
Imports System.ComponentModel
Imports ClsStpService

Public Class Frmmain
    Implements ExecImp
    Dim frmin As New frminput
    Private _def_condition As String = Nothing
    Public Property def_condition As String Implements ExecImp.def_condition
        Get
            Return _def_condition
        End Get
        Set(value As String)
            _def_condition = value
        End Set
    End Property
    Private _defaultFields As Dictionary(Of String, Object) = Nothing
    Public Property defaultFields As Dictionary(Of String, Object) Implements ExecImp.defaultFields
        Get
            Return _defaultFields
        End Get
        Set(value As Dictionary(Of String, Object))
            _defaultFields = value
        End Set
    End Property
    Private _addNewWhenLoadFirst As Boolean = False
    Public Property addNewWhenLoadFirst As Boolean Implements ExecImp.addNewWhenLoadFirst
        Get
            Return _addNewWhenLoadFirst
        End Get
        Set(value As Boolean)
            _addNewWhenLoadFirst = value
        End Set
    End Property
    Public Sub setId(_voucherid As String) Implements ExecImp.SetId
        If Voucher Is Nothing Then
            Voucherid = _voucherid.Split(" ")(0)
            Voucher = New Voucher20(Voucherid, grd, frmin.TabControl1, frmin)
            frmin.setParent(Me)
            Voucher.autoRefreshMaster = False
            grd.ReadOnly = False
            SetLable(Voucher.oLan, Me)
            Me.Icon = frmin.Icon
            Voucher.AddToolStrip(ToolStrip1)
            'tao menu
            Dim ctm As New ContextMenuStrip
            Voucher.AddContextMenuStrip(ctm)
            Me.ContextMenuStrip = ctm
            Dim tabmanager As New TabManager(frmin.TabControl1)
            SetUpLookup()
            loadf()
        End If
    End Sub
    Public Sub Add(defaultFields As Dictionary(Of String, Object)) Implements ExecImp.Add
        Voucher.add_first_argument = defaultFields
        If Voucher.add_first_argument Is Nothing Then
            Voucher.add_first_argument = New Dictionary(Of String, Object)
        End If
        Voucher.News()
    End Sub

    Public Sub Search(condition As String) Implements ExecImp.Search
        If condition <> Me.def_condition Then
            Voucher.Search(condition)
        End If
    End Sub

    Sub New()
        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        txtuser.Text = Clsql.Reg.GetValue("ID")


    End Sub
    Private Sub dmload(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '


        '  loadf()
    End Sub

    Private Sub thoat(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuthoat.Click
        Voucher = Nothing
        Me.Close()
    End Sub
    Private Sub tim()
        Dim search As New frmsearch
        search.Icon = Me.Icon
        search.StartPosition = FormStartPosition.CenterParent
        ClsControl2.PropertyOfForm.SetLable(Voucher.oLan, search)
        If search.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
            Clsql.Reg.SetValue("tu_ngay", search.Txttu_ngay.Value)
            Clsql.Reg.SetValue("den_ngay", search.TxtDen_ngay.Value)
            Clsql.Reg.SetValue("ma_kh", search.txtma_kh.Text)

            Dim query As String
            Dim strdk As String = " ngay_ct between " & Voucher.conn.ConvertToSQLType(search.Txttu_ngay.Value) & " and " & Voucher.conn.ConvertToSQLType(search.TxtDen_ngay.Value)
            strdk = strdk & " and  ma_kh like '" & search.txtma_kh.Text & "%'"
            strdk = strdk & " and  so_ct like '" & search.txtso_ct.Text & "%'"


            query = Voucher.QueryLoad & " and " & strdk & " and stt_rec in " & "(select stt_rec from vdpc1 where "

            query = query & " ma_bp like '" & search.txtma_bp.Text
            query = query & "%' and ma_phi like '" & search.txtma_phi.Text
            query = query & "%' and ma_dt like '" & search.txtma_dt.Text & "%')"

            Voucher.LoadData(query.Replace("#*#", "cast(0 as bit) as sel,*"))
        End If

    End Sub

    Sub beforeadd(ByVal e As String)
        Dim defaultvalue As New Collection
        defaultvalue.Add(Now, "ngay_ct")
        Voucher.ValueDefaults = defaultvalue
        frmin.TabControl1.SelectedTab = frmin.TabControl1.TabPages(0)
    End Sub
    Sub SetUpLookup()

        Voucher.Tabdetails("vtdttco").AutoLoad = False
        AddHandler Voucher.Tabdetails("vtdttco").Load, AddressOf detailHD_load
        

        ClsLookup.AddItems.AddItemCbb(Voucher.conn, "select inds,text,text2 from dmitemofcbb where form ='" & Voucherid & "' and name = 'status'", frmin.cbbstatus, "text", "text2", "inds")
        ClsLookup.AddItems.AddItemCbb(Voucher.conn, "select inds,text,text2 from dmitemofcbb where form ='" & Voucherid & "' and name = 'ma_gd'", frmin.cbbma_gd, "text", "text2", "inds")
        'hd

        ClsLookup.AddItems.AddItemCbb(Voucher.conn, "exec s_dmnt", frmin.cbbma_nt, "ten_nt", "ma_nt")

        AddHandler Voucher.FormLookups.Item("txtma_kh").AfterLookup, AddressOf ma_khSelected

    End Sub
    Dim current_kh As StpTableRow
    Sub ma_khSelected(ByVal row As StpTableRow)
        frmin.txtcon_no.Value = 0
        current_kh = row
        Dim thread As New Threading.Thread(AddressOf tinh_cn_ht)
        thread.IsBackground = True
        thread.Start()

    End Sub
    Public Delegate Sub DelegateStandardPattern(ByVal cn As Double)

    Sub setCon_no(ByVal cn As Double)
        frmin.txtcon_no.Value = cn
    End Sub
    Sub tinh_cn_ht()
        Try
            Dim query As String = "select du from dbo.EdCust('331'"
            query = query & "," & conn.ConvertToSQLType(current_kh("ma_kh"))
            query = query & "," & conn.ConvertToSQLType(Now)
            query = query & ",'')"
            Dim cn As Double = conn.GetValue(query)
            If frmin.txtcon_no.InvokeRequired Then
                frmin.txtcon_no.Invoke(New DelegateStandardPattern(AddressOf setCon_no), cn)
            Else
                setCon_no(cn)
            End If

        Catch ex As Exception
        End Try
    End Sub

    Sub detailHD_load(ByVal e As String)
        Voucher.Tabdetails("vtdttco").gridDetailKeyin.AllowUserToAddRows = False
        If Voucher.Action = ClsSV31.Voucher20.Actions.ADD Then
            frmin.Txtngay_ct.Value = Now
        Else
            frmin.Txtngay_ct.Value = grd.Item("ngay_ct", grd.CurrentRow.Index).Value
            frmin.txtma_kh.Text = grd.Item("ma_kh", grd.CurrentRow.Index).Value
        End If
        Voucher.Tabdetails("vtdttco").Datatable = conn.GetDatatable("Exec GetInvoice4Paid_load ''," & conn.ConvertToSQLType(frmin.Txtngay_ct.Value) & "," & Voucher.Action & "," & conn.ConvertToSQLType(e))

        'If Voucher.Tabdetails("vtdttco").Datatable Is Nothing Then
        '    Voucher.Tabdetails("vtdttco").Datatable = Voucher.Tabdetails("vtdttco").DatatableView.Clone
        'End If
        'Clsql.Data.CopyTableSame(Voucher.Tabdetails("vtdttco").DatatableView, Voucher.Tabdetails("vtdttco").Datatable, "stt_rec='" & e & "'", "1=1")

        Voucher.Tabdetails("vtdttco").bindingsource.DataSource = Voucher.Tabdetails("vtdttco").Datatable

    End Sub

    Sub AfterDeleted(ByVal e As String)
        If querytt <> "" Then
            conn.Execute(querytt)
        End If
        querytt = ""
    End Sub
    Sub BeforeDelete(ByVal e As String)
        Dim dt As DataTable = conn.GetDatatable("select stt_rec_tt,ma_ct_tt from vtdttco where stt_rec ='" & e & "'")
        For Each r As DataRow In dt.Rows
            querytt = querytt & Chr(13) & "EXEC Tatoanco '" & r("stt_rec_tt") & "','" & r("ma_ct_tt") & "'"
        Next
    End Sub

    Sub loadf()
        '
        f_tien = Clsql.Format.GetFormatNumeric(conn)
        f_tien_nt = Clsql.Format.GetFormatNumeric(conn, "f_tien_nt")
        f_so_luong = Clsql.Format.GetFormatNumeric(conn, "f_sl")
        dtht = Clsql.Others.Options("a_dtht", conn)
        '
        Voucher.btnCancel = frmin.btnhuy
        AddHandler Voucher.btnFind.Click, AddressOf tim
        AddHandler Voucher.BeforeAdd, AddressOf beforeadd
        AddHandler Voucher.BeforeDelete, AddressOf BeforeDelete
        AddHandler Voucher.AfterDelete, AddressOf AfterDeleted
        AddHandler ClsSV31.Functions.BeforePost, AddressOf BeforePost
        AddHandler ClsSV31.Functions.AfterPost, AddressOf AfterPost
        AddHandler Voucher.AfterImportFromExcel, AddressOf postimportfromexcel
        AddHandler Voucher.btnPrint.Click, AddressOf vPrint
        'print

        'set up formtask

        'load data
        'Voucher.LoadFirst2(def_condition, defaultFields, addNewWhenLoadFirst)

    End Sub

    Sub vPrint()
        getPrint().Print()
    End Sub
    Private _CPrint As ClsSV31.Print20
    Function getPrint() As ClsSV31.Print20
        If _CPrint IsNot Nothing Then
            Return _CPrint
        End If
        If Voucherid.ToUpper = "BN1" Then
            fPrintDialog2 = New frmPrint2
            SetLable(Voucher.oLan, fPrintDialog2)
            fPrintDialog2.Icon = frmin.Icon
            _CPrint = New ClsSV31.Print20(Voucher, fPrintDialog2.cbbmau, fPrintDialog2.txttieu_de, fPrintDialog2.Txtso_lien)

            fPrintDialog2.StartPosition = FormStartPosition.CenterParent
            fPrintDialog2.Txtso_lien.Value = Voucher.Voucherinfo("d_so_lien")
            AddHandler _CPrint.BeforeShowReport, AddressOf beforePrint
            AddHandler fPrintDialog2.Load, AddressOf frmPrint2_Load
        Else
            fPrintDialog = New frmPrint
            SetLable(Voucher.oLan, fPrintDialog)
            fPrintDialog.Icon = frmin.Icon
            _CPrint = New ClsSV31.Print20(Voucher, fPrintDialog.cbbmau, fPrintDialog.txttieu_de, fPrintDialog.Txtso_lien)

            fPrintDialog.StartPosition = FormStartPosition.CenterParent
            fPrintDialog.Txtso_lien.Value = Voucher.Voucherinfo("d_so_lien")
            AddHandler _CPrint.BeforeShowReport, AddressOf beforePrintpc
        End If
        Return _CPrint
    End Function
    Sub beforePrint()
        getPrint.oPrint.SetParameterValue("ten_kh_P", fPrintDialog2.ten_kh.Text)

        getPrint.oPrint.SetParameterValue("sctkt", fPrintDialog2.Txtsctkt.Value)
        getPrint.oPrint.SetParameterValue("dien_giai_ctg", fPrintDialog2.txtdien_giai_ctg.Text)

        getPrint.oPrint.SetParameterValue("ten_nh_P", fPrintDialog2.ten_nh.Text)
        getPrint.oPrint.SetParameterValue("tk_nh_P", fPrintDialog2.so_tk.Text)
        getPrint.oPrint.SetParameterValue("tinh_thanh_P", fPrintDialog2.Tinh_thanh.Text)
        getPrint.oPrint.SetParameterValue("noi_dung_P", fPrintDialog2.noi_dung.Text)

    End Sub
    Sub beforePrintpc()
        getPrint.oPrint.SetParameterValue("sctkt", fPrintDialog.Txtsctkt.Value)
        getPrint.oPrint.SetParameterValue("dien_giai_ctg", fPrintDialog.txtdien_giai_ctg.Text)
    End Sub

    Private Sub frmPrint2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs)
        fPrintDialog2.noi_dung.Text = grd.CurrentRow.Cells("dien_giai").Value
        'form in
        Dim dr As StpTableRow = conn.GetRow("select a.*,b.ten_tinh_thanh  from dkh a left join dtt b on a.ma_tinh_thanh = b.ma_tinh_thanh where ma_kh ='" & grd.CurrentRow.Cells("ma_kh").Value & "'")
        Try
            If Reg.GetValue("Language") = "Vi" Then
                fPrintDialog2.ten_kh.Text = dr("ten_kh")
            Else
                fPrintDialog2.ten_kh.Text = dr("ten_kh2")
            End If
            fPrintDialog2.ten_nh.Text = grd.CurrentRow.Cells("ten_nh").Value ' dr("ten_nh")
            fPrintDialog2.so_tk.Text = grd.CurrentRow.Cells("tk_nh").Value 'dr("tk_nk")
            fPrintDialog2.Tinh_thanh.Text = dr("ten_tinh_thanh")

        Catch ex As Exception

        End Try
    End Sub

   


   
   
    Sub BeforePost(ByVal ma_ct As String, ByVal stt_rec As String, ByVal status As Integer)
        If querytt <> "" Then
            conn.Execute(querytt)
        End If
    End Sub
    Sub AfterPost(ByVal ma_ct As String, ByVal stt_rec As String, ByVal status As Integer)
        querytt = getQuerytattoan(stt_rec)
        If querytt <> "" Then
            conn.Execute(querytt)
        End If
    End Sub

    Sub postimportfromexcel(ByVal dicstt_rec As Dictionary(Of String, String), ByVal status As Integer)
        For Each stt_rec As String In dicstt_rec.Keys
            ClsSV31.Functions.Post(conn, Voucherid, Voucher.tenbangchung, Voucher.Stt_rec, status)
        Next
    End Sub
#Region "module"
    Public Voucherid As String = "PC1"
    Public Voucher As ClsSV31.Voucher20 = Nothing


    Public querytt As String = ""

    Private fPrintDialog As frmPrint
    Private fPrintDialog2 As frmPrint2
#End Region

End Class
