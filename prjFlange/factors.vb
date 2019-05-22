Option Strict Off
Option Explicit On
Imports System.Math
Module ts_factor
    '----------------------------------------------------------------
    ' factors.vb
    '
    ' This module implements the calculation of a tubesheet in
    ' CODAP, EN13445 and ASME
    '
    ' (c) 2008 RvS
    '
    ' 1-3-2008 beginning fixed tubesheet example BS5500; in VB6.0
    ' 18-9-2008 begonnen fixed tubesheet van RTOD; in VB 2005 express
    ' 19-3-2009 elasticiteits factoren toegevoegd 
    '----------------------------------------------------------------

   

    Public ep, mu As Double
    Public Estar, E As Double
    Public vstar As Double
    Public pat As Boolean


    'stel begin waarden in
    'als voorbeeld
    Public Sub Init_example()

        'pi is gedefinieerd 

        ' pi = System.Math.PI
        ep = 1.0
        mu = 0.2
        pat = True
        E = 200000
        Estar = 0
        vstar = 0

    End Sub
    Public Sub Test_calc()

        Estar = factor_Estar(ep, mu, pat)
        vstar = factor_vstar(ep, mu, pat)

    End Sub


    '------------------------------------------------------------
    ' Tubesheet factor E/E* = f(e/p,mu)
    ' bereken factor E*/E (elasticiteit)
    ' met formules uit ASME VIII div.2 2007 annex 5.E.
    '
    'afhankelijk van ratio dikte/pitch (ep)  en ligament efficiency (mu)
    'en pattern triangular (true) of square (false)
    'bereken voor twee waarden e/p en interpoleer daartussen
    'aannames: 0 < mu < 1 en 0.1 < e/p < 2.0 
    'getest op : 19-3-2009
    '-------------------------------------------------------------
    Public Function factor_Estar(ByVal ep As Double, ByVal mu As Double, ByVal pattern As Boolean) As Double

        Dim C1, C2, C As Double
        Dim A0, A1, A2, A3, A4, A5, A6, A7, A8 As Double
        Dim i1, i2 As Short

        Dim Erat As Double() = {0.1, 0.25, 0.5, 2.0}

        ' array met factoren uit ASME VIII div.2 2007 annex 5.E.
        '-------factoren voor triangular pattern
        Dim Etriang As Object
        Etriang = New Double(,) _
        {{0.0000149641, 66.20641, 4.301938, -33.93999, 76.72133, 1.497235, -30.12851, 16.13346, 0.0}, _
         {0.00000635263, 1151.132, 12.75654, -1643.137, 1202.564, 1257.743, -999.8214, -551.1521, 0.0}, _
         {-0.00133385, -2.55696, 0.677798, 3.994838, 0.1550319, -4.396305, -2.431697, 2.177133, 1.81901}, _
         {0.000728591, -0.7005325, 0.115169, 2.440697, 4.439786, -5.840415, -8.312674, 4.12315, 4.780299}}
        '-------factoren voor square pattern (note: A8 = 0)
        Dim Esquare As Object
        Esquare = New Double(,) _
        {{-0.000040856, 523.1431, -6.376136, 7857.623, 2284.635, -7366.96, 4844.156, 6092.597, 0.0}, _
        {-0.00048285, 8.372334, 2.947067, -9.963856, 3.710254, 7.250874, 0.0, 0.0, 0.0}, _
        {0.0000892587, 17.83577, 2.896931, -19.45644, 13.77083, 8.840783, -8.45756, 0.0, 0.0}, _
        {0.001589308, 18.14855, 2.693793, -23.74421, 9.002308, 16.27106, 0.0, 0.0, 0.0}}

        'berekening 
        If (mu < 0) Then mu = 0
        If (mu > 1) Then mu = 1
        If (ep < 0.1) Then ep = 0.1
        If (ep > 2) Then ep = 2

        If (ep >= Erat(3)) Then
            i2 = 3
            i1 = 3
        ElseIf (ep >= Erat(2)) Then
            i1 = 2
            i2 = 3
        ElseIf (ep >= Erat(1)) Then
            i1 = 1
            i2 = 2
        ElseIf (ep >= Erat(0)) Then
            i1 = 0
            i2 = 1
        End If
        If (pattern) Then
            A0 = Etriang(i2, 0)
            A1 = Etriang(i2, 1)
            A2 = Etriang(i2, 2)
            A3 = Etriang(i2, 3)
            A4 = Etriang(i2, 4)
            A5 = Etriang(i2, 5)
            A6 = Etriang(i2, 6)
            A7 = Etriang(i2, 7)
            A8 = Etriang(i2, 8)
        Else
            A0 = Esquare(i2, 0)
            A1 = Esquare(i2, 1)
            A2 = Esquare(i2, 2)
            A3 = Esquare(i2, 3)
            A4 = Esquare(i2, 4)
            A5 = Esquare(i2, 5)
            A6 = Esquare(i2, 6)
            A7 = Esquare(i2, 7)
            A8 = Esquare(i2, 8)
        End If
        C2 = (A0 + A2 * mu + A4 * mu ^ 2 + A6 * mu ^ 3 + A8 * mu ^ 4) / (1 + A1 * mu + A3 * mu ^ 2 + A5 * mu ^ 3 + A7 * mu ^ 4)
        If (pattern) Then
            A0 = Etriang(i1, 0)
            A1 = Etriang(i1, 1)
            A2 = Etriang(i1, 2)
            A3 = Etriang(i1, 3)
            A4 = Etriang(i1, 4)
            A5 = Etriang(i1, 5)
            A6 = Etriang(i1, 6)
            A7 = Etriang(i1, 7)
            A8 = Etriang(i1, 8)
        Else
            A0 = Esquare(i1, 0)
            A1 = Esquare(i1, 1)
            A2 = Esquare(i1, 2)
            A3 = Esquare(i1, 3)
            A4 = Esquare(i1, 4)
            A5 = Esquare(i1, 5)
            A6 = Esquare(i1, 6)
            A7 = Esquare(i1, 7)
            A8 = Esquare(i1, 8)
        End If

        C1 = (A0 + A2 * mu + A4 * mu ^ 2 + A6 * mu ^ 3 + A8 * mu ^ 4) / (1 + A1 * mu + A3 * mu ^ 2 + A5 * mu ^ 3 + A7 * mu ^ 4)

        'interpoleren tussen C1 en C2
        If (i2 > i1) Then
            C = C1 + (C2 - C1) * (ep - Erat(i1)) / (Erat(i2) - Erat(i1))
        Else
            C = C1
        End If
        'Debug.Print("==================")
        'Debug.Print("C1 = " & C1)
        'Debug.Print("C2 = " & C2)
        'Debug.Print("i1 = " & i1)


        factor_Estar = C

    End Function
    '------------------------------------------------------------
    ' Tubesheet factor v* = f(e/p,mu)
    ' bereken factor v* (poisson ratio)
    ' met formules uit ASME VIII div.2 2007 annex 5.E.
    '
    'afhankelijk van ratio dikte/pitch (ep)  en ligament efficiency (mu)
    'en pattern triangular (true) of square (false)
    'bereken voor twee waarden e/p en interpoleer daartussen
    'aannames: 0 < mu < 1 en 0.1 < e/p < 2.0 
    'getest op : 
    '-------------------------------------------------------------
    Public Function factor_vstar(ByVal ep As Double, ByVal mu As Double, ByVal pattern As Boolean) As Double

        Dim C1, C2, C As Double
        Dim B0, B1, B2, B3, B4, B5, B6, B7, B8, B9 As Double
        Dim i1, i2 As Short

        Dim vrat As Double() = {0.1, 0.15, 0.25, 0.5, 1.0, 2.0}

        ' array met factoren uit ASME VIII div.2 2007 annex 5.E.
        '-------factoren voor triangular pattern (note B9 = 0)
        Dim vtriang As Object
        vtriang = New Double(,) _
        {{0.01722338, -32.0315, 1.76588, 232.124, -25.93198, -217.1148, 93.57422, 110.7294, -40.95396, 0.0}, _
        {-0.7248304, -31.80156, 15.99207, 285.9222, -95.17465, -138.8896, 254.734, 72.01617, -118.2527, 0.0}, _
        {382.4487, 15394.72, 2264.094, -41758.12, -14615.39, 71526.97, 29816.78, 13871.88, 0.0, 0.0}, _
        {2.8604, 56.79314, 0.4717135, -216.6572, -37.87845, 322.6507, 83.68412, 0.0, 0.0, 0.0}, _
        {1.483591, 15.04975, -1.976814, -61.93608, -7.869233, 109.4078, 27.33155, 0.0, 0.0, 0.0}, _
        {0.9823512, 0.9655558, -2.811381, 4.633821, 5.917858, 7.097756, 0.0, 0.0, 0.0, 0.0}}

        '-------factoren voor square pattern 
        Dim vsquare As Object
        vsquare = New Double(,) _
        {{-0.07288894, -11.27111, 1.325618, 39.4977, -8.530838, -23.59313, 21.30422, 5.916208, -10.56089, 0.0}, _
        {2.089015, 119.9162, -15.35964, -754.317, 61.29051, 1921.504, -134.6693, -1921.418, 180.8025, 946.5777}, _
        {1397.869, 86786.86, 5003.924, -185719.2, -21742.19, 236300.3, 56741.45, 0.0, 0.0, 0.0}, _
        {0.4915542, 22.02591, 4.392312, -59.69066, -14.07781, 60.2203, 16.27461, 0.0, 0.0, 0.0}, _
        {0.3475156, -1.094083, -0.5737278, 4.985966, 1.875825, 0.6108286, 0.0, 0.0, 0.0, 0.0}, _
        {0.3337833, 2.923681, 1.13201, -12.0938, -4.921427, 16.56896, 6.722375, 2.496675, 0.0, 0.0}}

        'berekening 
        If (mu < 0) Then mu = 0
        If (mu > 1) Then mu = 1
        If (ep < 0.1) Then ep = 0.1
        If (ep > 2) Then ep = 2

        If (ep >= vrat(5)) Then
            i2 = 5
            i1 = 5
        ElseIf (ep >= vrat(4)) Then
            i2 = 5
            i1 = 4
        ElseIf (ep >= vrat(3)) Then
            i2 = 4
            i1 = 3
        ElseIf (ep >= vrat(2)) Then
            i2 = 3
            i1 = 2
        ElseIf (ep >= vrat(1)) Then
            i2 = 2
            i1 = 1
        ElseIf (ep >= vrat(0)) Then
            i2 = 1
            i1 = 0
        End If
        If (pattern) Then
            B0 = vtriang(i2, 0)
            B1 = vtriang(i2, 1)
            B2 = vtriang(i2, 2)
            B3 = vtriang(i2, 3)
            B4 = vtriang(i2, 4)
            B5 = vtriang(i2, 5)
            B6 = vtriang(i2, 6)
            B7 = vtriang(i2, 7)
            B8 = vtriang(i2, 8)
            B9 = vtriang(i2, 9)
        Else
            B0 = vsquare(i2, 0)
            B1 = vsquare(i2, 1)
            B2 = vsquare(i2, 2)
            B3 = vsquare(i2, 3)
            B4 = vsquare(i2, 4)
            B5 = vsquare(i2, 5)
            B6 = vsquare(i2, 6)
            B7 = vsquare(i2, 7)
            B8 = vsquare(i2, 8)
            B9 = vsquare(i2, 9)
        End If
        C2 = (B0 + B2 * mu + B4 * mu ^ 2 + B6 * mu ^ 3 + B8 * mu ^ 4) / (1 + B1 * mu + B3 * mu ^ 2 + B5 * mu ^ 3 + B7 * mu ^ 4 + B9 * mu ^ 5)
        If (pattern) Then
            B0 = vtriang(i1, 0)
            B1 = vtriang(i1, 1)
            B2 = vtriang(i1, 2)
            B3 = vtriang(i1, 3)
            B4 = vtriang(i1, 4)
            B5 = vtriang(i1, 5)
            B6 = vtriang(i1, 6)
            B7 = vtriang(i1, 7)
            B8 = vtriang(i1, 8)
            B9 = vtriang(i1, 9)
        Else
            B0 = vsquare(i1, 0)
            B1 = vsquare(i1, 1)
            B2 = vsquare(i1, 2)
            B3 = vsquare(i1, 3)
            B4 = vsquare(i1, 4)
            B5 = vsquare(i1, 5)
            B6 = vsquare(i1, 6)
            B7 = vsquare(i1, 7)
            B8 = vsquare(i1, 8)
            B9 = vsquare(i1, 9)
        End If
        C1 = (B0 + B2 * mu + B4 * mu ^ 2 + B6 * mu ^ 3 + B8 * mu ^ 4) / (1 + B1 * mu + B3 * mu ^ 2 + B5 * mu ^ 3 + B7 * mu ^ 4 + B9 * mu ^ 5)


        'interpoleren tussen C1 en C2
        If (i2 > i1) Then
            C = C1 + (C2 - C1) * (ep - vrat(i1)) / (vrat(i2) - vrat(i1))
        Else
            C = C1
        End If

        'Debug.Print("==================")
        'Debug.Print("C1 = " & C1)
        'Debug.Print("C2 = " & C2)
        'Debug.Print("i1 = " & i1)


        factor_vstar = C

    End Function
   
End Module