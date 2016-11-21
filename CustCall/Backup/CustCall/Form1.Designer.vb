<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
        Me.txtdien_thoai = New System.Windows.Forms.TextBox
        Me.txtma_kh = New System.Windows.Forms.TextBox
        Me.txtten_kh = New System.Windows.Forms.TextBox
        Me.txtdia_chi = New System.Windows.Forms.TextBox
        Me.btnAddNewCust = New System.Windows.Forms.Button
        Me.btnOrder = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtemail = New System.Windows.Forms.TextBox
        Me.btnGhi_chu = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'txtdien_thoai
        '
        Me.txtdien_thoai.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtdien_thoai.BackColor = System.Drawing.Color.White
        Me.txtdien_thoai.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtdien_thoai.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtdien_thoai.ForeColor = System.Drawing.Color.Blue
        Me.txtdien_thoai.Location = New System.Drawing.Point(12, 12)
        Me.txtdien_thoai.Name = "txtdien_thoai"
        Me.txtdien_thoai.ReadOnly = True
        Me.txtdien_thoai.Size = New System.Drawing.Size(438, 35)
        Me.txtdien_thoai.TabIndex = 1
        Me.txtdien_thoai.TabStop = False
        Me.txtdien_thoai.Text = "dien thoai"
        Me.txtdien_thoai.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtma_kh
        '
        Me.txtma_kh.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtma_kh.BackColor = System.Drawing.Color.White
        Me.txtma_kh.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtma_kh.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtma_kh.Location = New System.Drawing.Point(116, 64)
        Me.txtma_kh.Name = "txtma_kh"
        Me.txtma_kh.ReadOnly = True
        Me.txtma_kh.Size = New System.Drawing.Size(334, 23)
        Me.txtma_kh.TabIndex = 0
        Me.txtma_kh.TabStop = False
        '
        'txtten_kh
        '
        Me.txtten_kh.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtten_kh.BackColor = System.Drawing.Color.White
        Me.txtten_kh.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtten_kh.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtten_kh.Location = New System.Drawing.Point(116, 93)
        Me.txtten_kh.Name = "txtten_kh"
        Me.txtten_kh.Size = New System.Drawing.Size(334, 23)
        Me.txtten_kh.TabIndex = 1
        '
        'txtdia_chi
        '
        Me.txtdia_chi.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtdia_chi.BackColor = System.Drawing.Color.White
        Me.txtdia_chi.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtdia_chi.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtdia_chi.Location = New System.Drawing.Point(116, 122)
        Me.txtdia_chi.Name = "txtdia_chi"
        Me.txtdia_chi.Size = New System.Drawing.Size(334, 23)
        Me.txtdia_chi.TabIndex = 2
        '
        'btnAddNewCust
        '
        Me.btnAddNewCust.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnAddNewCust.Location = New System.Drawing.Point(15, 182)
        Me.btnAddNewCust.Name = "btnAddNewCust"
        Me.btnAddNewCust.Size = New System.Drawing.Size(100, 23)
        Me.btnAddNewCust.TabIndex = 5
        Me.btnAddNewCust.Text = "Cập nhật KH"
        Me.btnAddNewCust.UseVisualStyleBackColor = True
        '
        'btnOrder
        '
        Me.btnOrder.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnOrder.Location = New System.Drawing.Point(119, 182)
        Me.btnOrder.Name = "btnOrder"
        Me.btnOrder.Size = New System.Drawing.Size(84, 23)
        Me.btnOrder.TabIndex = 6
        Me.btnOrder.Text = "Đặt hàng"
        Me.btnOrder.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 68)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(55, 13)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "Mã khách"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 97)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(86, 13)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "Tên khách hàng"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 126)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(40, 13)
        Me.Label3.TabIndex = 9
        Me.Label3.Text = "Địa chỉ"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(12, 155)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(32, 13)
        Me.Label4.TabIndex = 11
        Me.Label4.Text = "Email"
        '
        'txtemail
        '
        Me.txtemail.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtemail.BackColor = System.Drawing.Color.White
        Me.txtemail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtemail.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtemail.Location = New System.Drawing.Point(116, 150)
        Me.txtemail.MaxLength = 32
        Me.txtemail.Name = "txtemail"
        Me.txtemail.Size = New System.Drawing.Size(334, 23)
        Me.txtemail.TabIndex = 3
        '
        'btnGhi_chu
        '
        Me.btnGhi_chu.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnGhi_chu.Location = New System.Drawing.Point(209, 182)
        Me.btnGhi_chu.Name = "btnGhi_chu"
        Me.btnGhi_chu.Size = New System.Drawing.Size(84, 23)
        Me.btnGhi_chu.TabIndex = 12
        Me.btnGhi_chu.Text = "Ghi chú"
        Me.btnGhi_chu.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(462, 208)
        Me.Controls.Add(Me.btnGhi_chu)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtemail)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnOrder)
        Me.Controls.Add(Me.btnAddNewCust)
        Me.Controls.Add(Me.txtdia_chi)
        Me.Controls.Add(Me.txtten_kh)
        Me.Controls.Add(Me.txtma_kh)
        Me.Controls.Add(Me.txtdien_thoai)
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Khách hàng liên hệ"
        Me.TopMost = True
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtdien_thoai As System.Windows.Forms.TextBox
    Friend WithEvents txtma_kh As System.Windows.Forms.TextBox
    Friend WithEvents txtten_kh As System.Windows.Forms.TextBox
    Friend WithEvents txtdia_chi As System.Windows.Forms.TextBox
    Friend WithEvents btnAddNewCust As System.Windows.Forms.Button
    Friend WithEvents btnOrder As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtemail As System.Windows.Forms.TextBox
    Friend WithEvents btnGhi_chu As System.Windows.Forms.Button

End Class
