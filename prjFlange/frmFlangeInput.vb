'-------------------------------------------------------
' frmFlangeInput.vb
'
' this is the main form  (Startup form)
'
' Visual Studio 2013
'-------------------------------------------------------
Option Strict Off
Option Explicit On
Imports CSBoltLib
Imports CSMaterialLib

Public Class frmFlange
    Inherits System.Windows.Forms.Form
    '----------------------------------------
    ' frmFlangeInput
    ' (main Form )
    '-----------------------------------------
    Public myBolt As CSBoltLib.BoltClass
    Public myFlange As ASME_flange
    Public myFlangeMaterial As CSMaterialLib.Material
    Public myBoltMaterial As CSMaterialLib.Material

    Dim flangeName() As String = {"Integral", "Loose", "Slipon"}

    ' schaal factor voor de panel1 box;  hoe groter getal hoe kleiner het plaatje
    Const iScaleFactor As Single = 1.5

    Private Sub cmdCalc_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdCalc.Click

        'button Calculate aangeklikt

        'retrieve input from the input form (this form)
        ReadInput()

        'calculate in flangeEN.vb of flangeASME.vb
        myFlange.Flange_calc()



        'show results on a separate form (in rtf box)
        ResultForm.Show()


    End Sub


    Private Sub frmFlangeInput_Activated(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Activated

        'ReadInput()
        'Invullen()



    End Sub

    Private Sub frmFlangeInput_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load

        Dim i As Integer

        'do things to initialise the form
        myFlange = New ASME_flange()

        myBolt = New BoltClass()

        myFlangeMaterial = Nothing
        myBoltMaterial = Nothing

        myBolt.d = 12


        'eerst de data typen initialiseren
        cbType.Items.Clear()

        For Each s As String In flangeName
            cbType.Items.Add(s)
        Next

        cbType.SelectedIndex = 0

        cbGasket.Items.Clear()
        myFlange.Init_Gaskets()
        For i = 0 To myFlange.gasketlist.Count - 1
            Dim agasket As vbGasket = DirectCast(myFlange.gasketlist(i), vbGasket)
            cbGasket.Items.Add(agasket.Name)

        Next
        cbType.SelectedIndex = 0

        'nu kan de form verder ingevuld worden
        myFlange.Init_example() ' take values from hard coded example input

        Invullen()

        'moet alvast de form vooraan zetten 
        Me.BringToFront()

  



    End Sub



    Public Sub Invullen()
        'invullen van text velden met getals waarden
        'update this form's input cells with current input values
        'may also be from a loaded file

        With myFlange
            Text_P.Text = CStr(.Pd)
            Text_T.Text = CStr(.Td)
            'Text_Pt.Text = CStr(Pt)
            'Text_nu.Text = CStr(.nu)

            'Text_Sfa.Text = CStr(.Sfa)
            'Text_Sfo.Text = CStr(.Sfo)


            Text_A.Text = .A.ToString
            Text_e.Text = .tn.ToString
            Text_B.Text = .Bn.ToString
            Text_C.Text = .C.ToString

            Text_ca.Text = .ca.ToString
            Text_fa.Text = .fall.ToString

            Text_h1.Text = .h1.ToString

            Text_g0.Text = CStr(.g0n)
            Text_g1.Text = CStr(.g1n)
            cbType.SelectedIndex = .fl_type
            If (myFlangeMaterial IsNot Nothing) Then

                Text_material.Text = .fl_mat

            End If

            Text_Go.Text = .Go.ToString
            Text_Gi.Text = .Gi.ToString

            cbGasket.SelectedIndex = .gasket_type
            Text_m.Text = .m.ToString
            Text_y.Text = .y.ToString


            Text_nb.Text = .nbolts.ToString

            'bolt data van frmSelectBolt dialog
            Text_Ar.Text = Format(.Ar, "#0.00")
            Text_boltsize.Text = .sBoltName
            If (myBoltMaterial IsNot Nothing) Then

                Text_bolt.Text = .bolt_mat
            End If

            'Text_bolt.Text = .bolt_mat

            'Text_Sa.Text = .Sa.ToString
            'Text_Sb.Text = .Sb.ToString



        End With

        'invoer velden voor bolt bijwerken
 
        'bolt cirkel plaatje bijwerken
        Panel1.Refresh()
        'bolt spacing weergeven
        myFlange.calcSpacing()


        With StatusStrip1
            .Items.Clear()
            .Items.Add("min. spacing : " & Format(myFlange.minspacing, "#.00"))
            .Items.Add("actual spacing : " & Format(myFlange.spacing, "#0.00"))
            .Items.Add("max spacing : " & Format(myFlange.maxspacing, "#0.00"))
            .Items(0).AutoSize = True
            .Items(1).AutoSize = True
            .Items(2).AutoSize = True
        End With


    End Sub

    Public Sub ReadInput()
        'alle variabelen (double vars) lezen uit de huidige text velden
        'retrieve input variables from the textbox input values
        'no error checking 

        Try
            myFlange.Pd = Double.Parse(Text_P.Text)
            myFlange.Td = Double.Parse(Text_T.Text)

            '    //Pt = CDbl(Text_Pt.Text)  test pressure niet nodig in ASME
            '   //materiaal: allowables invullen
            'myFlange.Sfa = Double.Parse(Text_Sfa.Text)
            'myFlange.Sfo = Double.Parse(Text_Sfo.Text)

            myFlange.A = Double.Parse(Text_A.Text)
            myFlange.tn = Double.Parse(Text_e.Text)
            myFlange.Bn = Double.Parse(Text_B.Text)
            myFlange.C = Double.Parse(Text_C.Text)
            myFlange.ca = Double.Parse(Text_ca.Text)
            myFlange.fall = Double.Parse(Text_fa.Text)
            myFlange.h1 = Double.Parse(Text_h1.Text)
            myFlange.g0n = Double.Parse(Text_g0.Text)
            myFlange.g1n = Double.Parse(Text_g1.Text)

            '//fl_mat = Text_material.Text
            myFlange.Go = Double.Parse(Text_Go.Text)
            myFlange.Gi = Double.Parse(Text_Gi.Text)
            myFlange.m = Double.Parse(Text_m.Text)
            myFlange.y = Double.Parse(Text_y.Text)

            'flange material was selected
            If (myFlangeMaterial IsNot Nothing) Then
                '
                myFlange.m_Rm = myFlangeMaterial.MinTensile
                myFlange.m_Re20 = myFlangeMaterial.MinYield
                myFlange.m_Re = myFlangeMaterial.Yield(myFlange.Td)

            End If

            '    //gasket_type = cbGasket.SelectedIndex
            myFlange.nbolts = Integer.Parse(Text_nb.Text)

            'bolt material was selected
            If (myBoltMaterial IsNot Nothing) Then
                '
                myFlange.m_bolt_Rm = myBoltMaterial.MinTensile
                myFlange.m_bolt_Re20 = myBoltMaterial.MinYield
                myFlange.m_bolt_Re = myBoltMaterial.Yield(myFlange.Td)
            End If

            'myFlange.Sa = Double.Parse(Text_Sa.Text)
            'myFlange.Sb = Double.Parse(Text_Sb.Text)

        Catch ex As Exception
            MessageBox.Show("---> You must enter a value <---", "Wrong Input", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try



    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        'ends the program
        Me.Close()
        End

    End Sub


    Private Sub cbGasket_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbGasket.SelectedIndexChanged

        ' als je met de combobox een andere gasket factor kiest, andere velden aanpassen
        '
        myFlange.gasket_type = cbGasket.SelectedIndex
        ' if user defined allow editing of m and y
        ' otherwise dont allow editing
        If cbGasket.SelectedIndex = 0 Then
            Text_m.ReadOnly = False
            Text_m.Enabled = True
            Text_y.ReadOnly = False
            Text_y.Enabled = True
        Else
            Text_m.ReadOnly = True
            Text_m.Enabled = False
            Text_y.ReadOnly = True
            Text_y.Enabled = False
        End If
        Dim agasket As vbGasket = DirectCast(myFlange.gasketlist(myFlange.gasket_type), vbGasket)
        'cbGasket.Items.Add(agasket.Name)
        myFlange.m = agasket.m
        myFlange.y = agasket.y

        Text_m.Text = myFlange.m.ToString
        Text_y.Text = myFlange.y.ToString

    End Sub

    Private Sub Panel1_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Panel1.Paint
        '
        '
        '---------- bijwerken van de inhoud van de panel -------------------------
        '  dit is een plaatje van de boutcirkel
        'gebruikt globale variabelen C ,  nbolts, iScaleFactor 
        'en data van huidig geselecteerde bolt (myBolt)
        '--------------------------------------------------------------------------
        'teken bout cirkel op deze form
        'nbolts is minimaal 1 
        Dim x0, y0 As Single
        Dim rcRect As Rectangle
        Dim xsize, ysize As Integer
        Dim rc1 As New Rectangle(20, 20, 50, 100)
        Dim transparentBrush As New SolidBrush(Color.FromArgb(50, Color.Yellow))

        'gebruiken van e.Graphics

        xsize = Panel1.Width
        ysize = Panel1.Height
        x0 = myFlange.C * (iScaleFactor - 1) / 2                 'bepaalt de positie vd cirkel horizontaal
        y0 = myFlange.C * (iScaleFactor - 1) / 2                 'positie verticaal

        rcRect.X = CInt(x0)
        rcRect.Y = CInt(y0)
        rcRect.Width = CInt(myFlange.C)
        rcRect.Height = CInt(myFlange.C)

        'schaal van de tekening aanpassen aan de afmeting van het object
        e.Graphics.PageScale = xsize / (myFlange.C * iScaleFactor)

        'draw the boltcircle met een stippellijn
        Dim LPen As New System.Drawing.Pen(System.Drawing.Color.Black)
        LPen.DashStyle = Drawing2D.DashStyle.Dot
        LPen.Width = 1
        e.Graphics.DrawEllipse(LPen, rcRect)

        'draw all bolts
        'on the boltcircle in equal distances
        Dim i As Integer
        Dim alfa As Double

        For i = 0 To myFlange.nbolts - 1
            Dim nx As Single
            Dim ny As Single

            alfa = i * (2 * Math.PI) / myFlange.nbolts

            nx = (myFlange.C / 2) * (1 + Math.Cos(alfa)) - (myBolt.d / 2)
            ny = (myFlange.C / 2) * (1 + Math.Sin(alfa)) - (myBolt.d / 2)

            e.Graphics.DrawEllipse(Pens.Green, rcRect.X + nx, rcRect.Y + ny, CInt(myBolt.d), CInt(myBolt.d))

        Next

    End Sub

   


    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        '
        ' user klikt om bolt te selecteren
        ' Debug.Print("open de bolt dialog")
        '  

        ' //open bolt dialog (from CSBoltLib.dll)
        Using myDialog As New CSBoltLib.frmSelectBolt("")

            '//de database moet staan in \bin\Debug of in startup path
            myDialog.sDataFile = "\\Cea_bolt.mdb"
            myDialog.sDataPath = Application.StartupPath

            myDialog.ShowDialog()
            myBolt = myDialog.myBolt


        End Using
        'de gekozen bolt info opslaan in het flange object
        myFlange.Ar = myBolt.Ab_root
        myFlange.bolt_mat = Text_bolt.Text
        myFlange.sBoltName = myBolt.szDiameter
        myFlange.d = myBolt.d
        myFlange.Emin = myBolt.E
        myFlange.Rmin = myBolt.R
        myFlange.minspacing = myBolt.minpitch

        'invoer form bijwerken
        ReadInput()
        Invullen()

       


    End Sub

    Private Sub Text_nb_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Text_nb.Leave, Text_C.Leave, Text_m.Leave, Text_e.Leave
        'number of bolts, gasket factor m, or 
        ' bijwerken voor bolt cirkel plaatje 
        ReadInput()
        Invullen()

    End Sub

   

   
    Private Sub Button3_Click(sender As System.Object, e As System.EventArgs)
        'save button


    End Sub

    Private Sub btnSelectFlangeMaterial_Click(sender As Object, e As EventArgs) Handles btnSelectFlangeMaterial.Click
        '
        ' 
        ' select material
        Dim myDialog As New frmSelectMaterial()
        myDialog.sDataFile = "\vmdb.mdb"
        ' myDialog.sDataPath = "D:\Eigen"
        myDialog.sDataPath = Application.StartupPath
        myDialog.ShowDialog()

        myFlangeMaterial = myDialog.mySelectedMaterial()
        If (myFlangeMaterial IsNot Nothing) Then
            myFlange.fl_mat = myFlangeMaterial.Name
            Text_material.Text = myFlange.fl_mat


        End If
    End Sub

    Private Sub btnSelectBoltMaterial_Click(sender As Object, e As EventArgs) Handles btnSelectBoltMaterial.Click
        '
        ' select material
        Dim myDialog As New frmSelectMaterial()
        myDialog.sDataFile = "\vmdb.mdb"
        ' myDialog.sDataPath = "D:\Eigen"
        myDialog.sDataPath = Application.StartupPath
        myDialog.ShowDialog()

        myBoltMaterial = myDialog.mySelectedMaterial()
        If (myBoltMaterial IsNot Nothing) Then
            myFlange.bolt_mat = myBoltMaterial.Name
            Text_bolt.Text = myFlange.bolt_mat

        End If
    End Sub
End Class