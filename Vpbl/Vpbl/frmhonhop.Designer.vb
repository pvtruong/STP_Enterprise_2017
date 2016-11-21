<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmhonhop
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtso_tien = New ClsControl2.TxtNumeric()
        Me.TxtNumeric1 = New ClsControl2.TxtNumeric()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnOk = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.txtso_the = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtchu_the = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(102, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Thanh toán tiền mặt"
        '
        'txtso_tien
        '
        Me.txtso_tien.Location = New System.Drawing.Point(120, 5)
        Me.txtso_tien.MaxLength = 18
        Me.txtso_tien.Name = "txtso_tien"
        Me.txtso_tien.NumberDecimalDigits = 0
        Me.txtso_tien.Size = New System.Drawing.Size(162, 20)
        Me.txtso_tien.TabIndex = 5
        Me.txtso_tien.Text = "0"
        Me.txtso_tien.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtso_tien.Value = 0R
        Me.txtso_tien.Value2 = 0R
        '
        'TxtNumeric1
        '
        Me.TxtNumeric1.Location = New System.Drawing.Point(120, 31)
        Me.TxtNumeric1.MaxLength = 18
        Me.TxtNumeric1.Name = "TxtNumeric1"
        Me.TxtNumeric1.NumberDecimalDigits = 0
        Me.TxtNumeric1.Size = New System.Drawing.Size(162, 20)
        Me.TxtNumeric1.TabIndex = 7
        Me.TxtNumeric1.Text = "0"
        Me.TxtNumeric1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TxtNumeric1.Value = 0R
        Me.TxtNumeric1.Value2 = 0R
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 35)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(101, 13)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Thanh toán qua thẻ"
        '
        'btnOk
        '
        Me.btnOk.Location = New System.Drawing.Point(116, 135)
        Me.btnOk.Name = "btnOk"
        Me.btnOk.Size = New System.Drawing.Size(75, 23)
        Me.btnOk.TabIndex = 8
        Me.btnOk.Text = "Nhận"
        Me.btnOk.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(197, 135)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 9
        Me.btnCancel.Text = "Hủy"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'txtso_the
        '
        Me.txtso_the.Location = New System.Drawing.Point(120, 83)
        Me.txtso_the.MaxLength = 32
        Me.txtso_the.Name = "txtso_the"
        Me.txtso_the.Size = New System.Drawing.Size(162, 20)
        Me.txtso_the.TabIndex = 13
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(10, 86)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(38, 13)
        Me.Label3.TabIndex = 12
        Me.Label3.Tag = "401"
        Me.Label3.Text = "So the"
        '
        'txtchu_the
        '
        Me.txtchu_the.Location = New System.Drawing.Point(120, 57)
        Me.txtchu_the.MaxLength = 32
        Me.txtchu_the.Name = "txtchu_the"
        Me.txtchu_the.Size = New System.Drawing.Size(162, 20)
        Me.txtchu_the.TabIndex = 11
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(10, 60)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(44, 13)
        Me.Label4.TabIndex = 10
        Me.Label4.Tag = "400"
        Me.Label4.Text = "Chu the"
        '
        'frmhonhop
        '
        Me.AcceptButton = Me.btnOk
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(287, 168)
        Me.Controls.Add(Me.txtso_the)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtchu_the)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnOk)
        Me.Controls.Add(Me.TxtNumeric1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtso_tien)
        Me.Controls.Add(Me.Label1)
        Me.Name = "frmhonhop"
        Me.Text = "Thanh toán"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents txtso_tien As ClsControl2.TxtNumeric
    Friend WithEvents TxtNumeric1 As ClsControl2.TxtNumeric
    Friend WithEvents Label2 As Label
    Friend WithEvents btnOk As Button
    Friend WithEvents btnCancel As Button
    Friend WithEvents txtso_the As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents txtchu_the As TextBox
    Friend WithEvents Label4 As Label
End Class
