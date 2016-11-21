Imports System.Net

Public Class frmSendSMS

    Dim dmkh As DataTable
    Dim vdmkh As DataView
    Private Sub frmSendSMS_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ToolStripProgressBar1.Visible = False
        dmkh = conn.GetDatatable("select cast(0 as bit) as sel, * from dkh where dien_thoai<>'' and trang_thai=1")
        vdmkh = dmkh.DefaultView
        vdmkh.RowFilter = "1=0"
        ClsControl2.PropertyOfGrid.FillGrid(conn, "dmkh4sms", gridkh, vdmkh)
        cbbloai_nhom.SelectedIndex = 0
    End Sub

    Private Sub cbbloai_nhom_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbbloai_nhom.SelectedIndexChanged
        vdmkh.RowFilter = "1=0"
        Dim query As String = "select ma_nhom,ten_nhom from dmnhomkh where loai_nhom=" & (cbbloai_nhom.SelectedIndex + 1)
        Dim dt As DataTable = conn.GetDatatable(query)
        listGroup.Items.Clear()

        For Each r As DataRow In dt.Rows
            Dim item As New ListViewItem()
            item.Tag = r("ma_nhom")
            item.Text = r("ten_nhom")
            listGroup.Items.Add(item)
        Next
        'chua phan nhom
        Dim item1 As New ListViewItem()
        item1.Tag = ""
        item1.Text = "Chưa phân nhóm"
        listGroup.Items.Add(item1)
    End Sub

    Private Sub listGroup_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles listGroup.Click
        If listGroup.SelectedItems.Count = 0 Then
            Return
        End If
        Dim loai_nhom As Integer = cbbloai_nhom.SelectedIndex + 1
        vdmkh.RowFilter = "nh_kh" & loai_nhom & "='" & listGroup.SelectedItems(0).Tag & "'"
    End Sub

    Private Sub btnSend_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSend.Click
        gridkh.EndEdit()
        dmkh.AcceptChanges()
        If txtMessage.Text.Trim = "" Then
            MsgBox("Bạn chưa nhập nội dung để gửi", MsgBoxStyle.Critical, Clsql.AboutMe.Name)
            Return
        End If
        btnSend.Enabled = False
        gridkh.Enabled = False
        btngettemplate.Enabled = False
        ToolStripProgressBar1.Visible = True
        msg_error = ""
        BackgroundWorker1.RunWorkerAsync()
    End Sub
    Dim msg_error As String
    Private Sub btngettemplate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btngettemplate.Click
        If OpenFileDialog1.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
            Dim fileReader As New IO.StreamReader(OpenFileDialog1.FileName)
            txtMessage.Text = fileReader.ReadToEnd
            fileReader.Close()
        End If
    End Sub
    Dim url As String = Nothing
    Private Sub BackgroundWorker1_DoWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        If url Is Nothing Then
            url = Clsql.Reg.GetValue("server")
            If url.EndsWith("/") Then
                url = url.Substring(0, url.Length - 1)
            End If
            url = "http://" & url & ":1985/" & Clsql.Reg.GetValue("database") & "/sendsms?token=" & Clsql.Reg.GetValue("token")
        End If

        For Each r As DataRow In dmkh.Rows
            If r("sel") = False Then
                Continue For
            End If
            Dim msg As String = txtMessage.Text
            For Each c As DataColumn In dmkh.Columns
                msg = msg.Replace("{{" & c.ColumnName.ToLower & "}}", r(c).ToString)
            Next
            Dim receiver As String = r("dien_thoai")
            Dim c_url As String = url & "&receiver=" & receiver & "&message=" & msg & "&type=DMKH"
            Try
                Dim w As New WebClient
                Dim rs As String = w.DownloadString(c_url)
                If rs.Contains("ERROR") Then
                    conn.Server.writeError("Can't send sms: " & rs & Chr(13) & c_url)
                    If msg_error <> "" Then
                        msg_error = msg_error & Chr(13) & "------------------------------" & Chr(13)
                    End If
                    msg_error = msg_error & "Không thể gửi tin nhắn tới số " & receiver & " - Khách hàng:" & r("ma_kh") & "-" & r("ten_kh")
                End If
            Catch ex As Exception
                conn.Server.writeError("Can't send sms: " & ex.Message & Chr(13) & c_url)

                If msg_error <> "" Then
                    msg_error = msg_error & Chr(13) & "------------------------------" & Chr(13)
                End If
                msg_error = msg_error & "Không thể gửi tin nhắn tới số " & receiver & " - Khách hàng:" & r("ma_kh") & "-" & r("ten_kh")

            End Try

        Next

    End Sub

    Private Sub BackgroundWorker1_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted
        btnSend.Enabled = True
        gridkh.Enabled = True
        btngettemplate.Enabled = True
        ToolStripProgressBar1.Visible = False
        If msg_error = "" Then
            MsgBox("Chương trình đã thực hiện xong", , Clsql.AboutMe.Name)
        Else
            MsgBox(msg_error, MsgBoxStyle.Critical, Clsql.AboutMe.Name)
        End If

    End Sub
End Class