Imports ClsLookup

Public Class frminput
    Dim isloaded As Boolean = False
    Dim t_tien, t_tien_nt As Double
    Dim _parent As Frmmain, voucher As ClsSV31.Voucher20
    Public Sub setParent(v As Frmmain)
        _parent = v
        voucher = v.Voucher
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
        For Each dvtab As ClsSV31.TabDetail20 In _parent.Voucher.Tabdetails.Values
            RemoveHandler dvtab.AfterCalcOnCell, AddressOf tinh_tong_tien
        Next
        RemoveHandler _parent.Voucher.Tabdetails("tdttno").gridDetailKeyin.CellBeginEdit, AddressOf grddetailhd_CellBeginEdit

    End Sub

    Private Sub frminput_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        For Each dvtab As ClsSV31.TabDetail20 In _parent.Voucher.Tabdetails.Values
            AddHandler dvtab.AfterCalcOnCell, AddressOf tinh_tong_tien
        Next
        AddHandler _parent.Voucher.Tabdetails("tdttno").gridDetailKeyin.CellBeginEdit, AddressOf grddetailhd_CellBeginEdit

    End Sub
    Private Sub frminput_show(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        Dim dvr As DataRowView = cbbma_nt.SelectedItem

        hide_show_control(dvr("ma_nt"))
        isloaded = True
        If _parent.Voucher.Action = ClsSV31.Voucher20.Actions.ADD Then
            Txtty_gia.Value = conn.GetValue("exec getty_gia " & conn.ConvertToSQLType(cbbma_nt.SelectedValue.trim) & "," & conn.ConvertToSQLType(Txtngay_ct.Value))
        End If

        If cbbma_gd.SelectedValue = 1 Then
            _parent.Voucher.Tabdetails("vdpt1").status = False

            _parent.Voucher.Tabdetails("tdttno").status = True

            btngethoadon.Visible = True

        Else
            _parent.Voucher.Tabdetails("vdpt1").status = True

            _parent.Voucher.Tabdetails("tdttno").status = False
            btngethoadon.Visible = False

        End If
        _parent.Voucher.CreateFormKeyIn(True)

    End Sub
#Region "lay ty gia tu dong"
    Dim ngay_ctold As Date
    Private Sub Txtngay_ct_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txtngay_ct.Validated
        If ngay_ctold <> Txtngay_ct.Value Then
            If isloaded Then
                If voucher.Action = ClsSV31.Voucher20.Actions.ADD Then
                    Txtty_gia.Value = conn.GetValue("exec getty_gia " & conn.ConvertToSQLType(cbbma_nt.SelectedValue.trim) & "," & conn.ConvertToSQLType(Txtngay_ct.Value))
                End If
            End If
        End If
    End Sub
    Private Sub Txtngay_ct_endter(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txtngay_ct.Enter
        ngay_ctold = Txtngay_ct.Value
    End Sub
#End Region



    Private Sub grddetailhd_CellBeginEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs)
        _parent.Voucher.Tabdetails("tdttno").gridDetailKeyin.Item("stt_rec", e.RowIndex).Value = _parent.Voucher.Stt_rec
        _parent.Voucher.Tabdetails("tdttno").gridDetailKeyin.Item("ma_ct", e.RowIndex).Value = _parent.Voucherid
        _parent.Voucher.Tabdetails("tdttno").gridDetailKeyin.Item("loai_tt", e.RowIndex).Value = 1

    End Sub

    'form task
    Public formtask As ClsSV31.frmTask
    Private Sub btnLuu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLuu.Click
        If save() = False Then
            Exit Sub
        End If
        If formtask Is Nothing Then
            formtask = New ClsSV31.frmTask
            ClsControl2.PropertyOfForm.SetLable(voucher.oLan, formtask)
            formtask.Icon = Me.Icon
            formtask.btnnew.Enabled = _parent.Voucher.rights.NewRight
            formtask.btnprint.Enabled = _parent.Voucher.rights.PrintRight
        End If
        If cbbma_gd.SelectedValue = 1 Then
            formtask.btncopy.Enabled = False
        Else
            formtask.btncopy.Enabled = True
        End If
        If formtask.btncopy.Enabled = True Then
            formtask.btncopy.Enabled = _parent.Voucher.rights.NewRight
        End If

        formtask.ShowDialog(Me)
        Select Case formtask.task
            Case ClsSV31.frmTask.Tasks.AddNew
                Me.BindingContext(_parent.Voucher.BindingSource).EndCurrentEdit()
                _parent.Voucher.Mdatatable.AcceptChanges()
                _parent.Voucher.News2()
                cbbma_gd.Enabled = True
                txtma_kh.Enabled = True
            Case ClsSV31.frmTask.Tasks.Copy

                _parent.Voucher.Copy()
            Case ClsSV31.frmTask.Tasks.Print
                For Each r As DataRow In _parent.Voucher.Mdatatable.Select("sel=true")
                    r("sel") = False
                Next
                _parent.Voucher.BindingSource.Current("sel") = True
                'printF()
                _parent.getPrint.Print()
                Me.Close()
            Case ClsSV31.frmTask.Tasks.Close
                Me.DialogResult = DialogResult.OK
                Me.Close()
        End Select
    End Sub
    Function save() As Boolean
        'kiem tra so chung tu
        If _parent.Voucher.CheckSoCT(Txtngay_ct.Value, txtso_ct.Text) = False Then
            Return False
            Exit Function
        End If

        'ket thuc nhap lieu
        _parent.Voucher.BindingSource.EndEdit()

        'xoa cac hoa don khong thanh toan
        For Each r As DataRow In _parent.Voucher.Tabdetails("tdttno").Datatable.Select("tien_nt =0")
            r.Delete()
        Next

        'kiem tra da nhap chi tiet chua
        If _parent.Voucher.CheckKeyIn = False Then
            Return False
        End If
        'dien cac gia tri cu m vao d
        _parent.Voucher.SynMD()
        '
        For Each detail As ClsSV31.TabDetail20 In _parent.Voucher.Tabdetails.Values
            detail.bindingsource.DataSource = Nothing
            For Each r As DataRow In detail.Datatable.Rows
                If r.RowState = DataRowState.Deleted Then
                    Continue For
                End If
                If cbbma_gd.SelectedValue <> 1 Then
                    If detail.Datatable.Columns.Contains("ty_gia_gs_co") Then
                        If chbtg_gs_dd_yn.Checked = False Then
                            If r("loai_cl_co") = 1 Then
                                r("ty_gia_gs_co") = 0
                            End If
                        End If
                    End If
                End If
            Next
            detail.bindingsource.DataSource = detail.Datatable
        Next
        '
        _parent.querytt = getQuerytattoan(voucher.Stt_rec)
        If _parent.Voucher.Action = ClsSV31.Voucher20.Actions.ADD Then
            _parent.Voucher.Insert()
        Else
            _parent.Voucher.Update()
        End If

        'post detail trong truong hop thanh toan theo hoa don
        Dim sqltattoan As String = ""
        If _parent.Voucher.Tabdetails("vdpt1").status = False Then
            sqltattoan = conn.GetInsertQueryFromDatatable(_parent.Voucher.Tabdetails("tdttno").Datatable, _parent.Voucher.Tabdetails("vdpt1").TableName)
            conn.Execute(sqltattoan)
            Dim tbdetail As DataTable = conn.GetDatatable("select * from vdpt1 where stt_rec ='" & _parent.Voucher.Stt_rec & "'")
            Clsql.Data.CopyTable(tbdetail, _parent.Voucher.Tabdetails("vdpt1").DatatableView, "1=1", "stt_rec='" & _parent.Voucher.Stt_rec & "'")
            tbdetail.Dispose()
        End If
        'post
        ClsSV31.Functions.Post(conn, _parent.Voucherid, _parent.Voucher.Mviewname, _parent.Voucher.Stt_rec, cbbstatus.SelectedValue)
        '
        _parent.Voucher.refreshMaster()
        Return True
    End Function
    Sub tinh_tong_tien()
        If isloaded = False Then
            Return
        End If
        If _parent.Voucher.Tabdetails("vdpt1").status Then
            t_tien_nt = ClsControl2.PropertyOfGrid.Sum(_parent.Voucher.Tabdetails("vdpt1").gridDetailKeyin, "tien_nt")
            t_tien = ClsControl2.PropertyOfGrid.Sum(_parent.Voucher.Tabdetails("vdpt1").gridDetailKeyin, "tien")

        Else
            t_tien = ClsControl2.PropertyOfGrid.Sum(_parent.Voucher.Tabdetails("tdttno").gridDetailKeyin, "tien")
            t_tien_nt = ClsControl2.PropertyOfGrid.Sum(_parent.Voucher.Tabdetails("tdttno").gridDetailKeyin, "tien_nt")
        End If

        Txtt_tien_nt.Value = t_tien_nt
        Txtt_tien.Value = t_tien
    End Sub

    Private Sub btnluuandmoi_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnluuandmoi.Click
        If save() = False Then
            Exit Sub
        End If
        Me.BindingContext(_parent.Voucher.BindingSource).EndCurrentEdit()
        _parent.Voucher.Mdatatable.AcceptChanges()
        _parent.Voucher.News2()
        Txtty_gia.Value = conn.GetValue("exec getty_gia " & conn.ConvertToSQLType(cbbma_nt.SelectedValue.trim) & "," & conn.ConvertToSQLType(Txtngay_ct.Value))
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

                Txtty_gia.Value = conn.GetValue("exec getty_gia " & conn.ConvertToSQLType(cbbma_nt.SelectedValue.trim) & "," & conn.ConvertToSQLType(Txtngay_ct.Value))
                hide_show_control(dvr("ma_nt"))
            End If

        Catch ex As Exception

        End Try
    End Sub



    Private Sub cbbma_gd_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbbma_gd.SelectedValueChanged

        Try

            If isloaded Then
                If cbbma_gd.SelectedValue = 1 Then
                    _parent.Voucher.Tabdetails("vdpt1").status = False

                    _parent.Voucher.Tabdetails("tdttno").status = True

                    btngethoadon.Visible = True
                    TSDropDownGetdata.Visible = False

                Else
                    _parent.Voucher.Tabdetails("vdpt1").status = True

                    _parent.Voucher.Tabdetails("tdttno").status = False
                    btngethoadon.Visible = False
                    TSDropDownGetdata.Visible = True

                End If
                _parent.Voucher.CreateFormKeyIn(True)
            End If

        Catch ex As Exception

        End Try

    End Sub
    'Dim ma_khold As String
    'Private Sub txtma_kh_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtma_kh.Enter, cbbma_gd.Enter
    '    ma_khold = txtma_kh.Text.Trim
    '    cbbma_gd.Enabled = True
    '    txtma_kh.ReadOnly = False
    '    For Each r As DataGridViewRow In Voucher.Tabdetails("tdttno").gridDetailKeyin.Rows
    '        If Not r.IsNewRow Then
    '            If r.Cells("stt_rec_tt").Value <> "" Then
    '                txtma_kh.ReadOnly = True
    '                cbbma_gd.Enabled = False
    '                Exit For
    '            End If
    '        End If
    '    Next

    'End Sub

    'Private Sub txtma_kh_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtma_kh.Validated
    '    If ma_khold.ToUpper <> txtma_kh.Text.Trim.ToUpper Then
    '        ma_khold = txtma_kh.Text
    '    End If

    'End Sub

    Sub hide_show_control(ByVal ma_nt As String)
        For Each t As ClsSV31.TabDetail20 In _parent.Voucher.Tabdetails.Values
            t.ma_nt = ma_nt
        Next
        If ma_nt.Trim.ToUpper = Clsql.Others.Options("a_dtht", conn) Then

            _parent.Voucher.Tabdetails("vdpt1").gridDetailKeyin.Columns("ty_gia_gs_co").Visible = False

            Txtty_gia.ReadOnly = True
            Txtt_tien.Hide() 'Visible = False
            Ltien.Hide() 'Visible = False
            chbtg_gs_dd_yn.Hide()

            Txtt_tien_nt.NumberDecimalDigits = Clsql.Others.Options("f_tien", conn)

        Else

            _parent.Voucher.Tabdetails("vdpt1").gridDetailKeyin.Columns("ty_gia_gs_co").Visible = True
            Txtty_gia.ReadOnly = False
            Txtt_tien.Show() 'Visible = True
            Ltien.Show() 'Visible = True
            chbtg_gs_dd_yn.Show()

            Txtt_tien_nt.NumberDecimalDigits = Clsql.Others.Options("f_tien_nt", conn)
            tinh_tong_tien()
        End If
    End Sub

    Private Sub btngethoadon_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btngethoadon.Click
        Dim filter As New frmfilterHD
        filter.Txttu_ngay.Value = DateSerial(Txtngay_ct.Value.Year, 1, 1)
        filter.Txtden_ngay.Value = Txtngay_ct.Value
        filter.txtma_kh.Text = txtma_kh.Text
        filter.Icon = Me.Icon
        filter.StartPosition = FormStartPosition.CenterParent
        If filter.ShowDialog(Me) = DialogResult.OK Then
            Dim layhd As New GetDataByStore(conn, "dpt1_ghd", "TTHD")
            AddHandler layhd.BeforeShow, AddressOf BeforeShowInvoide

            If layhd.Show("Exec GetInvoice4Rec_multi " & conn.ConvertToSQLType(filter.txtma_kh.Text) & "," & conn.ConvertToSQLType(filter.txtso_hd.Text) & "," & conn.ConvertToSQLType(filter.txtso_ct.Text) & "," & conn.ConvertToSQLType(filter.Txttu_ngay.Value) & "," & conn.ConvertToSQLType(filter.Txtden_ngay.Value) & "," & voucher.Action & ",'" & voucher.Stt_rec & "'") = Windows.Forms.DialogResult.OK Then

                _parent.Voucher.Tabdetails("tdttno").bindingsource.DataSource = Nothing
                _parent.Voucher.Tabdetails("tdttno").Datatable.Clear()

                'For Each r As DataRow In layhd.DataView.Table.Select("sel = false")
                '    r.Delete()
                'Next
                Clsql.Data.CopyTableSame(layhd.DataView.Table, _parent.Voucher.Tabdetails("tdttno").Datatable, "sel=true")
                'set gia tri mac dinh
                For Each r As DataRow In voucher.Tabdetails("tdttno").Datatable.Rows
                    For Each df As String In voucher.Tabdetails("tdttno").ProcessOnGrid.DefaultOnGrids.Keys
                        If r.Table.Columns.Contains(df) AndAlso String.IsNullOrEmpty(r(df)) Then
                            If voucher.Tabdetails("tdttno").Datatable.Columns(df).DataType.ToString.Contains("Boolean") Then
                                If voucher.Tabdetails("tdttno").ProcessOnGrid.DefaultOnGrids.Item(df) = "1" Then
                                    r(df) = True
                                Else
                                    r(df) = False
                                End If
                            Else
                                r(df) = voucher.Tabdetails("tdttno").ProcessOnGrid.DefaultOnGrids.Item(df)
                            End If
                        End If


                    Next
                Next
                'Voucher.Tabdetails("tdttno").Datatable = layhd.DataView.Table
                voucher.Tabdetails("tdttno").bindingsource.DataSource = voucher.Tabdetails("tdttno").Datatable

                SendKeys.Send("{tab}")
            End If
        End If

    End Sub

    Private Sub btnsodu_Click(sender As Object, e As EventArgs) Handles btnsodu.Click
        If _parent.Voucherid.ToUpper = "PT1" Then
            Dim p As Process = Process.Start(Application.StartupPath & "\rptvcdetail.exe", "rsodutaiquy ""1," & conn.ConvertToSQLType(conn.Server.GetDate) & ",'','111'""")
        Else
            If _parent.Voucherid.ToUpper = "BC1" Then
                Dim p As Process = Process.Start(Application.StartupPath & "\rptvcdetail.exe", "rsodutaiquy ""1," & conn.ConvertToSQLType(conn.Server.GetDate) & ",'','112'""")
            Else
                Dim p As Process = Process.Start(Application.StartupPath & "\rptvcdetail.exe", "rsodutaiquy ""1," & conn.ConvertToSQLType(conn.Server.GetDate) & ",'','11'""")
            End If
        End If
    End Sub

    Private Sub laydulieutuhoadonToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btngetdatafromhd.Click


        Dim layhd As GetDataByStoreMD
        layhd = New GetDataByStoreMD(Voucher.conn, "MHD2_BL", "dpt1", , "xhd")
        Dim fdkloc As New frmdklayhd
        ClsControl2.PropertyOfForm.SetLable(Voucher.oLan, fdkloc)
        fdkloc.Icon = Me.Icon
        fdkloc.StartPosition = FormStartPosition.CenterParent
        If fdkloc.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
            If layhd.Show("Exec GetXHD4PT1 " & conn.ConvertToSQLType(fdkloc.Txttu_ngay.Value) & "," & conn.ConvertToSQLType(fdkloc.TxtDen_ngay.Value) & "," & conn.ConvertToSQLType(txtma_kh.Text) & "," & conn.ConvertToSQLType(Voucher.Stt_rec) & "," & conn.ConvertToSQLType(fdkloc.txtso_hd.Text)) = Windows.Forms.DialogResult.OK Then
                'For Each r As DataRow In layhd.MDataView.Table.Select("sel = false")
                '    For Each r2 As DataRow In layhd.DDataView.Table.Select("stt_rec = '" & r("stt_rec") & "'")
                '        r2.Delete()
                '    Next

                'Next

                'For Each r As DataRow In layhd.DDataView.Table.Select("sel = false")
                '    r.Delete()
                'Next



                _parent.Voucher.Tabdetails(_parent.Voucher.TabFirst).bindingsource.DataSource = Nothing

                Clsql.Data.CopyTable(layhd.DDataView.Table, _parent.Voucher.Tabdetails(_parent.Voucher.TabFirst).Datatable, "sel=true")

                _parent.Voucher.Tabdetails(_parent.Voucher.TabFirst).bindingsource.DataSource = _parent.Voucher.Tabdetails(_parent.Voucher.TabFirst).Datatable
                'lay cac gia tri phan thong tin chung
                For Each r As DataRow In layhd.MDataView.Table.Select("sel = true")
                    _parent.Voucher.CurrentVoucher("ma_kh") = r("ma_kh")
                    _parent.Voucher.CurrentVoucher("ong_ba") = r("ong_ba")

                    txtma_kh.Focus()
                    _parent.Voucher.Tabdetails(_parent.Voucher.TabFirst).gridDetailKeyin.Focus()
                    Exit For
                Next
                tinh_tong_tien()


            End If
        End If
    End Sub
End Class