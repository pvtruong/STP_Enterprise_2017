﻿Imports ClsLookup

Public Class frminput

    Dim isloaded As Boolean = False
    Dim t_tien, t_ck, t_thue, t_tt, t_sl, t_tien_von, t_tien_nt, t_ck_nt, t_thue_nt, t_tt_nt, t_sl_nt, t_tien_von_nt As Double
    Private Sub frminput_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        If isloaded = False Then
            Me.txtso_ct.Focus()
            Me.txtso_ct.SelectionStart = txtso_ct.Text.Length
        End If
    End Sub

    Private Sub frminput_show(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        Dim ma_nt As String = Voucher.CurrentVoucher("ma_nt")
        If ma_nt IsNot Nothing Then
            hide_show_control(ma_nt)
        End If
        isloaded = True
        If Voucher.Action = ClsSV31.Voucher20.Actions.ADD Then
            Txtty_gia.Value = conn.GetValue("exec getty_gia " & conn.ConvertToSQLType(ma_nt) & "," & conn.ConvertToSQLType(Txtngay_ct.Value))
        End If
    End Sub

    Private Sub frminput_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        isloaded = False
        For Each dvtab As ClsSV31.TabDetail20 In Voucher.Tabdetails.Values
            RemoveHandler dvtab.AfterCalcOnCell, AddressOf tinh_tong_tien
        Next
        RemoveHandler Voucher.Tabdetails(Voucher.TabFirst).ProcessOnGrid.RowRemoving, AddressOf row_remove
        RemoveHandler Voucher.Tabdetails("vatra").gridDetailKeyin.CellEndEdit, AddressOf grdvat_CellEndEdit
    End Sub

    Private Sub frminput_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        For Each dvtab As ClsSV31.TabDetail20 In Voucher.Tabdetails.Values
            AddHandler dvtab.AfterCalcOnCell, AddressOf tinh_tong_tien
        Next
        AddHandler Voucher.Tabdetails(Voucher.TabFirst).ProcessOnGrid.RowRemoving, AddressOf row_remove
        AddHandler Voucher.Tabdetails("vatra").gridDetailKeyin.CellEndEdit, AddressOf grdvat_CellEndEdit
    End Sub
#Region "lay ty gia tu dong"
    Dim ngay_ctold As Date
    Private Sub Txtngay_ct_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txtngay_ct.Validated
        If ngay_ctold <> Txtngay_ct.Value Then
            If isloaded Then
                If Voucher.Action = ClsSV31.Voucher20.Actions.ADD Then
                    Txtty_gia.Value = conn.GetValue("exec getty_gia " & conn.ConvertToSQLType(cbbma_nt.SelectedValue.trim) & "," & conn.ConvertToSQLType(Txtngay_ct.Value))
                End If
            End If
        End If
    End Sub
    Private Sub Txtngay_ct_endter(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txtngay_ct.Enter
        ngay_ctold = Txtngay_ct.Value
    End Sub
#End Region

    Private Sub grdvat_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)

        Dim ty_gia As Double = Txtty_gia.Value
        If sender.Rows(e.RowIndex).IsNewRow = False Then
            Select Case sender.Columns(e.ColumnIndex).Name
                Case "ma_hoa_don"
                    If Voucher.Tabdetails(Voucher.TabFirst).gridDetailKeyin.RowCount > 1 Then
                        sender.Item("tk_du", e.RowIndex).Value = Voucher.Tabdetails(Voucher.TabFirst).gridDetailKeyin.Rows(0).Cells("tk_no").Value
                    End If
                Case "so_seri"
                    sender.Item("so_seri", e.RowIndex).Value = sender.Item("so_seri", e.RowIndex).Value.ToString.ToUpper

                    'Case "so_hd"
                    '    sender.Item("so_hd", e.RowIndex).Value = sender.Item("so_hd", e.RowIndex).Value.ToString.ToUpper

                    '    Dim tien As Double = 0
                    '    Dim tien_nt As Double = 0

                    '    For Each r As DataGridViewRow In Voucher.Tabdetails(Voucher.TabFirst).gridDetailKeyin.Rows
                    '        If Not r.IsNewRow Then
                    '            If r.Cells("so_hd").Value.ToString.Trim.ToLower = sender.Item("so_hd", e.RowIndex).Value.ToString.Trim.ToLower Then
                    '                tien = tien + r.Cells("tien").Value
                    '                tien_nt = tien_nt + r.Cells("tien_nt").Value
                    '                sender.Item("t_tien", e.RowIndex).Value = tien
                    '                sender.Item("t_tien_nt", e.RowIndex).Value = tien_nt
                    '                sender.Item("t_thue_nt", e.RowIndex).Value = tien_nt * sender.Item("thue_suat", e.RowIndex).Value / 100
                    '                sender.Item("t_thue", e.RowIndex).Value = tien * sender.Item("thue_suat", e.RowIndex).Value / 100
                    '                sender.Item("tk_du", e.RowIndex).Value = r.Cells("tk_no").Value
                    '            End If
                    '        End If
                    '    Next
                    '    tien = Nothing
                    '    tien_nt = Nothing
                    '    tinh_tong_tien()

            End Select
        End If
    End Sub
    Public formtask As ClsSV31.frmTask
    Private Sub btnLuu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLuu.Click
        If save() = False Then
            Exit Sub
        End If
        If formtask Is Nothing Then
            formtask = New ClsSV31.frmTask
            ClsControl2.PropertyOfForm.SetLable(Voucher.oLan, formtask)
            formtask.Icon = Me.Icon

            formtask.TD1.Visible = True
            formtask.TD1.Text = "Thu tiền"
            formtask.btnnew.Enabled = Voucher.rights.NewRight
            If formtask.btncopy.Enabled = True Then
                formtask.btncopy.Enabled = Voucher.rights.NewRight
            End If
            formtask.btnprint.Enabled = Voucher.rights.PrintRight
        End If

        formtask.ShowDialog(Me)
        Select Case formtask.task
            Case ClsSV31.frmTask.Tasks.AddNew
                Me.BindingContext(Voucher.BindingSource).EndCurrentEdit()
                Voucher.Mdatatable.AcceptChanges()
                Voucher.News2()
            Case ClsSV31.frmTask.Tasks.Copy
                Voucher.Copy()
            Case ClsSV31.frmTask.Tasks.TD1
                Dim f As New frmThuTien
                f.Icon = Me.Icon
                f.Text = formtask.TD1.Text
                f.StartPosition = FormStartPosition.CenterParent
                f.txtma_kh.Text = txtma_kh.Text
                f.ten_kh.Text = txtten_kh.Text
                f.txttien_hd.Value = Voucher.CurrentVoucher.Item("t_tt")
                f.txtma_nt.Text = cbbma_nt.SelectedValue
                f.txtty_gia.Value = Txtty_gia.Value
                Dim dtpc As DataTable = conn.GetDatatable("select * from mpt1 where stt_rec_goc_hd ='" & Voucher.Stt_rec & "'")
                If dtpc.Rows.Count > 0 Then
                    f.txtty_gia.Value = dtpc.Rows(0).Item("ty_gia")
                    f.txtma_nt.Text = dtpc.Rows(0).Item("ma_nt")
                    f.txttien_nt.Value = conn.GetValue("select sum(tien_nt) from dpt1 where stt_rec='" & dtpc.Rows(0).Item("stt_rec") & "'")
                    f.txttien.Value = conn.GetValue("select sum(tien) from dpt1 where stt_rec='" & dtpc.Rows(0).Item("stt_rec") & "'")
                End If
                
                If f.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
                    Dim query As String
                    Dim query_tt As String = ""
                    'xoa phieu thu cu
                    If dtpc.Rows.Count > 0 Then
                        Dim stt_rec_pc As String = dtpc.Rows(0).Item("stt_rec")
                        query = "delete from dpt1 where stt_rec='" & stt_rec_pc & "'"
                        query = query & ChrW(13) & "GO" & ChrW(13) & "delete from mpt1 where stt_rec='" & stt_rec_pc & "'"
                        conn.ExecuteWithMultiQuery(query)
                        'xoa post
                        ClsSV31.Functions.deletePost(conn, dtpc.Rows(0).Item("ma_ct"), dtpc.Rows(0))
                    End If
                    'tao phieu chi
                    query = "select * from mpt1 where 1=0"
                    query = query & ChrW(13) & "select * from dpt1 where 1=0"
                    Dim dspc As DataSet = conn.GetDataSet(query)
                    'get new stt_rec pt
                    Dim stt_rec_pt As String = conn.GetValue("select dbo.getnewsttrec('PT1')")
                    conn.Execute("update Dmct set stt_rec_ht = right('" & stt_rec_pt & "',9)  where ma_ct = 'PT1'")
                    'create master
                    Clsql.Data.CopyTable(Voucher.Mdatatable, dspc.Tables(0), "stt_rec='" & Voucher.Stt_rec & "'")
                    dspc.Tables(0).Rows(0).Item("ma_ct") = "PT1"
                    dspc.Tables(0).Rows(0).Item("ma_gd") = 0
                    dspc.Tables(0).Rows(0).Item("stt_rec") = stt_rec_pt
                    dspc.Tables(0).Rows(0).Item("ma_nt") = f.txtma_nt.Text
                    dspc.Tables(0).Rows(0).Item("ty_gia") = f.txtty_gia.Value
                    dspc.Tables(0).Rows(0).Item("stt_rec_goc_hd") = Voucher.Stt_rec
                    'create detail
                    Clsql.Data.CopyTable(dspc.Tables(0), dspc.Tables(1))
                    dspc.Tables(1).Rows(0).Item("ma_nvu") = f.txtma_nvu.Text
                    dspc.Tables(1).Rows(0).Item("tien_nt") = f.txttien_nt.Value
                    dspc.Tables(1).Rows(0).Item("tien") = f.txttien.Value
                    Dim nghvu As DataTable = conn.GetDatatable("select * from dmnvu where ma_nvu='" & f.txtma_nvu.Text & "'")
                    dspc.Tables(1).Rows(0).Item("tk_no") = nghvu.Rows(0).Item("tk_no")
                    dspc.Tables(1).Rows(0).Item("tk_co") = nghvu.Rows(0).Item("tk_co")
                    'create tdttno
                    Dim rowtdttno As DataRow = Nothing
                    If f.chbttthd.Checked Then
                        query = "Exec GetInvoice4Rec "
                        query = query & conn.ConvertToSQLType(Me.txtma_kh.Text)
                        query = query & "," & conn.ConvertToSQLType(Me.Txtngay_ct.Value)
                        If Voucher.Action = ClsSV31.Voucher20.Actions.ADD Then
                            query = query & ",1"
                        Else
                            query = query & ",2"
                        End If
                        query = query & "," & conn.ConvertToSQLType(Voucher.Stt_rec)
                        Dim tdttno As DataTable = conn.GetDatatable(query)

                        For Each r As DataRow In tdttno.Rows
                            If r.Item("stt_rec").ToString.Substring(0, 1) & r.Item("ma_ct").ToString & r.Item("stt_rec").ToString.Substring(4) = Voucher.Stt_rec Then
                                r.Item("stt_rec") = stt_rec_pt
                                r.Item("ma_ct") = "PT1"
                                r.Item("loai_tt") = "1"
                                r.Item("ngay_ct") = Me.Txtngay_ct.Value
                                r.Item("so_ct") = Me.txtso_ct.Text
                                r.Item("status") = Me.cbbstatus.SelectedValue
                                r.Item("tk_no") = nghvu.Rows(0).Item("tk_no")
                                r.Item("ma_nvu") = f.txtma_nvu.Text
                                dspc.Tables(1).Rows(0).Item("tk_co") = r.Item("tk_co")
                                dspc.Tables(0).Rows(0).Item("ma_gd") = 1
                                r.Item("ma_nt") = f.txtma_nt.Text
                                r.Item("ty_gia") = f.txtty_gia.Value
                                r.Item("tien_nt") = f.txttien_nt.Value
                                r.Item("tien") = f.txttien.Value
                                r.Item("tt_qd") = f.txttien.Value / r.Item("ty_gia_tt")
                                rowtdttno = r
                                If r.Item("tt_qd") >= r.Item("con_lai_nt") Then
                                    query_tt = "EXEC Tatoanno " & conn.ConvertToSQLType(r.Item("stt_rec_tt")) & "," & "'" & r.Item("ma_ct_tt") & "'"
                                End If

                                Exit For
                            End If
                        Next
                    End If
                    'run
                    query = conn.GetInsertQueryFromDatatable(dspc.Tables(0), "mpt1")
                    query = query & ChrW(13) & "GO" & conn.GetInsertQueryFromDatatable(dspc.Tables(1), "dpt1")
                    If rowtdttno IsNot Nothing Then
                        query = query & ChrW(13) & "GO" & conn.GetInsertQueryFromDataRow(rowtdttno, "tdttno")
                    End If
                    conn.ExecuteWithMultiQuery(query)
                    'post phieu chi
                    ClsSV31.Functions.Post(conn, dspc.Tables(0).Rows(0).Item("ma_ct"), "vmpt1", dspc.Tables(0).Rows(0).Item("stt_rec"), cbbstatus.SelectedValue)
                    'tat toan
                    If query_tt <> "" Then
                        conn.Execute(query_tt)
                    End If
                End If
                Me.Close()
            Case ClsSV31.frmTask.Tasks.Print
                For Each r As DataRow In Voucher.Mdatatable.Select("sel=true")
                    r("sel") = False
                Next
                Voucher.BindingSource.Current("sel") = True
                getPrint().Print()
                Me.Close()
            Case ClsSV31.frmTask.Tasks.Close
                Me.DialogResult = DialogResult.OK
                Me.Close()
        End Select
    End Sub
    Function save() As Boolean
        Voucher.BindingSource.EndEdit()
        'kiem tra so chung tu
        If Voucher.CheckSoCT(Txtngay_ct.Value, txtso_ct.Text) = False Then
            Return False
        End If
        'kiem tra trung so hoa don
        If Voucher.Action = ClsSV31.Voucher20.Actions.ADD AndAlso txtso_hd.Text.Trim <> "" Then
            Dim query_check As String = "select 1 from vatra where so_hd ='" & txtso_hd.Text & "'"
            If conn.GetDatatable(query_check).Rows.Count > 0 Then
                If MsgBox("Số hóa đơn này đã tồn tại, bạn có muốn tiếp tục lưu không", MsgBoxStyle.YesNo, Clsql.AboutMe.Name) = MsgBoxResult.No Then
                    txtso_hd.Focus()
                    Return False
                End If
                
            End If
        End If
        If conn.GetValue("if  exists(select stt_rec from tdttno where status = 5 and stt_rec_tt='" & Voucher.Stt_rec & "') select 0 else select 1 ") = False Then
            MsgBox(Voucher.oLan("417"), MsgBoxStyle.Exclamation, Text)
            Return False
        End If
        'kiem tra nhap lieu
        If Voucher.CheckKeyIn = False Then
            Return False
        End If
        'kiem tra han muc no
        If Clsql.Others.Options("td_cn_vdm", conn) = "1" Then
            Dim tk_dm As String = conn.GetValue("select tk_cn from dkh where ma_kh='" & txtma_kh.Text & "'")
            If tk_dm.Trim <> "" Then
                Voucher.Tabdetails(Voucher.TabFirst).Datatable.AcceptChanges()
                Dim ps_no As Double = 0
                Dim ps_no_nt As Double = 0
                For Each r As DataRow In Voucher.Tabdetails(Voucher.TabFirst).Datatable.Select("tk_no ='" & tk_dm.Trim & "'")
                    ps_no = ps_no + r("tien") - r("tien_ck") + r("tien_thue")
                    ps_no_nt = ps_no_nt + r("tien_nt") - r("tien_ck_nt") + r("tien_thue_nt")
                Next

                If Voucher.Action = ClsSV31.Voucher20.Actions.EDIT Then
                    ps_no = ps_no - conn.GetValue("select ps_no from vsocai where stt_rec ='" & Voucher.Stt_rec & "' and tk ='" & tk_dm & "'")
                    ps_no_nt = ps_no_nt - conn.GetValue("select ps_no_nt from vsocai where stt_rec ='" & Voucher.Stt_rec & "' and tk ='" & tk_dm & "'")
                End If
                If ps_no > 0 Then
                    Dim vuot As Double = conn.GetValue("exec check_vuot_dinh_muc_no " & conn.ConvertToSQLType(txtma_kh.Text) _
                                     & "," & conn.ConvertToSQLType(Txtngay_ct.Value) _
                                    & "," & ps_no & "," & ps_no_nt)
                    If vuot > 0 Then
                        If MsgBox(Voucher.oLan("207").Replace("%t", Strings.FormatNumber(vuot)).Replace("%k", txtma_kh.Text), MsgBoxStyle.YesNo, Clsql.AboutMe.Name) <> MsgBoxResult.Yes Then
                            Return False
                        End If

                    End If
                End If
            End If

        End If
        'dien cac gia tri cu m vao d
        Voucher.SynMD()
        If Voucher.Action = 1 Then
            Voucher.Insert()
        Else
            Voucher.Update()
        End If
        'post
        ClsSV31.Functions.Post(conn, Voucherid, Voucher.Mviewname, Voucher.Stt_rec, cbbstatus.SelectedValue)
        '
        Dim query As String = ""
        'xoa phieu thu cu
        Dim dtpc As DataTable = conn.GetDatatable("select * from mpt1 where stt_rec_goc ='" & Voucher.Stt_rec & "'")
        If dtpc.Rows.Count > 0 Then
            Dim stt_rec_pc As String = dtpc.Rows(0).Item("stt_rec")
            query = "delete from dpt1 where stt_rec='" & stt_rec_pc & "'"
            query = query & ChrW(13) & "GO" & ChrW(13) & "delete from mpt1 where stt_rec='" & stt_rec_pc & "'"
            conn.ExecuteWithMultiQuery(query)
            'xoa post
            ClsSV31.Functions.deletePost(conn, dtpc.Rows(0).Item("ma_ct"), dtpc.Rows(0))
        End If

        'tu tao phieu thu
        query = "exec CreatePTFromHD2 '" & Voucher.Stt_rec & "'"
        Dim dspc As DataSet = conn.GetDataSet(query)
        If dspc.Tables(0).Rows.Count > 0 Then
            query = conn.GetInsertQueryFromDatatable(dspc.Tables(0), "mpt1")
            query = query & ChrW(13) & "GO" & conn.GetInsertQueryFromDatatable(dspc.Tables(1), "dpt1")
            conn.ExecuteWithMultiQuery(query)
            'post phieu chi
            ClsSV31.Functions.Post(conn, dspc.Tables(0).Rows(0).Item("ma_ct"), "vmpt1", dspc.Tables(0).Rows(0).Item("stt_rec"), cbbstatus.SelectedValue)
        End If
        Return True
    End Function

    Public Sub tinh_tong_tien()
        If isloaded = False Then
            Return
        End If

        t_tien_nt = ClsControl2.PropertyOfGrid.Sum(Voucher.Tabdetails(Voucher.TabFirst).gridDetailKeyin, "tien_nt")
        t_tien = ClsControl2.PropertyOfGrid.Sum(Voucher.Tabdetails(Voucher.TabFirst).gridDetailKeyin, "tien")
        t_ck_nt = ClsControl2.PropertyOfGrid.Sum(Voucher.Tabdetails(Voucher.TabFirst).gridDetailKeyin, "tien_ck_nt")
        t_ck = ClsControl2.PropertyOfGrid.Sum(Voucher.Tabdetails(Voucher.TabFirst).gridDetailKeyin, "tien_ck")
        t_thue_nt = ClsControl2.PropertyOfGrid.Sum(Voucher.Tabdetails("vatra").gridDetailKeyin, "t_thue_nt")
        t_thue = ClsControl2.PropertyOfGrid.Sum(Voucher.Tabdetails("vatra").gridDetailKeyin, "t_thue")

        t_sl = ClsControl2.PropertyOfGrid.Sum(Voucher.Tabdetails(Voucher.TabFirst).gridDetailKeyin, "sl_xuat")
        t_tien_von = ClsControl2.PropertyOfGrid.Sum(Voucher.Tabdetails(Voucher.TabFirst).gridDetailKeyin, "tien_xuat")


        t_tt_nt = t_tien_nt - t_ck_nt + t_thue_nt
        t_tt = t_tien - t_ck + t_thue


        Txtt_tien_nt.Value = t_tien_nt
        Txtt_tien.Value = t_tien

        Txtt_ck_nt.Value = t_ck_nt
        Txtt_ck.Value = t_ck

        txtt_thue_nt.Value = t_thue_nt
        txtt_thue.Value = t_thue

        txtt_tt_nt.Value = t_tt_nt
        txtt_tt.Value = t_tt

        Txtt_sl.Value = t_sl
        Txtt_tien_von.Value = t_tien_von
    End Sub

    Private Sub LấyDữLiệuTừPhiếuXuấtHàngToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LấyDữLiệuTừPhiếuXuấtHàngToolStripMenuItem.Click
        Dim layhd As GetDataByStoreMD
        layhd = New GetDataByStoreMD(Voucher.conn, "mpxh", "dpxh_get4hd2", , "GetPXH")
        Dim fdkloc As New frmdklayhd
        ClsControl2.PropertyOfForm.SetLable(Voucher.oLan, fdkloc)
        fdkloc.Icon = Me.Icon
        fdkloc.StartPosition = FormStartPosition.CenterParent
        If fdkloc.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
            If layhd.Show("Exec GetPXH4HD2 " & conn.ConvertToSQLType(fdkloc.Txttu_ngay.Value) & "," & conn.ConvertToSQLType(fdkloc.TxtDen_ngay.Value) & "," & conn.ConvertToSQLType(Voucher.Stt_rec) & "," & conn.ConvertToSQLType(fdkloc.txtma_nvu.Text)) = Windows.Forms.DialogResult.OK Then
                For Each r As DataRow In layhd.MDataView.Table.Select("sel = false")
                    For Each r2 As DataRow In layhd.DDataView.Table.Select("stt_rec = '" & r("stt_rec") & "'")
                        r2.Delete()
                    Next

                Next
                For Each r As DataRow In layhd.DDataView.Table.Select("sel = false")
                    r.Delete()
                Next
                Voucher.Tabdetails(Voucher.TabFirst).bindingsource.DataSource = Nothing
                Clsql.Data.CopyTable(layhd.DDataView.Table, Voucher.Tabdetails(Voucher.TabFirst).Datatable)
                Voucher.Tabdetails(Voucher.TabFirst).bindingsource.DataSource = Voucher.Tabdetails(Voucher.TabFirst).Datatable
                'lay cac gia tri phan thong tin chung
                For Each r As DataRow In layhd.MDataView.Table.Select("sel = true")
                    Voucher.CurrentVoucher("ma_kh") = r("ma_kh")
                    Voucher.CurrentVoucher("ong_ba") = r("ong_ba")
                    txtma_kh.Focus()
                    Voucher.Tabdetails(Voucher.TabFirst).gridDetailKeyin.Focus()
                    Exit For
                Next
                tinh_tong_tien()
            End If
        End If
    End Sub

    Private Sub btnluuandmoi_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnluuandmoi.Click
        If save() = False Then
            Exit Sub
        End If
        Me.BindingContext(Voucher.BindingSource).EndCurrentEdit()
        Voucher.Mdatatable.AcceptChanges()
        Voucher.News2()
        Txtty_gia.Value = conn.GetValue("exec getty_gia " & conn.ConvertToSQLType(cbbma_nt.SelectedValue.trim) & "," & conn.ConvertToSQLType(Txtngay_ct.Value))
        txtso_ct.Focus()
    End Sub

    Private Sub cbbma_nt_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbbma_nt.SelectedValueChanged
        If isloaded = False Then
            Exit Sub
        End If
        Try
            If cbbma_nt.SelectedItem IsNot Nothing Then
                Dim dvr As DataRowView = cbbma_nt.SelectedItem
                Txtty_gia.Value = conn.GetValue("exec getty_gia " & conn.ConvertToSQLType(cbbma_nt.SelectedValue.trim) & "," & conn.ConvertToSQLType(Txtngay_ct.Value))
                hide_show_control(dvr("ma_nt"))
            End If

        Catch ex As Exception

        End Try
    End Sub

  
    Sub hide_show_control(ByVal ma_nt As String)
        For Each t As ClsSV31.TabDetail20 In Voucher.Tabdetails.Values
            t.ma_nt = ma_nt
        Next
        If ma_nt.Trim.ToUpper = ma_nt_ht.Trim.ToUpper Then
            '-0--
            Txtty_gia.ReadOnly = True
            Txtt_tien.Hide() 'Visible = False
            Txtt_ck.Hide() 'Visible = False
            txtt_thue.Hide() 'Visible = False
            txtt_tt.Hide() 'Visible = False

            Txtt_tien_nt.NumberDecimalDigits = Clsql.Others.Options("f_tien", conn)
            Txtt_ck_nt.NumberDecimalDigits = Clsql.Others.Options("f_tien", conn)
            txtt_thue_nt.NumberDecimalDigits = Clsql.Others.Options("f_tien", conn)
            txtt_tt_nt.NumberDecimalDigits = Clsql.Others.Options("f_tien", conn)

        Else
            '-0--
            Txtty_gia.ReadOnly = False
            Txtt_tien.Show() 'Visible = True
            Txtt_ck.Show() 'Visible = True
            txtt_thue.Show() 'Visible = True
            txtt_tt.Show() 'Visible = True

            Txtt_tien_nt.NumberDecimalDigits = Clsql.Others.Options("f_tien_nt", conn)
            Txtt_ck_nt.NumberDecimalDigits = Clsql.Others.Options("f_tien_nt", conn)
            txtt_thue_nt.NumberDecimalDigits = Clsql.Others.Options("f_tien_nt", conn)
            txtt_tt_nt.NumberDecimalDigits = Clsql.Others.Options("f_tien_nt", conn)
            tinh_tong_tien()
        End If
    End Sub



    Private Sub btnlaydulieutudonhang_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnlaydulieutudonhang.Click
        Dim layhd As GetDataByStoreMD
        layhd = New GetDataByStoreMD(Voucher.conn, "mSO1", "dSO1_get4HD2", , "GetSO1")
        Dim fdkloc As New frmdklayhd
        ClsControl2.PropertyOfForm.SetLable(Voucher.oLan, fdkloc)
        fdkloc.Icon = Me.Icon
        fdkloc.StartPosition = FormStartPosition.CenterParent
        If fdkloc.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
            If layhd.Show("Exec GetSO14HD2 " & conn.ConvertToSQLType(fdkloc.Txttu_ngay.Value) & "," & conn.ConvertToSQLType(fdkloc.TxtDen_ngay.Value) & "," & conn.ConvertToSQLType(Voucher.Stt_rec) & "," & conn.ConvertToSQLType(fdkloc.txtma_nvu.Text) & "," & conn.ConvertToSQLType(fdkloc.txtma_kho.Text)) = Windows.Forms.DialogResult.OK Then
                For Each r As DataRow In layhd.MDataView.Table.Select("sel = false")
                    For Each r2 As DataRow In layhd.DDataView.Table.Select("stt_rec = '" & r("stt_rec") & "'")
                        r2.Delete()
                    Next

                Next
                For Each r As DataRow In layhd.DDataView.Table.Select("sel = false")
                    r.Delete()
                Next

                Clsql.Data.CopyTable(layhd.DDataView.Table, Voucher.Tabdetails(Voucher.TabFirst).Datatable)
                'tinh lai tien hang va tien nhap
                For Each r As DataRow In Voucher.Tabdetails(Voucher.TabFirst).Datatable.Rows
                    r("tien") = r("gia_ban") * r("sl_xuat")
                    r("tien_nt") = r("gia_ban_nt") * r("sl_xuat")
                Next
                ' Voucher.chitiet.Datatable = layhd.DDataView.Table
                Voucher.Tabdetails(Voucher.TabFirst).bindingsource.DataSource = Voucher.Tabdetails(Voucher.TabFirst).Datatable
                'lay cac gia tri phan thong tin chung
                For Each r As DataRow In layhd.MDataView.Table.Select("sel = true")
                    Voucher.CurrentVoucher("ma_kh") = r("ma_kh")
                    Voucher.CurrentVoucher("ong_ba") = r("ong_ba")
                    Voucher.CurrentVoucher("ma_nv") = r("ma_nv")
                    Voucher.CurrentVoucher("hinh_thuc_tt") = r("ma_tt")
                    Voucher.CurrentVoucher("han_tt") = r("han_tt")
                    txtma_kh.Focus()
                    Voucher.Tabdetails(Voucher.TabFirst).gridDetailKeyin.Focus()
                    Exit For
                Next
                tinh_tong_tien()


            End If
        End If
    End Sub

    Dim so_hd, so_seri As String, ngay_hd As Date
    Private Sub txtso_hd_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtso_hd.Enter
        so_hd = txtso_hd.Text
    End Sub

    Private Sub txtso_hd_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtso_hd.Validated
        If so_hd <> txtso_hd.Text AndAlso Voucher.Tabdetails("vatra").Datatable.Rows.Count = 1 Then
            Voucher.Tabdetails("vatra").Datatable.Rows(0)("so_hd") = txtso_hd.Text
        End If
    End Sub
    Private Sub txtso_seri_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtso_seri.Enter
        so_seri = txtso_seri.Text
    End Sub

    Private Sub txtso_seri_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtso_seri.Validated
        If so_seri <> txtso_seri.Text AndAlso Voucher.Tabdetails("vatra").Datatable.Rows.Count = 1 Then
            Voucher.Tabdetails("vatra").Datatable.Rows(0)("so_seri") = txtso_seri.Text
        End If
    End Sub
    Private Sub txtngay_hd_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtngay_hd.Enter
        ngay_hd = txtngay_hd.Value
    End Sub

    Private Sub txtngay_hd_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtngay_hd.Validated
        If ngay_hd <> txtngay_hd.Value AndAlso Voucher.Tabdetails("vatra").Datatable.Rows.Count = 1 Then
            Voucher.Tabdetails("vatra").Datatable.Rows(0)("ngay_hd") = txtngay_hd.Value
        End If
    End Sub
End Class