Imports ClsControl2

Public Class frmsearch

    Private Sub btntim_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btntim.Click
        DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub btnhuy_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnhuy.Click
        Me.Close()
    End Sub


    Private Sub frmsearch_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'dien gia tri mac dinh cho form tim kiem
        Dim oNCC2search As New ClsLookup.AutoCompleteLookup(Voucher.conn, "ldkh", txtma_kh, "ma_kh", False, False)

        Dim otkno As New ClsLookup.AutoCompleteLookup(Voucher.conn, "dmtk", txttk_no, "tk", False, False)
        Dim otkco As New ClsLookup.AutoCompleteLookup(Voucher.conn, "dmtk", txttk_co, "tk", False, False)
        If Clsql.Reg.GetValue("Language") = "Vi" Then
            oNCC2search.SetValue("ten_kh", lblten_khach)

            otkno.SetValue("ten_tk", ten_tk_no)
            otkco.SetValue("ten_tk", ten_tk_co)

        Else
            oNCC2search.SetValue("ten_kh2", lblten_khach)

            otkno.SetValue("ten_tk2", ten_tk_no)
            otkco.SetValue("ten_tk2", ten_tk_co)

        End If
        Try
            Txttu_ngay.Value = Clsql.Reg.GetValue("tu_ngay")
            TxtDen_ngay.Value = Clsql.Reg.GetValue("den_ngay")
        Catch ex As Exception

        End Try

        txtma_kh.Text = Clsql.Reg.GetValue("ma_kh")
        PropertyOfForm.KeyEnter(Me)
        StartPosition = FormStartPosition.CenterParent
        ClsControl2.PropertyOfForm.SetLable(Voucher.oLan, Me)

    End Sub
End Class