Imports ClsStpService

Public Class frnVisa
    Public t_phai_thu As Double = 0
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If txtchu_the.Text = "" Or txtso_the.Text = "" Then
            Return
        End If
        DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub frnVisa_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then
            Button1.PerformClick()
        End If
    End Sub

    Private Sub frnVisa_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtchu_the.Focus()
        ClsControl2.PropertyOfForm.KeyEnter(Me)
    End Sub

    Private Sub txtso_tien_ValueChanged() Handles txtso_tien.ValueChanged
        txtt_thu_tm.Value = t_phai_thu - txtso_tien.Value
        If txtt_thu_tm.Value < 0 Then
            txtt_thu_tm.Value = 0
        End If
    End Sub
End Class

