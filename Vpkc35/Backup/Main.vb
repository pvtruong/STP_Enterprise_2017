Imports Clsql
Imports ClsControl2
Imports ClsControl2.PropertyOfForm
Imports ClsLookup
Imports ClsSV31
Imports System.ComponentModel

Public Class Frmmain

    Dim frmin As New frminput
    Dim WithEvents bgwk As New BackgroundWorker
    Delegate Sub delegateloadf()
    Private Sub dmload(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Windows.Forms.Control.CheckForIllegalCrossThreadCalls = False
        'kiem tra dang ky
        If ClsControl2.PropertyOfForm.CheckRegister = False Then
            Me.Close()
        End If
        txtuser.Text = Clsql.Reg.GetValue("ID")
        '
        Voucher = New Voucher20(Voucherid, grd, frmin.TabControl1, frmin)
        Voucher.AddToolStrip(ToolStrip1)
        Voucher.btnpostGL.Visible = False
        Voucher.btnPostStock.Visible = False

        Dim ctm As New ContextMenuStrip
        Voucher.AddContextMenuStrip(ctm)
        Me.ContextMenuStrip = ctm
        conn = Voucher.conn
        'thong tin thue

        '
        f_tien = Clsql.Format.GetFormatNumeric(conn)
        f_tien_nt = Clsql.Format.GetFormatNumeric(conn, "f_tien_nt")
        f_so_luong = Clsql.Format.GetFormatNumeric(conn, "f_sl")
        ma_nt_ht = Clsql.Others.Options("a_dtht", conn)
        '

        grd.ReadOnly = False

        'khai bao lookup
        bgwk.RunWorkerAsync()

    End Sub
    Sub loadf()
        Voucher.btnCancel = frmin.btnhuy
        'Dim oLable As Collection = SetLable(Voucher.conn, frmin, Voucherid)
        SetLable(Voucher.oLan, Me)
        SetLable(Voucher.oLan, frmsearch)
        SetLable(Voucher.oLan, fPrintDialog)
        fPrintDialog.Icon = frmin.Icon
        Me.Icon = frmin.Icon
        frmsearch.Icon = Me.Icon

        AddHandler Voucher.btnFind.Click, AddressOf tim

        AddHandler Voucher.BeforeAdd, AddressOf beforeadd
        AddHandler Voucher.AfterImportFromExcel, AddressOf postimportfromexcel
        'print
        oPrint = New ClsSV31.Print20(Voucher, fPrintDialog.cbbmau, fPrintDialog.txttieu_de, fPrintDialog.Txtso_lien)
        AddHandler Voucher.btnPrint.Click, AddressOf oPrint.Print
        fPrintDialog.StartPosition = FormStartPosition.CenterParent
        fPrintDialog.Txtso_lien.Value = Voucher.Voucherinfo("d_so_lien")
        'set up formtask
        SetLable(Voucher.oLan, formtask)
        formtask.Icon = Me.Icon
        'load data
        Voucher.LoadFirst()
    End Sub
    Private Sub thoat(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuthoat.Click
        Voucher = Nothing
        Me.Close()
    End Sub
    Private Sub tim()
        Dim search As New frmsearch
        search.Icon = Me.Icon
        If search.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then

            Clsql.Reg.SetValue("tu_ngay", search.Txttu_ngay.Value)
            Clsql.Reg.SetValue("den_ngay", search.TxtDen_ngay.Value)
            Clsql.Reg.SetValue("ma_kh", search.txtma_kh.Text)

            Dim query As String
            Dim strdk As String = " ngay_ct between " & Voucher.conn.ConvertToSQLType(search.Txttu_ngay.Value) & " and " & Voucher.conn.ConvertToSQLType(search.TxtDen_ngay.Value)
            strdk = strdk & " and  ma_kh like '" & search.txtma_kh.Text & "%'"
            strdk = strdk & " and  so_ct like '" & search.txtso_ct.Text & "%'"


            query = Voucher.QueryLoad & " and " & strdk & " and stt_rec in " & "(select stt_rec from " & Voucher.Tabdetails(Voucher.TabFirst).TableName & " where "
            query = query & " tk_no like '" & search.txttk_no.Text
            query = query & "%' and tk_co like '" & search.txttk_co.Text & "%')"
            Voucher.LoadData(query.Replace("#*#", "cast(0 as bit) as sel,*"))
        End If

    End Sub

    Private Sub grd_RowsAdded(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsAddedEventArgs) Handles grd.RowsAdded
        txtt_tien_nt.Text = Strings.Format(ClsControl2.PropertyOfGrid.Sum(grd, "t_tt_nt"), f_tien_nt)
    End Sub

    Private Sub grd_RowsRemoved(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsRemovedEventArgs) Handles grd.RowsRemoved
        txtt_tien_nt.Text = Strings.Format(ClsControl2.PropertyOfGrid.Sum(grd, "t_tt_nt"), f_tien_nt)
    End Sub
    Sub beforeadd(ByVal e As String)
        Dim defaultvalue As New Collection
        defaultvalue.Add("VND", "ma_nt")
        defaultvalue.Add(Clsql.Others.EndDateOfMonth(Now.Month, Now.Year), "ngay_ct")
        defaultvalue.Add(Now.Month, "tu_ky")
        defaultvalue.Add(Now.Month, "den_ky")
        defaultvalue.Add(Now.Year, "nam")
        Voucher.ValueDefaults = defaultvalue

    End Sub
    Sub SetUpLookup()
        ClsLookup.AddItems.AddItemCbb(Voucher.conn, "select inds,text,text2 from dmitemofcbb where form ='" & Voucherid & "' and name = 'status'", frmin.cbbstatus, "text", "text2", "inds")
        ClsLookup.AddItems.AddItemCbb(Voucher.conn, "exec s_dmnt", frmin.cbbma_nt, "ten_nt", "ma_nt")
    End Sub
   


    Private Sub bgwk_DoWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles bgwk.DoWork
        SetUpLookup()
        grd.BeginInvoke(New delegateloadf(AddressOf loadf))
    End Sub

    Sub postimportfromexcel(ByVal dicstt_rec As Dictionary(Of String, String), ByVal status As Integer)
        For Each stt_rec As String In dicstt_rec.Keys
            ClsSV31.Functions.Post(conn, Voucherid, Voucher.tenbangchung, Voucher.Stt_rec, status)
        Next
    End Sub
End Class
