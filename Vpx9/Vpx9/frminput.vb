Imports System.ComponentModel
Imports ClsLookup

Public Class frminput

    Dim isloaded As Boolean = False

    Private Sub frminput_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        If isloaded = False Then
            Me.txtso_ct.Focus()
            Me.txtso_ct.SelectionStart = txtso_ct.Text.Length
        End If
    End Sub
    Private Sub frminput_show(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        isloaded = True
        hide_show_control("VND")
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
        '
        Voucher.BindingSource.Current("t_tien_nt") = t_tien_nt
        Voucher.BindingSource.Current("t_tien") = t_tien
        Voucher.BindingSource.Current("t_sl") = t_sl
        'kiem tra da nhap chi tiet chua
        If Voucher.CheckKeyIn = False Then
            Return False
        End If
        'kiem tra ma the
        Voucher.Tabdetails(Voucher.TabFirst).gridDetailKeyin.EndEdit()
        If Voucher.Tabdetails(Voucher.TabFirst).Datatable.Rows.Count > 0 Then
            For Each r As DataRow In Voucher.Tabdetails(Voucher.TabFirst).Datatable.Rows
                If r.RowState = DataRowState.Deleted Then
                    Continue For
                End If
                Dim ma_the As String = r("ma_the")
                Dim q = From rs As DataRow In Voucher.Tabdetails(Voucher.TabFirst).Datatable.Rows Where rs.RowState <> DataRowState.Deleted AndAlso rs("ma_the") = ma_the
                If q.Count > 1 Then
                    MsgBox("Số thẻ giảm giá " & ma_the & " đã được xuất nhiều hơn một lần",, Clsql.AboutMe.Name)
                    Return False
                End If
            Next
        End If
        'kiem tra so chung tu
        If Voucher.CheckSoCT(Txtngay_ct.Value, txtso_ct.Text) = False Then
            Return False
        End If

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



    Private Sub TạoPhiếuXuấtKhoTừPhiếuXuấtHàngToolStripMenuItem_Click(sender As Object, e As EventArgs)
        Dim layhd As GetDataByStoreMD
        layhd = New GetDataByStoreMD(Voucher.conn, "mpxh", "dpxh_get4hd2", , "GetPXH")
        Dim fdkloc As New frmdklayhd
        ClsControl2.PropertyOfForm.SetLable(Voucher.oLan, fdkloc)
        fdkloc.Icon = Me.Icon
        fdkloc.StartPosition = FormStartPosition.CenterParent
        If fdkloc.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
            If layhd.Show("Exec GetPXH4PXK " & conn.ConvertToSQLType(fdkloc.Txttu_ngay.Value) & "," & conn.ConvertToSQLType(fdkloc.TxtDen_ngay.Value) & "," & conn.ConvertToSQLType(Voucher.Stt_rec) & "," & conn.ConvertToSQLType(fdkloc.txtma_nvu.Text)) = Windows.Forms.DialogResult.OK Then
                For Each r As DataRow In layhd.MDataView.Table.Select("sel = false")
                    For Each r2 As DataRow In layhd.DDataView.Table.Select("stt_rec = '" & r("stt_rec") & "'")
                        r2.Delete()
                    Next

                Next
                For Each r As DataRow In layhd.DDataView.Table.Select("sel = false")
                    r.Delete()
                Next
                Voucher.Tabdetails(Voucher.TabFirst).bindingsource.DataSource = Nothing
                Clsql.Data.CopyTable(layhd.DDataView.Table, Voucher.Tabdetails(Voucher.TabFirst).Datatable)
                Voucher.Tabdetails(Voucher.TabFirst).bindingsource.DataSource = Voucher.Tabdetails(Voucher.TabFirst).Datatable
                'lay cac gia tri phan thong tin chung
                For Each r As DataRow In layhd.MDataView.Table.Select("sel = true")
                    Voucher.CurrentVoucher("ma_kh") = r("ma_kh")
                    Voucher.CurrentVoucher("ong_ba") = r("ong_ba")
                    txtma_kh.Focus()
                    Voucher.Tabdetails(Voucher.TabFirst).gridDetailKeyin.Focus()
                    Exit For
                Next
                tinh_tong_tien()
            End If
        End If
    End Sub

    Sub tinh_tong_tien()
        If isloaded = False Then
            Return
        End If
        t_tien_nt = ClsControl2.PropertyOfGrid.Sum(Voucher.Tabdetails(Voucher.TabFirst).gridDetailKeyin, "tien_xuat_nt")
        t_tien = ClsControl2.PropertyOfGrid.Sum(Voucher.Tabdetails(Voucher.TabFirst).gridDetailKeyin, "tien_xuat")
        t_sl = ClsControl2.PropertyOfGrid.Sum(Voucher.Tabdetails(Voucher.TabFirst).gridDetailKeyin, "sl_xuat")
        '
        Txtt_tien_nt.Value = t_tien_nt
        Txtt_tien.Value = t_tien
        Txtt_sl.Value = t_sl


    End Sub
    Private Sub btnluuandmoi_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnluuandmoi.Click
        If save() = False Then
            Exit Sub
        End If
        Me.BindingContext(Voucher.BindingSource).EndCurrentEdit()
        Voucher.Mdatatable.AcceptChanges()
        Voucher.News2()
        ' Dim dvr As DataRowView = cbbma_nt.SelectedItem

        txtso_ct.Focus()

    End Sub

    'Private Sub btnhuy_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnhuy.Click
    '    If Voucher.Action = 1 Then
    '        Voucher.Mdatatable.Rows.Remove(Voucher.CurrentVoucher)
    '    End If
    'End Sub





    Sub hide_show_control(ByVal ma_nt As String)
        For Each t As ClsSV31.TabDetail20 In Voucher.Tabdetails.Values
            t.ma_nt = ma_nt
        Next
        If ma_nt.Trim.ToUpper = ma_nt_ht.Trim.ToUpper Then

            Txtt_tien.Hide() 'Visible = False
            Txtt_tien_nt.NumberDecimalDigits = Clsql.Others.Options("f_tien", conn)
        Else

            Txtt_tien.Show() 'Visible = True
            Txtt_tien_nt.NumberDecimalDigits = Clsql.Others.Options("f_tien_nt", conn)
            tinh_tong_tien()
        End If
    End Sub


End Class