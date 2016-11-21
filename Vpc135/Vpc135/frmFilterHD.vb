Public Class frmFilterHD
    Private Sub btnOk_Click(sender As Object, e As EventArgs) Handles btnOk.Click
        DialogResult = DialogResult.OK
        Me.Close()
    End Sub

    Private Sub btncancel_Click(sender As Object, e As EventArgs) Handles btncancel.Click
        Me.Close()
    End Sub

    Private Sub frmFilterHD_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim kh As New ClsLookup.AutoCompleteLookup(Clsql.SQL.newInstance, "dmkh", txtma_kh, "ma_kh", False)
        kh.SetValue("ten_kh", ten_kh)
    End Sub
End Class