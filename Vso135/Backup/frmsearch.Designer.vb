﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmsearch
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.txtso_ct = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.ten_dt = New System.Windows.Forms.Label
        Me.txtma_dt = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.ten_phi = New System.Windows.Forms.Label
        Me.txtma_phi = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.ten_bp = New System.Windows.Forms.Label
        Me.txtma_bp = New System.Windows.Forms.TextBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.ten_vt = New System.Windows.Forms.Label
        Me.txtma_vt = New System.Windows.Forms.TextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.TxtDen_ngay = New ClsControl2.TxtDate
        Me.Txttu_ngay = New ClsControl2.TxtDate
        Me.lblten_kh = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtma_kh = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.btntim = New System.Windows.Forms.Button
        Me.btnhuy = New System.Windows.Forms.Button
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.txtso_ct)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.ten_dt)
        Me.GroupBox1.Controls.Add(Me.txtma_dt)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.ten_phi)
        Me.GroupBox1.Controls.Add(Me.txtma_phi)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.ten_bp)
        Me.GroupBox1.Controls.Add(Me.txtma_bp)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.ten_vt)
        Me.GroupBox1.Controls.Add(Me.txtma_vt)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.TxtDen_ngay)
        Me.GroupBox1.Controls.Add(Me.Txttu_ngay)
        Me.GroupBox1.Controls.Add(Me.lblten_kh)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.txtma_kh)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(-6, -7)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(599, 191)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'txtso_ct
        '
        Me.txtso_ct.Location = New System.Drawing.Point(130, 12)
        Me.txtso_ct.Name = "txtso_ct"
        Me.txtso_ct.Size = New System.Drawing.Size(100, 20)
        Me.txtso_ct.TabIndex = 0
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(5, 16)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(65, 13)
        Me.Label3.TabIndex = 104
        Me.Label3.Tag = "220"
        Me.Label3.Text = "So chung tu"
        '
        'ten_dt
        '
        Me.ten_dt.AutoSize = True
        Me.ten_dt.Location = New System.Drawing.Point(233, 169)
        Me.ten_dt.Name = "ten_dt"
        Me.ten_dt.Size = New System.Drawing.Size(34, 13)
        Me.ten_dt.TabIndex = 102
        Me.ten_dt.Text = "ten dt"
        '
        'txtma_dt
        '
        Me.txtma_dt.Location = New System.Drawing.Point(130, 165)
        Me.txtma_dt.Name = "txtma_dt"
        Me.txtma_dt.Size = New System.Drawing.Size(100, 20)
        Me.txtma_dt.TabIndex = 9
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(5, 169)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(68, 13)
        Me.Label6.TabIndex = 101
        Me.Label6.Tag = "F03"
        Me.Label6.Text = "ma doi tuong"
        '
        'ten_phi
        '
        Me.ten_phi.AutoSize = True
        Me.ten_phi.Location = New System.Drawing.Point(233, 144)
        Me.ten_phi.Name = "ten_phi"
        Me.ten_phi.Size = New System.Drawing.Size(39, 13)
        Me.ten_phi.TabIndex = 100
        Me.ten_phi.Text = "ten phi"
        '
        'txtma_phi
        '
        Me.txtma_phi.Location = New System.Drawing.Point(130, 140)
        Me.txtma_phi.Name = "txtma_phi"
        Me.txtma_phi.Size = New System.Drawing.Size(100, 20)
        Me.txtma_phi.TabIndex = 8
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(5, 144)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(39, 13)
        Me.Label8.TabIndex = 99
        Me.Label8.Tag = "F02"
        Me.Label8.Text = "Ma phi"
        '
        'ten_bp
        '
        Me.ten_bp.AutoSize = True
        Me.ten_bp.Location = New System.Drawing.Point(233, 118)
        Me.ten_bp.Name = "ten_bp"
        Me.ten_bp.Size = New System.Drawing.Size(37, 13)
        Me.ten_bp.TabIndex = 98
        Me.ten_bp.Text = "ten bp"
        '
        'txtma_bp
        '
        Me.txtma_bp.Location = New System.Drawing.Point(130, 114)
        Me.txtma_bp.Name = "txtma_bp"
        Me.txtma_bp.Size = New System.Drawing.Size(100, 20)
        Me.txtma_bp.TabIndex = 7
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(5, 118)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(64, 13)
        Me.Label10.TabIndex = 97
        Me.Label10.Tag = "F01"
        Me.Label10.Text = "Ma bo phan"
        '
        'ten_vt
        '
        Me.ten_vt.AutoSize = True
        Me.ten_vt.Location = New System.Drawing.Point(233, 92)
        Me.ten_vt.Name = "ten_vt"
        Me.ten_vt.Size = New System.Drawing.Size(34, 13)
        Me.ten_vt.TabIndex = 18
        Me.ten_vt.Text = "ten vt"
        '
        'txtma_vt
        '
        Me.txtma_vt.Location = New System.Drawing.Point(130, 88)
        Me.txtma_vt.Name = "txtma_vt"
        Me.txtma_vt.Size = New System.Drawing.Size(100, 20)
        Me.txtma_vt.TabIndex = 6
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(5, 92)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(34, 13)
        Me.Label9.TabIndex = 17
        Me.Label9.Tag = "422"
        Me.Label9.Text = "Ma vt"
        '
        'TxtDen_ngay
        '
        Me.TxtDen_ngay.Location = New System.Drawing.Point(236, 38)
        Me.TxtDen_ngay.Mask = "00/00/0000"
        Me.TxtDen_ngay.Name = "TxtDen_ngay"
        Me.TxtDen_ngay.Size = New System.Drawing.Size(100, 20)
        Me.TxtDen_ngay.TabIndex = 2
        Me.TxtDen_ngay.Text = "22012010"
        Me.TxtDen_ngay.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TxtDen_ngay.Value = New Date(2010, 1, 22, 0, 0, 0, 0)
        '
        'Txttu_ngay
        '
        Me.Txttu_ngay.Location = New System.Drawing.Point(130, 38)
        Me.Txttu_ngay.Mask = "00/00/0000"
        Me.Txttu_ngay.Name = "Txttu_ngay"
        Me.Txttu_ngay.Size = New System.Drawing.Size(100, 20)
        Me.Txttu_ngay.TabIndex = 1
        Me.Txttu_ngay.Text = "22012010"
        Me.Txttu_ngay.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.Txttu_ngay.Value = New Date(2010, 1, 22, 0, 0, 0, 0)
        '
        'lblten_kh
        '
        Me.lblten_kh.AutoSize = True
        Me.lblten_kh.Location = New System.Drawing.Point(233, 68)
        Me.lblten_kh.Name = "lblten_kh"
        Me.lblten_kh.Size = New System.Drawing.Size(55, 13)
        Me.lblten_kh.TabIndex = 6
        Me.lblten_kh.Text = "ten khach"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(5, 68)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(38, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Tag = "210"
        Me.Label2.Text = "Khach"
        '
        'txtma_kh
        '
        Me.txtma_kh.Location = New System.Drawing.Point(130, 64)
        Me.txtma_kh.Name = "txtma_kh"
        Me.txtma_kh.Size = New System.Drawing.Size(100, 20)
        Me.txtma_kh.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(5, 42)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(65, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Tag = "232"
        Me.Label1.Text = "tu/den ngay"
        '
        'btntim
        '
        Me.btntim.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btntim.Location = New System.Drawing.Point(5, 190)
        Me.btntim.Name = "btntim"
        Me.btntim.Size = New System.Drawing.Size(75, 23)
        Me.btntim.TabIndex = 1
        Me.btntim.Tag = "233"
        Me.btntim.Text = "Tim"
        Me.btntim.UseVisualStyleBackColor = True
        '
        'btnhuy
        '
        Me.btnhuy.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnhuy.Location = New System.Drawing.Point(86, 190)
        Me.btnhuy.Name = "btnhuy"
        Me.btnhuy.Size = New System.Drawing.Size(75, 23)
        Me.btnhuy.TabIndex = 2
        Me.btnhuy.Tag = "229"
        Me.btnhuy.Text = "Huy"
        Me.btnhuy.UseVisualStyleBackColor = True
        '
        'frmsearch
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(586, 217)
        Me.Controls.Add(Me.btnhuy)
        Me.Controls.Add(Me.btntim)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "frmsearch"
        Me.Tag = "234"
        Me.Text = "frmsearch"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblten_kh As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtma_kh As System.Windows.Forms.TextBox
    Friend WithEvents btntim As System.Windows.Forms.Button
    Friend WithEvents btnhuy As System.Windows.Forms.Button
    Friend WithEvents TxtDen_ngay As ClsControl2.TxtDate
    Friend WithEvents Txttu_ngay As ClsControl2.TxtDate
    Friend WithEvents ten_vt As System.Windows.Forms.Label
    Friend WithEvents txtma_vt As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents ten_dt As System.Windows.Forms.Label
    Friend WithEvents txtma_dt As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents ten_phi As System.Windows.Forms.Label
    Friend WithEvents txtma_phi As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents ten_bp As System.Windows.Forms.Label
    Friend WithEvents txtma_bp As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtso_ct As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
End Class
