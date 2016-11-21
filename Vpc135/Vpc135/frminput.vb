Imports ClsLookup

Public Class frminput

    Dim isloaded As Boolean = False
    Dim t_thue, t_thue_nt, t_tien, t_tien_nt As Double, _parent As Frmmain, voucher As ClsSV31.Voucher20
    Public Sub setParent(_p As Frmmain)
        _parent = _p
        voucher = _p.Voucher
    End Sub
    Private Sub frminput_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        If isloaded = False Then
            Me.txtso_ct.Focus()
            Me.txtso_ct.SelectionStart = txtso_ct.Text.Length
            txtma_kh.ReadOnly = False
            cbbma_gd.Enabled = True
        End If

    End Sub

    Private Sub frminput_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        isloaded = False
        For Each dvtab As ClsSV31.TabDetail20 In voucher.Tabdetails.Values
            RemoveHandler dvtab.AfterCalcOnCell, AddressOf tinh_tong_tien
        Next
        RemoveHandler voucher.Tabdetails("vtdttco").gridDetailKeyin.CellBeginEdit, AddressOf grddetailhd_CellBeginEdit
        RemoveHandler voucher.Tabdetails("vvatvao").gridDetailKeyin.CellEndEdit, AddressOf grdvat_CellEndEdit
    End Sub

    Private Sub frminput_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        For Each dvtab As ClsSV31.TabDetail20 In voucher.Tabdetails.Values
            AddHandler dvtab.AfterCalcOnCell, AddressOf tinh_tong_tien
        Next

        AddHandler voucher.Tabdetails("vtdttco").gridDetailKeyin.CellBeginEdit, AddressOf grddetailhd_CellBeginEdit
        AddHandler voucher.Tabdetails("vvatvao").gridDetailKeyin.CellEndEdit, AddressOf grdvat_CellEndEdit
    End Sub
    Private Sub frminput_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        Dim dvr As DataRowView = cbbma_nt.SelectedItem

        hide_show_control(dvr("ma_nt"))
        isloaded = True
        If voucher.Action = ClsSV31.Voucher20.Actions.ADD Then
            Txtty_gia.Value = Clsql.SQL.newInstance.GetValue("exec getty_gia " & Clsql.SQL.newInstance.ConvertToSQLType(cbbma_nt.SelectedValue.trim) & "," & Clsql.SQL.newInstance.ConvertToSQLType(Txtngay_ct.Value))     'dvr("ty_gia")
        End If
        '
        If isloaded Then
            Try
                If cbbma_gd.SelectedValue = 1 Then

                    voucher.Tabdetails("vtdttco").status = True
                    voucher.Tabdetails("vdpc1").status = False
                    voucher.Tabdetails("vvatvao").status = False


                    btngethoadon.Visible = True
                Else
                    voucher.Tabdetails("vtdttco").status = False
                    voucher.Tabdetails("vdpc1").status = True
                    voucher.Tabdetails("vvatvao").status = True
                    btngethoadon.Visible = False
                End If
                voucher.CreateFormKeyIn(True)
                hide_show_control(cbbma_nt.SelectedValue)
            Catch ex As Exception

            End Try
        End If
    End Sub
