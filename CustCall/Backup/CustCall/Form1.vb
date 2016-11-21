Public Class Form1

    Dim conn As Clsql.SQL
    Dim dtCust As DataTable
    Dim rowCust As DataRow
    Dim action As Clsql.Actions.Action
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ClsControl2.PropertyOfForm.SetICon4Control("mainicon.ico", Me)
        ClsControl2.PropertyOfForm.KeyEnter(Me)
        Dim dien_thoai As String = Clsql.Others.GetArgu(1)
        txtdien_thoai.Text = dien_thoai
        If dien_thoai <> "" Then
            conn = New Clsql.SQL
            dtCust = conn.GetDatatable("select top 1 * from dkh where dien_thoai ='" & dien_thoai & "'")
            If dtCust.Rows.Count > 0 Then
                rowCust = dtCust.Rows(0)
                txtma_kh.Text = rowCust("ma_kh")
                txtten_kh.Text = rowCust("ten_kh")
                txtdia_chi.Text = rowCust("dia_chi")
                rowCust("nguoi_sua") = Clsql.Reg.GetValue("id")
                rowCust("ngay_sua") = conn.Server.GetDate()
                action = Clsql.Actions.Action.Edit
            Else
                rowCust = dtCust.NewRow
                rowCust("dien_thoai") = dien_thoai
                rowCust("nguoi_tao") = Clsql.Reg.GetValue("id")
                rowCust("ngay_tao") = conn.Server.GetDate()
                rowCust("trang_thai") = True
                dtCust.Rows.Add(rowCust)
                action = Clsql.Actions.Action.Add
                btnOrder.Enabled = False
            End If
        Else
            Me.Close()
        End If
    End Sub

    Dim vno As ClsVno.AutoCreateCode
    Private Sub btnAddNewCust_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddNewCust.Click
        If txtten_kh.Text = "" Or txtdia_chi.Text = "" Then
            MsgBox("Tên khách hàng và địa chỉ không được trống.", MsgBoxStyle.Critical, Clsql.AboutMe.Name)
            Return
        End If
        If action = Clsql.Actions.Action.Add Then
            vno = New ClsVno.AutoCreateCode(conn, "dmkh")
            txtma_kh.Text = vno.GetNextCode("dkh", "ma_kh")
            vno.UpdateCode(txtma_kh.Text)
        End If
        'save
        rowCust("ma_kh") = txtma_kh.Text
        rowCust("ten_kh") = txtten_kh.Text
        rowCust("dia_chi") = txtdia_chi.Text
        rowCust("email") = txtemail.Text
        rowCust("nguoi_tao") = Clsql.Reg.GetValue("id")
        rowCust("ngay_tao") = conn.Server.GetDate
        ''
        Clsql.Data.ClearNullValue(dtCust)
        If action = Clsql.Actions.Action.Add Then
            conn.WriteToServer(dtCust, "dkh")
        Else
            Dim query As String = conn.GetUpdateQueryFromDatarow(rowCust, "dkh")
            conn.Execute(query)
        End If
        conn.Execute("exec CreateSyncList 'dmkh','ma_kh=''" & txtma_kh.Text & "'''")
        MsgBox("Thông tin khách hàng đã được cập nhật", , Clsql.AboutMe.Name)
        btnOrder.Enabled = True
    End Sub

    Private Sub btnOrder_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOrder.Click
        Clsql.Others.Exec("VSO1.exe", "SO1 -ADD ma_kh:" & txtma_kh.Text.Trim & " ngay_giao:" & Strings.Format(Now, "yyyy/MM/dd") & " dia_chi_giao:" & txtdia_chi.Text.Replace(" ", "%s") & " ong_ba:" & txtten_kh.Text.Replace(" ", "%s"))
    End Sub

    Private Sub btnGhi_chu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGhi_chu.Click
        Dim path As String = Application.StartupPath & "\Lnotes.exe"
        Dim args As String = "NOTES <!add> ma_kh:" & txtma_kh.Text
        Dim p As Process = Process.Start(path, args)
        p.WaitForExit()

    End Sub
End Class
