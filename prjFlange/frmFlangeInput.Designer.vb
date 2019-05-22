<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmFlange
#Region "Windows Form Designer generated code "
    <System.Diagnostics.DebuggerNonUserCode()> Public Sub New()
        MyBase.New()
        'This call is required by the Windows Form Designer.
        InitializeComponent()
    End Sub
    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> Protected Overloads Overrides Sub Dispose(ByVal Disposing As Boolean)
        If Disposing Then
            If Not components Is Nothing Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(Disposing)
    End Sub
    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer
    Public WithEvents cmdCalc As System.Windows.Forms.Button
    Public WithEvents Text_y As System.Windows.Forms.TextBox
    Public WithEvents Text_m As System.Windows.Forms.TextBox
    Public WithEvents Text_bolt As System.Windows.Forms.TextBox
    Public WithEvents Text_nb As System.Windows.Forms.TextBox
    Public WithEvents Text_Ar As System.Windows.Forms.TextBox
    Public WithEvents Text_Go As System.Windows.Forms.TextBox
    Public WithEvents Label15 As System.Windows.Forms.Label
    Public WithEvents Label14 As System.Windows.Forms.Label
    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.Text_y = New System.Windows.Forms.TextBox()
        Me.Text_m = New System.Windows.Forms.TextBox()
        Me.Text_bolt = New System.Windows.Forms.TextBox()
        Me.Text_nb = New System.Windows.Forms.TextBox()
        Me.Text_Ar = New System.Windows.Forms.TextBox()
        Me.Text_Go = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.btnSelectFlangeMaterial = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Text_Sfa = New System.Windows.Forms.TextBox()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.Text_Sfo = New System.Windows.Forms.TextBox()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.Text_fa = New System.Windows.Forms.TextBox()
        Me.Text_ca = New System.Windows.Forms.TextBox()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.cbType = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Text_h1 = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Text_A = New System.Windows.Forms.TextBox()
        Me.Text_e = New System.Windows.Forms.TextBox()
        Me.Text_B = New System.Windows.Forms.TextBox()
        Me.Text_g0 = New System.Windows.Forms.TextBox()
        Me.Text_g1 = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Text_material = New System.Windows.Forms.TextBox()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.Text_P = New System.Windows.Forms.TextBox()
        Me.Text_T = New System.Windows.Forms.TextBox()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.Text_Gi = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.cbGasket = New System.Windows.Forms.ComboBox()
        Me.Label32 = New System.Windows.Forms.Label()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.btnSelectBoltMaterial = New System.Windows.Forms.Button()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Text_Sa = New System.Windows.Forms.TextBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Text_Sb = New System.Windows.Forms.TextBox()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.Text_boltsize = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Text_C = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.dlgDialogOpen = New System.Windows.Forms.OpenFileDialog()
        Me.cmdCalc = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        Me.SuspendLayout()
        '
        'Text_y
        '
        Me.Text_y.AcceptsReturn = True
        Me.Text_y.BackColor = System.Drawing.SystemColors.Window
        Me.Text_y.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.Text_y.ForeColor = System.Drawing.Color.Blue
        Me.Text_y.Location = New System.Drawing.Point(168, 176)
        Me.Text_y.MaxLength = 0
        Me.Text_y.Name = "Text_y"
        Me.Text_y.ReadOnly = True
        Me.Text_y.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Text_y.Size = New System.Drawing.Size(97, 20)
        Me.Text_y.TabIndex = 9
        Me.Text_y.Text = "y"
        '
        'Text_m
        '
        Me.Text_m.AcceptsReturn = True
        Me.Text_m.BackColor = System.Drawing.SystemColors.Window
        Me.Text_m.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.Text_m.ForeColor = System.Drawing.Color.Blue
        Me.Text_m.Location = New System.Drawing.Point(168, 144)
        Me.Text_m.MaxLength = 0
        Me.Text_m.Name = "Text_m"
        Me.Text_m.ReadOnly = True
        Me.Text_m.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Text_m.Size = New System.Drawing.Size(97, 20)
        Me.Text_m.TabIndex = 7
        Me.Text_m.Text = "m"
        '
        'Text_bolt
        '
        Me.Text_bolt.AcceptsReturn = True
        Me.Text_bolt.BackColor = System.Drawing.SystemColors.Window
        Me.Text_bolt.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.Text_bolt.ForeColor = System.Drawing.Color.Blue
        Me.Text_bolt.Location = New System.Drawing.Point(181, 149)
        Me.Text_bolt.MaxLength = 0
        Me.Text_bolt.Name = "Text_bolt"
        Me.Text_bolt.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Text_bolt.Size = New System.Drawing.Size(96, 20)
        Me.Text_bolt.TabIndex = 10
        Me.Text_bolt.Text = "SA193 B7"
        '
        'Text_nb
        '
        Me.Text_nb.AcceptsReturn = True
        Me.Text_nb.BackColor = System.Drawing.SystemColors.Window
        Me.Text_nb.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.Text_nb.ForeColor = System.Drawing.Color.Blue
        Me.Text_nb.Location = New System.Drawing.Point(181, 60)
        Me.Text_nb.MaxLength = 0
        Me.Text_nb.Name = "Text_nb"
        Me.Text_nb.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Text_nb.Size = New System.Drawing.Size(96, 20)
        Me.Text_nb.TabIndex = 3
        Me.Text_nb.Text = "nb"
        '
        'Text_Ar
        '
        Me.Text_Ar.AcceptsReturn = True
        Me.Text_Ar.BackColor = System.Drawing.SystemColors.Info
        Me.Text_Ar.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.Text_Ar.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Text_Ar.Location = New System.Drawing.Point(181, 121)
        Me.Text_Ar.MaxLength = 0
        Me.Text_Ar.Name = "Text_Ar"
        Me.Text_Ar.ReadOnly = True
        Me.Text_Ar.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Text_Ar.Size = New System.Drawing.Size(96, 20)
        Me.Text_Ar.TabIndex = 8
        '
        'Text_Go
        '
        Me.Text_Go.AcceptsReturn = True
        Me.Text_Go.BackColor = System.Drawing.SystemColors.Window
        Me.Text_Go.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.Text_Go.ForeColor = System.Drawing.Color.Blue
        Me.Text_Go.Location = New System.Drawing.Point(168, 29)
        Me.Text_Go.MaxLength = 0
        Me.Text_Go.Name = "Text_Go"
        Me.Text_Go.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Text_Go.Size = New System.Drawing.Size(97, 20)
        Me.Text_Go.TabIndex = 1
        Me.Text_Go.Text = "Go"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.BackColor = System.Drawing.SystemColors.Control
        Me.Label15.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label15.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label15.Location = New System.Drawing.Point(17, 179)
        Me.Label15.Name = "Label15"
        Me.Label15.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label15.Size = New System.Drawing.Size(86, 13)
        Me.Label15.TabIndex = 8
        Me.Label15.Text = "factor y (N/mm2)"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.BackColor = System.Drawing.SystemColors.Control
        Me.Label14.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label14.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label14.Location = New System.Drawing.Point(17, 151)
        Me.Label14.Name = "Label14"
        Me.Label14.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label14.Size = New System.Drawing.Size(45, 13)
        Me.Label14.TabIndex = 6
        Me.Label14.Text = "factor m"
        '
        'TabControl1
        '
        Me.TabControl1.Alignment = System.Windows.Forms.TabAlignment.Bottom
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Location = New System.Drawing.Point(12, 12)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(713, 341)
        Me.TabControl1.TabIndex = 52
        '
        'TabPage1
        '
        Me.TabPage1.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.TabPage1.Controls.Add(Me.btnSelectFlangeMaterial)
        Me.TabPage1.Controls.Add(Me.Label2)
        Me.TabPage1.Controls.Add(Me.Text_Sfa)
        Me.TabPage1.Controls.Add(Me.Label25)
        Me.TabPage1.Controls.Add(Me.Text_Sfo)
        Me.TabPage1.Controls.Add(Me.Label28)
        Me.TabPage1.Controls.Add(Me.Text_fa)
        Me.TabPage1.Controls.Add(Me.Text_ca)
        Me.TabPage1.Controls.Add(Me.Label26)
        Me.TabPage1.Controls.Add(Me.Label7)
        Me.TabPage1.Controls.Add(Me.cbType)
        Me.TabPage1.Controls.Add(Me.Label6)
        Me.TabPage1.Controls.Add(Me.Text_h1)
        Me.TabPage1.Controls.Add(Me.Label8)
        Me.TabPage1.Controls.Add(Me.Label9)
        Me.TabPage1.Controls.Add(Me.Label10)
        Me.TabPage1.Controls.Add(Me.Label11)
        Me.TabPage1.Controls.Add(Me.Label12)
        Me.TabPage1.Controls.Add(Me.Text_A)
        Me.TabPage1.Controls.Add(Me.Text_e)
        Me.TabPage1.Controls.Add(Me.Text_B)
        Me.TabPage1.Controls.Add(Me.Text_g0)
        Me.TabPage1.Controls.Add(Me.Text_g1)
        Me.TabPage1.Controls.Add(Me.Label4)
        Me.TabPage1.Controls.Add(Me.Text_material)
        Me.TabPage1.Controls.Add(Me.Label22)
        Me.TabPage1.Controls.Add(Me.Label23)
        Me.TabPage1.Controls.Add(Me.Text_P)
        Me.TabPage1.Controls.Add(Me.Text_T)
        Me.TabPage1.Location = New System.Drawing.Point(4, 4)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(705, 315)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Flange"
        '
        'btnSelectFlangeMaterial
        '
        Me.btnSelectFlangeMaterial.Location = New System.Drawing.Point(290, 154)
        Me.btnSelectFlangeMaterial.Name = "btnSelectFlangeMaterial"
        Me.btnSelectFlangeMaterial.Size = New System.Drawing.Size(67, 23)
        Me.btnSelectFlangeMaterial.TabIndex = 91
        Me.btnSelectFlangeMaterial.Text = "Select"
        Me.btnSelectFlangeMaterial.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.SystemColors.Control
        Me.Label2.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label2.Enabled = False
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Location = New System.Drawing.Point(15, 185)
        Me.Label2.Name = "Label2"
        Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label2.Size = New System.Drawing.Size(138, 13)
        Me.Label2.TabIndex = 90
        Me.Label2.Text = "Flange allowable at ambient"
        Me.Label2.Visible = False
        '
        'Text_Sfa
        '
        Me.Text_Sfa.AcceptsReturn = True
        Me.Text_Sfa.BackColor = System.Drawing.SystemColors.Window
        Me.Text_Sfa.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.Text_Sfa.Enabled = False
        Me.Text_Sfa.ForeColor = System.Drawing.Color.Blue
        Me.Text_Sfa.Location = New System.Drawing.Point(187, 185)
        Me.Text_Sfa.MaxLength = 0
        Me.Text_Sfa.Name = "Text_Sfa"
        Me.Text_Sfa.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Text_Sfa.Size = New System.Drawing.Size(97, 20)
        Me.Text_Sfa.TabIndex = 89
        Me.Text_Sfa.Text = "Sfa"
        Me.Text_Sfa.Visible = False
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.BackColor = System.Drawing.SystemColors.Control
        Me.Label25.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label25.Enabled = False
        Me.Label25.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label25.Location = New System.Drawing.Point(15, 218)
        Me.Label25.Name = "Label25"
        Me.Label25.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label25.Size = New System.Drawing.Size(157, 13)
        Me.Label25.TabIndex = 88
        Me.Label25.Text = "Flange allowable at temperature"
        Me.Label25.Visible = False
        '
        'Text_Sfo
        '
        Me.Text_Sfo.AcceptsReturn = True
        Me.Text_Sfo.BackColor = System.Drawing.SystemColors.Window
        Me.Text_Sfo.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.Text_Sfo.Enabled = False
        Me.Text_Sfo.ForeColor = System.Drawing.Color.Blue
        Me.Text_Sfo.Location = New System.Drawing.Point(187, 218)
        Me.Text_Sfo.MaxLength = 0
        Me.Text_Sfo.Name = "Text_Sfo"
        Me.Text_Sfo.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Text_Sfo.Size = New System.Drawing.Size(97, 20)
        Me.Text_Sfo.TabIndex = 87
        Me.Text_Sfo.Text = "Sfo"
        Me.Text_Sfo.Visible = False
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.BackColor = System.Drawing.SystemColors.Control
        Me.Label28.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label28.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label28.Location = New System.Drawing.Point(363, 156)
        Me.Label28.Name = "Label28"
        Me.Label28.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label28.Size = New System.Drawing.Size(152, 13)
        Me.Label28.TabIndex = 72
        Me.Label28.Text = "Allowance on flange face (mm)"
        '
        'Text_fa
        '
        Me.Text_fa.AcceptsReturn = True
        Me.Text_fa.BackColor = System.Drawing.SystemColors.Window
        Me.Text_fa.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.Text_fa.ForeColor = System.Drawing.Color.Blue
        Me.Text_fa.Location = New System.Drawing.Point(536, 153)
        Me.Text_fa.MaxLength = 0
        Me.Text_fa.Name = "Text_fa"
        Me.Text_fa.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Text_fa.Size = New System.Drawing.Size(97, 20)
        Me.Text_fa.TabIndex = 71
        Me.Text_fa.Text = "fa"
        '
        'Text_ca
        '
        Me.Text_ca.AcceptsReturn = True
        Me.Text_ca.BackColor = System.Drawing.SystemColors.Window
        Me.Text_ca.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.Text_ca.ForeColor = System.Drawing.Color.Blue
        Me.Text_ca.Location = New System.Drawing.Point(536, 117)
        Me.Text_ca.MaxLength = 0
        Me.Text_ca.Name = "Text_ca"
        Me.Text_ca.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Text_ca.Size = New System.Drawing.Size(97, 20)
        Me.Text_ca.TabIndex = 70
        Me.Text_ca.Text = "ca"
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.BackColor = System.Drawing.SystemColors.Control
        Me.Label26.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label26.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label26.Location = New System.Drawing.Point(363, 120)
        Me.Label26.Name = "Label26"
        Me.Label26.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label26.Size = New System.Drawing.Size(127, 13)
        Me.Label26.TabIndex = 69
        Me.Label26.Text = "Corrosion allowance (mm)"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(15, 120)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(75, 13)
        Me.Label7.TabIndex = 68
        Me.Label7.Text = "Type of flange"
        '
        'cbType
        '
        Me.cbType.ForeColor = System.Drawing.Color.Blue
        Me.cbType.FormattingEnabled = True
        Me.cbType.Location = New System.Drawing.Point(187, 117)
        Me.cbType.Name = "cbType"
        Me.cbType.Size = New System.Drawing.Size(97, 21)
        Me.cbType.TabIndex = 67
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.SystemColors.Control
        Me.Label6.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label6.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label6.Location = New System.Drawing.Point(363, 185)
        Me.Label6.Name = "Label6"
        Me.Label6.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label6.Size = New System.Drawing.Size(91, 13)
        Me.Label6.TabIndex = 64
        Me.Label6.Text = "hub length h (mm)"
        '
        'Text_h1
        '
        Me.Text_h1.AcceptsReturn = True
        Me.Text_h1.BackColor = System.Drawing.SystemColors.Window
        Me.Text_h1.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.Text_h1.ForeColor = System.Drawing.Color.Blue
        Me.Text_h1.Location = New System.Drawing.Point(536, 182)
        Me.Text_h1.MaxLength = 0
        Me.Text_h1.Name = "Text_h1"
        Me.Text_h1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Text_h1.Size = New System.Drawing.Size(97, 20)
        Me.Text_h1.TabIndex = 61
        Me.Text_h1.Text = "h1"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.SystemColors.Control
        Me.Label8.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label8.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label8.Location = New System.Drawing.Point(361, 250)
        Me.Label8.Name = "Label8"
        Me.Label8.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label8.Size = New System.Drawing.Size(139, 13)
        Me.Label8.TabIndex = 60
        Me.Label8.Text = "hub thickness large g1 (mm)"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.SystemColors.Control
        Me.Label9.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label9.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label9.Location = New System.Drawing.Point(361, 24)
        Me.Label9.Name = "Label9"
        Me.Label9.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label9.Size = New System.Drawing.Size(121, 13)
        Me.Label9.TabIndex = 56
        Me.Label9.Text = "Outside diameter A (mm)"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.SystemColors.Control
        Me.Label10.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label10.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label10.Location = New System.Drawing.Point(361, 53)
        Me.Label10.Name = "Label10"
        Me.Label10.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label10.Size = New System.Drawing.Size(87, 13)
        Me.Label10.TabIndex = 58
        Me.Label10.Text = "Thickness t (mm)"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.SystemColors.Control
        Me.Label11.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label11.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label11.Location = New System.Drawing.Point(361, 85)
        Me.Label11.Name = "Label11"
        Me.Label11.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label11.Size = New System.Drawing.Size(120, 13)
        Me.Label11.TabIndex = 57
        Me.Label11.Text = "Internal diameter B (mm)"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.SystemColors.Control
        Me.Label12.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label12.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label12.Location = New System.Drawing.Point(361, 218)
        Me.Label12.Name = "Label12"
        Me.Label12.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label12.Size = New System.Drawing.Size(139, 13)
        Me.Label12.TabIndex = 59
        Me.Label12.Text = "hub thickness small g0 (mm)"
        '
        'Text_A
        '
        Me.Text_A.AcceptsReturn = True
        Me.Text_A.BackColor = System.Drawing.SystemColors.Window
        Me.Text_A.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.Text_A.ForeColor = System.Drawing.Color.Blue
        Me.Text_A.Location = New System.Drawing.Point(536, 24)
        Me.Text_A.MaxLength = 0
        Me.Text_A.Name = "Text_A"
        Me.Text_A.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Text_A.Size = New System.Drawing.Size(97, 20)
        Me.Text_A.TabIndex = 51
        Me.Text_A.Text = "A"
        '
        'Text_e
        '
        Me.Text_e.AcceptsReturn = True
        Me.Text_e.BackColor = System.Drawing.SystemColors.Window
        Me.Text_e.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.Text_e.ForeColor = System.Drawing.Color.Blue
        Me.Text_e.Location = New System.Drawing.Point(536, 56)
        Me.Text_e.MaxLength = 0
        Me.Text_e.Name = "Text_e"
        Me.Text_e.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Text_e.Size = New System.Drawing.Size(97, 20)
        Me.Text_e.TabIndex = 52
        Me.Text_e.Text = "t"
        '
        'Text_B
        '
        Me.Text_B.AcceptsReturn = True
        Me.Text_B.BackColor = System.Drawing.SystemColors.Window
        Me.Text_B.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.Text_B.ForeColor = System.Drawing.Color.Blue
        Me.Text_B.Location = New System.Drawing.Point(536, 82)
        Me.Text_B.MaxLength = 0
        Me.Text_B.Name = "Text_B"
        Me.Text_B.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Text_B.Size = New System.Drawing.Size(97, 20)
        Me.Text_B.TabIndex = 53
        Me.Text_B.Text = "B"
        '
        'Text_g0
        '
        Me.Text_g0.AcceptsReturn = True
        Me.Text_g0.BackColor = System.Drawing.SystemColors.Window
        Me.Text_g0.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.Text_g0.ForeColor = System.Drawing.Color.Blue
        Me.Text_g0.Location = New System.Drawing.Point(536, 218)
        Me.Text_g0.MaxLength = 0
        Me.Text_g0.Name = "Text_g0"
        Me.Text_g0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Text_g0.Size = New System.Drawing.Size(97, 20)
        Me.Text_g0.TabIndex = 55
        Me.Text_g0.Text = "g0"
        '
        'Text_g1
        '
        Me.Text_g1.AcceptsReturn = True
        Me.Text_g1.BackColor = System.Drawing.SystemColors.Window
        Me.Text_g1.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.Text_g1.ForeColor = System.Drawing.Color.Blue
        Me.Text_g1.Location = New System.Drawing.Point(536, 247)
        Me.Text_g1.MaxLength = 0
        Me.Text_g1.Name = "Text_g1"
        Me.Text_g1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Text_g1.Size = New System.Drawing.Size(97, 20)
        Me.Text_g1.TabIndex = 54
        Me.Text_g1.Text = "g1"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.SystemColors.Control
        Me.Label4.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label4.Location = New System.Drawing.Point(15, 156)
        Me.Label4.Name = "Label4"
        Me.Label4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label4.Size = New System.Drawing.Size(107, 13)
        Me.Label4.TabIndex = 50
        Me.Label4.Text = "Flange material name"
        '
        'Text_material
        '
        Me.Text_material.AcceptsReturn = True
        Me.Text_material.BackColor = System.Drawing.SystemColors.Window
        Me.Text_material.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.Text_material.ForeColor = System.Drawing.Color.Blue
        Me.Text_material.Location = New System.Drawing.Point(187, 156)
        Me.Text_material.MaxLength = 0
        Me.Text_material.Name = "Text_material"
        Me.Text_material.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Text_material.Size = New System.Drawing.Size(97, 20)
        Me.Text_material.TabIndex = 49
        Me.Text_material.Text = "SA266 gr.2"
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.BackColor = System.Drawing.SystemColors.Control
        Me.Label22.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label22.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label22.Location = New System.Drawing.Point(15, 24)
        Me.Label22.Name = "Label22"
        Me.Label22.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label22.Size = New System.Drawing.Size(128, 13)
        Me.Label22.TabIndex = 40
        Me.Label22.Text = "Design Pressure (N/mm2)"
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.BackColor = System.Drawing.SystemColors.Control
        Me.Label23.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label23.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label23.Location = New System.Drawing.Point(15, 53)
        Me.Label23.Name = "Label23"
        Me.Label23.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label23.Size = New System.Drawing.Size(119, 13)
        Me.Label23.TabIndex = 42
        Me.Label23.Text = "Design temperature (°C)"
        '
        'Text_P
        '
        Me.Text_P.AcceptsReturn = True
        Me.Text_P.BackColor = System.Drawing.SystemColors.Window
        Me.Text_P.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.Text_P.ForeColor = System.Drawing.Color.Blue
        Me.Text_P.Location = New System.Drawing.Point(187, 24)
        Me.Text_P.MaxLength = 0
        Me.Text_P.Name = "Text_P"
        Me.Text_P.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Text_P.Size = New System.Drawing.Size(97, 20)
        Me.Text_P.TabIndex = 35
        Me.Text_P.Text = "P"
        '
        'Text_T
        '
        Me.Text_T.AcceptsReturn = True
        Me.Text_T.BackColor = System.Drawing.SystemColors.Window
        Me.Text_T.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.Text_T.ForeColor = System.Drawing.Color.Blue
        Me.Text_T.Location = New System.Drawing.Point(187, 56)
        Me.Text_T.MaxLength = 0
        Me.Text_T.Name = "Text_T"
        Me.Text_T.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Text_T.Size = New System.Drawing.Size(97, 20)
        Me.Text_T.TabIndex = 36
        Me.Text_T.Text = "T"
        '
        'TabPage2
        '
        Me.TabPage2.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.TabPage2.Controls.Add(Me.Text_Gi)
        Me.TabPage2.Controls.Add(Me.Label13)
        Me.TabPage2.Controls.Add(Me.Label17)
        Me.TabPage2.Controls.Add(Me.cbGasket)
        Me.TabPage2.Controls.Add(Me.Label32)
        Me.TabPage2.Controls.Add(Me.Text_y)
        Me.TabPage2.Controls.Add(Me.Text_m)
        Me.TabPage2.Controls.Add(Me.Text_Go)
        Me.TabPage2.Controls.Add(Me.Label14)
        Me.TabPage2.Controls.Add(Me.Label15)
        Me.TabPage2.Location = New System.Drawing.Point(4, 4)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(705, 315)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Gasket"
        '
        'Text_Gi
        '
        Me.Text_Gi.AcceptsReturn = True
        Me.Text_Gi.BackColor = System.Drawing.SystemColors.Window
        Me.Text_Gi.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.Text_Gi.ForeColor = System.Drawing.Color.Blue
        Me.Text_Gi.Location = New System.Drawing.Point(168, 58)
        Me.Text_Gi.MaxLength = 0
        Me.Text_Gi.Name = "Text_Gi"
        Me.Text_Gi.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Text_Gi.Size = New System.Drawing.Size(97, 20)
        Me.Text_Gi.TabIndex = 3
        Me.Text_Gi.Text = "Gi"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.SystemColors.Control
        Me.Label13.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label13.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label13.Location = New System.Drawing.Point(17, 58)
        Me.Label13.Name = "Label13"
        Me.Label13.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label13.Size = New System.Drawing.Size(115, 13)
        Me.Label13.TabIndex = 2
        Me.Label13.Text = "inside diameter Gi (mm)"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(17, 103)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(74, 13)
        Me.Label17.TabIndex = 4
        Me.Label17.Text = "type of gasket"
        '
        'cbGasket
        '
        Me.cbGasket.ForeColor = System.Drawing.Color.Blue
        Me.cbGasket.FormattingEnabled = True
        Me.cbGasket.Location = New System.Drawing.Point(166, 100)
        Me.cbGasket.Name = "cbGasket"
        Me.cbGasket.Size = New System.Drawing.Size(306, 21)
        Me.cbGasket.TabIndex = 5
        '
        'Label32
        '
        Me.Label32.AutoSize = True
        Me.Label32.BackColor = System.Drawing.SystemColors.Control
        Me.Label32.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label32.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label32.Location = New System.Drawing.Point(17, 29)
        Me.Label32.Name = "Label32"
        Me.Label32.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label32.Size = New System.Drawing.Size(126, 13)
        Me.Label32.TabIndex = 0
        Me.Label32.Text = "outside diameter Go (mm)"
        '
        'TabPage3
        '
        Me.TabPage3.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.TabPage3.Controls.Add(Me.btnSelectBoltMaterial)
        Me.TabPage3.Controls.Add(Me.Label18)
        Me.TabPage3.Controls.Add(Me.Text_Sa)
        Me.TabPage3.Controls.Add(Me.Label20)
        Me.TabPage3.Controls.Add(Me.Text_Sb)
        Me.TabPage3.Controls.Add(Me.StatusStrip1)
        Me.TabPage3.Controls.Add(Me.Text_boltsize)
        Me.TabPage3.Controls.Add(Me.Label5)
        Me.TabPage3.Controls.Add(Me.Text_C)
        Me.TabPage3.Controls.Add(Me.Label16)
        Me.TabPage3.Controls.Add(Me.Label1)
        Me.TabPage3.Controls.Add(Me.Label31)
        Me.TabPage3.Controls.Add(Me.Label29)
        Me.TabPage3.Controls.Add(Me.Text_nb)
        Me.TabPage3.Controls.Add(Me.Text_Ar)
        Me.TabPage3.Controls.Add(Me.Text_bolt)
        Me.TabPage3.Controls.Add(Me.Button2)
        Me.TabPage3.Controls.Add(Me.Panel1)
        Me.TabPage3.Location = New System.Drawing.Point(4, 4)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Size = New System.Drawing.Size(705, 315)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "Bolts"
        '
        'btnSelectBoltMaterial
        '
        Me.btnSelectBoltMaterial.Location = New System.Drawing.Point(283, 147)
        Me.btnSelectBoltMaterial.Name = "btnSelectBoltMaterial"
        Me.btnSelectBoltMaterial.Size = New System.Drawing.Size(67, 23)
        Me.btnSelectBoltMaterial.TabIndex = 92
        Me.btnSelectBoltMaterial.Text = "Select"
        Me.btnSelectBoltMaterial.UseVisualStyleBackColor = True
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.BackColor = System.Drawing.SystemColors.Control
        Me.Label18.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label18.Enabled = False
        Me.Label18.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label18.Location = New System.Drawing.Point(27, 182)
        Me.Label18.Name = "Label18"
        Me.Label18.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label18.Size = New System.Drawing.Size(124, 13)
        Me.Label18.TabIndex = 11
        Me.Label18.Text = "Bolt allowable at ambient"
        '
        'Text_Sa
        '
        Me.Text_Sa.AcceptsReturn = True
        Me.Text_Sa.BackColor = System.Drawing.SystemColors.Window
        Me.Text_Sa.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.Text_Sa.Enabled = False
        Me.Text_Sa.ForeColor = System.Drawing.Color.Blue
        Me.Text_Sa.Location = New System.Drawing.Point(181, 182)
        Me.Text_Sa.MaxLength = 0
        Me.Text_Sa.Name = "Text_Sa"
        Me.Text_Sa.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Text_Sa.Size = New System.Drawing.Size(96, 20)
        Me.Text_Sa.TabIndex = 12
        Me.Text_Sa.Text = "Sa"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.BackColor = System.Drawing.SystemColors.Control
        Me.Label20.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label20.Enabled = False
        Me.Label20.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label20.Location = New System.Drawing.Point(27, 215)
        Me.Label20.Name = "Label20"
        Me.Label20.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label20.Size = New System.Drawing.Size(143, 13)
        Me.Label20.TabIndex = 13
        Me.Label20.Text = "Bolt allowable at temperature"
        '
        'Text_Sb
        '
        Me.Text_Sb.AcceptsReturn = True
        Me.Text_Sb.BackColor = System.Drawing.SystemColors.Window
        Me.Text_Sb.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.Text_Sb.Enabled = False
        Me.Text_Sb.ForeColor = System.Drawing.Color.Blue
        Me.Text_Sb.Location = New System.Drawing.Point(181, 215)
        Me.Text_Sb.MaxLength = 0
        Me.Text_Sb.Name = "Text_Sb"
        Me.Text_Sb.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Text_Sb.Size = New System.Drawing.Size(96, 20)
        Me.Text_Sb.TabIndex = 14
        Me.Text_Sb.Text = "Sb"
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.StatusStrip1.Dock = System.Windows.Forms.DockStyle.None
        Me.StatusStrip1.Location = New System.Drawing.Point(315, 271)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(48, 22)
        Me.StatusStrip1.TabIndex = 16
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'Text_boltsize
        '
        Me.Text_boltsize.BackColor = System.Drawing.SystemColors.Info
        Me.Text_boltsize.Location = New System.Drawing.Point(181, 93)
        Me.Text_boltsize.Name = "Text_boltsize"
        Me.Text_boltsize.ReadOnly = True
        Me.Text_boltsize.Size = New System.Drawing.Size(97, 20)
        Me.Text_boltsize.TabIndex = 5
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.SystemColors.Control
        Me.Label5.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label5.Location = New System.Drawing.Point(27, 30)
        Me.Label5.Name = "Label5"
        Me.Label5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label5.Size = New System.Drawing.Size(88, 13)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "Bolt circle C (mm)"
        '
        'Text_C
        '
        Me.Text_C.AcceptsReturn = True
        Me.Text_C.BackColor = System.Drawing.SystemColors.Window
        Me.Text_C.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.Text_C.ForeColor = System.Drawing.Color.Blue
        Me.Text_C.Location = New System.Drawing.Point(181, 30)
        Me.Text_C.MaxLength = 0
        Me.Text_C.Name = "Text_C"
        Me.Text_C.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Text_C.Size = New System.Drawing.Size(96, 20)
        Me.Text_C.TabIndex = 1
        Me.Text_C.Text = "C"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(27, 152)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(63, 13)
        Me.Label16.TabIndex = 9
        Me.Label16.Text = "bolt material"
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.Control
        Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(28, 96)
        Me.Label1.Name = "Label1"
        Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label1.Size = New System.Drawing.Size(112, 13)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "bolt size "
        '
        'Label31
        '
        Me.Label31.BackColor = System.Drawing.SystemColors.Control
        Me.Label31.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label31.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label31.Location = New System.Drawing.Point(28, 121)
        Me.Label31.Name = "Label31"
        Me.Label31.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label31.Size = New System.Drawing.Size(112, 13)
        Me.Label31.TabIndex = 7
        Me.Label31.Text = "root area Ar (mm2)"
        '
        'Label29
        '
        Me.Label29.BackColor = System.Drawing.SystemColors.Control
        Me.Label29.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label29.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label29.Location = New System.Drawing.Point(28, 57)
        Me.Label29.Name = "Label29"
        Me.Label29.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label29.Size = New System.Drawing.Size(96, 13)
        Me.Label29.TabIndex = 2
        Me.Label29.Text = "number of bolts"
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(288, 93)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(34, 19)
        Me.Button2.TabIndex = 6
        Me.Button2.Text = "..."
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.SystemColors.Window
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel1.Location = New System.Drawing.Point(368, 17)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(274, 250)
        Me.Panel1.TabIndex = 15
        '
        'dlgDialogOpen
        '
        Me.dlgDialogOpen.CheckFileExists = False
        Me.dlgDialogOpen.FileName = "OpenFileDialog1"
        '
        'cmdCalc
        '
        Me.cmdCalc.BackColor = System.Drawing.SystemColors.Control
        Me.cmdCalc.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdCalc.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdCalc.Image = Global.prjFlange.My.Resources.Resources.Radio
        Me.cmdCalc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdCalc.Location = New System.Drawing.Point(239, 371)
        Me.cmdCalc.Name = "cmdCalc"
        Me.cmdCalc.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdCalc.Size = New System.Drawing.Size(165, 33)
        Me.cmdCalc.TabIndex = 0
        Me.cmdCalc.Text = "Calculate"
        Me.cmdCalc.UseVisualStyleBackColor = False
        '
        'Button1
        '
        Me.Button1.Image = Global.prjFlange.My.Resources.Resources.corpland
        Me.Button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button1.Location = New System.Drawing.Point(513, 375)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(113, 29)
        Me.Button1.TabIndex = 1
        Me.Button1.Text = "Exit"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'frmFlange
        '
        Me.AcceptButton = Me.cmdCalc
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(737, 420)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.cmdCalc)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Location = New System.Drawing.Point(4, 23)
        Me.Name = "frmFlange"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Text = "ASME Flange calculation "
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        Me.TabPage3.ResumeLayout(False)
        Me.TabPage3.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Public WithEvents Label32 As System.Windows.Forms.Label
    Public WithEvents Label31 As System.Windows.Forms.Label
    Public WithEvents Label29 As System.Windows.Forms.Label
    Public WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Public WithEvents Label22 As System.Windows.Forms.Label
    Public WithEvents Label23 As System.Windows.Forms.Label
    Public WithEvents Text_P As System.Windows.Forms.TextBox
    Public WithEvents Text_T As System.Windows.Forms.TextBox
    Public WithEvents Label6 As System.Windows.Forms.Label
    Public WithEvents Text_h1 As System.Windows.Forms.TextBox
    Public WithEvents Label8 As System.Windows.Forms.Label
    Public WithEvents Label9 As System.Windows.Forms.Label
    Public WithEvents Label10 As System.Windows.Forms.Label
    Public WithEvents Label11 As System.Windows.Forms.Label
    Public WithEvents Label12 As System.Windows.Forms.Label
    Public WithEvents Text_A As System.Windows.Forms.TextBox
    Public WithEvents Text_e As System.Windows.Forms.TextBox
    Public WithEvents Text_B As System.Windows.Forms.TextBox
    Public WithEvents Text_g0 As System.Windows.Forms.TextBox
    Public WithEvents Text_g1 As System.Windows.Forms.TextBox
    Public WithEvents Label4 As System.Windows.Forms.Label
    Public WithEvents Text_material As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents cbType As System.Windows.Forms.ComboBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents cbGasket As System.Windows.Forms.ComboBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Public WithEvents Label5 As System.Windows.Forms.Label
    Public WithEvents Text_C As System.Windows.Forms.TextBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents dlgDialogOpen As System.Windows.Forms.OpenFileDialog
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Text_boltsize As System.Windows.Forms.TextBox
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Public WithEvents Label28 As System.Windows.Forms.Label
    Public WithEvents Text_fa As System.Windows.Forms.TextBox
    Public WithEvents Text_ca As System.Windows.Forms.TextBox
    Public WithEvents Label26 As System.Windows.Forms.Label
    Public WithEvents Label2 As System.Windows.Forms.Label
    Public WithEvents Text_Sfa As System.Windows.Forms.TextBox
    Public WithEvents Label25 As System.Windows.Forms.Label
    Public WithEvents Text_Sfo As System.Windows.Forms.TextBox
    Public WithEvents Text_Gi As System.Windows.Forms.TextBox
    Public WithEvents Label13 As System.Windows.Forms.Label
    Public WithEvents Label18 As System.Windows.Forms.Label
    Public WithEvents Text_Sa As System.Windows.Forms.TextBox
    Public WithEvents Label20 As System.Windows.Forms.Label
    Public WithEvents Text_Sb As System.Windows.Forms.TextBox
    Friend WithEvents btnSelectFlangeMaterial As Button
    Friend WithEvents btnSelectBoltMaterial As Button
#End Region
End Class