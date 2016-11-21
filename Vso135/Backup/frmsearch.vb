Imports ClsControl2

Public Class frmsearch

    Private Sub btntim_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btntim.Click
        DialogResult = Windows.Forms.DialogResult.OK
        Clsql.Reg.SetValue("tu_ngay", Txttu_ngay.Value)
        Clsql.Reg.SetValue("den_ngay", TxtDen_ngay.Value)
        Clsql.Reg.SetValue("ma_kh", txtma_kh.Text)
        Clsql.Reg.SetValue("ma_vt", txtma_vt.Text)
        Me.Close()
    End Sub

    Private Sub btnhuy_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnhuy.Click
        Me.Close()
    End Sub


    Private Sub frmsearch_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'dien gia tri mac dinh cho form tim kiem
        Dim okh As New ClsLookup.AutoCompleteLookup(Voucher.conn, "dmkh", txtma_kh, "ma_kh", False, False)

        Dim omavt As New ClsLookup.AutoCompleteLookup(Voucher.conn, "dmvt", txtma_vt, "ma_vt", False, False)

        Dim obpSearch As New ClsLookup.AutoCompleteLookup(Voucher.conn, "dmbp", txtma_bp, "ma_bp", False, False)
        Dim oKhophi As New ClsLookup.AutoCompleteLookup(Voucher.conn, "dmphi", txtma_phi, "ma_phi", False, False)
        Dim oKhodt As New ClsLookup.AutoCompleteLookup(Voucher.conn, "dmdt", txtma_dt, "ma_dt", False, False)


        If Clsql.Reg.GetValue("Language") = "Vi" Then
            okh.SetValue("ten_kh", lblten_kh)

            omavt.SetValue("ten_vt", ten_vt)

            oKhodt.SetValue("ten_dt", ten_dt)
            oKhophi.SetValue("ten_phi", ten_phi)
            obpSearch.SetValue("ten_bp", ten_bp)
        Else
            okh.SetValue("ten_kh2", lblten_kh)

            omavt.SetValue("ten_vt2", ten_vt)

            oKhodt.SetValue("ten_dt2", ten_dt)
            oKhophi.SetValue("ten_phi2", ten_phi)
            obpSearch.SetValue("ten_bp2", ten_bp)
        End If
        Try
            Txttu_ngay.Value = Clsql.Reg.GetValue("tu_ngay")
            TxtDen_ngay.Value = Clsql.Reg.GetValue("den_ngay")
        Catch ex As Exception

        End Try

        txtma_kh.Text = Clsql.Reg.GetValue("ma_kh")
        txtma_vt.Text = Clsql.Reg.GetValue("ma_vt")

        PropertyOfForm.KeyEnter(Me)
        StartPosition = FormStartPosition.CenterParent

        ClsControl2.PropertyOfForm.SetLable(Voucher.oLan, Me)

    End Sub
End Class