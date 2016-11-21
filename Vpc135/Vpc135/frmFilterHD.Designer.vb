<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmFilterHD
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.btncancel = New System.Windows.Forms.Button()
        Me.btnOk = New System.Windows.Forms.Button()
        Me.Txtden_ngay = New ClsControl2.TxtDate()
        Me.Txttu_ngay = New ClsControl2.TxtDate()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtso_hd = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.ten_kh = New System.Windows.Forms.Label()
        Me.txtma_kh = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtso_ct = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'btncancel
        '
        Me.btncancel.Location = New System.Drawing.Point(200, 123)
        Me.btncancel.Name = "btncancel"
        Me.btncancel.Size = New System.Drawing.Size(75, 23)
        Me.btncancel.TabIndex = 19
        Me.btncancel.Text = "Hủy"
        Me.btncancel.UseVisualStyleBackColor = True
        '
        'btnOk
        '
        Me.btnOk.Location = New System.Drawing.Point(119, 123)
        Me.btnOk.Name = "btnOk"
        Me.btnOk.Size = New System.Drawing.Size(75, 23)
        Me.btnOk.TabIndex = 18
        Me.btnOk.Text = "Nhận"
        Me.btnOk.UseVisualStyleBackColor = True
        '
        'Txtden_ngay
        '
        Me.Txtden_ngay.Location = New System.Drawing.Point(225, 92)
        Me.Txtden_ngay.Mask = "00/00/0000"
        Me.Txtden_ngay.Name = "Txtden_ngay"
        Me.Txtden_ngay.Size = New System.Drawing.Size(100, 20)
        Me.Txtden_ngay.TabIndex = 17
        Me.Txtden_ngay.Text = "15012010"
        Me.Txtden_ngay.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.Txtden_ngay.Value = New Date(2010, 1, 15, 0, 0, 0, 0)
        '
        'Txttu_ngay
        '
        Me.Txttu_ngay.Location = New System.Drawing.Point(119, 92)
        Me.Txttu_ngay.Mask = "00/00/0000"
        Me.Txttu_ngay.Name = "Txttu_ngay"
        Me.Txttu_ngay.Size = New System.Drawing.Size(100, 20)
        Me.Txttu_ngay.TabIndex = 15
        Me.Txttu_ngay.Text = "15012010"
        Me.Txttu_ngay.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.Txttu_ngay.Value = New Date(2010, 1, 15, 0, 0, 0, 0)
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(4, 95)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(96, 13)
        Me.Label4.TabIndex = 16
        Me.Label4.Tag = "221"
        Me.Label4.Text = "Từ ngày/đến ngày"
        '
        'txtso_hd
        '
        Me.txtso_hd.Location = New System.Drawing.Point(119, 38)
        Me.txtso_hd.Name = "txtso_hd"
        Me.txtso_hd.Size = New System.Drawing.Size(100, 20)
        Me.txtso_hd.TabIndex = 1
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(4, 41)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(63, 13)
        Me.Label3.TabIndex = 13
        Me.Label3.Text = "Số hóa đơn"
        '
        'ten_kh
        '
        Me.ten_kh.AutoSize = True
        Me.ten_kh.Location = New System.Drawing.Point(225, 15)
        Me.ten_kh.Name = "ten_kh"
        Me.ten_kh.Size = New System.Drawing.Size(39, 13)
        Me.ten_kh.TabIndex = 12
        Me.ten_kh.Text = "Label2"
        '
        'txtma_kh
        '
        Me.txtma_kh.Location = New System.Drawing.Point(119, 12)
        Me.txtma_kh.Name = "txtma_kh"
        Me.txtma_kh.Size = New System.Drawing.Size(100, 20)
        Me.txtma_kh.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(4, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(65, 13)
        Me.Label1.TabIndex = 10
        Me.Label1.Text = "Khách hàng"
        '
        'txtso_ct
        '
        Me.txtso_ct.Location = New System.Drawing.Point(119, 64)
        Me.txtso_ct.Name = "txtso_ct"
        Me.txtso_ct.Size = New System.Drawing.Size(100, 20)
        Me.txtso_ct.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(4, 67)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(65, 13)
        Me.Label2.TabIndex = 20
        Me.Label2.Text = "Số chứng từ"
        '
        'frmFilterHD
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(380, 149)
        Me.Controls.Add(Me.txtso_ct)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.btncancel)
        Me.Controls.Add(Me.btnOk)
        Me.Controls.Add(Me.Txtden_ngay)
        Me.Controls.Add(Me.Txttu_ngay)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtso_hd)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.ten_kh)
        Me.Controls.Add(Me.txtma_kh)
        Me.Controls.Add(Me.Label1)
        Me.Name = "frmFilterHD"
        Me.Text = "Lọc hóa đơn"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btncancel As Button
    Friend WithEvents btnOk As Button
    Friend WithEvents Txtden_ngay As ClsControl2.TxtDate
    Friend WithEvents Txttu_ngay As ClsControl2.TxtDate
    Friend WithEvents Label4 As Label
    Friend WithEvents txtso_hd As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents ten_kh As Label
    Friend WithEvents txtma_kh As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents txtso_ct As TextBox
    Friend WithEvents Label2 As Label
End Class
