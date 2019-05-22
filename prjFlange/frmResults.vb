Option Strict Off
Option Explicit On
Friend Class frmResults
	Inherits System.Windows.Forms.Form

    '
    ' Uitvoer naar frmResults RichTextBox control
    ' tip: je kan ook laden of saven vanuit een RichTextBox
    '

    Private Sub uitvoer_2000()
        Dim s As String
        Dim mystrf As String
        Dim myvalf As String

        mystrf = "@@@@@@@@@@@@@@@@@@@@!"
        myvalf = "#0.000;;\n\u\l"


        RTB1.Clear()
        RTB1.SelectionFont = New Font("Arial", 10, FontStyle.Regular)

        RTB1.SelectionColor = System.Drawing.Color.Black
        RTB1.AppendText("== Calculation of an expansion joint acc. RTOD D0901 ==" & vbCrLf & vbCrLf)
        RTB1.AppendText("== Input data =============" & vbCrLf & vbCrLf)
        RTB1.AppendText("shellside design pressure (pds)   : " & Format(pds, myvalf) & " MPa" & vbCrLf)
        RTB1.AppendText("shellside design temperature (tds): " & Format(tds, myvalf) & " °C" & vbCrLf)
        RTB1.AppendText("tubeside design pressure (pdp)    : " & Format(pdp, myvalf) & " MPa" & vbCrLf)
        RTB1.AppendText("tubeside design temperature (tdt) : " & Format(tdt, myvalf) & " °C" & vbCrLf)
        RTB1.AppendText("tubeside test pressure  (ptp)     : " & Format(ptp, myvalf) & " barg" & vbCrLf)
        RTB1.AppendText("tube outside diameter   (Dep)     : " & Format(Dep, myvalf) & " mm" & vbCrLf)


      
        RTB1.AppendText(s & vbCrLf)
        RTB1.AppendText("== Calculation results =============" & vbCrLf & vbCrLf)

        '        RTB1.AppendText("shell allowable stress (fs) : " & Format(fs, myvalf) & " MPa" & vbCrLf)
        '        RTB1.AppendText("tube allowable stress (f2) : " & Format(f2, myvalf) & " MPa" & vbCrLf)
        '       RTB1.AppendText("tubesheet allowable stress (f) : " & Format(f, myvalf) & " MPa" & vbCrLf)

        'RTB1.AppendText("d = dnom - cass - cats - tol : " & Format(dt, myvalf) & vbCrLf)
        'RTB1.AppendText("ds                           : " & Format(ds, myvalf) & vbCrLf)
        'RTB1.AppendText("dp                           : " & Format(dp, myvalf) & vbCrLf)
        'RTB1.AppendText("ds'                          : " & Format(dsi, myvalf) & vbCrLf)
        'RTB1.AppendText("dc'                          : " & Format(dci, myvalf) & vbCrLf)
        'RTB1.AppendText("ls                           : " & Format(ls, myvalf) & vbCrLf)
        'RTB1.AppendText("lc                           : " & Format(lc, myvalf) & vbCrLf)
        'RTB1.AppendText("Dis                          : " & Format(Dis, myvalf) & vbCrLf)
        'RTB1.AppendText("A = pi/4*D2^2                : " & Format(At, myvalf) & vbCrLf)

        'RTB1.AppendText("As : " & Format(Ass, myvalf) & vbCrLf)
        'RTB1.AppendText("Ap : " & Format(Ap, myvalf) & vbCrLf)
        'RTB1.AppendText("lambda : " & Format(lambda, myvalf) & vbCrLf)
        'RTB1.AppendText("z3 : " & Format(z3, myvalf) & vbCrLf)
        'RTB1.AppendText("Ia : " & Format(Ia, myvalf) & vbCrLf)

        'RTB1.AppendText("Factor a : " & Format(a, myvalf) & vbCrLf)
        'RTB1.AppendText("Factor a1 : " & Format(a1, myvalf) & vbCrLf)
        'RTB1.AppendText("Factor a2 : " & Format(a2, myvalf) & vbCrLf)
        'RTB1.AppendText("Factor a3 : " & Format(a3, myvalf) & vbCrLf)
        'RTB1.AppendText("Factor a4 : " & Format(a4, myvalf) & vbCrLf)


        'RTB1.AppendText("Factor u1 : " & Format(u1, myvalf) & vbCrLf)
        'RTB1.AppendText("Factor u2 : " & Format(u2, myvalf) & vbCrLf)
        'RTB1.AppendText("Factor u3 : " & Format(u3, myvalf) & vbCrLf)

        'RTB1.AppendText("Factor C : " & Format(C, myvalf) & vbCrLf)
        'RTB1.AppendText("Factor C1 : " & Format(C1, myvalf) & vbCrLf)
        'RTB1.AppendText("Factor C2 : " & Format(C2, myvalf) & vbCrLf)

        'RTB1.AppendText("Tube side equivalent pressure (pp) : " & Format(pp, myvalf) & vbCrLf)
        'RTB1.AppendText("Shell side equivalent pressure (ps) : " & Format(ps, myvalf) & vbCrLf)
        'RTB1.AppendText("Thermal expansion pressure (pv) : " & Format(pv, myvalf) & vbCrLf)
        'RTB1.AppendText("Tubesheet design pressure (pd) : " & Format(pd, myvalf) & vbCrLf)
        'RTB1.AppendText("Weakening factor z : " & Format(z, myvalf) & vbCrLf & vbCrLf)

        'RTB1.AppendText("2. Tubesheet required thickness " & vbCrLf & vbCrLf)


        'RTB1.AppendText("Calculated tubesheet thickness d : ")
        'RTB1.SelectionFont = New Font("Arial", 12, FontStyle.Bold)
        'RTB1.SelectionColor = Color.Blue
        'RTB1.AppendText(Format(dcalc, myvalf) & " mm" & vbCrLf)

        'RichTextBox1.SelectionFont = New Font("Tahoma", 12, FontStyle.Bold)
        'RichTextBox1.SelectionColor = System.Drawing.Color.Red
        'richTextBox1.LoadFile("C:\MyDocument.rtf")
        'richTextBox1.Find("Text", RichTextBoxFinds.MatchCase)

        'richTextBox1.SelectionFont = New Font("Verdana", 12, FontStyle.Bold)
        'richTextBox1.SelectionColor = Color.Red

        'richTextBox1.SaveFile("C:\MyDocument.rtf", RichTextBoxStreamType.RichText)
        'RTB1.SelectionFont = New Font("Arial", 10, FontStyle.Regular)
        'RTB1.SelectionColor = Color.Black
        'RTB1.AppendText("Actual tubesheet thickness dt : " & Format(dt, myvalf) & vbCrLf & vbCrLf)

        'RTB1.AppendText("7. Strength check of the shell " & vbCrLf & vbCrLf)

        'RTB1.AppendText("              Ss1  : " & Format(Ss1, myvalf) & vbCrLf)
        'RTB1.AppendText("              Ss2  : " & Format(Ss2, myvalf) & vbCrLf)
        'RTB1.AppendText("              Ss3  : " & Format(Ss3, myvalf) & vbCrLf & vbCrLf)

        'RTB1.AppendText("6. Assesment of the tubes " & vbCrLf & vbCrLf)

        'RTB1.AppendText("              Sax1 : " & Format(Sax1, myvalf) & vbCrLf)
        'RTB1.AppendText("              Sax2 : " & Format(Sax2, myvalf) & vbCrLf)
        'RTB1.AppendText("              Sax3 : " & Format(Sax3, myvalf) & vbCrLf)
        'RTB1.AppendText("              Sax4 : " & Format(Sax4, myvalf) & vbCrLf)
        'RTB1.AppendText("              Sax5 : " & Format(Sax5, myvalf) & vbCrLf)
        'RTB1.AppendText("              Sax6 : " & Format(Sax6, myvalf) & vbCrLf)

        'RTB1.AppendText("              Stg1  : " & Format(Stg1, myvalf) & vbCrLf)
        'RTB1.AppendText("              Stg2  : " & Format(Stg2, myvalf) & vbCrLf)
        'RTB1.AppendText("              Stg3  : " & Format(Stg3, myvalf) & vbCrLf)
        'RTB1.AppendText("              Sv1 : " & Format(Sv1, myvalf) & vbCrLf)
        'RTB1.AppendText("              Sv2 : " & Format(Sv2, myvalf) & vbCrLf)
        'RTB1.AppendText("              Sv3 : " & Format(Sv3, myvalf) & vbCrLf)
        'RTB1.AppendText("              Sv4 : " & Format(Sv4, myvalf) & vbCrLf)
        'RTB1.AppendText("              Sv5 : " & Format(Sv5, myvalf) & vbCrLf)
        'RTB1.AppendText("              Sv6 : " & Format(Sv6, myvalf) & vbCrLf)
        'RTB1.AppendText("            Svmax : " & Format(Svmax, myvalf) & vbCrLf & vbCrLf)

        'RTB1.AppendText("Stability check of the tubes (lk = " & Format(lk, myvalf) & " mm) " & vbCrLf & vbCrLf)


        'RTB1.AppendText("              Sax71 : " & Format(Sax71, myvalf) & vbCrLf)
        'RTB1.AppendText("              Sax72 : " & Format(Sax72, myvalf) & vbCrLf)
        'RTB1.AppendText("              Sax73 : " & Format(Sax73, myvalf) & vbCrLf)
        'RTB1.AppendText("              Sax74 : " & Format(Sax74, myvalf) & vbCrLf)
        'RTB1.AppendText("              Sax75 : " & Format(Sax75, myvalf) & vbCrLf)
        'RTB1.AppendText("              Sax76 : " & Format(Sax76, myvalf) & vbCrLf)
        'RTB1.AppendText("               Sax7 : " & Format(Sax7, myvalf) & vbCrLf)

        ''RTB1.AppendText("               lk   : " & Format(lk, myvalf) & vbCrLf)
        'RTB1.AppendText("                k   : " & Format(k, myvalf) & vbCrLf)


        'RTB1.AppendText("         Sax7,allow : " & Format(Sax7allow, myvalf) & vbCrLf & vbCrLf)

        'RTB1.AppendText(" During testing with pt = " & Format(ptp, myvalf) & " bar " & vbCrLf)
        'RTB1.AppendText("              Stest : " & Format(Stest, myvalf) & vbCrLf)
        'RTB1.AppendText("        Stest,allow : " & Format(Stestallow, myvalf) & vbCrLf)


    End Sub
	'UPGRADE_WARNING: Form event frmResults.Activate has a new behavior. Click for more: 'ms-help://MS.VSExpressCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
	Private Sub frmResults_Activated(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Activated
		
		'
        'uitvoer()
        uitvoer_2000()
		
	End Sub
	
	Private Sub OKButton_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles OKButton.Click
		Me.Close()
		
		'UPGRADE_NOTE: Object frmResults may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSExpressCC.v80/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
        'Me = Nothing
		
	End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        'save report
        ' Displays a SaveFileDialog so the user can save 
        ' the text in richtextbox 1
        Dim saveFileDialog1 As New SaveFileDialog()

        saveFileDialog1.Filter = "RTF|*.rtf|Plain text|*.txt"
        saveFileDialog1.Title = "Save Report File"
        saveFileDialog1.ShowDialog()

        ' If the file name is not an empty string open it for saving.
        If saveFileDialog1.FileName <> "" Then
            RTB1.SaveFile(saveFileDialog1.FileName)
            ' Saves the Image via a FileStream created by the OpenFile method.
            'Dim fs As System.IO.FileStream = CType _
            '   (saveFileDialog1.OpenFile(), System.IO.FileStream)
            '' Saves the Image in the appropriate ImageFormat based upon the
            '' file type selected in the dialog box.
            '' NOTE that the FilterIndex property is one-based.
            'Select Case saveFileDialog1.FilterIndex
            '    Case 1
            '        Me.button2.Image.Save(fs, _
            '           System.Drawing.Imaging.ImageFormat.Jpeg)

            '    Case 2
            '        Me.button2.Image.Save(fs, _
            '           System.Drawing.Imaging.ImageFormat.Bmp)

            '    Case 3
            '        Me.button2.Image.Save(fs, _
            '           System.Drawing.Imaging.ImageFormat.Gif)
            'End Select

            'fs.Close()
        End If

    End Sub
End Class