<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frmmain
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
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.lbluser = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.lbllines = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripmain = New System.Windows.Forms.ToolStrip()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.grid = New System.Windows.Forms.DataGridView()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.thong_tin_chung = New System.Windows.Forms.TabPage()
        Me.txtnh_tk1 = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtten_loai_cl_co2 = New System.Windows.Forms.TextBox()
        Me.txtten_loai_cl_no2 = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtten_loai_cl_co = New System.Windows.Forms.TextBox()
        Me.txtten_loai_cl_no = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtloai_tk = New System.Windows.Forms.TextBox()
        Me.txtbac_tk = New System.Windows.Forms.TextBox()
        Me.chbtk_cn = New System.Windows.Forms.CheckBox()
        Me.chbtrang_thai = New System.Windows.Forms.CheckBox()
        Me.txttk = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtma_nt = New System.Windows.Forms.TextBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.txttk_me = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.txtten_tk2 = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtten_tk = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.StatusStrip1.SuspendLayout()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.grid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControl1.SuspendLayout()
        Me.thong_tin_chung.SuspendLayout()
        Me.SuspendLayout()
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lbluser, Me.ToolStripStatusLabel1, Me.lbllines})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 428)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(970, 22)
        Me.StatusStrip1.TabIndex = 1
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'lbluser
        '
        Me.lbluser.Name = "lbluser"
        Me.lbluser.Size = New System.Drawing.Size(29, 17)
        Me.lbluser.Text = "user"
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(926, 17)
        Me.ToolStripStatusLabel1.Spring = True
        '
        'lbllines
        '
        Me.lbllines.Name = "lbllines"
        Me.lbllines.Size = New System.Drawing.Size(0, 17)
        '
        'ToolStripmain
        '
        Me.ToolStripmain.Location = New System.Drawing.Point(0, 0)
        Me.ToolStripmain.Name = "ToolStripmain"
        Me.ToolStripmain.Size = New System.Drawing.Size(970, 25)
        Me.ToolStripmain.TabIndex = 2
        Me.ToolStripmain.Text = "ToolStrip1"
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 25)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.grid)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.TabControl1)
        Me.SplitContainer1.Size = New System.Drawing.Size(970, 403)
        Me.SplitContainer1.SplitterDistance = 423
        Me.SplitContainer1.TabIndex = 6
        '
        'grid
        '
        Me.grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grid.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grid.Location = New System.Drawing.Point(0, 0)
        Me.grid.Name = "grid"
        Me.grid.Size = New System.Drawing.Size(423, 403)
        Me.grid.TabIndex = 0
        '
        'TabControl1
        '
        Me.TabControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabControl1.Controls.Add(Me.thong_tin_chung)
        Me.TabControl1.Location = New System.Drawing.Point(0, 2)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(542, 399)
        Me.TabControl1.TabIndex = 23
        '
        'thong_tin_chung
        '
        Me.thong_tin_chung.BackColor = System.Drawing.Color.White
        Me.thong_tin_chung.Controls.Add(Me.txtnh_tk1)
        Me.thong_tin_chung.Controls.Add(Me.Label10)
        Me.thong_tin_chung.Controls.Add(Me.txtten_loai_cl_co2)
        Me.thong_tin_chung.Controls.Add(Me.txtten_loai_cl_no2)
        Me.thong_tin_chung.Controls.Add(Me.Label7)
        Me.thong_tin_chung.Controls.Add(Me.Label5)
        Me.thong_tin_chung.Controls.Add(Me.txtten_loai_cl_co)
        Me.thong_tin_chung.Controls.Add(Me.txtten_loai_cl_no)
        Me.thong_tin_chung.Controls.Add(Me.Label4)
        Me.thong_tin_chung.Controls.Add(Me.Label3)
        Me.thong_tin_chung.Controls.Add(Me.txtloai_tk)
        Me.thong_tin_chung.Controls.Add(Me.txtbac_tk)
        Me.thong_tin_chung.Controls.Add(Me.chbtk_cn)
        Me.thong_tin_chung.Controls.Add(Me.chbtrang_thai)
        Me.thong_tin_chung.Controls.Add(Me.txttk)
        Me.thong_tin_chung.Controls.Add(Me.Label1)
        Me.thong_tin_chung.Controls.Add(Me.txtma_nt)
        Me.thong_tin_chung.Controls.Add(Me.Label18)
        Me.thong_tin_chung.Controls.Add(Me.txttk_me)
        Me.thong_tin_chung.Controls.Add(Me.Label14)
        Me.thong_tin_chung.Controls.Add(Me.txtten_tk2)
        Me.thong_tin_chung.Controls.Add(Me.Label11)
        Me.thong_tin_chung.Controls.Add(Me.txtten_tk)
        Me.thong_tin_chung.Controls.Add(Me.Label2)
        Me.thong_tin_chung.Location = New System.Drawing.Point(4, 22)
        Me.thong_tin_chung.Name = "thong_tin_chung"
        Me.thong_tin_chung.Padding = New System.Windows.Forms.Padding(3)
        Me.thong_tin_chung.Size = New System.Drawing.Size(534, 373)
        Me.thong_tin_chung.TabIndex = 0
        Me.thong_tin_chung.Tag = "096"
        Me.thong_tin_chung.Text = "Thông tin chính"
        '
        'txtnh_tk1
        '
        Me.txtnh_tk1.Location = New System.Drawing.Point(135, 229)
        Me.txtnh_tk1.Name = "txtnh_tk1"
        Me.txtnh_tk1.Size = New System.Drawing.Size(100, 20)
        Me.txtnh_tk1.TabIndex = 9
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(3, 233)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(82, 13)
        Me.Label10.TabIndex = 127
        Me.Label10.Tag = "102"
        Me.Label10.Text = "Nhom tai khoan"
        '
        'txtten_loai_cl_co2
        '
        Me.txtten_loai_cl_co2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtten_loai_cl_co2.Location = New System.Drawing.Point(135, 205)
        Me.txtten_loai_cl_co2.Name = "txtten_loai_cl_co2"
        Me.txtten_loai_cl_co2.Size = New System.Drawing.Size(392, 20)
        Me.txtten_loai_cl_co2.TabIndex = 8
        '
        'txtten_loai_cl_no2
        '
        Me.txtten_loai_cl_no2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtten_loai_cl_no2.Location = New System.Drawing.Point(135, 181)
        Me.txtten_loai_cl_no2.Name = "txtten_loai_cl_no2"
        Me.txtten_loai_cl_no2.Size = New System.Drawing.Size(392, 20)
        Me.txtten_loai_cl_no2.TabIndex = 7
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(3, 209)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(79, 13)
        Me.Label7.TabIndex = 123
        Me.Label7.Tag = "011"
        Me.Label7.Text = "PP tinh tggs co"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(3, 185)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(79, 13)
        Me.Label5.TabIndex = 122
        Me.Label5.Tag = "010"
        Me.Label5.Text = "PP tinh tggs no"
        '
        'txtten_loai_cl_co
        '
        Me.txtten_loai_cl_co.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtten_loai_cl_co.Location = New System.Drawing.Point(135, 205)
        Me.txtten_loai_cl_co.Name = "txtten_loai_cl_co"
        Me.txtten_loai_cl_co.Size = New System.Drawing.Size(392, 20)
        Me.txtten_loai_cl_co.TabIndex = 121
        '
        'txtten_loai_cl_no
        '
        Me.txtten_loai_cl_no.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtten_loai_cl_no.Location = New System.Drawing.Point(135, 181)
        Me.txtten_loai_cl_no.Name = "txtten_loai_cl_no"
        Me.txtten_loai_cl_no.Size = New System.Drawing.Size(392, 20)
        Me.txtten_loai_cl_no.TabIndex = 120
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(3, 158)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(39, 13)
        Me.Label4.TabIndex = 119
        Me.Label4.Tag = "009"
        Me.Label4.Text = "Loai tk"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(3, 132)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(38, 13)
        Me.Label3.TabIndex = 118
        Me.Label3.Tag = "008"
        Me.Label3.Text = "Bac tk"
        '
        'txtloai_tk
        '
        Me.txtloai_tk.Location = New System.Drawing.Point(135, 155)
        Me.txtloai_tk.Name = "txtloai_tk"
        Me.txtloai_tk.Size = New System.Drawing.Size(100, 20)
        Me.txtloai_tk.TabIndex = 6
        '
        'txtbac_tk
        '
        Me.txtbac_tk.Location = New System.Drawing.Point(135, 129)
        Me.txtbac_tk.Name = "txtbac_tk"
        Me.txtbac_tk.Size = New System.Drawing.Size(100, 20)
        Me.txtbac_tk.TabIndex = 5
        '
        'chbtk_cn
        '
        Me.chbtk_cn.AutoSize = True
        Me.chbtk_cn.Location = New System.Drawing.Point(135, 255)
        Me.chbtk_cn.Name = "chbtk_cn"
        Me.chbtk_cn.Size = New System.Drawing.Size(116, 17)
        Me.chbtk_cn.TabIndex = 10
        Me.chbtk_cn.Tag = "006"
        Me.chbtk_cn.Text = "Tai khoan cong no"
        Me.chbtk_cn.UseVisualStyleBackColor = True
        '
        'chbtrang_thai
        '
        Me.chbtrang_thai.AutoSize = True
        Me.chbtrang_thai.Location = New System.Drawing.Point(135, 280)
        Me.chbtrang_thai.Name = "chbtrang_thai"
        Me.chbtrang_thai.Size = New System.Drawing.Size(74, 17)
        Me.chbtrang_thai.TabIndex = 11
        Me.chbtrang_thai.Tag = "007"
        Me.chbtrang_thai.Text = "Trang thai"
        Me.chbtrang_thai.UseVisualStyleBackColor = True
        '
        'txttk
        '
        Me.txttk.Location = New System.Drawing.Point(135, 6)
        Me.txttk.Name = "txttk"
        Me.txttk.Size = New System.Drawing.Size(100, 20)
        Me.txttk.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(3, 10)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(55, 13)
        Me.Label1.TabIndex = 115
        Me.Label1.Tag = "001"
        Me.Label1.Text = "Tai khoan"
        '
        'txtma_nt
        '
        Me.txtma_nt.Location = New System.Drawing.Point(135, 103)
        Me.txtma_nt.Name = "txtma_nt"
        Me.txtma_nt.Size = New System.Drawing.Size(100, 20)
        Me.txtma_nt.TabIndex = 4
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(3, 107)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(47, 13)
        Me.Label18.TabIndex = 113
        Me.Label18.Tag = "005"
        Me.Label18.Text = "Ngoai te"
        '
        'txttk_me
        '
        Me.txttk_me.Location = New System.Drawing.Point(135, 79)
        Me.txttk_me.Name = "txttk_me"
        Me.txttk_me.Size = New System.Drawing.Size(100, 20)
        Me.txttk_me.TabIndex = 3
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(3, 83)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(33, 13)
        Me.Label14.TabIndex = 112
        Me.Label14.Tag = "004"
        Me.Label14.Text = "tk me"
        '
        'txtten_tk2
        '
        Me.txtten_tk2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtten_tk2.Location = New System.Drawing.Point(135, 55)
        Me.txtten_tk2.Name = "txtten_tk2"
        Me.txtten_tk2.Size = New System.Drawing.Size(392, 20)
        Me.txtten_tk2.TabIndex = 2
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(3, 59)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(44, 13)
        Me.Label11.TabIndex = 111
        Me.Label11.Tag = "003"
        Me.Label11.Text = "Ten tk2"
        '
        'txtten_tk
        '
        Me.txtten_tk.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtten_tk.Location = New System.Drawing.Point(135, 31)
        Me.txtten_tk.Name = "txtten_tk"
        Me.txtten_tk.Size = New System.Drawing.Size(392, 20)
        Me.txtten_tk.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(3, 35)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(38, 13)
        Me.Label2.TabIndex = 110
        Me.Label2.Tag = "002"
        Me.Label2.Text = "Ten tk"
        '
        'Frmmain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(970, 450)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.ToolStripmain)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Name = "Frmmain"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Tag = "000"
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.ResumeLayout(False)
        CType(Me.grid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControl1.ResumeLayout(False)
        Me.thong_tin_chung.ResumeLayout(False)
        Me.thong_tin_chung.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents lbluser As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripmain As System.Windows.Forms.ToolStrip
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents thong_tin_chung As System.Windows.Forms.TabPage
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents lbllines As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents chbtk_cn As System.Windows.Forms.CheckBox
    Friend WithEvents chbtrang_thai As System.Windows.Forms.CheckBox
    Friend WithEvents txttk As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtma_nt As System.Windows.Forms.TextBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents txttk_me As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txtten_tk2 As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtten_tk As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtloai_tk As System.Windows.Forms.TextBox
    Friend WithEvents txtbac_tk As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtten_loai_cl_co As System.Windows.Forms.TextBox
    Friend WithEvents txtten_loai_cl_no As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents grid As System.Windows.Forms.DataGridView
    Friend WithEvents txtten_loai_cl_co2 As System.Windows.Forms.TextBox
    Friend WithEvents txtten_loai_cl_no2 As System.Windows.Forms.TextBox
    Friend WithEvents txtnh_tk1 As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label



End Class