#Region "lay ty gia tu dong"
    Dim ngay_ctold As Date
    Private Sub Txtngay_ct_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txtngay_ct.Validated
        If ngay_ctold <> Txtngay_ct.Value Then
            If isloaded Then
                If voucher.Action = ClsSV31.Voucher20.Actions.ADD Then
                    Txtty_gia.Value = Clsql.SQL.newInstance.GetValue("exec getty_gia " & Clsql.SQL.newInstance.ConvertToSQLType(cbbma_nt.SelectedValue.trim) & "," & Clsql.SQL.newInstance.ConvertToSQLType(Txtngay_ct.Value))     'dvr("ty_gia")
                End If
            End If
        End If
    End Sub
    Private Sub Txtngay_ct_endter(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txtngay_ct.Enter
        ngay_ctold = Txtngay_ct.Value
    End Sub
#End Region





    Private Sub grddetailhd_CellBeginEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs)
        voucher.Tabdetails("vtdttco").gridDetailKeyin.Item("stt_rec", e.RowIndex).Value = voucher.Stt_rec
        voucher.Tabdetails("vtdttco").gridDetailKeyin.Item("ma_ct", e.RowIndex).Value = _parent.Voucherid
        voucher.Tabdetails("vtdttco").gridDetailKeyin.Item("loai_tt", e.RowIndex).Value = 1

    End Sub


    Private Sub grdvat_CellBeginEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs)


    End Sub
    Private Sub grdvat_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)

        Dim ty_gia As Double = Txtty_gia.Value
        If sender.Rows(e.RowIndex).IsNewRow = False Then
            Select Case sender.Columns(e.ColumnIndex).Name
                Case "so_seri"
                    sender.Item("so_seri", e.RowIndex).Value = sender.Item("so_seri", e.RowIndex).Value.ToString.ToUpper
                Case "so_hd"
                    sender.Item("so_hd", e.RowIndex).Value = sender.Item("so_hd", e.RowIndex).Value.ToString.ToUpper


                    Dim tien As Double = 0
                    Dim tien_nt As Double = 0

                    For Each r As DataGridViewRow In voucher.Tabdetails("vdpc1").gridDetailKeyin.Rows
                        If Not r.IsNewRow Then
                            If r.Cells("so_hd").Value.ToString.Trim.ToLower = sender.Item("so_hd", e.RowIndex).Value.ToString.Trim.ToLower Then
                                tien = tien + r.Cells("tien").Value
                                tien_nt = tien_nt + r.Cells("tien_nt").Value
                                sender.Item("t_tien", e.RowIndex).Value = tien
                                sender.Item("t_tien_nt", e.RowIndex).Value = tien_nt
                                sender.Item("t_thue_nt", e.RowIndex).Value = tien_nt * sender.Item("thue_suat", e.RowIndex).Value / 100
                                sender.Item("t_thue", e.RowIndex).Value = tien * sender.Item("thue_suat", e.RowIndex).Value / 100
                                sender.Item("ngay_hd", e.RowIndex).Value = Txtngay_ct.Value
                                sender.Item("tk_du", e.RowIndex).Value = r.Cells("tk_co").Value
                                sender.Item("ty_gia_gs_co", e.RowIndex).Value = r.Cells("ty_gia_gs_co").Value
                            End If
                        End If
                    Next
                    tien = Nothing
                    tien_nt = Nothing

                    tinh_tong_tien()

            End Select
        End If
    End Sub
    Dim formtask As ClsSV31.frmTask = Nothing
    Private Sub btnLuu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLuu.Click
        If save() = False Then
            Exit Sub
        End If
        If formtask Is Nothing Then
            formtask = New ClsSV31.frmTask
            ClsControl2.PropertyOfForm.SetLable(voucher.oLan, formtask)
            formtask.Icon = Me.Icon

            formtask.btnprint.Enabled = voucher.rights.PrintRight
        End If
        If cbbma_gd.SelectedValue = 1 Then
            formtask.btncopy.Enabled = False
        Else
            formtask.btncopy.Enabled = True
        End If
        formtask.btnnew.Enabled = voucher.rights.NewRight
        If formtask.btncopy.Enabled = True Then
            formtask.btncopy.Enabled = voucher.rights.NewRight
        End If


        formtask.ShowDialog(Me)
        Select Case formtask.task
            Case ClsSV31.frmTask.Tasks.AddNew
                Me.BindingContext(voucher.BindingSource).EndCurrentEdit()
                voucher.Mdatatable.AcceptChanges()
                voucher.News2()
            Case ClsSV31.frmTask.Tasks.Copy
                voucher.Copy()
            Case ClsSV31.frmTask.Tasks.Print
                For Each r As DataRow In voucher.Mdatatable.Select("sel=true")
                    r("sel") = False
                Next
                voucher.BindingSource.Current("sel") = True
                _parent.getPrint.Print()
                Me.Close()
            Case ClsSV31.frmTask.Tasks.Close
                Me.DialogResult = DialogResult.OK
                Me.Close()
        End Select
    End Sub
    Function save() As Boolean
        'kiem tra so chung tu
        If voucher.CheckSoCT(Txtngay_ct.Value, txtso_ct.Text) = False Then
            Return False
            Exit Function
        End If
        voucher.BindingSource.EndEdit()

        For Each r As DataRow In voucher.Tabdetails("vtdttco").Datatable.Select("tien_nt =0")
            r.Delete()
        Next

        'kiem tra cap nhat
        If voucher.CheckKeyIn() = False Then
            Return False
        End If

        'dien cac gia tri cu m vao d
        Dim sqltattoan As String = ""
        voucher.SynMD()
        _parent.querytt = getQuerytattoan(voucher.Stt_rec)
        If voucher.Action = 1 Then

            voucher.Insert()
        Else
            voucher.Update()
        End If
        'post detail trong truong hop thanh toan theo hoa don
        If voucher.Tabdetails("vdpc1").status = False Then
            sqltattoan = Clsql.SQL.newInstance.GetInsertQueryFromDatatable(voucher.Tabdetails("vtdttco").Datatable, voucher.Tabdetails("vdpc1").TableName)
            Clsql.SQL.newInstance.Execute(sqltattoan)

            'Clsql.Data.CopyTable(Voucher.Tabdetails("vtdttco").Datatable, Voucher.Tabdetails("vdpc1").DatatableView, "1=1", "stt_rec='" & Voucher.Stt_rec & "'")
            Dim tbdetail As DataTable = Clsql.SQL.newInstance.GetDatatable("select * from vdpc1 where stt_rec ='" & voucher.Stt_rec & "'")
            Clsql.Data.CopyTable(tbdetail, voucher.Tabdetails("vdpc1").DatatableView, "1=1", "stt_rec='" & voucher.Stt_rec & "'")
            tbdetail.Dispose()
        End If
        'post
        ClsSV31.Functions.Post(Clsql.SQL.newInstance, voucher.voucherID, voucher.Mviewname, voucher.Stt_rec, cbbstatus.SelectedValue)
        voucher.refreshMaster()
        Return True
    End Function
    Sub tinh_tong_tien()
        If isloaded = False Then
            Return
        End If
        t_thue = ClsControl2.PropertyOfGrid.Sum(voucher.Tabdetails("vvatvao").gridDetailKeyin, "t_thue")
        t_thue_nt = ClsControl2.PropertyOfGrid.Sum(voucher.Tabdetails("vvatvao").gridDetailKeyin, "t_thue_nt")


        txtt_thue_nt.Value = t_thue_nt
        txtt_thue.Value = t_thue
        If cbbma_gd.SelectedValue = 1 Then
            t_tien = ClsControl2.PropertyOfGrid.Sum(voucher.Tabdetails("vtdttco").gridDetailKeyin, "tien")

            t_tien_nt = ClsControl2.PropertyOfGrid.Sum(voucher.Tabdetails("vtdttco").gridDetailKeyin, "tien_nt")


        Else
            t_tien = ClsControl2.PropertyOfGrid.Sum(voucher.Tabdetails("vdpc1").gridDetailKeyin, "tien")
            t_tien_nt = ClsControl2.PropertyOfGrid.Sum(voucher.Tabdetails("vdpc1").gridDetailKeyin, "tien_nt")

        End If

        Txtt_tien_nt.Value = t_tien_nt
        Txtt_tien.Value = t_tien

        txtt_tt_nt.Value = t_thue_nt + t_tien_nt
        txtt_tt.Value = t_thue + t_tien

    End Sub
    Private Sub btnluuandmoi_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnluuandmoi.Click
        If save() = False Then
            Exit Sub
        End If
        Me.BindingContext(voucher.BindingSource).EndCurrentEdit()
        voucher.Mdatatable.AcceptChanges()
        voucher.News2()
        Txtty_gia.Value = Clsql.SQL.newInstance.GetValue("exec getty_gia " & Clsql.SQL.newInstance.ConvertToSQLType(cbbma_nt.SelectedValue.trim) & "," & Clsql.SQL.newInstance.ConvertToSQLType(Txtngay_ct.Value))
        txtso_ct.Focus()
    End Sub

    Private Sub btnhuy_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnhuy.Click
        'If Voucher.Action = 1 Then
        '    Voucher.Mdatatable.Rows.Remove(Voucher.CurrentVoucher)
        'End If
        isloaded = False
    End Sub


    Private Sub cbbma_nt_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbbma_nt.SelectedValueChanged
        If isloaded = False Then
            Exit Sub
        End If
        Try
            TabControl1.SelectedTab = TabControl1.TabPages(0)
            If cbbma_nt.SelectedItem IsNot Nothing Then
                Dim dvr As DataRowView = cbbma_nt.SelectedItem

                Txtty_gia.Value = Clsql.SQL.newInstance.GetValue("exec getty_gia " & Clsql.SQL.newInstance.ConvertToSQLType(cbbma_nt.SelectedValue.trim) & "," & Clsql.SQL.newInstance.ConvertToSQLType(Txtngay_ct.Value))
                hide_show_control(dvr("ma_nt"))
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub cbbma_gd_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbbma_gd.SelectedValueChanged
        If isloaded Then
            Try
                If cbbma_gd.SelectedValue = 1 Then

                    voucher.Tabdetails("vtdttco").status = True
                    voucher.Tabdetails("vdpc1").status = False
                    voucher.Tabdetails("vvatvao").status = False


                    btngethoadon.Visible = True
                Else
                    voucher.Tabdetails("vtdttco").status = False
                    voucher.Tabdetails("vdpc1").status = True
                    voucher.Tabdetails("vvatvao").status = True
                    btngethoadon.Visible = False
                End If
                voucher.CreateFormKeyIn(True)
                hide_show_control(cbbma_nt.SelectedValue)
            Catch ex As Exception

            End Try
        End If

    End Sub
    Private Sub btnsodu_Click(sender As Object, e As EventArgs) Handles btnsodu.Click
        If _parent.Voucherid.ToUpper = "PC1" Then
            Dim p As Process = Process.Start(Application.StartupPath & "\rptvcdetail.exe", "rsodutaiquy ""1," & Clsql.SQL.newInstance.ConvertToSQLType(Clsql.SQL.newInstance.Server.GetDate) & ",'','111'""")
        Else
            If _parent.Voucherid.ToUpper = "BN1" Then
                Dim p As Process = Process.Start(Application.StartupPath & "\rptvcdetail.exe", "rsodutaiquy ""1," & Clsql.SQL.newInstance.ConvertToSQLType(Clsql.SQL.newInstance.Server.GetDate) & ",'','112'""")
            Else
                Dim p As Process = Process.Start(Application.StartupPath & "\rptvcdetail.exe", "rsodutaiquy ""1," & Clsql.SQL.newInstance.ConvertToSQLType(Clsql.SQL.newInstance.Server.GetDate) & ",'','11'""")
            End If
        End If
    End Sub

    'Dim ma_khold As String
    'Private Sub txtma_kh_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtma_kh.Enter, cbbma_gd.Enter
    '    ma_khold = txtma_kh.Text.Trim
    '    cbbma_gd.Enabled = True
    '    txtma_kh.ReadOnly = False
    '    If Voucher.Tabdetails("vtdttco").status = True Then
    '        For Each r As DataGridViewRow In Voucher.Tabdetails("vtdttco").gridDetailKeyin.Rows
    '            If Not r.IsNewRow Then
    '                If r.Cells("stt_rec_tt").Value <> "" Then
    '                    txtma_kh.ReadOnly = True
    '                    cbbma_gd.Enabled = False
    '                    Exit For
    '                End If
    '            End If
    '        Next
    '    End If

    'End Sub

    'Private Sub txtma_kh_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtma_kh.Validated
    '    If ma_khold.ToUpper <> txtma_kh.Text.Trim.ToUpper Then
    '        ma_khold = txtma_kh.Text
    '        If cbbma_gd.SelectedValue = 1 Then
    '            'Tabdetailhd.Datatable = clsql.sql.newInstance.GetDatatable("Exec GetInvoice4Paid " & clsql.sql.newInstance.ConvertToSQLType(txtma_kh.Text) & "," & clsql.sql.newInstance.ConvertToSQLType(Txtngay_ct.Value) & "," & Voucher.Action)
    '            '   Tabdetailhd.bindingsource.DataSource = Tabdetailhd.Datatable
    '            '  Txtt_tien_nt.Value = ClsControl2.PropertyOfGrid.Sum(grddetailhd, "tien_nt")
    '            ' Txtt_tien.Value = ClsControl2.PropertyOfGrid.Sum(grddetailhd, "tien")
    '            'txtt_tt.Value = Txtt_tien.Value
    '            'txtt_tt_nt.Value = Txtt_tien_nt.Value
    '        End If
    '    End If

    'End Sub

    Sub hide_show_control(ByVal ma_nt As String)

        Ltienthue.Visible = True
        Ltongthanhtoan.Visible = True
        txtt_thue.Visible = True
        txtt_thue_nt.Visible = True
        txtt_tt_nt.Visible = True
        txtt_tt.Visible = True
        For Each t As ClsSV31.TabDetail20 In voucher.Tabdetails.Values
            t.ma_nt = ma_nt
        Next
        If ma_nt.Trim.ToUpper = dtht.Trim.ToUpper Then
            voucher.Tabdetails("vdpc1").gridDetailKeyin.Columns("ty_gia_gs_co").Visible = False
            voucher.Tabdetails("vdpc1").gridDetailKeyin.Columns("ty_gia_gs_no").Visible = False
            Txtty_gia.ReadOnly = True
            Txtt_tien.Visible = False
            txtt_thue.Visible = False
            txtt_tt.Visible = False
            chbtg_gs_dd_yn.Hide()
            '
            Txtt_tien_nt.NumberDecimalDigits = Clsql.Others.Options("f_tien", Clsql.SQL.newInstance)
            txtt_thue_nt.NumberDecimalDigits = Clsql.Others.Options("f_tien", Clsql.SQL.newInstance)
            txtt_tt_nt.NumberDecimalDigits = Clsql.Others.Options("f_tien", Clsql.SQL.newInstance)
        Else
            voucher.Tabdetails("vdpc1").gridDetailKeyin.Columns("ty_gia_gs_co").Visible = True
            voucher.Tabdetails("vdpc1").gridDetailKeyin.Columns("ty_gia_gs_no").Visible = True
            Txtty_gia.ReadOnly = False
            Txtt_tien.Visible = True
            txtt_thue.Visible = True
            txtt_tt.Visible = True
            chbtg_gs_dd_yn.Show()
            '
            Txtt_tien_nt.NumberDecimalDigits = Clsql.Others.Options("f_tien_nt", Clsql.SQL.newInstance)
            txtt_thue_nt.NumberDecimalDigits = Clsql.Others.Options("f_tien_nt", Clsql.SQL.newInstance)
            txtt_tt_nt.NumberDecimalDigits = Clsql.Others.Options("f_tien_nt", Clsql.SQL.newInstance)
            tinh_tong_tien()
        End If

        If cbbma_gd.SelectedValue = 1 Then
            Ltienthue.Visible = False
            Ltongthanhtoan.Visible = False
            txtt_thue.Visible = False
            txtt_thue_nt.Visible = False
            txtt_tt_nt.Visible = False
            txtt_tt.Visible = False
        End If
    End Sub

    Private Sub lay_hoa_don_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btngethoadon.Click
        Dim filter As New frmFilterHD
        filter.Icon = Me.Icon
        filter.Txttu_ngay.Value = DateSerial(Txtngay_ct.Value.Year, 1, 1)
        filter.Txtden_ngay.Value = Txtngay_ct.Value
        filter.txtma_kh.Text = txtma_kh.Text
        filter.StartPosition = FormStartPosition.CenterParent
        If filter.ShowDialog(Me) = DialogResult.OK Then
            Dim layhd As GetDataByStore = New GetDataByStore(conn, "dpc1_ghd", "CTHD")
            AddHandler layhd.BeforeShow, AddressOf BeforeShowInvoide

            If layhd.Show("Exec GetInvoice4Paid_multi " & Clsql.SQL.newInstance.ConvertToSQLType(filter.txtma_kh.Text) & "," & Clsql.SQL.newInstance.ConvertToSQLType(filter.txtso_hd.Text) & "," & Clsql.SQL.newInstance.ConvertToSQLType(filter.txtso_ct.Text) & "," & Clsql.SQL.newInstance.ConvertToSQLType(filter.Txttu_ngay.Value) & "," & Clsql.SQL.newInstance.ConvertToSQLType(filter.Txtden_ngay.Value) & "," & voucher.Action & ",'" & voucher.Stt_rec & "'") = Windows.Forms.DialogResult.OK Then



                voucher.Tabdetails("vtdttco").Datatable.Clear()
                For Each r As DataRow In layhd.DataView.Table.Select("sel = false")
                    r.Delete()
                Next
                voucher.Tabdetails("vtdttco").Datatable = layhd.DataView.Table
                voucher.Tabdetails("vtdttco").bindingsource.DataSource = voucher.Tabdetails("vtdttco").Datatable

                'set gia tri mac dinh
                For Each r As DataRow In voucher.Tabdetails("vtdttco").Datatable.Rows
                    For Each df As String In voucher.Tabdetails("vtdttco").ProcessOnGrid.DefaultOnGrids.Keys
                        If r.Table.Columns.Contains(df) AndAlso String.IsNullOrEmpty(r(df)) Then
                            If voucher.Tabdetails("vtdttco").Datatable.Columns(df).DataType.ToString.Contains("Boolean") Then
                                If voucher.Tabdetails("vtdttco").ProcessOnGrid.DefaultOnGrids.Item(df) = "1" Then
                                    r(df) = True
                                Else
                                    r(df) = False
                                End If
                            Else
                                r(df) = voucher.Tabdetails("vtdttco").ProcessOnGrid.DefaultOnGrids.Item(df)
                            End If
                        End If
                    Next
                Next


            End If
            SendKeys.Send("{tab}")
        End If

    End Sub




    Private Sub chbtg_gs_dd_yn_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chbtg_gs_dd_yn.CheckedChanged
        'grddetail.Columns("ty_gia_gs_co").Visible = chbtg_gs_dd_yn.Checked
        'grddetailhd.Columns("ty_gia_gs_co").Visible = chbtg_gs_dd_yn.Checked
        'grdvat.Columns("ty_gia_gs_co").Visible = chbtg_gs_dd_yn.Checked


    End Sub


End Class