<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCK
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
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Txttien_ck_hd = New ClsControl2.TxtNumeric()
        Me.btnOK = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Txtty_le_ck_hd = New ClsControl2.TxtNumeric()
        Me.SuspendLayout()
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(4, 42)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(81, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Tiền chiết khấu"
        '
        'Txttien_ck_hd
        '
        Me.Txttien_ck_hd.Location = New System.Drawing.Point(109, 39)
        Me.Txttien_ck_hd.MaxLength = 18
        Me.Txttien_ck_hd.Name = "Txttien_ck_hd"
        Me.Txttien_ck_hd.NumberDecimalDigits = 2
        Me.Txttien_ck_hd.Size = New System.Drawing.Size(163, 20)
        Me.Txttien_ck_hd.TabIndex = 2
        Me.Txttien_ck_hd.Text = "0.00"
        Me.Txttien_ck_hd.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.Txttien_ck_hd.Value = 0R
        Me.Txttien_ck_hd.Value2 = 0R
        '
        'btnOK
        '
        Me.btnOK.Location = New System.Drawing.Point(109, 69)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(75, 23)
        Me.btnOK.TabIndex = 4
        Me.btnOK.Text = "Xác nhận"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(4, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(102, 13)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Tỷ lệ chiết khấu HD"
        '
        'Txtty_le_ck_hd
        '
        Me.Txtty_le_ck_hd.Location = New System.Drawing.Point(109, 13)
        Me.Txtty_le_ck_hd.MaxLength = 18
        Me.Txtty_le_ck_hd.Name = "Txtty_le_ck_hd"
        Me.Txtty_le_ck_hd.NumberDecimalDigits = 2
        Me.Txtty_le_ck_hd.Size = New System.Drawing.Size(163, 20)
        Me.Txtty_le_ck_hd.TabIndex = 0
        Me.Txtty_le_ck_hd.Text = "0.00"
        Me.Txtty_le_ck_hd.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.Txtty_le_ck_hd.Value = 0R
        Me.Txtty_le_ck_hd.Value2 = 0R
        '
        'frmCK
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(284, 94)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Txtty_le_ck_hd)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Txttien_ck_hd)
        Me.Name = "frmCK"
        Me.Text = "Chiết khấu theo hóa đơn"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label2 As Label
    Friend WithEvents Txttien_ck_hd As ClsControl2.TxtNumeric
    Friend WithEvents btnOK As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents Txtty_le_ck_hd As ClsControl2.TxtNumeric
End Class
