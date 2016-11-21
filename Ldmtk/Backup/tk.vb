Imports Clsql

Public Class tk

    Private Sub frminput_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        Me.txttk.Focus()
        Me.txttk.SelectionStart = Len(txttk.Text)
        cbbloai_cl_co.Enabled = Not (ma_nt_ht.Trim.ToUpper = txtma_nt.Text.Trim.ToUpper)
        cbbloai_cl_no.Enabled = Not (ma_nt_ht.Trim.ToUpper = txtma_nt.Text.Trim.ToUpper)
    End Sub

    Private Sub kh_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
       
    End Sub

    Private Sub txttk_me_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles txttk_me.Enter
        oTK.oKey = "tk <> '" & txttk.Text & "'"
    End Sub

    Private Sub ma_nt_valid(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtma_nt.Validated
        cbbloai_cl_co.Enabled = Not (ma_nt_ht.Trim.ToUpper = txtma_nt.Text.Trim.ToUpper)
        cbbloai_cl_no.Enabled = Not (ma_nt_ht.Trim.ToUpper = txtma_nt.Text.Trim.ToUpper)
    End Sub

    Private Sub cbbloai_cl_co_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbbloai_cl_co.SelectedIndexChanged
        Try
            If cbbloai_cl_co.SelectedValue <> 0 Then
                cbbloai_cl_no.SelectedValue = 0
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cbbloai_cl_no_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbbloai_cl_no.SelectedIndexChanged
        Try
            If cbbloai_cl_no.SelectedValue <> 0 Then
                cbbloai_cl_co.SelectedValue = 0
            End If
        Catch ex As Exception

        End Try
    End Sub
End Class