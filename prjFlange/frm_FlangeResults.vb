Public Class ResultForm



    Private Sub uitvoer_2000()


        Dim normalfont As New Font("Arial", 10, FontStyle.Regular)
        Dim boltfont As New Font("Arial", 10, FontStyle.Bold Or FontStyle.Underline)

        Dim myvalf As String = "#0.00;;\n\u\l"
        Dim myval2f As String = "#0.00"
        Dim myval4f As String = "#,#0.0000"
        Dim myvalef As String = "#,#0"


        RTB1.Clear()
        RTB1.SelectionFont = boltfont
        RTB1.SelectionColor = System.Drawing.Color.Black

        RTB1.AppendText("Calculation of a flange acc. ASME VIII div.1 edition 2017" & vbCrLf & vbCrLf)

        RTB1.SelectionFont = boltfont
        RTB1.AppendText("Input data" & vbCrLf & vbCrLf)

        With frmFlange.myFlange

            RTB1.AppendText("Description of flange type  :  " & vbTab)
            Select Case .fl_type
                Case ASME_flange.typeflange.fl_integral
                    RTB1.AppendText("Integral")
                Case ASME_flange.typeflange.fl_loose
                    RTB1.AppendText("Loose")
                Case ASME_flange.typeflange.fl_slipon
                    RTB1.AppendText("Slip on")

            End Select
            RTB1.AppendText(vbCrLf & vbCrLf)

            RTB1.AppendText("design pressure (pd)      : " & vbTab & Format(.Pd, myval2f) & " MPa" & vbCrLf)
            RTB1.AppendText("design temperature (td) : " & vbTab & Format(.Td, myval2f) & " °C" & vbCrLf)
            RTB1.AppendText("internal corrosion allowance (ci) : " & vbTab & Format(.ca, myval2f) & " mm" & vbCrLf)
            RTB1.AppendText("attached shell inside diameter (B) : " & vbTab & Format(.Bn, myval2f) & " mm" & vbCrLf)
            RTB1.AppendText("flange outside diameter (A)        : " & vbTab & Format(.A, myval2f) & " mm" & vbCrLf)
            RTB1.AppendText("flange thickness (t)        : " & vbTab & Format(.tn, myval2f) & " mm" & vbCrLf)
            RTB1.AppendText("thickness of hub at small end  (g0) : " & vbTab & Format(.g0n, myval2f) & " mm" & vbCrLf)
            RTB1.AppendText("thickness of hub at large end  (g1) : " & vbTab & Format(.g1n, myval2f) & " mm" & vbCrLf)
            RTB1.AppendText("length of hub  (h) : " & vbTab & Format(.h1, myval2f) & " mm" & vbCrLf)
            RTB1.AppendText(vbCrLf)
            RTB1.AppendText("flange material     : " & vbTab & .fl_mat & vbCrLf)
            RTB1.AppendText("flange allowable stress, design (Sfo)     : " & vbTab & Format(.Sfo, myval2f) & " MPa" & vbCrLf)
            RTB1.AppendText("flange allowable stress, ambient (Sfa)    : " & vbTab & Format(.Sfa, myval2f) & " MPa" & vbCrLf)
            RTB1.AppendText(vbCrLf)
            RTB1.AppendText("bolt material     : " & vbTab & .bolt_mat & vbCrLf)
            RTB1.AppendText("bolt allowable stress, design  (Sb)       : " & vbTab & Format(.Sb, myval2f) & " MPa" & vbCrLf)
            RTB1.AppendText("bolt allowable stress, ambient  (Sa)      : " & vbTab & Format(.Sa, myval2f) & " MPa" & vbCrLf)

            RTB1.AppendText(vbCrLf)
            RTB1.AppendText("diameter of bolt circle       (C) : " & vbTab & Format(.C, myval2f) & " mm" & vbCrLf)
            RTB1.AppendText("nominal bolt diameter        (d) : " & vbTab & Format(.d, myval2f) & " mm" & vbCrLf)
            RTB1.AppendText("number of bolts                  : " & vbTab & Format(.nbolts, myvalf) & vbCrLf)

            RTB1.AppendText(vbCrLf)
            RTB1.AppendText("gasket outside diameter       (Go) : " & vbTab & Format(.Go, myval2f) & " mm" & vbCrLf)
            RTB1.AppendText("gasket inside diameter        (Gi) : " & vbTab & Format(.Gi, myval2f) & " mm" & vbCrLf)
            RTB1.AppendText("gasket factor                  (m) : " & vbTab & Format(.m, myval2f) & " -" & vbCrLf)
            RTB1.AppendText("gasket design seating stress   (y) : " & vbTab & Format(.y, myval2f) & " N/mm^2" & vbCrLf)


            RTB1.AppendText(vbCrLf & vbCrLf)
            RTB1.SelectionFont = boltfont
            RTB1.AppendText("Calculation" & vbCrLf & vbCrLf)

            RTB1.AppendText("corroded flange internal diameter (B)        : " & vbTab & Format(.B.operating, myval2f) & " mm" & vbCrLf)
            RTB1.AppendText("corroded large hub thickness(g1)      : " & vbTab & Format(.g1.operating, myval2f) & " mm" & vbCrLf)
            RTB1.AppendText("corroded small hub thickness(g0)      : " & vbTab & Format(.g0.operating, myval2f) & " mm" & vbCrLf)

            RTB1.AppendText("code R dimension     (R) : " & vbTab & Format(.Ract, myval2f) & " mm" & vbCrLf)

            RTB1.AppendText("gasket contact width  (N) : " & vbTab & Format(.N, myval2f) & " mm" & vbCrLf)
            RTB1.AppendText("basic gasket seating width (b0)            : " & vbTab & Format(.b0, myval2f) & " mm" & vbCrLf)
            RTB1.AppendText("effective gasket or joint seat width (b)   : " & vbTab & Format(.be, myval2f) & " mm" & vbCrLf)
            RTB1.AppendText("gasket reaction diameter (G)               : " & vbTab & Format(.G, myval2f) & " mm" & vbCrLf)

            RTB1.AppendText(vbCrLf & vbCrLf)
            RTB1.SelectionFont = boltfont
            RTB1.AppendText("Basic Flange and Bolt Loads:" & vbCrLf & vbCrLf)
            RTB1.AppendText(vbCrLf)


            RTB1.AppendText(vbTab & vbTab & vbTab & vbTab & vbTab & vbTab & "Operating " & vbTab & vbTab & vbCrLf)
            RTB1.AppendText("hydrostatic end load due to pressure (H)   : " & vbTab & vbTab & Format(.H.operating, myvalef) & " N" & vbCrLf)
            RTB1.AppendText("contact load on gasket surfaces (Hp)   " & vbTab & vbTab & Format(.Hp.operating, myvalef) & " N" & vbCrLf)
            RTB1.AppendText("hydrostatic end load at flange id (Hd)     : " & vbTab & Format(.Hd.operating, myvalef) & " N" & vbCrLf)
            RTB1.AppendText("pressure force on flange face (Ht)         : " & vbTab & Format(.Ht.operating, myvalef) & " N" & vbCrLf)
            RTB1.AppendText("operating bolt load (Wm1)                  : " & vbTab & vbTab & Format(.Wm1, myval2f) & " N" & vbCrLf)
            RTB1.AppendText("gasket seating bolt load (Wm2)             : " & vbTab & vbTab & Format(.Wm2, myval2f) & " N" & vbCrLf)
            RTB1.AppendText("required bolt area  (Am)                   : " & vbTab & vbTab & Format(.Am.operating, myval2f) & " mm2" & vbCrLf)
            RTB1.AppendText("available bolt area (Ab)                   : " & vbTab & vbTab & Format(.Ab.operating, myval2f) & " mm2" & vbCrLf)

            If (.Ab.operating < .Am.operating) Then
                RTB1.SelectionColor = Color.Red
                RTB1.AppendText(vbCrLf & "warning: insufficient bolt area ; Ab<Abmin " & vbCrLf & vbCrLf)
            End If

            RTB1.AppendText("ASME maximum circumferential spacing between bolts per app.2 eq.(3) (Bsmax) : " & vbTab & Format(.Bsmax, myval2f) & " mm" & vbCrLf)
            RTB1.AppendText("actual circumferential bolt spacing (Bs)             : " & vbTab & Format(.Bs, myval2f) & " mm" & vbCrLf)
            RTB1.AppendText("ASME moment multiplier for bolt spacing per app.2. eq.7 (Bsc) : " & vbTab & Format(.Bsc, myval2f) & " -" & vbCrLf)

            RTB1.AppendText(vbCrLf & vbCrLf)
            RTB1.SelectionFont = boltfont
            RTB1.AppendText("Bolting information for TEMA:" & vbCrLf & vbCrLf)
            RTB1.AppendText(vbCrLf)

            RTB1.AppendText("bolt area:" & vbCrLf & vbCrLf)
            RTB1.AppendText("radial distance between hub and bolts:" & vbTab)
            RTB1.AppendText(vbCrLf)
            RTB1.AppendText("radial distance between bolts and edge:" & vbTab)
            RTB1.AppendText(vbCrLf)
            RTB1.AppendText("circumferential spacing between bolts:" & vbTab)
            RTB1.AppendText(vbCrLf)

            RTB1.AppendText("flange design bolt load, gasket seating (W)             : " & vbTab & Format(.W.operating, myvalef) & " N" & vbCrLf)
            RTB1.AppendText("gasket load for the operating condition (Hg)      : " & vbTab & Format(.Hg.operating, myvalef) & " N" & vbCrLf)

            RTB1.AppendText(vbCrLf & vbCrLf)
            RTB1.SelectionFont = boltfont
            RTB1.AppendText("Moment arm calculations:" & vbCrLf & vbCrLf)
            RTB1.AppendText(vbCrLf)

            RTB1.AppendText("distance to gasket load reaction (hg)  : " & vbTab & Format(.hg1.operating, myval2f) & " mm" & vbCrLf)
            RTB1.AppendText("distance to face pressure reaction (ht) : " & vbTab & Format(.ht1.operating, myval2f) & " mm" & vbCrLf)
            RTB1.AppendText("distance to end pressure reaction (hd) : " & vbTab & Format(.hd1.operating, myval2f) & " mm" & vbCrLf)

            RTB1.AppendText(vbCrLf & vbCrLf)
            RTB1.SelectionFont = boltfont
            RTB1.AppendText("Summary of moments for internal pressure" & vbCrLf & vbCrLf)
            RTB1.AppendText(vbCrLf)

            RTB1.AppendText("total moment on flange, operating (M,op) : " & vbTab & Format(.Mop.operating, myvalef) & " N.mm" & vbTab & vbCrLf)
            RTB1.AppendText("total moment on flange, gasket seating  (M,a)  : " & vbTab & Format(.Ma.operating, myvalef) & " N.mm" & vbTab & vbCrLf)

            RTB1.AppendText(vbCrLf & vbCrLf)
            RTB1.AppendText("Flange factors " & vbCrLf & vbCrLf)
            RTB1.AppendText(vbCrLf)

            RTB1.AppendText("factor (K)  : " & vbTab & Format(.K.operating, myval4f) & " -" & vbCrLf)
            RTB1.AppendText("factor, effective hub length (h0)  : " & vbTab & Format(.I0.operating, myval4f) & " -" & vbCrLf)
            RTB1.AppendText("factor, from fig.2-7.1 (T)  : " & vbTab & Format(.betaT.operating, myval4f) & " -" & vbCrLf)
            RTB1.AppendText("factor, from fig.2-7.1 (U)  : " & vbTab & Format(.betaU.operating, myval4f) & " -" & vbCrLf)
            RTB1.AppendText("factor, from fig.2-7.1 (Y)  : " & vbTab & Format(.betaY.operating, myval4f) & " -" & vbCrLf)
            RTB1.AppendText("factor, from fig.2-7.1 (Z)  : " & vbTab & Format(.Z.operating, myval4f) & " -" & vbCrLf)

            RTB1.AppendText("ratio g1/g0  : " & vbTab & Format(.a1.operating + 1, myval4f) & " -" & vbCrLf)
            RTB1.AppendText("ratio h/I0  : " & vbTab & Format(.h1 / .I0.operating, myval4f) & " -" & vbCrLf)

            RTB1.AppendText(vbCrLf)

            If (.g1.operating > .h1 + .g0.operating) Then
                RTB1.SelectionColor = Color.Red
                RTB1.AppendText(vbCrLf & "warning: hub slope exceeds 1:1 ; needs g1 <= h + g0 " & vbCrLf & vbCrLf)
            End If

            If .fl_type = ASME_flange.typeflange.fl_integral Then
                RTB1.AppendText("factor F  : " & vbTab & Format(.betaF.operating, "#,#0.0000") & " -" & vbTab & vbCrLf)
                RTB1.AppendText("factor V  : " & vbTab & Format(.betaV.operating, "#,#0.0000") & " -" & vbCrLf)
                RTB1.AppendText("factor f    : " & vbTab & Format(.phi.operating, "#,#0.0000") & " -" & vbCrLf)
            Else
                RTB1.AppendText("factor Fl  : " & vbTab & Format(.betafl, "#,#0.0000") & " -" & vbTab & vbCrLf)
                RTB1.AppendText("factor Vl  : " & vbTab & Format(.betavl, "#,#0.0000") & " -" & vbCrLf)
            End If

            RTB1.AppendText("factor e     : " & vbTab & Format(.factor_e.operating, "#,#0.0000") & " -" & vbCrLf)
            RTB1.AppendText("factor d     : " & vbTab & Format(.factor_d.operating, "#,#0.0000") & " -" & vbCrLf)
            RTB1.AppendText("factor L     : " & vbTab & Format(.lambda.operating, "#,#0.0000") & " -" & vbCrLf)

            RTB1.AppendText(vbCrLf)

            RTB1.AppendText(vbTab & vbTab & vbTab & vbTab & "operating" & vbTab & vbTab & "gasket seating (assembly)")

            RTB1.AppendText(vbCrLf & vbCrLf)



            RTB1.AppendText("longitudinal hub stress (Sh)  : " & vbTab & Format(.sigmaho, myvalf) _
                                                               & vbTab & "<= " & Format(.Sfo * 1.5, myvalf) _
                                                               & vbTab & Format(.sigmaha, myvalf) _
                                                               & vbTab & "<= " & Format(.Sfa * 1.5, myvalf) _
                                                               & vbTab & " N/mm2" & vbCrLf)
            RTB1.AppendText("radial flange stress (Sr)     : " & vbTab & Format(.sigmaro, myvalf) _
                                                               & vbTab & "<= " & Format(.Sfo, myvalf) _
                                                               & vbTab & Format(.sigmara, myvalf) _
                                                               & vbTab & "<= " & Format(.Sfa, myvalf) _
                                                               & vbTab & " N/mm2" & vbCrLf)
            RTB1.AppendText("tangential flange stress (St) : " & vbTab & Format(.sigmaco, myvalf) _
                                                               & vbTab & "<= " & Format(.Sfo, myvalf) _
                                                               & vbTab & Format(.sigmaca, myvalf) _
                                                               & vbTab & "<= " & Format(.Sfa, myvalf) _
                                                               & vbTab & " N/mm2" & vbCrLf)

            RTB1.AppendText("flange stress 0.5*(Sh+Sr)     : " & vbTab & Format(0.5 * (.sigmaho + .sigmaro), myvalf) _
                                                             & vbTab & vbTab & Format(0.5 * (.sigmaha + .sigmara), myvalf) _
                                                             & vbTab & vbTab & Format(0.5 * (.sigmaht + .sigmart), myvalf) _
                                                             & vbTab & " N/mm2" & vbCrLf)

            RTB1.AppendText("flange stress 0.5*(Sh + St)   : " & vbTab & Format(0.5 * (.sigmaho + .sigmaco), myvalf) _
                                                             & vbTab & vbTab & Format(0.5 * (.sigmaha + .sigmaca), myvalf) _
                                                             & vbTab & vbTab & Format(0.5 * (.sigmaht + .sigmact), myvalf) _
                                                             & vbTab & " N/mm2" & vbCrLf)

            RTB1.AppendText(vbCrLf)
         

            RTB1.AppendText(vbCrLf & vbCrLf)


            '===== display warnings and errors at the end =====
            '
            If (.Ab.operating < .Am.operating) Then
                RTB1.SelectionColor = Color.Red
                RTB1.AppendText(vbCrLf & "warning: insufficient bolt area ; Ab<Abmin " & vbCrLf _
                                & "Ab = " & Format(.Ab, myvalf) & vbTab & "Abmin = " & Format(.Am, myvalf) _
                                & vbCrLf & vbCrLf)
            End If

            If (.g1.operating > .h1 + .g0.operating) Then
                RTB1.SelectionColor = Color.Red
                RTB1.AppendText(vbCrLf & "warning: hub slope exceeds 1:1 ; needs g1 <= h + g0 " _
                                        & vbCrLf & vbCrLf)
            End If

            If (.Eact < .Emin) Then
                RTB1.SelectionColor = Color.Red
                RTB1.AppendText(vbCrLf & "warning: distance of bolt to edge exceeds TEMA minimum; needs E < Emin" & vbCrLf _
                                       & "E = " & Format(.Eact, myvalf) & vbTab & "Emin = " & Format(.Emin, myvalf) _
                                       & vbCrLf & vbCrLf)
            End If

            If (.Ract < .Rmin) Then
                RTB1.SelectionColor = Color.Red
                RTB1.AppendText(vbCrLf & "warning: distance of bolt to hub exceeds TEMA minimum; needs R < Rmin" & vbCrLf _
                                       & "R = " & Format(.Ract, myvalf) & vbTab & "Rmin = " & Format(.Rmin, myvalf) _
                                       & vbCrLf & vbCrLf)

            End If

        End With

    End Sub


    Private Sub Form1_Activated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Activated
        ' 
        ' 
        uitvoer_2000()

        'zet rtbox aan het begin
        ' RTB1.Select(0, 0)



    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Close()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        '
        'saves the output as rich text format from RTB1 richtextbox
        '
        Dim saveFileDialog1 As New SaveFileDialog()

        saveFileDialog1.Filter = "RTF|*.rtf|Plain text|*.txt"
        saveFileDialog1.Title = "Save Report File"
        saveFileDialog1.ShowDialog()

        If saveFileDialog1.FileName <> String.Empty Then
            RTB1.SaveFile(saveFileDialog1.FileName)

        End If




    End Sub
End Class