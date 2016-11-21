Public Class frmCK
    Public t_hoa_don As Double = 0
    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        DialogResult = DialogResult.OK
        Me.Close()
    End Sub

    Private Sub frmCK_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Txtty_le_ck_hd.Focus()
    End Sub

    Dim ty_le_ck_old As Double = 0
    Private Sub Txtty_le_ck_hd_Enter(sender As Object, e As EventArgs) Handles Txtty_le_ck_hd.Enter
        ty_le_ck_old = Txtty_le_ck_hd.Value
    End Sub

    Private Sub Txtty_le_ck_hd_Validated(sender As Object, e As EventArgs) Handles Txtty_le_ck_hd.Validated
        If ty_le_ck_old <> Txtty_le_ck_hd.Value Then
            Txttien_ck_hd.Value = Math.Round(Txtty_le_ck_hd.Value * t_hoa_don / 100, 0)
        End If
    End Sub
End Class