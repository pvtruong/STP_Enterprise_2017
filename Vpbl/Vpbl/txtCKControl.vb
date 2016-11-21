Public Class txtCKControl
    Dim oldvalue As Double = 0
    Public Event ty_le_changed(ty_le_ck As Double)
    Public Event gia_tri_changed(gia_tri As Double)
    Public Event ok()
    Private Sub Txtty_le_Enter(sender As Object, e As EventArgs) Handles Txtty_le.Enter
        oldvalue = Txtty_le.Value
    End Sub

    Private Sub Txtty_le_Validated(sender As Object, e As EventArgs) Handles Txtty_le.Validated
        If oldvalue <> Txtty_le.Value Then
            RaiseEvent ty_le_changed(Txtty_le.Value)
        End If
    End Sub
    Private Sub Txtgia_tri_Enter(sender As Object, e As EventArgs) Handles Txtgia_tri.Enter
        oldvalue = Txtgia_tri.Value
    End Sub
    Private Sub Txtgia_tri_Validated(sender As Object, e As EventArgs) Handles Txtgia_tri.Validated
        If oldvalue <> Txtgia_tri.Value Then
            RaiseEvent gia_tri_changed(Txtgia_tri.Value)
        End If
    End Sub
    Private Sub Txtgia_tri_KeyDown(sender As Object, e As KeyEventArgs) Handles Txtgia_tri.KeyDown
        If e.KeyCode = Keys.Enter Then
            RaiseEvent ok()
        End If
    End Sub
End Class
