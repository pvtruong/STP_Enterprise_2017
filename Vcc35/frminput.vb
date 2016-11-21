Imports ClsLookup

Public Class frminput
    Dim ty_gia_cu As Double
    Dim isloaded As Boolean = False

    Private Sub frminput_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        If isloaded = False Then
            Me.txtso_ct.Focus()
            Me.txtso_ct.SelectionStart = txtso_ct.Text.Length
        End If
    End Sub

    Private Sub frminput_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        isloaded = False
        For Each dvtab As ClsSV31.TabDetail20 In Voucher.Tabdetails.Values
            RemoveHandler dvtab.AfterCalcOnCell, AddressOf tinh_tong_tien
        Next
        RemoveHandler Voucher.Tabdetails(Voucher.TabFirst).gridDetailKeyin.CellEndEdit, AddressOf grddetail_CellEndEdit

    End Sub

    Private Sub frminput_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        For Each dvtab As ClsSV31.TabDetail20 In Voucher.Tabdetails.Values
            AddHandler dvtab.AfterCalcOnCell, AddressOf tinh_tong_tien
        Next
        AddHandler Voucher.Tabdetails(Voucher.TabFirst).gridDetailKeyin.CellEndEdit, AddressOf grddetail_CellEndEdit
        If txtso_the_ts.Text = "" Then
            txtso_the_ts.Text = txtso_ct.Text
        End If
    End Sub

   
    Private Sub frminput_show(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        If Voucher.Action = ClsSV31.Voucher20.Actions.ADD Then
            cbbkieu_kh.Enabled = True
        Else
            cbbkieu_kh.Enabled = False
        End If
        isloaded = True


    End Sub


    Private Sub grddetail_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)
        If Voucher.Tabdetails(Voucher.TabFirst).gridDetailKeyin.Rows(e.RowIndex).IsNewRow = False Then
            Select Case Voucher.Tabdetails(Voucher.TabFirst).gridDetailKeyin.Columns(e.ColumnIndex).Name
                Case "nguyen_gia"
                    Voucher.Tabdetails(Voucher.TabFirst).gridDetailKeyin.Item("gt_cl", e.RowIndex).Value = Voucher.Tabdetails(Voucher.TabFirst).gridDetailKeyin.Item("nguyen_gia", e.RowIndex).Value - Voucher.Tabdetails(Voucher.TabFirst).gridDetailKeyin.Item("gt_da_kh", e.RowIndex).Value
                    tinh_gia_tri_kh_ky(Voucher.Tabdetails(Voucher.TabFirst).gridDetailKeyin.Rows(e.RowIndex))
                    tinh_tong_tien()
                Case "gt_da_kh"
                    Voucher.Tabdetails(Voucher.TabFirst).gridDetailKeyin.Item("gt_cl", e.RowIndex).Value = Voucher.Tabdetails(Voucher.TabFirst).gridDetailKeyin.Item("nguyen_gia", e.RowIndex).Value - Voucher.Tabdetails(Voucher.TabFirst).gridDetailKeyin.Item("gt_da_kh", e.RowIndex).Value
                    tinh_gia_tri_kh_ky(Voucher.Tabdetails(Voucher.TabFirst).gridDetailKeyin.Rows(e.RowIndex))
                    tinh_tong_tien()
                Case "gt_cl"
                    tinh_gia_tri_kh_ky(Voucher.Tabdetails(Voucher.TabFirst).gridDetailKeyin.Rows(e.RowIndex))
                    tinh_tong_tien()
            End Select

        End If
    End Sub

   


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
        'kiem tra so the ts
        If kiem_tra_so_the_ts() = False Then
            Return False
            Exit Function
        End If

        'kiem tra so chung tu
        If Voucher.CheckSoCT(Txtngay_ct.Value, txtso_ct.Text) = False Then
            Return False
            Exit Function
        End If
        Voucher.BindingSource.EndEdit()
        'kiem tra da nhap chi tiet chua
        If Voucher.CheckKeyIn = False Then
            Return False
        End If
        'dien cac gia tri cu m vao d
        Voucher.SynMD()
        If Voucher.Action = 1 Then
            Voucher.Insert()
        Else
            Voucher.Update()
            If oldso_the_ts <> Voucher.CurrentVoucher("so_the_ts") Then
                conn.Execute("EXEC ChangeSoTheCC '" & oldso_the_ts & "','" & Voucher.CurrentVoucher("so_the_ts") & "'")
            End If
        End If

        'post
        post()
        '
        Return True
    End Function


    Sub tinh_tong_tien()
        If isloaded = False Then
            Return
        End If


    End Sub
    Private Sub btnluuandmoi_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnluuandmoi.Click
        If save() = False Then
            Exit Sub
        End If
        Me.BindingContext(Voucher.BindingSource).EndCurrentEdit()
        Voucher.Mdatatable.AcceptChanges()
        Voucher.News2()

        txtso_ct.Focus()
    End Sub

    Private Sub btnhuy_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnhuy.Click
        If Voucher.Action = 1 Then
            Voucher.Mdatatable.Rows.Remove(Voucher.CurrentVoucher)
        End If
    End Sub

    Dim oldso_ky_kh As Integer
    Private Sub Txtso_ky_kh_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txtso_ky_kh.Enter
        oldso_ky_kh = Txtso_ky_kh.Value
    End Sub

    Private Sub Txtso_ky_kh_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txtso_ky_kh.Validated
        If oldso_ky_kh <> Txtso_ky_kh.Value Then
            For Each r As DataGridViewRow In Voucher.Tabdetails(Voucher.TabFirst).gridDetailKeyin.Rows
                tinh_gia_tri_kh_ky(r)
            Next
        End If
    End Sub
    Function kiem_tra_so_the_ts() As Boolean
        Dim kq As Boolean = True
        Dim dttest As DataTable = conn.GetDatatable("select so_the_ts,stt_rec from mcc where so_the_ts ='" & txtso_the_ts.Text.Trim & "'")

        If dttest.Rows.Count > 0 Then

            If Voucher.Action = ClsSV31.Voucher20.Actions.ADD Then
                kq = False

            Else
                If Voucher.Stt_rec.Trim.ToLower = dttest.Rows(0).Item("stt_rec").Trim.ToLower Then
                    kq = True

                Else
                    kq = False
                End If
            End If
        Else
            kq = True
        End If
