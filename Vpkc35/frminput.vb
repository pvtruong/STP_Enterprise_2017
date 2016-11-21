Imports ClsLookup

Public Class frminput

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
    End Sub

    Private Sub frminput_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        For Each dvtab As ClsSV31.TabDetail20 In Voucher.Tabdetails.Values
            AddHandler dvtab.AfterCalcOnCell, AddressOf tinh_tong_tien
        Next

    End Sub


   
    Private Sub frminput_show(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        Dim dvr As DataRowView = cbbma_nt.SelectedItem

        hide_show_control(dvr("ma_nt"))
        isloaded = True
        If Voucher.Action = ClsSV31.Voucher20.Actions.ADD Then
            Txtty_gia.Value = dvr("ty_gia")
        End If
        '
        cbbma_nt.SelectedValue = ma_nt_ht
        Txtty_gia.Value = 1
        ''
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
            Case ClsSV31.frmTask.Tasks.Close
                Me.DialogResult = DialogResult.OK
                Me.Close()
        End Select
    End Sub
    Function save() As Boolean
        '
        Voucher.BindingSource.EndEdit()
        updateBindingsource()
        'kiem tra so chung tu
        If Voucher.CheckSoCT(Txtngay_ct.Value, txtso_ct.Text) = False Then
            Return False
            Exit Function
        End If
        'kiem tra nhap lieu
        If Voucher.CheckKeyIn = False Then
            Return False
        End If
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
    Dim t_tien, t_tt, t_sl, t_tien_von, t_tien_nt, t_tt_nt, t_sl_nt, t_tien_von_nt As Double
    Sub tinh_tong_tien()

        t_tien_nt = ClsControl2.PropertyOfGrid.Sum(Voucher.Tabdetails(Voucher.TabFirst).gridDetailKeyin, "tien_nt")
        t_tien = ClsControl2.PropertyOfGrid.Sum(Voucher.Tabdetails(Voucher.TabFirst).gridDetailKeyin, "tien")

        t_tt_nt = t_tien_nt
        t_tt = t_tien
        '
        Txtt_tien_nt.Value = t_tien_nt
        Txtt_tien.Value = t_tien
        txtt_tt.Value = t_tt
        txtt_tt_nt.Value = t_tt_nt


    End Sub
    Private Sub btnluuandmoi_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnluuandmoi.Click
        If save() = False Then
            Exit Sub
        End If
        Me.BindingContext(Voucher.BindingSource).EndCurrentEdit()
        Voucher.Mdatatable.AcceptChanges()
        Voucher.News2()
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
            TabControl1.SelectedTab = TabControl1.TabPages(0)
            If cbbma_nt.SelectedItem IsNot Nothing Then
                Dim dvr As DataRowView = cbbma_nt.SelectedItem

                Txtty_gia.Value = conn.GetValue("exec getty_gia " & conn.ConvertToSQLType(cbbma_nt.SelectedValue.trim) & "," & conn.ConvertToSQLType(Txtngay_ct.Value))
                hide_show_control(dvr("ma_nt"))
            End If

        Catch ex As Exception

        End Try
    End Sub

    

    Sub hide_show_control(ByVal ma_nt As String)
        txtt_tt.Hide()
        txtt_tt_nt.Hide()
        For Each t As ClsSV31.TabDetail20 In Voucher.Tabdetails.Values
            t.ma_nt = ma_nt
        Next
        If ma_nt.Trim.ToUpper = ma_nt_ht.Trim.ToUpper Then
            
            Txtty_gia.ReadOnly = True
            Txtt_tien.Hide() ' = False

        Else

            Txtty_gia.ReadOnly = False
            Txtt_tien.Show() 'Visible = True
            tinh_tong_tien()

        End If
    End Sub
    Sub updateBindingsource()
        Voucher.BindingSource.Current("t_tt") = t_tt
        Voucher.BindingSource.Current("t_tt_nt") = t_tt_nt
        Voucher.BindingSource.Current("t_tien") = t_tien
    End Sub
    Private Sub btntao_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btntao.Click
        If checkkc() = False Then
            Exit Sub
        End If
        Dim dttable As DataTable = conn.GetDatatable("exec CreateClosingTrans " & txttu_ky.Value & "," & txtden_ky.Value & "," & txtnam.Value & ",'" & Clsql.Reg.GetValue("unit") & "','" & Voucher.Stt_rec & "'")
        Clsql.Data.CopyTable(dttable, Voucher.Tabdetails(Voucher.TabFirst).Datatable)
        ' Voucher.chitiet.Datatable = layhd.DDataView.Table
        Voucher.Tabdetails(Voucher.TabFirst).bindingsource.DataSource = Voucher.Tabdetails(Voucher.TabFirst).Datatable

    End Sub

    Private Sub Txtngay_ct_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txtngay_ct.TextChanged
        If Txtngay_ct.Focused Then
            If isloaded = True Then
                txtden_ky.Value = Txtngay_ct.Value.Month
                txttu_ky.Value = txtden_ky.Value
            End If
        End If

    End Sub

    Private Sub txtden_ky_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtden_ky.ValueChanged
        If txtden_ky.Focused Then
            If isloaded = True Then
                Txtngay_ct.Value = Clsql.Others.EndDateOfMonth(txtden_ky.Value, txtnam.Value)
                If txttu_ky.Value > txtden_ky.Value Then
                    txttu_ky.Value = txtden_ky.Value
                End If
            End If
        End If

    End Sub

    Private Sub txttu_ky_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txttu_ky.ValueChanged
        If txttu_ky.Focused Then
            If isloaded = True Then
                If txttu_ky.Value > txtden_ky.Value Then
                    txttu_ky.Value = txtden_ky.Value
                End If
            End If
        End If

    End Sub

    Private Sub btnkhaibao_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnkhaibao.Click
        Clsql.Others.Exec(Application.StartupPath & "\ldmkc.exe", "dmkc")
    End Sub
    Function checkkc() As Boolean
        If conn.GetValue("select count(stt) from dmkc where trang_thai =1") = 0 Then
            MsgBox(Voucher.oLan("K01"), MsgBoxStyle.Exclamation, Me.Text)
            Return False
        End If
        If Voucher.Action = ClsSV31.Voucher20.Actions.ADD Then
            If conn.GetValue("select count(stt_rec) from socai where ma_ct ='" & Voucherid & "' and month(ngay_ct) >=" & txttu_ky.Value & " and month(ngay_ct) <=" & txtden_ky.Value & " and year(ngay_ct) =" & txtnam.Value & " and ma_dvcs ='" & Clsql.Reg.GetValue("unit") & "'") > 0 Then
                If MsgBox(Voucher.oLan("K02"), MsgBoxStyle.YesNo, Me.Text) = MsgBoxResult.No Then
                    Return False
                End If
            End If
        End If

        Return True
    End Function
End Class