Imports Clsql
Imports ClsControl2
Imports ClsControl2.PropertyOfForm
Imports ClsLookup
Imports ClsSV31
Imports System.ComponentModel

Public Class Frmmain
    Dim frmin As New frminput
    Dim WithEvents bgwk As New BackgroundWorker

    Private Sub dmload(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

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
        
        '
        f_tien = Clsql.Format.GetFormatNumeric(conn)
        f_tien_nt = Clsql.Format.GetFormatNumeric(conn, "f_tien_nt")
        f_so_luong = Clsql.Format.GetFormatNumeric(conn, "f_sl")
        ma_nt_ht = Clsql.Others.Options("a_dtht", conn)
        '
        grd.ReadOnly = False
        'khai bao lookup
        bgwk.RunWorkerAsync()
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
        AddHandler Voucher.BeforeDelete, AddressOf BeforeDelete
        AddHandler Voucher.BeforeEdit, AddressOf BeforeEdit
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


            Dim query As String
            Dim strdk As String = " ngay_ct between " & Voucher.conn.ConvertToSQLType(search.Txttu_ngay.Value) & " and " & Voucher.conn.ConvertToSQLType(search.TxtDen_ngay.Value)
            strdk = strdk & " and  so_the_ts like '" & search.txtso_the_ts.Text & "%'"
            strdk = strdk & " and  so_ct like '" & search.txtso_ct.Text & "%'"


            query = Voucher.QueryLoad & " and " & strdk
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
        defaultvalue.Add(Now.Year, "nam_sx")
        defaultvalue.Add(Now, "ngay_ct")
        Voucher.ValueDefaults = defaultvalue
        frmin.TabControl1.SelectedTab = frmin.TabControl1.TabPages(0)
    End Sub
    Sub SetUpLookup()
        ClsLookup.AddItems.AddItemCbb(Voucher.conn, "select inds,text,text2 from dmitemofcbb where form ='" & Voucherid & "' and name = 'kieu_kh'", frmin.cbbkieu_kh, "text", "text2", "inds")
    End Sub
    Private Sub bgwk_DoWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles bgwk.DoWork
        SetUpLookup()
    End Sub

    Private Sub BeforeDelete(ByVal e As String)
        If conn.GetValue("if exists(select so_the_ts from kqkhts where so_the_ts='" & grd.CurrentRow.Cells("so_the_ts").Value.ToString.Trim & "') select 1 else select 0") = 1 Then
            MsgBox(Voucher.oLan("405"))
            Voucher.delete_yn = False
        End If
    End Sub

    Private Sub BeforeEdit(ByVal e As String)
        oldso_the_ts = grd.CurrentRow.Cells("so_the_ts").Value
    End Sub
End Class
