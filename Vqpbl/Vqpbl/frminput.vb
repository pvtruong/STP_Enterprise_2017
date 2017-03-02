Imports ClsLookup

Public Class frminput

    Dim isloaded As Boolean = False
    Dim t_tien, t_ck, t_thue, t_tt, t_sl, t_tien_von, t_tien_nt, t_ck_nt, t_thue_nt, t_tt_nt, t_sl_nt, t_tien_von_nt, t_giam_gia As Double
    Private Sub frminput_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        If isloaded = False Then
            Me.txtso_ct.Focus()
            Me.txtso_ct.SelectionStart = txtso_ct.Text.Length
        End If
    End Sub

    Private Sub frminput_show(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        Dim dvr As DataRowView = cbbma_nt.SelectedItem
        hide_show_control(dvr("ma_nt"))
        isloaded = True
        If Voucher.Action = ClsSV31.Voucher20.Actions.ADD Then
            Txtty_gia.Value = conn.GetValue("exec getty_gia " & conn.ConvertToSQLType(cbbma_nt.SelectedValue.trim) & "," & conn.ConvertToSQLType(Txtngay_ct.Value))
        End If
        'btnluuandmoi.Enabled = False
    End Sub

    Private Sub frminput_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        isloaded = False
        For Each dvtab As ClsSV31.TabDetail20 In Voucher.Tabdetails.Values
            RemoveHandler dvtab.AfterCalcOnCell, AddressOf tinh_tong_tien
        Next
    End Sub

    Private Sub frminput_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        For Each dvtab As ClsSV31.TabDetail20 In Voucher.Tabdetails.Values
            AddHandler dvtab.AfterCalcOnCell, AddressOf tinh_tong_tien
        Next

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

    Private Sub btnLuu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLuu.Click
        If save() = False Then
            Exit Sub
        End If

        formtask.btnnew.Enabled = Voucher.rights.NewRight
        If formtask.btncopy.Enabled = True Then
            formtask.btncopy.Enabled = Voucher.rights.NewRight
        End If
        formtask.btnprint.Enabled = Voucher.rights.PrintRight
        '
        formtask.btnnew.Enabled = False
        formtask.btncopy.Enabled = False
        formtask.ShowDialog(Me)
        Select Case formtask.task
            Case ClsSV31.frmTask.Tasks.AddNew
                Me.BindingContext(Voucher.BindingSource).EndCurrentEdit()
                Voucher.Mdatatable.AcceptChanges()
                Voucher.News2()
            Case ClsSV31.frmTask.Tasks.Copy
                Voucher.Copy()
            Case ClsSV31.frmTask.Tasks.Print
                For Each r As DataRow In Voucher.Mdatatable.Select("sel=true")
                    r("sel") = False
                Next
                Voucher.BindingSource.Current("sel") = True
                oPrint.Print()
                Me.Close()
            Case ClsSV31.frmTask.Tasks.Close
                Me.DialogResult = DialogResult.OK
                Me.Close()
        End Select
    End Sub
    Function save() As Boolean
        Voucher.BindingSource.EndEdit()
        'kiem tra tk chiet khau
        If txtt_tien_ck_hd.Value <> 0 AndAlso txttk_chiet_khau.Text = "" Then
            MsgBox("Tài khoản chiết khấu không được trống",, Clsql.AboutMe.Name)
            txttk_chiet_khau.Focus()
            Return False
        End If
        'kiem tra ma_the giam gia
        Voucher.Tabdetails("vctgiamgia").gridDetailKeyin.EndEdit()
        If Voucher.Tabdetails("vctgiamgia").Datatable.Rows.Count > 0 Then
            For Each r As DataRow In Voucher.Tabdetails("vctgiamgia").Datatable.Rows
                If r.RowState = DataRowState.Deleted Then
                    Continue For
                End If
                Dim ma_the As String = r("ma_the")
                Dim q = From rs As DataRow In Voucher.Tabdetails("vctgiamgia").Datatable.Rows Where rs.RowState <> DataRowState.Deleted AndAlso rs("ma_the") = ma_the
                If q.Count > 1 Then
                    MsgBox("Số thẻ giảm giá " & ma_the & " đã được sử dụng nhiều hơn một lần",, Clsql.AboutMe.Name)
                    TabControl1.SelectedIndex = 1
                    Return False
                End If
            Next
        End If
        'kiem tra so chung tu
        If Voucher.CheckSoCT(Txtngay_ct.Value, txtso_ct.Text) = False Then
            Return False
            Exit Function
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
        Return True
    End Function

    Sub tinh_tong_tien()
        If isloaded = False Then
            Return
        End If
        t_tien = ClsControl2.PropertyOfGrid.Sum(Voucher.Tabdetails(Voucher.TabFirst).gridDetailKeyin, "tien2")
        t_ck = ClsControl2.PropertyOfGrid.Sum(Voucher.Tabdetails(Voucher.TabFirst).gridDetailKeyin, "tien_ck")
        t_thue = ClsControl2.PropertyOfGrid.Sum(Voucher.Tabdetails(Voucher.TabFirst).gridDetailKeyin, "tien_thue")
        t_giam_gia = ClsControl2.PropertyOfGrid.Sum(Voucher.Tabdetails("vctgiamgia").gridDetailKeyin, "menh_gia")

        Dim t_hoa_don As Double = ClsControl2.PropertyOfGrid.Sum(Voucher.Tabdetails(Voucher.TabFirst).gridDetailKeyin, "t_hd")
        txtt_hoa_don.Value = t_hoa_don
        
        t_sl = ClsControl2.PropertyOfGrid.Sum(Voucher.Tabdetails(Voucher.TabFirst).gridDetailKeyin, "sl_xuat")
        t_tien_von = ClsControl2.PropertyOfGrid.Sum(Voucher.Tabdetails(Voucher.TabFirst).gridDetailKeyin, "tien_xuat")


        Txtt_sl.Value = t_sl
        Txtt_tien_von.Value = t_tien_von
        txtt_giam_gia.Value = t_giam_gia

        'If Txtty_le_ck_hd.Value <> 0 Then
        '    tinhchietkhauhoadon()
        'End If

        tinhchietkhauhoadon()

        txtt_phai_thu.Value = t_hoa_don - txtt_giam_gia.Value - txtt_tien_ck_hd.Value
        txtt_tra_lai.Value = txtt_thu.Value - txtt_phai_thu.Value
        If txtt_tra_lai.Value < 0 Then txtt_tra_lai.Value = 0
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

    Private Sub btnhuy_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnhuy.Click
        If Voucher.Action = 1 Then
            Voucher.Mdatatable.Rows.Remove(Voucher.CurrentVoucher)
        End If
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
            
        Else
            '-0--
            Txtty_gia.ReadOnly = False
           
            tinh_tong_tien()
        End If
    End Sub



    Private Sub btnlaydulieutudonhang_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim layhd As GetDataByStoreMD
        layhd = New GetDataByStoreMD(Voucher.conn, "mSO1", "dSO1_get4HD2", , "GetSO1")
        Dim fdkloc As New frmdklayhd
        ClsControl2.PropertyOfForm.SetLable(Voucher.oLan, fdkloc)
        fdkloc.Icon = Me.Icon
        fdkloc.StartPosition = FormStartPosition.CenterParent
        If fdkloc.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
            If layhd.Show("Exec GetSO14HD2 " & conn.ConvertToSQLType(fdkloc.Txttu_ngay.Value) & "," & conn.ConvertToSQLType(fdkloc.TxtDen_ngay.Value) & "," & conn.ConvertToSQLType(Voucher.Stt_rec)) = Windows.Forms.DialogResult.OK Then
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
                    txtma_kh.Focus()
                    Voucher.Tabdetails(Voucher.TabFirst).gridDetailKeyin.Focus()
                    Exit For
                Next
                tinh_tong_tien()


            End If
        End If
    End Sub

    Dim oldvalue As Double = Nothing
    Private Sub txtt_giam_gia_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtt_giam_gia.Enter, txtt_tien_ck_hd.Enter, txtt_thu.Enter
        oldvalue = sender.value
    End Sub

    Private Sub txtt_giam_gia_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtt_giam_gia.Validated, txtt_tien_ck_hd.Validated, txtt_thu.Validated
        If oldvalue <> sender.value Then
            Voucher.CurrentVoucher("t_tien_ck_hd_changed") = True
            txtt_phai_thu.Value = txtt_hoa_don.Value - txtt_giam_gia.Value - txtt_tien_ck_hd.Value
            txtt_tra_lai.Value = txtt_thu.Value - txtt_phai_thu.Value
            If txtt_tra_lai.Value < 0 Then txtt_tra_lai.Value = 0
        End If

    End Sub
    Dim ty_le_ck_hd As Double = 0
    Private Sub Txtty_le_ck_hd_Enter(sender As Object, e As EventArgs) Handles Txtty_le_ck_hd.Enter
        ty_le_ck_hd = Txtty_le_ck_hd.Value
    End Sub

    Private Sub Txtty_le_ck_hd_Validated(sender As Object, e As EventArgs) Handles Txtty_le_ck_hd.Validated
        If ty_le_ck_hd <> Txtty_le_ck_hd.Value Then
            Voucher.CurrentVoucher("ty_le_ck_hd_changed") = True
            Voucher.CurrentVoucher("ty_le_ck_hd") = Txtty_le_ck_hd.Value
            tinhchietkhauhoadon()
            txtt_phai_thu.Value = txtt_hoa_don.Value - txtt_giam_gia.Value - txtt_tien_ck_hd.Value
            txtt_tra_lai.Value = txtt_thu.Value - txtt_phai_thu.Value
            If txtt_tra_lai.Value < 0 Then txtt_tra_lai.Value = 0
        End If
    End Sub
    Sub tinhchietkhauhoadon()
        Dim ma_kho As String = ""
        If Voucher.Tabdetails(Voucher.TabFirst).Datatable.Rows.Count > 0 Then
            ma_kho = Voucher.Tabdetails(Voucher.TabFirst).Datatable.Rows(0)("ma_kho")
        End If
        tinhchietkhautheohoadon(ma_kho)
    End Sub

    Private Sub tinhchietkhautheohoadon(ma_kho As String)
        If IsDBNull(Voucher.CurrentVoucher("ty_le_ck_hd_changed")) Then
            Voucher.CurrentVoucher("ty_le_ck_hd_changed") = False
        End If
        If IsDBNull(Voucher.CurrentVoucher("t_tien_ck_hd_changed")) Then
            Voucher.CurrentVoucher("t_tien_ck_hd_changed") = False
        End If

        If Voucher.CurrentVoucher("t_tien_ck_hd_changed") = True Then
            Return
        End If
        If Voucher.CurrentVoucher("ty_le_ck_hd_changed") = True Then
            txtt_tien_ck_hd.Value = Math.Round(txtt_hoa_don.Value * Txtty_le_ck_hd.Value / 100, 0)
            txtt_phai_thu.Value = txtt_hoa_don.Value - txtt_giam_gia.Value - txtt_tien_ck_hd.Value
            Return
        End If

        'chiet khau theo hoa don
        Dim query As String = "exec get_ck_tong_hd "
        query = query & conn.ConvertToSQLType(txtt_hoa_don.Value)
        query = query & "," & conn.ConvertToSQLType(ma_kho)
        query = query & "," & conn.ConvertToSQLType(txtma_kh.Text)
        Dim ck_hdTable As DataTable = conn.GetDatatable(query)
        If ck_hdTable.Rows.Count > 0 Then
            txtt_tien_ck_hd.Value = ck_hdTable.Rows(0).Item("tien_ck")
            If ck_hdTable.Columns.Contains("ty_le_ck") Then
                Txtty_le_ck_hd.Value = ck_hdTable.Rows(0).Item("ty_le_ck")
            End If

            txtt_phai_thu.Value = txtt_hoa_don.Value - txtt_giam_gia.Value - txtt_tien_ck_hd.Value
        Else
            txtt_tien_ck_hd.Value = 0
            If ck_hdTable.Columns.Contains("ty_le_ck") Then
                Txtty_le_ck_hd.Value = 0
            End If

            txtt_phai_thu.Value = txtt_hoa_don.Value - txtt_giam_gia.Value - txtt_tien_ck_hd.Value
        End If
    End Sub
End Class