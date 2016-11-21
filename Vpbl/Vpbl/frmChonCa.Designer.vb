<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmChonCa
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
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.cbbma_kho = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cbbso_may = New System.Windows.Forms.ComboBox()
        Me.cbbso_ca = New System.Windows.Forms.ComboBox()
        Me.lblma_kho = New System.Windows.Forms.Label()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.ten_dt = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtma_dt = New System.Windows.Forms.TextBox()
        Me.chbshowProducts = New System.Windows.Forms.CheckBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cbbCOM = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtbaundrate = New ClsControl2.TxtNumeric()
        Me.ten_phi = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtma_phi = New System.Windows.Forms.TextBox()
        Me.GroupBox1.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Button1.Location = New System.Drawing.Point(0, 192)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 1
        Me.Button1.Tag = "603"
        Me.Button1.Text = "Bán hàng"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Button2.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Button2.Location = New System.Drawing.Point(81, 192)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 23)
        Me.Button2.TabIndex = 2
        Me.Button2.Tag = "604"
        Me.Button2.Text = "Thoát"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.BackColor = System.Drawing.Color.White
        Me.GroupBox1.Controls.Add(Me.TabControl1)
        Me.GroupBox1.Location = New System.Drawing.Point(-7, -18)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(571, 204)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'TabControl1
        '
        Me.TabControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Location = New System.Drawing.Point(7, 20)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(558, 184)
        Me.TabControl1.TabIndex = 9
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.cbbma_kho)
        Me.TabPage1.Controls.Add(Me.Label1)
        Me.TabPage1.Controls.Add(Me.Label2)
        Me.TabPage1.Controls.Add(Me.cbbso_may)
        Me.TabPage1.Controls.Add(Me.cbbso_ca)
        Me.TabPage1.Controls.Add(Me.lblma_kho)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(550, 117)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Ca"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'cbbma_kho
        '
        Me.cbbma_kho.FormattingEnabled = True
        Me.cbbma_kho.Location = New System.Drawing.Point(100, 6)
        Me.cbbma_kho.Name = "cbbma_kho"
        Me.cbbma_kho.Size = New System.Drawing.Size(411, 21)
        Me.cbbma_kho.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(8, 37)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(46, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Tag = "601"
        Me.Label1.Text = "Số quầy"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(8, 63)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(35, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Tag = "602"
        Me.Label2.Text = "Số ca"
        '
        'cbbso_may
        '
        Me.cbbso_may.FormattingEnabled = True
        Me.cbbso_may.Location = New System.Drawing.Point(100, 33)
        Me.cbbso_may.Name = "cbbso_may"
        Me.cbbso_may.Size = New System.Drawing.Size(411, 21)
        Me.cbbso_may.TabIndex = 1
        '
        'cbbso_ca
        '
        Me.cbbso_ca.FormattingEnabled = True
        Me.cbbso_ca.Location = New System.Drawing.Point(100, 59)
        Me.cbbso_ca.Name = "cbbso_ca"
        Me.cbbso_ca.Size = New System.Drawing.Size(411, 21)
        Me.cbbso_ca.TabIndex = 2
        '
        'lblma_kho
        '
        Me.lblma_kho.AutoSize = True
        Me.lblma_kho.Location = New System.Drawing.Point(8, 10)
        Me.lblma_kho.Name = "lblma_kho"
        Me.lblma_kho.Size = New System.Drawing.Size(26, 13)
        Me.lblma_kho.TabIndex = 3
        Me.lblma_kho.Tag = "KHO"
        Me.lblma_kho.Text = "Kho"
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.ten_phi)
        Me.TabPage2.Controls.Add(Me.Label8)
        Me.TabPage2.Controls.Add(Me.txtma_phi)
        Me.TabPage2.Controls.Add(Me.ten_dt)
        Me.TabPage2.Controls.Add(Me.Label6)
        Me.TabPage2.Controls.Add(Me.txtma_dt)
        Me.TabPage2.Controls.Add(Me.chbshowProducts)
        Me.TabPage2.Controls.Add(Me.Label4)
        Me.TabPage2.Controls.Add(Me.Label5)
        Me.TabPage2.Controls.Add(Me.cbbCOM)
        Me.TabPage2.Controls.Add(Me.Label3)
        Me.TabPage2.Controls.Add(Me.txtbaundrate)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(550, 158)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Khác"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'ten_dt
        '
        Me.ten_dt.AutoSize = True
        Me.ten_dt.Location = New System.Drawing.Point(239, 13)
        Me.ten_dt.Name = "ten_dt"
        Me.ten_dt.Size = New System.Drawing.Size(69, 13)
        Me.ten_dt.TabIndex = 12
        Me.ten_dt.Text = "ten doi tuong"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(11, 13)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(94, 13)
        Me.Label6.TabIndex = 11
        Me.Label6.Tag = "VV"
        Me.Label6.Text = "Vụ việc, đối tượng"
        '
        'txtma_dt
        '
        Me.txtma_dt.Location = New System.Drawing.Point(111, 9)
        Me.txtma_dt.Name = "txtma_dt"
        Me.txtma_dt.Size = New System.Drawing.Size(121, 20)
        Me.txtma_dt.TabIndex = 0
        '
        'chbshowProducts
        '
        Me.chbshowProducts.AutoSize = True
        Me.chbshowProducts.Location = New System.Drawing.Point(111, 66)
        Me.chbshowProducts.Name = "chbshowProducts"
        Me.chbshowProducts.Size = New System.Drawing.Size(150, 17)
        Me.chbshowProducts.TabIndex = 2
        Me.chbshowProducts.Text = "Hiện danh sách sản phẩm"
        Me.chbshowProducts.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(239, 93)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(129, 13)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "Tốc độ truyền (Baud rate)"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(163, Byte))
        Me.Label5.Location = New System.Drawing.Point(111, 116)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(166, 13)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "Cổng này dùng cho màn hình phụ"
        '
        'cbbCOM
        '
        Me.cbbCOM.FormattingEnabled = True
        Me.cbbCOM.Location = New System.Drawing.Point(111, 89)
        Me.cbbCOM.Name = "cbbCOM"
        Me.cbbCOM.Size = New System.Drawing.Size(121, 21)
        Me.cbbCOM.TabIndex = 4
        Me.cbbCOM.TabStop = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(11, 93)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(86, 13)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Chọn cổng COM"
        '
        'txtbaundrate
        '
        Me.txtbaundrate.Location = New System.Drawing.Point(422, 89)
        Me.txtbaundrate.MaxLength = 18
        Me.txtbaundrate.Name = "txtbaundrate"
        Me.txtbaundrate.NumberDecimalDigits = -1
        Me.txtbaundrate.Size = New System.Drawing.Size(100, 20)
        Me.txtbaundrate.TabIndex = 6
        Me.txtbaundrate.TabStop = False
        Me.txtbaundrate.Text = "0"
        Me.txtbaundrate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtbaundrate.Value = 0R
        Me.txtbaundrate.Value2 = 0R
        '
        'ten_phi
        '
        Me.ten_phi.AutoSize = True
        Me.ten_phi.Location = New System.Drawing.Point(239, 39)
        Me.ten_phi.Name = "ten_phi"
        Me.ten_phi.Size = New System.Drawing.Size(34, 13)
        Me.ten_phi.TabIndex = 15
        Me.ten_phi.Text = "ten dt"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(11, 39)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(73, 13)
        Me.Label8.TabIndex = 14
        Me.Label8.Tag = "PHI"
        Me.Label8.Text = "Mã doanh thu"
        '
        'txtma_phi
        '
        Me.txtma_phi.Location = New System.Drawing.Point(111, 35)
        Me.txtma_phi.Name = "txtma_phi"
        Me.txtma_phi.Size = New System.Drawing.Size(121, 20)
        Me.txtma_phi.TabIndex = 1
        '
        'frmChonCa
        '
        Me.AcceptButton = Me.Button1
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.Button2
        Me.CausesValidation = False
        Me.ClientSize = New System.Drawing.Size(554, 219)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmChonCa"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Tag = "600"
        Me.Text = "Chọn ca làm việc"
        Me.GroupBox1.ResumeLayout(False)
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cbbso_ca As System.Windows.Forms.ComboBox
    Friend WithEvents cbbso_may As System.Windows.Forms.ComboBox
    Friend WithEvents cbbma_kho As System.Windows.Forms.ComboBox
    Friend WithEvents lblma_kho As System.Windows.Forms.Label
    Friend WithEvents cbbCOM As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtbaundrate As ClsControl2.TxtNumeric
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label5 As Label
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents ten_dt As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents txtma_dt As TextBox
    Friend WithEvents chbshowProducts As CheckBox
    Friend WithEvents ten_phi As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents txtma_phi As TextBox
End Class