finish:
        If kq = False Then
            txtso_the_ts.Focus()
            MsgBox(Voucher.oLan("020"), MsgBoxStyle.Exclamation, Me.Text)
        End If
        Return kq
    End Function

    Private Sub cbbkieu_kh_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbbkieu_kh.SelectedValueChanged
        Try
            hide_show_field(cbbkieu_kh.SelectedValue)
        Catch ex As Exception

        End Try


    End Sub
    Sub hide_show_field(ByVal kieu_kh As Integer)
        Select Case kieu_kh
            Case 0
                Txtky_kh00.Enabled = False
                Txtty_le_kh.Enabled = False
                Txttong_sl.Enabled = False
            Case 1
                Txtky_kh00.Enabled = False
                Txtty_le_kh.Enabled = False
                Txttong_sl.Enabled = True
            Case 2
                Txtky_kh00.Enabled = True
                Txtty_le_kh.Enabled = True
                Txttong_sl.Enabled = False
        End Select
    End Sub
    Sub tinh_gia_tri_kh_ky(ByVal r As DataGridViewRow)
        If Not r.IsNewRow Then
            If Txtso_ky_kh.Value = 0 Then
                r.Cells("gt_kh_ky").Value = 0
            Else
                If chbtinh_kh_cl.Checked Then
                    r.Cells("gt_kh_ky").Value = r.Cells("gt_cl").Value / Txtso_ky_kh.Value
                Else
                    r.Cells("gt_kh_ky").Value = r.Cells("nguyen_gia").Value / Txtso_ky_kh.Value
                End If

            End If

        End If
    End Sub
    Private Sub txtso_ct_TextChanged(sender As Object, e As EventArgs) Handles txtso_ct.TextChanged
        If Voucher.FormKeyInShowed Then
            txtso_the_ts.Text = txtso_ct.Text
        End If
    End Sub
End Class