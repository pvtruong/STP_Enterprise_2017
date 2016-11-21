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


        If Clsql.Reg.GetValue("Language") = "Vi" Then
            okh.SetValue("ten_kh", lblten_kh)

            omavt.SetValue("ten_vt", ten_vt)


            obpSearch.SetValue("ten_bp", ten_bp)
        Else
            okh.SetValue("ten_kh2", lblten_kh)

            omavt.SetValue("ten_vt2", ten_vt)


            obpSearch.SetValue("ten_bp2", ten_bp)
        End If
        Try
            Txttu_ngay.Value = Clsql.Reg.GetValue("tu_ngay")
            TxtDen_ngay.Value = Clsql.Reg.GetValue("den_ngay")
        Catch ex As Exception

        End Try

        PropertyOfForm.KeyEnter(Me)
        StartPosition = FormStartPosition.CenterParent

        ClsControl2.PropertyOfForm.SetLable(Voucher.oLan, Me)

        ClsLookup.AddItems.AddItemCbb(Voucher.conn, "select inds,text,text2 from dmitemofcbb where form ='" & Voucherid & "' and name = 'status' order by inds", cbbstatus, "text", "text2", "inds")

        Dim dtdau As New DataTable
        dtdau.Columns.Add("id")
        For Each k As String In {"=", ">", "<"}
            Dim r As DataRow = dtdau.NewRow
            r("id") = k
            dtdau.Rows.Add(r)
        Next
        cbbdau.DataSource = dtdau
        cbbdau.ValueMember = "id"
        cbbdau.DisplayMember = "id"
        cbbdau.SelectedValue = "="




    End Sub
End Class