﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPrint
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
        Me.Label3 = New System.Windows.Forms.Label
        Me.Txtso_lien = New ClsControl2.TxtNumeric
        Me.txttieu_de = New System.Windows.Forms.TextBox
        Me.btnhuy = New System.Windows.Forms.Button
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.btnpreview = New System.Windows.Forms.Button
        Me.cbbmau = New System.Windows.Forms.ComboBox
        Me.btnprint = New System.Windows.Forms.Button
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(7, 15)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(37, 13)
        Me.Label3.TabIndex = 5
        Me.Label3.Tag = "204"
        Me.Label3.Text = "so lien"
        '
        'Txtso_lien
        '
        Me.Txtso_lien.Location = New System.Drawing.Point(117, 15)
        Me.Txtso_lien.MaxLength = 18
        Me.Txtso_lien.Name = "Txtso_lien"
        Me.Txtso_lien.NumberDecimalDigits = 0
        Me.Txtso_lien.Size = New System.Drawing.Size(64, 20)
        Me.Txtso_lien.TabIndex = 0
        Me.Txtso_lien.Text = "2"
        Me.Txtso_lien.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.Txtso_lien.Value = 2
        '
        'txttieu_de
        '
        Me.txttieu_de.Location = New System.Drawing.Point(117, 65)
        Me.txttieu_de.Name = "txttieu_de"
        Me.txttieu_de.Size = New System.Drawing.Size(267, 20)
        Me.txttieu_de.TabIndex = 2
        '
        'btnhuy
        '
        Me.btnhuy.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnhuy.Location = New System.Drawing.Point(305, 90)
        Me.btnhuy.Name = "btnhuy"
        Me.btnhuy.Size = New System.Drawing.Size(75, 23)
        Me.btnhuy.TabIndex = 34
        Me.btnhuy.Tag = "229"
        Me.btnhuy.Text = "huy"
        Me.btnhuy.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(7, 68)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(39, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Tag = "230"
        Me.Label2.Text = "tieu de"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(7, 40)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(30, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Tag = "231"
        Me.Label1.Text = "mau "
        '
        'btnpreview
        '
        Me.btnpreview.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnpreview.Location = New System.Drawing.Point(224, 90)
        Me.btnpreview.Name = "btnpreview"
        Me.btnpreview.Size = New System.Drawing.Size(75, 23)
        Me.btnpreview.TabIndex = 33
        Me.btnpreview.Tag = "228"
        Me.btnpreview.Text = "Xem"
        Me.btnpreview.UseVisualStyleBackColor = True
        '
        'cbbmau
        '
        Me.cbbmau.FormattingEnabled = True
        Me.cbbmau.Location = New System.Drawing.Point(117, 40)
        Me.cbbmau.Name = "cbbmau"
        Me.cbbmau.Size = New System.Drawing.Size(267, 21)
        Me.cbbmau.TabIndex = 1
        '
        'btnprint
        '
        Me.btnprint.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnprint.Location = New System.Drawing.Point(143, 90)
        Me.btnprint.Name = "btnprint"
        Me.btnprint.Size = New System.Drawing.Size(75, 23)
        Me.btnprint.TabIndex = 31
        Me.btnprint.Tag = "227"
        Me.btnprint.Text = "In"
        Me.btnprint.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Txtso_lien)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.txttieu_de)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.cbbmau)
        Me.GroupBox1.Location = New System.Drawing.Point(-4, -10)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(408, 93)
        Me.GroupBox1.TabIndex = 32
        Me.GroupBox1.TabStop = False
        '
        'frmPrint
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(398, 120)
        Me.Controls.Add(Me.btnhuy)
        Me.Controls.Add(Me.btnpreview)
        Me.Controls.Add(Me.btnprint)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "frmPrint"
        Me.Tag = "000"
        Me.Text = "frmPrint"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Txtso_lien As ClsControl2.TxtNumeric
    Friend WithEvents txttieu_de As System.Windows.Forms.TextBox
    Friend WithEvents btnhuy As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnpreview As System.Windows.Forms.Button
    Friend WithEvents cbbmau As System.Windows.Forms.ComboBox
    Friend WithEvents btnprint As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
End Class
