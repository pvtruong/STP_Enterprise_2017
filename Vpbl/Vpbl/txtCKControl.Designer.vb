<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class txtCKControl
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
        Me.Txtty_le = New ClsControl2.TxtNumeric()
        Me.Txtgia_tri = New ClsControl2.TxtNumeric()
        Me.SuspendLayout()
        '
        'Txtty_le
        '
        Me.Txtty_le.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Txtty_le.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Txtty_le.Font = New System.Drawing.Font("Microsoft Sans Serif", 25.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(163, Byte))
        Me.Txtty_le.Location = New System.Drawing.Point(0, 0)
        Me.Txtty_le.MaxLength = 18
        Me.Txtty_le.Name = "Txtty_le"
        Me.Txtty_le.NumberDecimalDigits = 2
        Me.Txtty_le.Size = New System.Drawing.Size(128, 45)
        Me.Txtty_le.TabIndex = 0
        Me.Txtty_le.Text = "0.00"
        Me.Txtty_le.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.Txtty_le.Value = 0R
        Me.Txtty_le.Value2 = 0R
        '
        'Txtgia_tri
        '
        Me.Txtgia_tri.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Txtgia_tri.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Txtgia_tri.Font = New System.Drawing.Font("Microsoft Sans Serif", 25.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(163, Byte))
        Me.Txtgia_tri.Location = New System.Drawing.Point(126, 0)
        Me.Txtgia_tri.MaxLength = 18
        Me.Txtgia_tri.Name = "Txtgia_tri"
        Me.Txtgia_tri.NumberDecimalDigits = 0
        Me.Txtgia_tri.Size = New System.Drawing.Size(172, 45)
        Me.Txtgia_tri.TabIndex = 1
        Me.Txtgia_tri.Text = "0"
        Me.Txtgia_tri.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.Txtgia_tri.Value = 0R
        Me.Txtgia_tri.Value2 = 0R
        '
        'txtCKControl
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.Controls.Add(Me.Txtgia_tri)
        Me.Controls.Add(Me.Txtty_le)
        Me.Name = "txtCKControl"
        Me.Size = New System.Drawing.Size(298, 45)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Public WithEvents Txtty_le As ClsControl2.TxtNumeric
    Public WithEvents Txtgia_tri As ClsControl2.TxtNumeric
End Class
