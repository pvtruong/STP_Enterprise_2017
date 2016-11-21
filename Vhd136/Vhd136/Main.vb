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
        If Voucher IsNot Nothing Then
            Return
        End If
        '
        Voucher = New Voucher20(Voucherid, grd, frmin.TabControl1, frmin)
        frmin.setParent(Me)
        Voucher.AddToolStrip(ToolStrip1)
        Voucher.btnpostGL.Visible = False
        Voucher.btnPostStock.Visible = False
        SetLable(Voucher.oLan, Me)
        Me.Icon = frmin.Icon
        Dim ctm As New ContextMenuStrip
        Voucher.AddContextMenuStrip(ctm)
        Me.ContextMenuStrip = ctm
        'khai bao lookup
        SetUpLookup()
        loadf()
        AddHandler frmin.Txtt_tien_nt.ValueChanged, AddressOf tinhtienthue
        AddHandler frmin.Txtt_ck_nt.ValueChanged, AddressOf tinhtienthue
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
    Private Sub dmload(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtuser.Text = Clsql.Reg.GetValue("ID")
    End Sub
    Private Sub tinhtienthue()
        If Voucher.FormKeyInShowed AndAlso Voucher.Tabdetails("vatra").Datatable.Rows.Count = 1 Then
            Voucher.BindingSource.EndEdit()
            Voucher.Tabdetails("vatra").Calc("t_tien_nt", 0, Voucher.CurrentVoucher("ty_gia"))
            Voucher.Tabdetails("vatra").Calc("t_tien", 0, Voucher.CurrentVoucher("ty_gia"))
            Voucher.Tabdetails("vatra").Calc("t_thue_nt", 0, Voucher.CurrentVoucher("ty_gia"))
            Voucher.Tabdetails("vatra").Calc("t_thue", 0, Voucher.CurrentVoucher("ty_gia"))
        End If
    End Sub
    Private Sub tim()
        Dim search As New frmsearch
        search.Icon = Me.Icon
        search.StartPosition = FormStartPosition.CenterParent
        ClsControl2.PropertyOfForm.SetLable(Voucher.oLan, Me)
        If search.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then

            Clsql.Reg.SetValue("tu_ngay", search.Txttu_ngay.Value)
            Clsql.Reg.SetValue("den_ngay", search.TxtDen_ngay.Value)
            Clsql.Reg.SetValue("ma_kh", search.txtma_kh.Text)

            Dim query As String
            Dim strdk As String = " ngay_ct between " & Voucher.conn.ConvertToSQLType(search.Txttu_ngay.Value) & " and " & Voucher.conn.ConvertToSQLType(search.TxtDen_ngay.Value)
            strdk = strdk & " and  ma_kh like '" & search.txtma_kh.Text & "%'"
            strdk = strdk & " and so_ct like '" & search.txtso_ct.Text & "%'"
            strdk = strdk & " and dien_giai like N'%" & search.txtdien_giai.Text.Trim & "%'"

            strdk = strdk & " and  stt_rec in (select stt_rec from  " & Voucher.TabFirst & " where "
            strdk = strdk & " ma_bp like '" & search.txtma_bp.Text & "%'"
            strdk = strdk & " and ma_phi like '" & search.txtma_phi.Text & "%'"
            strdk = strdk & " and ma_dt like '" & search.txtma_dt.Text & "%')"


            query = Voucher.QueryLoad & " and " & strdk

            Voucher.LoadData(query.Replace("#*#", "cast(0 as bit) as sel,*"))
        End If

    End Sub

    Sub beforeadd(ByVal e As String)
        Dim defaultvalue As New Collection
        defaultvalue.Add("VND", "ma_nt")
        defaultvalue.Add(Now, "ngay_ct")
        defaultvalue.Add(Now, "ngay_hd")
        Voucher.ValueDefaults = defaultvalue
        frmin.btnLuu.Enabled = True
        frmin.btnluuandmoi.Enabled = True
    End Sub
    Sub beforedelete(ByVal e As String)
        Voucher.delete_yn = conn.GetValue("if  exists(select stt_rec from tdttno where status = 5 and left(stt_rec_tt,1) ='" & Clsql.Reg.GetValue("workstation") & "' and right(stt_rec_tt,9)='" & Voucher.Stt_rec.Substring(4) & "' and ma_ct_tt='" & Voucherid & "') select 0 else select 1 ")
        If Voucher.delete_yn = False Then
            MsgBox(Voucher.oLan("416"), MsgBoxStyle.Exclamation, Text)
        End If
    End Sub

    Sub SetUpLookup()
        ClsLookup.AddItems.AddItemCbb(Voucher.conn, "select inds,text,text2 from dmitemofcbb where form ='" & Voucherid & "' and name = 'status'", frmin.cbbstatus, "text", "text2", "inds")

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
            Dim query As String = "select du from dbo.EdCust('131'"
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
    Sub kiem_tra_thanh_toan()
        If conn.GetValue("if  exists(select stt_rec from tdttno where status = 5 and left(stt_rec_tt,1) ='" & Clsql.Reg.GetValue("workstation") & "' and right(stt_rec_tt,9)='" & Voucher.Stt_rec.Substring(4) & "' and ma_ct_tt='" & Voucherid & "') select 0 else select 1 ") = False Then
            frmin.btnLuu.Enabled = False
            frmin.btnluuandmoi.Enabled = False
        End If

    End Sub
    Sub afterdelete(ByVal e As String)
        'xoa phieu chi cu
        Dim query As String
        Dim dtpc As DataTable = conn.GetDatatable("select * from mpt1 where stt_rec_goc ='" & e & "'")
        If dtpc.Rows.Count > 0 Then
            'xoa post
            ClsSV31.Functions.deletePost(conn, dtpc.Rows(0).Item("ma_ct"), dtpc.Rows(0))
            'xoa detail master
            Dim stt_rec_pc As String = dtpc.Rows(0).Item("stt_rec")
            query = "delete from dpt1 where stt_rec='" & stt_rec_pc & "'"
            query = query & ChrW(13) & "GO" & ChrW(13) & "delete from mpt1 where stt_rec='" & stt_rec_pc & "'"
            conn.ExecuteWithMultiQuery(query)

        End If
    End Sub
    Sub loadf()
        '
        f_tien = Clsql.Format.GetFormatNumeric(conn)
        f_tien_nt = Clsql.Format.GetFormatNumeric(conn, "f_tien_nt")
        f_so_luong = Clsql.Format.GetFormatNumeric(conn, "f_sl")
        '

        grd.ReadOnly = False


        Voucher.btnCancel = frmin.btnhuy
        'Dim oLable As Collection = SetLable(Voucher.conn, frmin, Voucherid)

        'SetLable(Voucher.oLan, frmsearch)


        ' frmsearch.Icon = Me.Icon

        AddHandler Voucher.btnFind.Click, AddressOf tim

        AddHandler Voucher.BeforeAdd, AddressOf beforeadd
        AddHandler Voucher.BeforeDelete, AddressOf beforedelete
        AddHandler Voucher.AfterDelete, AddressOf afterdelete
        AddHandler Voucher.BeforeEdit, AddressOf kiem_tra_thanh_toan
        AddHandler Voucher.AfterImportFromExcel, AddressOf postimportfromexcel
        AddHandler Voucher.btnPrint.Click, AddressOf vPrint
        'load data
        'Voucher.LoadFirst2(def_condition, defaultFields, addNewWhenLoadFirst)

    End Sub
    Private _oPrint As ClsSV31.Print20 = Nothing
    Private fPrintDialog As frmPrint
    Private Sub vPrint()
        getPrint().Print()
    End Sub
    Public Function getPrint() As ClsSV31.Print20
        If _oPrint IsNot Nothing Then
            Return _oPrint
        End If
        'print

        fPrintDialog = New frmPrint
        SetLable(Voucher.oLan, fPrintDialog)
        fPrintDialog.Icon = frmin.Icon

        fPrintDialog.StartPosition = FormStartPosition.CenterParent
        fPrintDialog.Txtso_lien.Value = Voucher.Voucherinfo("d_so_lien")

        _oPrint = New ClsSV31.Print20(Voucher, fPrintDialog.cbbmau, fPrintDialog.txttieu_de, fPrintDialog.Txtso_lien)
        Return _oPrint
    End Function
    Sub postimportfromexcel(ByVal dicstt_rec As Dictionary(Of String, String), ByVal status As Integer)
        For Each stt_rec As String In dicstt_rec.Keys
            'post(stt_rec, status)
            ClsSV31.Functions.Post(conn, Voucherid, Voucher.tenbangchung, Voucher.Stt_rec, status)
        Next
    End Sub

    Public Voucherid As String = "HD1"
    Public Voucher As ClsSV31.Voucher20

End Class
