<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frminput
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frminput))
        Me.btnLuu = New System.Windows.Forms.Button
        Me.btnhuy = New System.Windows.Forms.Button
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.ten_tt = New System.Windows.Forms.Label
        Me.txtma_tt = New System.Windows.Forms.TextBox
        Me.Label18 = New System.Windows.Forms.Label
        Me.txtso_hd = New System.Windows.Forms.TextBox
        Me.so_hd = New System.Windows.Forms.Label
        Me.txtdia_chi_giao = New System.Windows.Forms.TextBox
        Me.Label21 = New System.Windows.Forms.Label
        Me.Txtngay_giao = New ClsControl2.TxtDate
        Me.Label20 = New System.Windows.Forms.Label
        Me.txtso_yc = New System.Windows.Forms.TextBox
        Me.Label19 = New System.Windows.Forms.Label
        Me.TabControl1 = New System.Windows.Forms.TabControl
        Me.tabother = New System.Windows.Forms.TabPage
        Me.txtghi_chu5 = New System.Windows.Forms.TextBox
        Me.Label28 = New System.Windows.Forms.Label
        Me.txtghi_chu4 = New System.Windows.Forms.TextBox
        Me.Label27 = New System.Windows.Forms.Label
        Me.txtghi_chu3 = New System.Windows.Forms.TextBox
        Me.Label26 = New System.Windows.Forms.Label
        Me.txtghi_chu2 = New System.Windows.Forms.TextBox
        Me.Label24 = New System.Windows.Forms.Label
        Me.txtghi_chu1 = New System.Windows.Forms.TextBox
        Me.Label23 = New System.Windows.Forms.Label
        Me.ten_nv = New System.Windows.Forms.Label
        Me.txtma_nv = New System.Windows.Forms.TextBox
        Me.Label22 = New System.Windows.Forms.Label
        Me.Txtty_gia = New ClsControl2.TxtNumeric
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.Label15 = New System.Windows.Forms.Label
        Me.txtdia_chi = New System.Windows.Forms.TextBox
        Me.Label14 = New System.Windows.Forms.Label
        Me.txtong_ba = New System.Windows.Forms.TextBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.txtten_kh = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtma_kh = New System.Windows.Forms.TextBox
        Me.Txtngay_ct = New ClsControl2.TxtDate
        Me.Label11 = New System.Windows.Forms.Label
        Me.cbbma_nt = New System.Windows.Forms.ComboBox
        Me.txtdien_giai = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtso_ct = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.cbbstatus = New System.Windows.Forms.ComboBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.cbbma_gd = New System.Windows.Forms.ComboBox
        Me.Label16 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtnguoi_tao = New System.Windows.Forms.Label
        Me.txtngay_tao = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.txtngay_sua = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.txtnguoi_sua = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.btnluuandmoi = New System.Windows.Forms.Button
        Me.Label25 = New System.Windows.Forms.Label
        Me.Txtt_sl = New ClsControl2.TxtNumeric
        Me.Txtt_tien_nt = New ClsControl2.TxtNumeric
        Me.Txtt_tien = New ClsControl2.TxtNumeric
        Me.Label9 = New System.Windows.Forms.Label
        Me.Txtt_thue_nt = New ClsControl2.TxtNumeric
        Me.Txtt_thue = New ClsControl2.TxtNumeric
        Me.Label17 = New System.Windows.Forms.Label
        Me.Txtt_tt_nt = New ClsControl2.TxtNumeric
        Me.Txtt_tt = New ClsControl2.TxtNumeric
        Me.toolbar = New System.Windows.Forms.ToolStrip
        Me.TSDropDownGetdata = New System.Windows.Forms.ToolStripDropDownButton
        Me.btnLayDuLieuTuPhieuYC = New System.Windows.Forms.ToolStripMenuItem
        Me.Label29 = New System.Windows.Forms.Label
        Me.Txtt_ck_nt = New ClsControl2.TxtNumeric
        Me.txtt_ck = New ClsControl2.TxtNumeric
        Me.GroupBox1.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.tabother.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.toolbar.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnLuu
        '
        Me.btnLuu.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnLuu.Location = New System.Drawing.Point(3, 392)
        Me.btnLuu.Name = "btnLuu"
        Me.btnLuu.Size = New System.Drawing.Size(81, 48)
        Me.btnLuu.TabIndex = 99
        Me.btnLuu.Tag = "094"
        Me.btnLuu.Text = "Luu"
        Me.btnLuu.UseVisualStyleBackColor = True
        '
        'btnhuy
        '
        Me.btnhuy.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnhuy.CausesValidation = False
        Me.btnhuy.Location = New System.Drawing.Point(173, 392)
        Me.btnhuy.Name = "btnhuy"
        Me.btnhuy.Size = New System.Drawing.Size(78, 48)
        Me.btnhuy.TabIndex = 200
        Me.btnhuy.Tag = "095"
        Me.btnhuy.Text = "Huy"
        Me.btnhuy.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.ten_tt)
        Me.GroupBox1.Controls.Add(Me.txtma_tt)
        Me.GroupBox1.Controls.Add(Me.Label18)
        Me.GroupBox1.Controls.Add(Me.txtso_hd)
        Me.GroupBox1.Controls.Add(Me.so_hd)
        Me.GroupBox1.Controls.Add(Me.txtdia_chi_giao)
        Me.GroupBox1.Controls.Add(Me.Label21)
        Me.GroupBox1.Controls.Add(Me.Txtngay_giao)
        Me.GroupBox1.Controls.Add(Me.Label20)
        Me.GroupBox1.Controls.Add(Me.txtso_yc)
        Me.GroupBox1.Controls.Add(Me.Label19)
        Me.GroupBox1.Controls.Add(Me.TabControl1)
        Me.GroupBox1.Controls.Add(Me.Txtty_gia)
        Me.GroupBox1.Controls.Add(Me.GroupBox2)
        Me.GroupBox1.Controls.Add(Me.Txtngay_ct)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.cbbma_nt)
        Me.GroupBox1.Controls.Add(Me.txtdien_giai)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.txtso_ct)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(-5, -13)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(920, 399)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'ten_tt
        '
        Me.ten_tt.AutoSize = True
        Me.ten_tt.Location = New System.Drawing.Point(626, 160)
        Me.ten_tt.Name = "ten_tt"
        Me.ten_tt.Size = New System.Drawing.Size(123, 13)
        Me.ten_tt.TabIndex = 224
        Me.ten_tt.Text = "ten hinh thuc thanh toan"
        '
        'txtma_tt
        '
        Me.txtma_tt.Location = New System.Drawing.Point(520, 156)
        Me.txtma_tt.Name = "txtma_tt"
        Me.txtma_tt.Size = New System.Drawing.Size(100, 20)
        Me.txtma_tt.TabIndex = 9
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(405, 160)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(107, 13)
        Me.Label18.TabIndex = 223
        Me.Label18.Tag = "202"
        Me.Label18.Text = "Hinh thuc thanh toan"
        '
        'txtso_hd
        '
        Me.txtso_hd.Location = New System.Drawing.Point(332, 64)
        Me.txtso_hd.Name = "txtso_hd"
        Me.txtso_hd.Size = New System.Drawing.Size(100, 20)
        Me.txtso_hd.TabIndex = 3
        '
        'so_hd
        '
        Me.so_hd.AutoSize = True
        Me.so_hd.Location = New System.Drawing.Point(235, 68)
        Me.so_hd.Name = "so_hd"
        Me.so_hd.Size = New System.Drawing.Size(68, 13)
        Me.so_hd.TabIndex = 221
        Me.so_hd.Tag = "013"
        Me.so_hd.Text = "So hop dong"
        '
        'txtdia_chi_giao
        '
        Me.txtdia_chi_giao.Location = New System.Drawing.Point(126, 110)
        Me.txtdia_chi_giao.Name = "txtdia_chi_giao"
        Me.txtdia_chi_giao.Size = New System.Drawing.Size(306, 20)
        Me.txtdia_chi_giao.TabIndex = 5
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(6, 114)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(46, 13)
        Me.Label21.TabIndex = 219
        Me.Label21.Tag = "034"
        Me.Label21.Text = "Nơi giao"
        '
        'Txtngay_giao
        '
        Me.Txtngay_giao.Location = New System.Drawing.Point(126, 87)
        Me.Txtngay_giao.Mask = "00/00/0000"
        Me.Txtngay_giao.Name = "Txtngay_giao"
        Me.Txtngay_giao.Size = New System.Drawing.Size(100, 20)
        Me.Txtngay_giao.TabIndex = 4
        Me.Txtngay_giao.Text = "01011910"
        Me.Txtngay_giao.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.Txtngay_giao.Value = New Date(1910, 1, 1, 0, 0, 0, 0)
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(7, 90)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(53, 13)
        Me.Label20.TabIndex = 217
        Me.Label20.Tag = "033"
        Me.Label20.Text = "ngay giao"
        '
        'txtso_yc
        '
        Me.txtso_yc.Location = New System.Drawing.Point(126, 64)
        Me.txtso_yc.Name = "txtso_yc"
        Me.txtso_yc.Size = New System.Drawing.Size(100, 20)
        Me.txtso_yc.TabIndex = 2
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(6, 68)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(61, 13)
        Me.Label19.TabIndex = 215
        Me.Label19.Tag = "014"
        Me.Label19.Text = "So yeu cau"
        '
        'TabControl1
        '
        Me.TabControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabControl1.Controls.Add(Me.tabother)
        Me.TabControl1.Location = New System.Drawing.Point(6, 190)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(908, 209)
        Me.TabControl1.TabIndex = 211
        Me.TabControl1.TabStop = False
        '
        'tabother
        '
        Me.tabother.Controls.Add(Me.txtghi_chu5)
        Me.tabother.Controls.Add(Me.Label28)
        Me.tabother.Controls.Add(Me.txtghi_chu4)
        Me.tabother.Controls.Add(Me.Label27)
        Me.tabother.Controls.Add(Me.txtghi_chu3)
        Me.tabother.Controls.Add(Me.Label26)
        Me.tabother.Controls.Add(Me.txtghi_chu2)
        Me.tabother.Controls.Add(Me.Label24)
        Me.tabother.Controls.Add(Me.txtghi_chu1)
        Me.tabother.Controls.Add(Me.Label23)
        Me.tabother.Controls.Add(Me.ten_nv)
        Me.tabother.Controls.Add(Me.txtma_nv)
        Me.tabother.Controls.Add(Me.Label22)
        Me.tabother.Location = New System.Drawing.Point(4, 22)
        Me.tabother.Name = "tabother"
        Me.tabother.Size = New System.Drawing.Size(900, 183)
        Me.tabother.TabIndex = 1
        Me.tabother.Tag = "009"
        Me.tabother.Text = "thong tin khac"
        Me.tabother.UseVisualStyleBackColor = True
        '
        'txtghi_chu5
        '
        Me.txtghi_chu5.Location = New System.Drawing.Point(99, 121)
        Me.txtghi_chu5.Name = "txtghi_chu5"
        Me.txtghi_chu5.Size = New System.Drawing.Size(556, 20)
        Me.txtghi_chu5.TabIndex = 235
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Location = New System.Drawing.Point(5, 124)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(53, 13)
        Me.Label28.TabIndex = 236
        Me.Label28.Tag = "405"
        Me.Label28.Text = "Ghi chu 5"
        '
        'txtghi_chu4
        '
        Me.txtghi_chu4.Location = New System.Drawing.Point(99, 98)
        Me.txtghi_chu4.Name = "txtghi_chu4"
        Me.txtghi_chu4.Size = New System.Drawing.Size(556, 20)
        Me.txtghi_chu4.TabIndex = 233
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Location = New System.Drawing.Point(5, 101)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(53, 13)
        Me.Label27.TabIndex = 234
        Me.Label27.Tag = "207"
        Me.Label27.Text = "Ghi chu 4"
        '
        'txtghi_chu3
        '
        Me.txtghi_chu3.Location = New System.Drawing.Point(99, 74)
        Me.txtghi_chu3.Name = "txtghi_chu3"
        Me.txtghi_chu3.Size = New System.Drawing.Size(556, 20)
        Me.txtghi_chu3.TabIndex = 231
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Location = New System.Drawing.Point(5, 77)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(53, 13)
        Me.Label26.TabIndex = 232
        Me.Label26.Tag = "208"
        Me.Label26.Text = "Ghi chu 3"
        '
        'txtghi_chu2
        '
        Me.txtghi_chu2.Location = New System.Drawing.Point(99, 51)
        Me.txtghi_chu2.Name = "txtghi_chu2"
        Me.txtghi_chu2.Size = New System.Drawing.Size(556, 20)
        Me.txtghi_chu2.TabIndex = 229
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Location = New System.Drawing.Point(5, 54)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(53, 13)
        Me.Label24.TabIndex = 230
        Me.Label24.Tag = "411"
        Me.Label24.Text = "Ghi chu 2"
        '
        'txtghi_chu1
        '
        Me.txtghi_chu1.Location = New System.Drawing.Point(99, 28)
        Me.txtghi_chu1.Name = "txtghi_chu1"
        Me.txtghi_chu1.Size = New System.Drawing.Size(556, 20)
        Me.txtghi_chu1.TabIndex = 227
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(5, 31)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(53, 13)
        Me.Label23.TabIndex = 228
        Me.Label23.Tag = "401"
        Me.Label23.Text = "Ghi chu 1"
        '
        'ten_nv
        '
        Me.ten_nv.AutoSize = True
        Me.ten_nv.Location = New System.Drawing.Point(203, 8)
        Me.ten_nv.Name = "ten_nv"
        Me.ten_nv.Size = New System.Drawing.Size(72, 13)
        Me.ten_nv.TabIndex = 226
        Me.ten_nv.Text = "ten nhan vien"
        '
        'txtma_nv
        '
        Me.txtma_nv.Location = New System.Drawing.Point(99, 4)
        Me.txtma_nv.Name = "txtma_nv"
        Me.txtma_nv.Size = New System.Drawing.Size(100, 20)
        Me.txtma_nv.TabIndex = 224
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(5, 8)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(56, 13)
        Me.Label22.TabIndex = 225
        Me.Label22.Tag = "216"
        Me.Label22.Text = "Nhan vien"
        '
        'Txtty_gia
        '
        Me.Txtty_gia.Location = New System.Drawing.Point(299, 156)
        Me.Txtty_gia.MaxLength = 18
        Me.Txtty_gia.Name = "Txtty_gia"
        Me.Txtty_gia.NumberDecimalDigits = 0
        Me.Txtty_gia.Size = New System.Drawing.Size(100, 20)
        Me.Txtty_gia.TabIndex = 8
        Me.Txtty_gia.Text = "0"
        Me.Txtty_gia.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.Txtty_gia.Value = 0
        Me.Txtty_gia.Value2 = 0
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.Controls.Add(Me.Label15)
        Me.GroupBox2.Controls.Add(Me.txtdia_chi)
        Me.GroupBox2.Controls.Add(Me.Label14)
        Me.GroupBox2.Controls.Add(Me.txtong_ba)
        Me.GroupBox2.Controls.Add(Me.Label13)
        Me.GroupBox2.Controls.Add(Me.txtten_kh)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.txtma_kh)
        Me.GroupBox2.Location = New System.Drawing.Point(450, 25)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(480, 125)
        Me.GroupBox2.TabIndex = 18
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Tag = ""
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(10, 63)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(40, 13)
        Me.Label15.TabIndex = 11
        Me.Label15.Tag = "005"
        Me.Label15.Text = "Dia chi"
        '
        'txtdia_chi
        '
        Me.txtdia_chi.Location = New System.Drawing.Point(130, 59)
        Me.txtdia_chi.Name = "txtdia_chi"
        Me.txtdia_chi.ReadOnly = True
        Me.txtdia_chi.Size = New System.Drawing.Size(307, 20)
        Me.txtdia_chi.TabIndex = 6
        Me.txtdia_chi.TabStop = False
        Me.txtdia_chi.Tag = ""
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(10, 85)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(101, 13)
        Me.Label14.TabIndex = 9
        Me.Label14.Tag = "218"
        Me.Label14.Text = "Ten nguoi giao dich"
        '
        'txtong_ba
        '
        Me.txtong_ba.Location = New System.Drawing.Point(130, 81)
        Me.txtong_ba.Name = "txtong_ba"
        Me.txtong_ba.Size = New System.Drawing.Size(307, 20)
        Me.txtong_ba.TabIndex = 7
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(10, 41)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(86, 13)
        Me.Label13.TabIndex = 7
        Me.Label13.Tag = "002"
        Me.Label13.Text = "Ten khach hang"
        '
        'txtten_kh
        '
        Me.txtten_kh.Location = New System.Drawing.Point(130, 37)
        Me.txtten_kh.Name = "txtten_kh"
        Me.txtten_kh.ReadOnly = True
        Me.txtten_kh.Size = New System.Drawing.Size(307, 20)
        Me.txtten_kh.TabIndex = 5
        Me.txtten_kh.TabStop = False
        Me.txtten_kh.Tag = ""
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(10, 19)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(55, 13)
        Me.Label4.TabIndex = 5
        Me.Label4.Tag = "001"
        Me.Label4.Text = "Ma khach"
        '
        'txtma_kh
        '
        Me.txtma_kh.Location = New System.Drawing.Point(130, 15)
        Me.txtma_kh.Name = "txtma_kh"
        Me.txtma_kh.Size = New System.Drawing.Size(159, 20)
        Me.txtma_kh.TabIndex = 4
        Me.txtma_kh.Tag = ""
        '
        'Txtngay_ct
        '
        Me.Txtngay_ct.Location = New System.Drawing.Point(332, 42)
        Me.Txtngay_ct.Mask = "00/00/0000"
        Me.Txtngay_ct.Name = "Txtngay_ct"
        Me.Txtngay_ct.Size = New System.Drawing.Size(100, 20)
        Me.Txtngay_ct.TabIndex = 1
        Me.Txtngay_ct.Text = "01011910"
        Me.Txtngay_ct.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.Txtngay_ct.Value = New Date(1910, 1, 1, 0, 0, 0, 0)
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(6, 160)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(45, 13)
        Me.Label11.TabIndex = 37
        Me.Label11.Tag = "215"
        Me.Label11.Text = "ngoai te"
        '
        'cbbma_nt
        '
        Me.cbbma_nt.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbbma_nt.FormattingEnabled = True
        Me.cbbma_nt.Location = New System.Drawing.Point(126, 156)
        Me.cbbma_nt.Name = "cbbma_nt"
        Me.cbbma_nt.Size = New System.Drawing.Size(159, 21)
        Me.cbbma_nt.TabIndex = 7
        '
        'txtdien_giai
        '
        Me.txtdien_giai.Location = New System.Drawing.Point(126, 133)
        Me.txtdien_giai.Name = "txtdien_giai"
        Me.txtdien_giai.Size = New System.Drawing.Size(306, 20)
        Me.txtdien_giai.TabIndex = 6
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(6, 137)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(48, 13)
        Me.Label7.TabIndex = 11
        Me.Label7.Tag = "214"
        Me.Label7.Text = "Dien giai"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(235, 45)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(42, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Tag = "221"
        Me.Label2.Text = "ngay ct"
        '
        'txtso_ct
        '
        Me.txtso_ct.Location = New System.Drawing.Point(126, 42)
        Me.txtso_ct.Name = "txtso_ct"
        Me.txtso_ct.Size = New System.Drawing.Size(100, 20)
        Me.txtso_ct.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 46)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(65, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Tag = "220"
        Me.Label1.Text = "So chung tu"
        '
        'cbbstatus
        '
        Me.cbbstatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbbstatus.FormattingEnabled = True
        Me.cbbstatus.Location = New System.Drawing.Point(365, 1)
        Me.cbbstatus.Name = "cbbstatus"
        Me.cbbstatus.Size = New System.Drawing.Size(207, 21)
        Me.cbbstatus.TabIndex = 208
        Me.cbbstatus.TabStop = False
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.MediumAquamarine
        Me.Label12.Location = New System.Drawing.Point(288, 5)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(51, 13)
        Me.Label12.TabIndex = 209
        Me.Label12.Tag = "303"
        Me.Label12.Text = "trang thai"
        '
        'cbbma_gd
        '
        Me.cbbma_gd.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbbma_gd.FormattingEnabled = True
        Me.cbbma_gd.Location = New System.Drawing.Point(85, 1)
        Me.cbbma_gd.Name = "cbbma_gd"
        Me.cbbma_gd.Size = New System.Drawing.Size(197, 21)
        Me.cbbma_gd.TabIndex = 210
        Me.cbbma_gd.TabStop = False
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.BackColor = System.Drawing.Color.MediumAquamarine
        Me.Label16.Location = New System.Drawing.Point(1, 5)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(79, 13)
        Me.Label16.TabIndex = 211
        Me.Label16.Tag = "423"
        Me.Label16.Text = "Loai phieu xuat"
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label3.Location = New System.Drawing.Point(0, 440)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(56, 13)
        Me.Label3.TabIndex = 13
        Me.Label3.Tag = "090"
        Me.Label3.Text = "Nguoi tao:"
        '
        'txtnguoi_tao
        '
        Me.txtnguoi_tao.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtnguoi_tao.AutoSize = True
        Me.txtnguoi_tao.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.txtnguoi_tao.Location = New System.Drawing.Point(67, 440)
        Me.txtnguoi_tao.Name = "txtnguoi_tao"
        Me.txtnguoi_tao.Size = New System.Drawing.Size(51, 13)
        Me.txtnguoi_tao.TabIndex = 14
        Me.txtnguoi_tao.Text = "nguoi tao"
        '
        'txtngay_tao
        '
        Me.txtngay_tao.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtngay_tao.AutoSize = True
        Me.txtngay_tao.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.txtngay_tao.Location = New System.Drawing.Point(225, 440)
        Me.txtngay_tao.Name = "txtngay_tao"
        Me.txtngay_tao.Size = New System.Drawing.Size(48, 13)
        Me.txtngay_tao.TabIndex = 16
        Me.txtngay_tao.Text = "ngay tao"
        '
        'Label6
        '
        Me.Label6.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label6.AutoSize = True
        Me.Label6.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label6.Location = New System.Drawing.Point(158, 440)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(53, 13)
        Me.Label6.TabIndex = 15
        Me.Label6.Tag = "092"
        Me.Label6.Text = "Ngay tao:"
        '
        'txtngay_sua
        '
        Me.txtngay_sua.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtngay_sua.AutoSize = True
        Me.txtngay_sua.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.txtngay_sua.Location = New System.Drawing.Point(225, 455)
        Me.txtngay_sua.Name = "txtngay_sua"
        Me.txtngay_sua.Size = New System.Drawing.Size(50, 13)
        Me.txtngay_sua.TabIndex = 20
        Me.txtngay_sua.Text = "ngay sua"
        '
        'Label5
        '
        Me.Label5.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label5.AutoSize = True
        Me.Label5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label5.Location = New System.Drawing.Point(158, 455)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(55, 13)
        Me.Label5.TabIndex = 19
        Me.Label5.Tag = "093"
        Me.Label5.Text = "Ngay sua:"
        '
        'txtnguoi_sua
        '
        Me.txtnguoi_sua.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtnguoi_sua.AutoSize = True
        Me.txtnguoi_sua.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.txtnguoi_sua.Location = New System.Drawing.Point(67, 455)
        Me.txtnguoi_sua.Name = "txtnguoi_sua"
        Me.txtnguoi_sua.Size = New System.Drawing.Size(53, 13)
        Me.txtnguoi_sua.TabIndex = 18
        Me.txtnguoi_sua.Text = "nguoi sua"
        '
        'Label8
        '
        Me.Label8.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label8.AutoSize = True
        Me.Label8.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label8.Location = New System.Drawing.Point(0, 455)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(58, 13)
        Me.Label8.TabIndex = 17
        Me.Label8.Tag = "091"
        Me.Label8.Text = "Nguoi sua:"
        '
        'Label10
        '
        Me.Label10.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(527, 393)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(28, 13)
        Me.Label10.TabIndex = 108
        Me.Label10.Tag = "412"
        Me.Label10.Text = "Tien"
        '
        'btnluuandmoi
        '
        Me.btnluuandmoi.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnluuandmoi.Location = New System.Drawing.Point(87, 392)
        Me.btnluuandmoi.Name = "btnluuandmoi"
        Me.btnluuandmoi.Size = New System.Drawing.Size(82, 48)
        Me.btnluuandmoi.TabIndex = 100
        Me.btnluuandmoi.Tag = "219"
        Me.btnluuandmoi.Text = "Luu va them moi"
        Me.btnluuandmoi.UseVisualStyleBackColor = True
        '
        'Label25
        '
        Me.Label25.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label25.AutoSize = True
        Me.Label25.Location = New System.Drawing.Point(307, 393)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(75, 13)
        Me.Label25.TabIndex = 211
        Me.Label25.Tag = "418"
        Me.Label25.Text = "Tong so luong"
        '
        'Txtt_sl
        '
        Me.Txtt_sl.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Txtt_sl.Location = New System.Drawing.Point(388, 389)
        Me.Txtt_sl.MaxLength = 0
        Me.Txtt_sl.Name = "Txtt_sl"
        Me.Txtt_sl.NumberDecimalDigits = 2
        Me.Txtt_sl.ReadOnly = True
        Me.Txtt_sl.Size = New System.Drawing.Size(129, 20)
        Me.Txtt_sl.TabIndex = 210
        Me.Txtt_sl.TabStop = False
        Me.Txtt_sl.Text = "0.00"
        Me.Txtt_sl.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.Txtt_sl.Value = 0
        Me.Txtt_sl.Value2 = 0
        '
        'Txtt_tien_nt
        '
        Me.Txtt_tien_nt.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Txtt_tien_nt.Location = New System.Drawing.Point(643, 389)
        Me.Txtt_tien_nt.MaxLength = 0
        Me.Txtt_tien_nt.Name = "Txtt_tien_nt"
        Me.Txtt_tien_nt.NumberDecimalDigits = 2
        Me.Txtt_tien_nt.ReadOnly = True
        Me.Txtt_tien_nt.Size = New System.Drawing.Size(130, 20)
        Me.Txtt_tien_nt.TabIndex = 107
        Me.Txtt_tien_nt.TabStop = False
        Me.Txtt_tien_nt.Text = "0.00"
        Me.Txtt_tien_nt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.Txtt_tien_nt.Value = 0
        Me.Txtt_tien_nt.Value2 = 0
        '
        'Txtt_tien
        '
        Me.Txtt_tien.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Txtt_tien.Location = New System.Drawing.Point(777, 389)
        Me.Txtt_tien.MaxLength = 0
        Me.Txtt_tien.Name = "Txtt_tien"
        Me.Txtt_tien.NumberDecimalDigits = 0
        Me.Txtt_tien.ReadOnly = True
        Me.Txtt_tien.Size = New System.Drawing.Size(130, 20)
        Me.Txtt_tien.TabIndex = 108
        Me.Txtt_tien.TabStop = False
        Me.Txtt_tien.Text = "0"
        Me.Txtt_tien.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.Txtt_tien.Value = 0
        Me.Txtt_tien.Value2 = 0
        '
        'Label9
        '
        Me.Label9.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(527, 435)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(28, 13)
        Me.Label9.TabIndex = 214
        Me.Label9.Tag = "500"
        Me.Label9.Text = "thue"
        '
        'Txtt_thue_nt
        '
        Me.Txtt_thue_nt.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Txtt_thue_nt.Location = New System.Drawing.Point(643, 431)
        Me.Txtt_thue_nt.MaxLength = 0
        Me.Txtt_thue_nt.Name = "Txtt_thue_nt"
        Me.Txtt_thue_nt.NumberDecimalDigits = 2
        Me.Txtt_thue_nt.ReadOnly = True
        Me.Txtt_thue_nt.Size = New System.Drawing.Size(130, 20)
        Me.Txtt_thue_nt.TabIndex = 212
        Me.Txtt_thue_nt.TabStop = False
        Me.Txtt_thue_nt.Text = "0.00"
        Me.Txtt_thue_nt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.Txtt_thue_nt.Value = 0
        Me.Txtt_thue_nt.Value2 = 0
        '
        'Txtt_thue
        '
        Me.Txtt_thue.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Txtt_thue.Location = New System.Drawing.Point(777, 431)
        Me.Txtt_thue.MaxLength = 0
        Me.Txtt_thue.Name = "Txtt_thue"
        Me.Txtt_thue.NumberDecimalDigits = 0
        Me.Txtt_thue.ReadOnly = True
        Me.Txtt_thue.Size = New System.Drawing.Size(130, 20)
        Me.Txtt_thue.TabIndex = 213
        Me.Txtt_thue.TabStop = False
        Me.Txtt_thue.Text = "0"
        Me.Txtt_thue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.Txtt_thue.Value = 0
        Me.Txtt_thue.Value2 = 0
        '
        'Label17
        '
        Me.Label17.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(527, 456)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(59, 13)
        Me.Label17.TabIndex = 217
        Me.Label17.Tag = "501"
        Me.Label17.Text = "Tong cong"
        '
        'Txtt_tt_nt
        '
        Me.Txtt_tt_nt.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Txtt_tt_nt.Location = New System.Drawing.Point(643, 452)
        Me.Txtt_tt_nt.MaxLength = 0
        Me.Txtt_tt_nt.Name = "Txtt_tt_nt"
        Me.Txtt_tt_nt.NumberDecimalDigits = 2
        Me.Txtt_tt_nt.ReadOnly = True
        Me.Txtt_tt_nt.Size = New System.Drawing.Size(130, 20)
        Me.Txtt_tt_nt.TabIndex = 215
        Me.Txtt_tt_nt.TabStop = False
        Me.Txtt_tt_nt.Text = "0.00"
        Me.Txtt_tt_nt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.Txtt_tt_nt.Value = 0
        Me.Txtt_tt_nt.Value2 = 0
        '
        'Txtt_tt
        '
        Me.Txtt_tt.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Txtt_tt.Location = New System.Drawing.Point(777, 452)
        Me.Txtt_tt.MaxLength = 0
        Me.Txtt_tt.Name = "Txtt_tt"
        Me.Txtt_tt.NumberDecimalDigits = 0
        Me.Txtt_tt.ReadOnly = True
        Me.Txtt_tt.Size = New System.Drawing.Size(130, 20)
        Me.Txtt_tt.TabIndex = 216
        Me.Txtt_tt.TabStop = False
        Me.Txtt_tt.Text = "0"
        Me.Txtt_tt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.Txtt_tt.Value = 0
        Me.Txtt_tt.Value2 = 0
        '
        'toolbar
        '
        Me.toolbar.BackColor = System.Drawing.Color.MediumAquamarine
        Me.toolbar.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.toolbar.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TSDropDownGetdata})
        Me.toolbar.Location = New System.Drawing.Point(0, 0)
        Me.toolbar.Name = "toolbar"
        Me.toolbar.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.toolbar.Size = New System.Drawing.Size(912, 25)
        Me.toolbar.TabIndex = 218
        Me.toolbar.Tag = "200"
        Me.toolbar.Text = "ToolStrip1"
        '
        'TSDropDownGetdata
        '
        Me.TSDropDownGetdata.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.TSDropDownGetdata.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnLayDuLieuTuPhieuYC})
        Me.TSDropDownGetdata.Image = CType(resources.GetObject("TSDropDownGetdata.Image"), System.Drawing.Image)
        Me.TSDropDownGetdata.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TSDropDownGetdata.Name = "TSDropDownGetdata"
        Me.TSDropDownGetdata.Size = New System.Drawing.Size(77, 22)
        Me.TSDropDownGetdata.Text = "Lay du lieu"
        '
        'btnLayDuLieuTuPhieuYC
        '
        Me.btnLayDuLieuTuPhieuYC.Name = "btnLayDuLieuTuPhieuYC"
        Me.btnLayDuLieuTuPhieuYC.Size = New System.Drawing.Size(228, 22)
        Me.btnLayDuLieuTuPhieuYC.Tag = "201"
        Me.btnLayDuLieuTuPhieuYC.Text = "Lấy dữ liệu từ phiếu đặt hàng"
        '
        'Label29
        '
        Me.Label29.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label29.AutoSize = True
        Me.Label29.Location = New System.Drawing.Point(527, 414)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(58, 13)
        Me.Label29.TabIndex = 221
        Me.Label29.Tag = "TCK"
        Me.Label29.Text = "Chiết khấu"
        '
        'Txtt_ck_nt
        '
        Me.Txtt_ck_nt.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Txtt_ck_nt.Location = New System.Drawing.Point(643, 410)
        Me.Txtt_ck_nt.MaxLength = 0
        Me.Txtt_ck_nt.Name = "Txtt_ck_nt"
        Me.Txtt_ck_nt.NumberDecimalDigits = 2
        Me.Txtt_ck_nt.ReadOnly = True
        Me.Txtt_ck_nt.Size = New System.Drawing.Size(130, 20)
        Me.Txtt_ck_nt.TabIndex = 219
        Me.Txtt_ck_nt.TabStop = False
        Me.Txtt_ck_nt.Text = "0.00"
        Me.Txtt_ck_nt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.Txtt_ck_nt.Value = 0
        Me.Txtt_ck_nt.Value2 = 0
        '
        'txtt_ck
        '
        Me.txtt_ck.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtt_ck.Location = New System.Drawing.Point(777, 410)
        Me.txtt_ck.MaxLength = 0
        Me.txtt_ck.Name = "txtt_ck"
        Me.txtt_ck.NumberDecimalDigits = 0
        Me.txtt_ck.ReadOnly = True
        Me.txtt_ck.Size = New System.Drawing.Size(130, 20)
        Me.txtt_ck.TabIndex = 220
        Me.txtt_ck.TabStop = False
        Me.txtt_ck.Text = "0"
        Me.txtt_ck.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtt_ck.Value = 0
        Me.txtt_ck.Value2 = 0
        '
        'frminput
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(912, 474)
        Me.Controls.Add(Me.Label29)
        Me.Controls.Add(Me.Txtt_ck_nt)
        Me.Controls.Add(Me.txtt_ck)
        Me.Controls.Add(Me.cbbstatus)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.cbbma_gd)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.Txtt_tt_nt)
        Me.Controls.Add(Me.Txtt_tt)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Txtt_thue_nt)
        Me.Controls.Add(Me.Txtt_thue)
        Me.Controls.Add(Me.Label25)
        Me.Controls.Add(Me.Txtt_sl)
        Me.Controls.Add(Me.btnluuandmoi)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Txtt_tien_nt)
        Me.Controls.Add(Me.Txtt_tien)
        Me.Controls.Add(Me.txtngay_sua)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtnguoi_sua)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.txtngay_tao)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txtnguoi_tao)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.btnhuy)
        Me.Controls.Add(Me.btnLuu)
        Me.Controls.Add(Me.toolbar)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "frminput"
        Me.Tag = "000"
        Me.Text = "frminput"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.TabControl1.ResumeLayout(False)
        Me.tabother.ResumeLayout(False)
        Me.tabother.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.toolbar.ResumeLayout(False)
        Me.toolbar.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnLuu As System.Windows.Forms.Button
    Friend WithEvents btnhuy As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtnguoi_tao As System.Windows.Forms.Label
    Friend WithEvents txtngay_tao As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtngay_sua As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtnguoi_sua As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtma_kh As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtso_ct As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtdien_giai As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents cbbma_nt As System.Windows.Forms.ComboBox
    Friend WithEvents Txtngay_ct As ClsControl2.TxtDate
    Friend WithEvents Txtt_tien As ClsControl2.TxtNumeric
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents txtdia_chi As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txtong_ba As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txtten_kh As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Txtt_tien_nt As ClsControl2.TxtNumeric
    Friend WithEvents btnluuandmoi As System.Windows.Forms.Button
    Friend WithEvents Txtty_gia As ClsControl2.TxtNumeric
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents Txtt_sl As ClsControl2.TxtNumeric
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Txtt_thue_nt As ClsControl2.TxtNumeric
    Friend WithEvents Txtt_thue As ClsControl2.TxtNumeric
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Txtt_tt_nt As ClsControl2.TxtNumeric
    Friend WithEvents Txtt_tt As ClsControl2.TxtNumeric
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents tabother As System.Windows.Forms.TabPage
    Friend WithEvents txtso_yc As System.Windows.Forms.TextBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents txtdia_chi_giao As System.Windows.Forms.TextBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Txtngay_giao As ClsControl2.TxtDate
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents txtso_hd As System.Windows.Forms.TextBox
    Friend WithEvents so_hd As System.Windows.Forms.Label
    Friend WithEvents txtma_tt As System.Windows.Forms.TextBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents ten_tt As System.Windows.Forms.Label
    Friend WithEvents txtma_nv As System.Windows.Forms.TextBox
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents txtghi_chu5 As System.Windows.Forms.TextBox
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents txtghi_chu4 As System.Windows.Forms.TextBox
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents txtghi_chu3 As System.Windows.Forms.TextBox
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents txtghi_chu2 As System.Windows.Forms.TextBox
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents txtghi_chu1 As System.Windows.Forms.TextBox
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents ten_nv As System.Windows.Forms.Label
    Friend WithEvents cbbstatus As System.Windows.Forms.ComboBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents cbbma_gd As System.Windows.Forms.ComboBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents toolbar As System.Windows.Forms.ToolStrip
    Friend WithEvents TSDropDownGetdata As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents btnLayDuLieuTuPhieuYC As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents Txtt_ck_nt As ClsControl2.TxtNumeric
    Friend WithEvents txtt_ck As ClsControl2.TxtNumeric
End Class
