Imports ClsLookup
Imports ClsStpService

Public Class frminput

    Dim isloaded As Boolean = False

    Private Sub frminput_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        If isloaded = False Then
            Me.txtso_ct.Focus()
            Me.txtso_ct.SelectionStart = txtso_ct.Text.Length
        End If
    End Sub

   
    Private Sub frminput_show(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown

        Dim dvr As DataRowView = cbbma_nt.SelectedItem

        hide_show_control(dvr("ma_nt"))
        isloaded = True
        If Voucher.Action = ClsSV31.Voucher20.Actions.ADD Then
            Txtty_gia.Value = conn.GetValue("exec getty_gia " & conn.ConvertToSQLType(cbbma_nt.SelectedValue.trim) & "," & conn.ConvertToSQLType(Txtngay_ct.Value))
        End If
    End Sub
    Private Sub frminput_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        isloaded = False
        For Each dvtab As ClsSV31.TabDetail20 In Voucher.Tabdetails.Values
            RemoveHandler dvtab.AfterCalcOnCell, AddressOf tinh_tong_tien
        Next
    End Sub

    Private Sub frminput_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        For Each dvtab As ClsSV31.TabDetail20 In Voucher.Tabdetails.Values
            AddHandler dvtab.AfterCalcOnCell, AddressOf tinh_tong_tien
        Next
    End Sub
#Region "lay ty gia tu dong"
    Dim ngay_ctold As Date
    Private Sub Txtngay_ct_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txtngay_ct.Validated
        If ngay_ctold <> Txtngay_ct.Value Then
            If isloaded Then
                If Voucher.Action = ClsSV31.Voucher20.Actions.ADD Then
                    Txtty_gia.Value = conn.GetValue("exec getty_gia " & conn.ConvertToSQLType(cbbma_nt.SelectedValue.trim) & "," & conn.ConvertToSQLType(Txtngay_ct.Value))
                End If
            End If
        End If
    End Sub
    Private Sub Txtngay_ct_endter(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txtngay_ct.Enter
        ngay_ctold = Txtngay_ct.Value
    End Sub
#End Region


    Private Sub btnLuu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLuu.Click
        If save() = False Then
            Exit Sub
        End If
        formtask.btnnew.Enabled = Voucher.rights.NewRight
        If formtask.btncopy.Enabled = True Then
            formtask.btncopy.Enabled = Voucher.rights.NewRight
        End If
        formtask.btnprint.Enabled = Voucher.rights.PrintRight
        formtask.ShowDialog(Me)
        Select Case formtask.task
            Case ClsSV31.frmTask.Tasks.AddNew
                Me.BindingContext(Voucher.BindingSource).EndCurrentEdit()
                Voucher.Mdatatable.AcceptChanges()
                Voucher.News2()
            Case ClsSV31.frmTask.Tasks.Copy
                Voucher.Copy()
            Case ClsSV31.frmTask.Tasks.Print
                For Each r As DataRow In Voucher.Mdatatable.Select("sel=true")
                    r("sel") = False
                Next
                Voucher.BindingSource.Current("sel") = True
                oPrint.Print()
                Me.Close()
            Case ClsSV31.frmTask.Tasks.Close
                Me.DialogResult = DialogResult.OK
                Me.Close()
        End Select
    End Sub
    Function save() As Boolean
        'kiem tra da nhap chi tiet chua
        If Voucher.CheckKeyIn = False Then
            Return False
        End If
        'kiem tra da nhap truong so luong chua
        For Each r As DataGridViewRow In Voucher.Tabdetails(Voucher.TabFirst).gridDetailKeyin.Rows
            If r.IsNewRow = False Then
                If r.Cells("so_luong").Value = 0 Then
                    MsgBox(Voucher.oLan("421"), MsgBoxStyle.Critical, Me.Text)
                    Voucher.Tabdetails(Voucher.TabFirst).gridDetailKeyin.CurrentCell = r.Cells("so_luong")
                    Return False
                    Exit For
                End If
            End If

        Next
        'kiem tra so chung tu
        If Voucher.CheckSoCT(Txtngay_ct.Value, txtso_ct.Text) = False Then
            Return False
            Exit Function
        End If
        'ket thuc kiem tra
        Voucher.BindingSource.EndEdit()
        'dien cac gia tri cu m vao d
        Voucher.SynMD()
        If Voucher.Action = 1 Then
            Voucher.Insert()
        Else
            Voucher.Update()
        End If
        'post
        ClsSV31.Functions.Post(conn, Voucherid, Voucher.Mviewname, Voucher.Stt_rec, cbbstatus.SelectedValue)
        '
        Return True
    End Function
    Dim t_tien, t_ck, t_thue, t_tt, t_cp, t_sl, t_tien_von, t_tien_nt, t_ck_nt, t_thue_nt, t_tt_nt, t_sl_nt, t_tien_von_nt, t_cp_nt As Double

    Sub tinh_tong_tien()
        If isloaded = False Then
            Return
        End If

        t_tien_nt = ClsControl2.PropertyOfGrid.Sum(Voucher.Tabdetails(Voucher.TabFirst).gridDetailKeyin, "tien_nt")
        t_tien = ClsControl2.PropertyOfGrid.Sum(Voucher.Tabdetails(Voucher.TabFirst).gridDetailKeyin, "tien")

        t_ck_nt = ClsControl2.PropertyOfGrid.Sum(Voucher.Tabdetails(Voucher.TabFirst).gridDetailKeyin, "tien_ck_nt")
        t_ck = ClsControl2.PropertyOfGrid.Sum(Voucher.Tabdetails(Voucher.TabFirst).gridDetailKeyin, "tien_ck")


        t_thue_nt = ClsControl2.PropertyOfGrid.Sum(Voucher.Tabdetails(Voucher.TabFirst).gridDetailKeyin, "tien_thue_nt")
        t_thue = ClsControl2.PropertyOfGrid.Sum(Voucher.Tabdetails(Voucher.TabFirst).gridDetailKeyin, "tien_thue")

        t_tt_nt = ClsControl2.PropertyOfGrid.Sum(Voucher.Tabdetails(Voucher.TabFirst).gridDetailKeyin, "t_tien_nt")
        t_tt = ClsControl2.PropertyOfGrid.Sum(Voucher.Tabdetails(Voucher.TabFirst).gridDetailKeyin, "t_tien")

        t_sl = ClsControl2.PropertyOfGrid.Sum(Voucher.Tabdetails(Voucher.TabFirst).gridDetailKeyin, "so_luong")
        '
        Txtt_tien_nt.Value = t_tien_nt
        Txtt_tien.Value = t_tien
        Txtt_sl.Value = t_sl

        txtt_ck.Value = t_ck
        Txtt_ck_nt.Value = t_ck_nt

        Txtt_thue.Value = t_thue
        Txtt_thue_nt.Value = t_thue_nt

        Txtt_tt.Value = t_tt
        Txtt_tt_nt.Value = t_tt_nt

    End Sub
    Private Sub btnluuandmoi_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnluuandmoi.Click
        If save() = False Then
            Exit Sub
        End If
        Me.BindingContext(Voucher.BindingSource).EndCurrentEdit()
        Voucher.Mdatatable.AcceptChanges()
        Voucher.News2()
        Txtty_gia.Value = conn.GetValue("exec getty_gia " & conn.ConvertToSQLType(cbbma_nt.SelectedValue.trim) & "," & conn.ConvertToSQLType(Txtngay_ct.Value))
        txtso_ct.Focus()
    End Sub

    Private Sub btnhuy_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnhuy.Click
        If Voucher.Action = 1 Then
            Voucher.Mdatatable.Rows.Remove(Voucher.CurrentVoucher)
        End If
    End Sub


    Private Sub cbbma_nt_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbbma_nt.SelectedValueChanged
        If isloaded = False Then
            Exit Sub
        End If
        Try
            If cbbma_nt.SelectedItem IsNot Nothing Then
                Dim dvr As DataRowView = cbbma_nt.SelectedItem
                Txtty_gia.Value = conn.GetValue("exec getty_gia " & conn.ConvertToSQLType(cbbma_nt.SelectedValue.trim) & "," & conn.ConvertToSQLType(Txtngay_ct.Value))
                hide_show_control(dvr("ma_nt"))
            End If

        Catch ex As Exception

        End Try
    End Sub

   
    Sub hide_show_control(ByVal ma_nt As String)
        For Each t As ClsSV31.TabDetail20 In Voucher.Tabdetails.Values
            t.ma_nt = ma_nt
        Next
        If ma_nt.Trim.ToUpper = ma_nt_ht.Trim.ToUpper Then

            Txtty_gia.ReadOnly = True
            Txtt_tien.Hide() 'Visible = False
            Txtt_thue.Hide()
            Txtt_tt.Hide()
            txtt_ck.Hide()
            Txtt_tien_nt.NumberDecimalDigits = Clsql.Others.Options("f_tien", conn)
            Txtt_thue_nt.NumberDecimalDigits = Clsql.Others.Options("f_tien", conn)
            Txtt_tt_nt.NumberDecimalDigits = Clsql.Others.Options("f_tien", conn)
            Txtt_ck_nt.NumberDecimalDigits = Clsql.Others.Options("f_tien", conn)
        Else

            Txtty_gia.ReadOnly = False
            Txtt_tien.Show() 'Visible = True
            Txtt_thue.Show()
            Txtt_tt.Show()
            txtt_ck.Show()
            Txtt_tien_nt.NumberDecimalDigits = Clsql.Others.Options("f_tien_nt", conn)
            Txtt_thue_nt.NumberDecimalDigits = Clsql.Others.Options("f_tien_nt", conn)
            Txtt_tt_nt.NumberDecimalDigits = Clsql.Others.Options("f_tien_nt", conn)
            Txtt_ck_nt.NumberDecimalDigits = Clsql.Others.Options("f_tien_nt", conn)
            tinh_tong_tien()
        End If
    End Sub
    Private Sub grddetail_RowsAdded(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsAddedEventArgs)
        tinh_tong_tien()
    End Sub

    Private Sub grddetail_RowsRemoved(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsRemovedEventArgs)
        tinh_tong_tien()
    End Sub

    Private Sub cbbma_gd_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbbma_gd.SelectedValueChanged
        Try
            txtso_hd.Visible = (cbbma_gd.SelectedValue <> 2)
            so_hd.Visible = (cbbma_gd.SelectedValue <> 2)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnLayDuLieuTuPhieuYC_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLayDuLieuTuPhieuYC.Click
        Dim layhd As New GetDataByStoreMD(Voucher.conn, "mSQ1", "dSQ1_get4SO1", , "GetSQ1")

        Dim fdkloc As New frmdklayhd
        ClsControl2.PropertyOfForm.SetLable(Voucher.oLan, fdkloc)
        fdkloc.Icon = Me.Icon
        fdkloc.StartPosition = FormStartPosition.CenterParent
        If fdkloc.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
            If layhd.Show("Exec GetSQ14SO1 " & conn.ConvertToSQLType(fdkloc.Txttu_ngay.Value) & "," & conn.ConvertToSQLType(fdkloc.TxtDen_ngay.Value) & "," & conn.ConvertToSQLType(Voucher.Stt_rec)) = Windows.Forms.DialogResult.OK Then

                For Each r As DataRow In layhd.MDataView.Table.Select("sel = false")
                    For Each r2 As DataRow In layhd.DDataView.Table.Select("stt_rec = '" & r("stt_rec") & "'")
                        r2.Delete()
                    Next

                Next

                For Each r As DataRow In layhd.DDataView.Table.Select("sel = false")
                    r.Delete()
                Next

                Clsql.Data.CopyTable(layhd.DDataView.Table, Voucher.Tabdetails(Voucher.TabFirst).Datatable)
                ' Voucher.chitiet.Datatable = layhd.DDataView.Table
                Voucher.Tabdetails(Voucher.TabFirst).bindingsource.DataSource = Voucher.Tabdetails(Voucher.TabFirst).Datatable
                'lay cac gia tri phan thong tin chung
                For Each r As DataRow In layhd.MDataView.Table.Select("sel = true")
                    Voucher.CurrentVoucher("ma_kh") = r("ma_kh")
                    txtma_kh.Focus()
                    Voucher.Tabdetails(Voucher.TabFirst).gridDetailKeyin.Focus()
                    Exit For
                Next
                tinh_tong_tien()

            End If
        End If
    End Sub
    Private Sub laydulieutuhopdong(ByVal row As StpTableRow)
        Voucher.CurrentVoucher("ma_kh") = row("ma_kh")
        Dim query As String = "select * from vdSO1 where so_ct='" & row("so_ct") & "'"
        Dim getdata As DataTable = conn.GetDatatable(query)

        Clsql.Data.CopyTable(getdata, Voucher.Tabdetails(Voucher.TabFirst).Datatable)
        ' Voucher.chitiet.Datatable = layhd.DDataView.Table
        Voucher.Tabdetails(Voucher.TabFirst).bindingsource.DataSource = Voucher.Tabdetails(Voucher.TabFirst).Datatable
        tinh_tong_tien()
    End Sub

End Class