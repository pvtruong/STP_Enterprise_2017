Imports Clsql
Imports ClsControl2
Imports ClsControl2.PropertyOfForm
Imports ClsLookup
Imports ClsSV31
Imports System.ComponentModel

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
        'kiem tra dang ky
        If ClsControl2.PropertyOfForm.CheckRegister = False Then
            Me.Close()
        End If

        'create voucher
        Voucher = New Voucher20(Voucherid, grd, frmin.TabControl1, frmin)
        conn = Voucher.conn
        Voucher.AddToolStrip(ToolStrip1)
        Voucher.btnpostGL.Visible = False
        Voucher.btnPostStock.Visible = False
        'set status
        txtuser.Text = Clsql.Reg.GetValue("ID")
        'khai bao lookup
        SetUpLookup()
        loadf()
        '

        Dim ctm As New ContextMenuStrip
        Voucher.AddContextMenuStrip(ctm)
        Me.ContextMenuStrip = ctm

        '
        grd.ReadOnly = False
        Voucher.btnCancel = frmin.btnhuy
        'Dim oLable As Collection = SetLable(Voucher.conn, frmin, Voucherid)
        SetLable(Voucher.oLan, Me)
        SetLable(Voucher.oLan, fPrintDialog)
        fPrintDialog.Icon = frmin.Icon
        Me.Icon = frmin.Icon
    End Sub
    Private Sub dmload(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load



    End Sub

    Private Sub thoat(ByVal sender As Object, ByVal e As System.EventArgs)
        Voucher = Nothing
        Me.Close()
    End Sub
    Private Sub tim()
        Dim search As New frmsearch
        search.StartPosition = FormStartPosition.CenterParent
        search.Icon = Me.Icon
        If search.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
            Clsql.Reg.SetValue("tu_ngay", search.Txttu_ngay.Value)
            Clsql.Reg.SetValue("den_ngay", search.TxtDen_ngay.Value)


            Dim query As String
            Dim strdk As String = " ngay_ct between " & Voucher.conn.ConvertToSQLType(search.Txttu_ngay.Value) & " and " & Voucher.conn.ConvertToSQLType(search.TxtDen_ngay.Value)

            strdk = strdk & " and  so_ct like '" & search.txtso_ct.Text & "%'"

            query = Voucher.QueryLoad & " and " & strdk
            Voucher.LoadData(query.Replace("#*#", "cast(0 as bit) as sel,*"))
        End If

    End Sub
    Sub beforeadd(ByVal e As String)
        Dim defaultvalue As New Collection
        defaultvalue.Add("VND", "ma_nt")
        defaultvalue.Add(Now, "ngay_ct")
        Voucher.ValueDefaults = defaultvalue

    End Sub
    Sub beforeedit(ByVal e As String)

    End Sub


    Sub SetUpLookup()

        ClsLookup.AddItems.AddItemCbb(Voucher.conn, "select inds,text,text2 from dmitemofcbb where form ='" & Voucherid & "' and name = 'status' order by inds", frmin.cbbstatus, "text", "text2", "inds")
        ClsLookup.AddItems.AddItemCbb(Voucher.conn, "select inds,text,text2 from dmitemofcbb where form ='" & Voucherid & "' and name = 'ma_gd' order by inds", frmin.cbbma_gd, "text", "text2", "inds")



    End Sub
    Sub loadf()
        f_tien = Clsql.Format.GetFormatNumeric(conn)
        f_tien_nt = Clsql.Format.GetFormatNumeric(conn, "f_tien_nt")
        f_so_luong = Clsql.Format.GetFormatNumeric(conn, "f_sl")
        ma_nt_ht = Clsql.Others.Options("a_dtht", conn)
        '
        AddHandler Voucher.btnFind.Click, AddressOf tim

        AddHandler Voucher.BeforeAdd, AddressOf beforeadd
        AddHandler Voucher.BeforeEdit, AddressOf beforeedit

        AddHandler Voucher.AfterImportFromExcel, AddressOf postimportfromexcel
        'print
        oPrint = New Print20(Voucher, fPrintDialog.cbbmau, fPrintDialog.txttieu_de, fPrintDialog.Txtso_lien)
        AddHandler Voucher.btnPrint.Click, AddressOf oPrint.Print
        fPrintDialog.StartPosition = FormStartPosition.CenterParent
        fPrintDialog.Txtso_lien.Value = Voucher.Voucherinfo("d_so_lien")
        'set up formtask
        SetLable(Voucher.oLan, formtask)
        formtask.Icon = Me.Icon
        'load data
        'Voucher.LoadFirst()
    End Sub

    Sub postimportfromexcel(ByVal dicstt_rec As Dictionary(Of String, String), ByVal status As Integer)
        For Each stt_rec As String In dicstt_rec.Keys
            ClsSV31.Functions.Post(conn, Voucherid, Voucher.tenbangchung, Voucher.Stt_rec, status)
        Next
    End Sub

   
End Class
