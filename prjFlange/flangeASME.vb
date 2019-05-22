Option Strict Off
Option Explicit On
Imports System.Math

Public Class ASME_flange
    '----------------------------------------------------------------
    ' flangeASME.vb
    '
    ' This module implements the calculation of a 
    ' narrow face flange in
    '  ASME VIII 
    '
    ' (c) 2009 RvS
    '
    ' 20-7-2009 started with input screen
    ' 27-7-2009 added loose flange type; tested and looks OK
    ' 15-11-2009 added gasket factor class and arraylist
    ' 9-12-2009 added bolt database
    ' 7-11-2014 added testcondition calculation; checked with VES software
    ' 22-9-2015 changed module to class
    '           added CSBoltLib
    '           changed to ASME 
    ' 22/5/2019 added user defined gasket factor
    '           corrected tab order
    '           added material selection database (compare with prjCylinder)
    '           extended structure mydouble with ambient condition
    '
    ' TODO:  
    '           check bolt database met TEMA
    '           berekening bolt torque 
    '           laden en saven 
    '           berekening voor externe druk

    '           plot of flange (met doorsnede)
    '----------------------------------------------------------------


    'types en constants

    Public Enum typeflange
        fl_integral
        fl_loose
        fl_slipon
    End Enum



    Structure myDouble
        Dim operating As Double     'operating = design
        Dim ambient As Double
        Dim testing As Double
    End Structure


    'zet hier de globale variabelen
    '

    'data uit frmSelectBolt dialog
    Public Ar As Double                 'bolt root area
    Public d As Double                  'bolt nominal diameter
    Public sBoltName As String          'bolt name
    Public Emin, Rmin As Double         'min distances for bolt to edge
    Public headsize As Double           'sleutelwijdte
    Public minspacing As Double         'bolt min spacing (uit bolt database)
    Public maxspacing As Double         'bolt max spacing (acc. PD5500 3.8.4.3)
    Public spacing As Double            'actual bolt spacing (calculated)


    'input variables FLANGE
    Public Pd, Td, Pt As Double
    Public m_Re20, m_Re, m_Rm As Double       'strength values for flange material
    Public nu As Double
    Public m_bolt_Re20, m_bolt_Re, m_bolt_Rm As Double    'strength values for bolt material
    Public Bn, g0n, g1n As Double
    Public A, C, Go, Gi As Double

    Public B, g0, g1 As myDouble                    'apart voor operating en testing

    Public fall, ca As Double
    Public tn, t, h1 As Double                         'flange thickness tn = nominal t = actual h1 = hub length

    Public w1, m, y As Double

    Public N As Double

    Public nbolts As Integer                         'number of bolts
    '
    Public fl_mat, bolt_mat As String
    Public fl_type As typeflange
    Public gasket_type, bolt_size As Short


    'other variables
    Public f As myDouble
    Public fb As myDouble      'allowable stresses
    Public Sfa, Sfo As Double                           'asme flange allowable stress
    Public Sa, Sb As Double                             'bolt allowable stress
    Public fbo, fbt As Double
    Public b0, be, G, Dig As Double
    Public Eact, Ract As Double                         'bolt distances
    Public Bs, Bsmax As Double                          'max bolt spacing
    Public Bsc As Double                                'moment multiplier for bolt spacing

    Public H, Hd, Ht As myDouble
    Public Hp, Hg As myDouble
    Public hd1, hg1, ht1, hl As myDouble
    Public Wa, Wop, W As myDouble
    Public Wm1, Wm2 As Double

    Public Am, Ab As myDouble                           'Am = Abmin
    Public Ma, Mop As myDouble


    Public Cf, K, I0 As myDouble
    Public a1, c1 As myDouble
    Public betaT, betaU, betaY As myDouble
    Public Z, factor_e, factor_d As myDouble                                'factor Z, e  en d alleen voor ASME
    Public betaF, betaV As myDouble
    Public betafl, betavl As Double

    Public phi, lambda As myDouble
    Public Ma1, Mop1, Mtest As Double

    Public sigmaha, sigmara, sigmaca As Double
    Public sigmaho, sigmaro, sigmaco As Double
    Public sigmaht, sigmart, sigmact As Double

    Public k1 As myDouble

    Public gasketlist As ArrayList

    'default constructor
    Public Sub ASME_flange()

        'some default values



    End Sub


    ' =======================================================================================
    '  this is the calculation for a flange acc ASME VIII app.2; similar to EN13445, PD5500, and CODAP
    '========================================================================================

    Public Sub Flange_calc()

        'determine allowable stress for flange from material data
        ' dit geldt voor koolstofstaal volgens EN13445
        ' note m_Re is de 0.2% yield
        f.operating = Min(m_Re / 1.5, m_Rm / 2.4)
        f.ambient = Min(m_Re20 / 1.5, m_Rm / 2.4)
        f.testing = m_Re20 / 1.05

        Sfo = f.operating
        Sfa = f.ambient

        'determine allowable stress for bolt from material data
        fb.operating = Min(m_bolt_Re / 3, m_Rm / 4)
        fb.ambient = Min(m_bolt_Re20 / 3, m_Rm / 4)
        fb.testing = m_bolt_Re20 / 3

        Sa = fb.ambient
        Sb = fb.operating

        '//gasket contact width
        N = (Go - Gi) / 2

        'effective gasket width
        b0 = N / 2                          'for RTJ b0 = w/8

        If (b0 <= 6.3) Then
            be = b0
        Else
            be = 2.52 * Sqrt(b0)
        End If

        '//gasket reaction diameter
        G = (Go + Gi) / 2


        If (be < 6.3) Then
            '
            G = Go + Dig
        Else
            '
            G = Go - 2 * be
        End If

        'flange actual thickness;

        t = tn - fall

        '====== check bolt distances to hub and flange od
        'note boltspacing wordt al eerder apart berekend voor update in frmFlangeInput
        Eact = (A - C) / 2
        Ract = (C - Bn) / 2 - g1n

        '======berekening voor operating (design pressure, corroded, design temperature)
        'note : pvelite gebruikt 0.785 ipv pi/4 daardoor wijken uitkomsten af

        B.operating = Bn + 2 * ca
        g0.operating = g0n - ca
        g1.operating = g1n - ca

        'hydrostatic end load due to pressure
        H.operating = PI / 4 * G ^ 2 * Pd

        'contact load on gasket surfaces
        Hp.operating = 2 * be * PI * G * m * Pd

        Hd.operating = PI / 4 * B.operating ^ 2 * Pd

        Ht.operating = H.operating - Hd.operating

        Wm1 = Max(H.operating + Hp.operating, 0)          'Wm1 = operating bolt load (Wop)
        Wm2 = PI * be * G * y                             'Wm2 = gasket seating bolt load (Wa)

        'required bolt area
        Am.operating = Max(Wm1 / Sb, Wm2 / Sa)

        'maximum bolt spacing
        Bsmax = 2 * d + 6 * t / (m + 0.5)

        'actual bolt spacing
        Bs = C * Sin(PI / nbolts)

        'moment multiplier for bolt spacing per app.2 eq.7
        Bsc = Max(Sqrt(Bs / (2 * d + t)), 1)

        'actual bolt area
        Ab.operating = nbolts * Ar

        'flange design bolt load 
        W.operating = 0.5 * (Am.operating + Ab.operating) * Sa

        'gasket load for operating condition
        Hg.operating = Wm1 - H.operating

        'moment arm calculations
        hg1.operating = (C - G) / 2
        ht1.operating = (2 * C - B.operating - G) / 4

        If fl_type = typeflange.fl_integral Then
            hd1.operating = (C - B.operating - g1.operating) / 2
        Else
            hd1.operating = (C - B.operating) / 2
        End If


        Ma.operating = W.operating * hg1.operating

        Mop.operating = Hd.operating * hd1.operating + Ht.operating * ht1.operating + Hp.operating * hg1.operating

        Cf.operating = 1          'eigenlijk nog boutdiameter erbij 

        'factor K
        K.operating = A / B.operating
        'factor h0 effective hub length
        I0.operating = Sqrt(B.operating * g0.operating)

        'bepaal flens stress factors from subroutine
        'alleen nodig voor een hubbed flange (weld neck flange)
        a1.operating = g1.operating / g0.operating - 1
        c1.operating = 48 * (1 - nu ^ 2) * (h1 / I0.operating) ^ 4

        berekenfactoren(a1.operating, c1.operating, betaF.operating, betaV.operating, phi.operating, betafl, betavl)

        'formule van ASME app.2
        betaT.operating = (K.operating ^ 2 * (1 + 8.55246 * Log10(K.operating)) - 1) / ((1.0472 + 1.9448 * K.operating ^ 2) * (K.operating - 1))

        betaU.operating = (K.operating ^ 2 * (1 + 8.55246 * Log10(K.operating)) - 1) / ((1.36136 * (K.operating ^ 2 - 1) * (K.operating - 1)))

        betaY.operating = (1 / (K.operating - 1)) * (0.66845 + 5.7169 * (K.operating ^ 2 * Log10(K.operating) / (K.operating ^ 2 - 1)))

        Z.operating = (K.operating ^ 2 + 1) / (K.operating ^ 2 - 1)

        'Ma1 = Ma.operating * Cf.operating / B.operating
        'Mop1 = Mop.operating * Cf.operating / B.operating

        If fl_type = typeflange.fl_integral Then
            factor_e.operating = betaF.operating / I0.operating
            factor_d.operating = betaU.operating * I0.operating * g0.operating ^ 2 / betaV.operating

        Else
            factor_e.operating = betafl / I0.operating
            factor_d.operating = betaU.operating * I0.operating * g0.operating ^ 2 / betavl

        End If
        lambda.operating = (t * factor_e.operating + 1) / betaT.operating + (t ^ 3) / factor_d.operating

        'stress factor
        'If B.operating < 1000 Then
        '    k1.operating = 1
        'ElseIf B.operating > 2000 Then
        '    k1.operating = 1.333
        'Else
        '    k1.operating = 0.6666 * (1 + B.operating / 2000)
        'End If

        'bereken nu de flangestresses

        Select Case fl_type
            Case typeflange.fl_integral
                sigmaha = (phi.operating * Ma.operating / B.operating) / (lambda.operating * g1.operating ^ 2)
                sigmaho = (phi.operating * Mop.operating / B.operating) / (lambda.operating * g1.operating ^ 2)

                sigmara = (1.3333 * t * factor_e.operating + 1) / (lambda.operating * t ^ 2 * B.operating) * Ma.operating
                sigmaro = (1.3333 * t * factor_e.operating + 1) / (lambda.operating * t ^ 2 * B.operating) * Mop.operating

                sigmaca = (betaY.operating * Ma.operating) / (t ^ 2 * B.operating) - (sigmara * Z.operating)
                sigmaco = (betaY.operating * Mop.operating) / (t ^ 2 * B.operating) - (sigmaro * Z.operating)

            Case typeflange.fl_loose
                sigmaha = 0
                sigmaho = 0

                sigmara = 0
                sigmaro = 0

                sigmaca = ((betaY.operating * Ma1) / t ^ 2)
                sigmaco = ((betaY.operating * Mop1) / t ^ 2)

            Case typeflange.fl_slipon
                sigmaha = (phi.operating * Ma1) / (lambda.operating * g1.operating ^ 2)
                sigmaho = (phi.operating * Mop1) / (lambda.operating * g1.operating ^ 2)

                sigmara = (1.3333 * t * betaF.operating + I0.operating) / (lambda.operating * t ^ 2 * I0.operating) * Ma1
                sigmaro = (1.3333 * t * betaF.operating + I0.operating) / (lambda.operating * t ^ 2 * I0.operating) * Mop1

                sigmaca = ((betaY.operating * Ma1) / t ^ 2) - (sigmara * (K.operating ^ 2 + 1) / (K.operating ^ 2 - 1))
                sigmaco = ((betaY.operating * Mop1) / t ^ 2) - (sigmaro * (K.operating ^ 2 + 1) / (K.operating ^ 2 - 1))

        End Select

        '======berekening voor testing (test pressure, uncorroded, at ambient temperature)
        B.testing = Bn
        g0.testing = g0n
        g1.testing = g1n

        H.testing = PI / 4 * G ^ 2 * Pt

        Hg.testing = 2 * PI * G * be * m * Pt

        Wa.testing = PI * be * G * y
        Wop.testing = H.testing + Hg.testing

        Am.testing = Max(Wop.testing / fb.testing, Wa.testing / fb.ambient)
        Ab.testing = nbolts * Ar

        Hd.testing = PI / 4 * B.testing ^ 2 * Pt
        Ht.testing = H.testing - Hd.testing

        If fl_type = typeflange.fl_integral Then
            hd1.testing = (C - B.testing - g1.testing) / 2
        Else
            hd1.testing = (C - B.testing) / 2
        End If

        hg1.testing = (C - G) / 2
        ht1.testing = (2 * C - B.testing - G) / 4

        W.testing = 0.5 * (Am.testing + Ab.testing) * fb.ambient

        Ma.testing = W.testing * hg1.testing

        Mop.testing = Hd.testing * hd1.testing + Ht.testing * ht1.testing + Hg.testing * hg1.testing

        Cf.testing = 1          'eigenlijk nog boutdiameter erbij 

        K.testing = A / B.testing
        I0.testing = Sqrt(B.testing * g0.testing)

        'bepaal flens stress factors from subroutine
        'alleen voor een hubbed flange
        a1.testing = g1.testing / g0.testing - 1
        c1.testing = 48 * (1 - nu ^ 2) * (h1 / I0.testing) ^ 4
        berekenfactoren(a1.testing, c1.testing, betaF.testing, betaV.testing, phi.testing, betafl, betavl)

        'formule van EN13445 (lijkt op ASME)
        betaT.testing = (K.testing ^ 2 * (1 + 8.55246 * Log10(K.testing)) - 1) / ((1.0472 + 1.9448 * K.testing ^ 2) * (K.testing - 1))

        betaU.testing = (K.testing ^ 2 * (1 + 8.55246 * Log10(K.testing)) - 1) / ((1.36136 * (K.testing ^ 2 - 1) * (K.testing - 1)))

        betaY.testing = (1 / (K.testing - 1)) * (0.66845 + 5.7169 * (K.testing ^ 2 * Log10(K.testing) / (K.testing ^ 2 - 1)))

        'Ma1 = Ma.testing * Cf.testing / B.testing dont need this
        Mtest = Mop.testing * Cf.testing / B.testing

        If fl_type = typeflange.fl_integral Then
            lambda.testing = (e * betaF.testing + I0.testing) / (betaT.testing * I0.testing) + (e ^ 3 * betaV.testing) / (betaU.testing * I0.testing * g0.testing ^ 2)
        Else

            lambda.testing = (e * betafl + I0.testing) / (betaT.testing * I0.testing) + (e ^ 3 * betavl) / (betaU.testing * I0.testing * g0.testing ^ 2)
        End If

        'stress factor
        If B.testing < 1000 Then
            k1.testing = 1
        ElseIf B.testing > 2000 Then
            k1.testing = 1.333
        Else
            k1.testing = 0.6666 * (1 + B.testing / 2000)
        End If

        'bereken nu de flangestresses bij testing

        Select Case fl_type
            Case typeflange.fl_integral
                sigmaht = (phi.testing * Mtest) / (lambda.testing * g1.testing ^ 2)

                sigmart = (1.3333 * e * betaF.testing + I0.testing) / (lambda.testing * e ^ 2 * I0.testing) * Mtest

                sigmact = ((betaY.testing * Mtest) / e ^ 2) - (sigmart * (K.testing ^ 2 + 1) / (K.testing ^ 2 - 1))

            Case typeflange.fl_loose
                sigmaht = 0

                sigmart = 0

                sigmact = ((betaY.testing * Mtest) / e ^ 2)

            Case typeflange.fl_slipon
                sigmaht = (phi.testing * Mtest) / (lambda.testing * g1.testing ^ 2)

                sigmart = (1.3333 * e * betaF.testing + I0.testing) / (lambda.testing * e ^ 2 * I0.testing) * Mtest

                sigmact = ((betaY.testing * Mtest) / e ^ 2) - (sigmart * (K.testing ^ 2 + 1) / (K.testing ^ 2 - 1))

        End Select




    End Sub
    'stel begin waarden in
    'als voorbeeld
    Public Sub Init_example()


        Pd = 0.59
        Td = 225

        fl_mat = "SA-965 gr.F316L"

        Sfo = 78.6
        Sfa = 115.1

        nu = 0.3
        bolt_mat = "SA-193 B7"
       
        Sb = 172.4
        Sa = 172.4

        A = 3800
        tn = 185
        Bn = 3594
        C = 3725
        ca = 0
        fall = 0
        h1 = 60
        g0n = 20
        g1n = 25
        Go = 3670
        Gi = 3638
        m = 3.75
        y = 52.4

        fl_type = typeflange.fl_integral

        bolt_size = 25.4
        gasket_type = 0

        ' bolt afmetingen
        ' 
        d = 25.4

        nbolts = 120
        sBoltName = "1"""
        Ar = 355.5
        minspacing = 52.4
        ''

    End Sub
    Public Sub calcSpacing()

        'wordt gebruikt bij readinput
        'dwz alleen invoer gegevens zijn dan bekend
        spacing = PI * C / nbolts
        maxspacing = 2 * d + 6 * tn / (m + 0.5)


    End Sub

    Sub berekenfactoren(ByVal a1 As Double, ByVal c1 As Double, ByRef F As Double, ByRef V As Double, ByRef phi As Double, ByRef F2 As Double, ByRef V2 As Double)
        '----------------------------------------------------------------------------------
        ' berekening vormfactoren voor BS5500 of EN13445 part 11 flensberekening
        ' overgenomen uit BSFLENS.BAS
        ' deze formule staat o.a. in ASME VIII div.1 app.2 en ook in EN13445

        '260 Print "     * Datum:  23 oktober 1996;         Auteur: M. Beernink.   *"
        '270 Print "     * Laatste wijziging:               Level:  0              *"
        '280 Print "     ***********************************************************"
        '  routine getest, is OK
        ' aangepast met return variabelen
        '----------------------------------------------------------------------------------

        Dim c(70) As Double

        '  Dim F, V, F1, F2, F3, V2 As Double
        Dim F1 As Double
        '21000 '   BEREKENING VORMFAKTOREN.

        '

        c(1) = 1 / 3 + a1 / 12
        c(2) = 5 / 42 + 17 * a1 / 336
        c(3) = 1 / 210 + a1 / 360
        c(4) = 11 / 360 + 59 * a1 / 5040 + (1 + 3 * a1) / c1
        c(5) = 1 / 90 + 5 * a1 / 1008 - (1 + a1) ^ 3 / c1
        c(6) = 1 / 120 + 17 * a1 / 5040 + 1 / c1
        c(7) = 215 / 2772 + 51 * a1 / 1232 + (60 / 7 + 225 * a1 / 14 + 75 * a1 ^ 2 / 7 + 5 * a1 ^ 3 / 2) / c1
        c(8) = 31 / 6930 + 128 * a1 / 45045.0! + (6 / 7 + 15 * a1 / 7 + 12 * a1 ^ 2 / 7 + 5 * a1 ^ 3 / 11) / c1
        c(9) = 533 / 30240 + 653 * a1 / 73920.0! + (1 / 2 + 33 * a1 / 14 + 39 * a1 ^ 2 / 28 + 25 * a1 ^ 3 / 84) / c1
        c(10) = 29 / 3780 + 3 * a1 / 704 - (1 / 2 + 33 * a1 / 14 + 81 * a1 ^ 2 / 28 + 13 * a1 ^ 3 / 12) / c1
        c(11) = 31 / 6048 + 1763 * a1 / 665280.0! + (1 / 2 + 6 * a1 / 7 + 15 * a1 ^ 2 / 28 + 5 * a1 ^ 3 / 42) / c1
        c(12) = 1 / 2925 + 71 * a1 / 300300.0! + (8 / 35 + 18 * a1 / 35 + 156 * a1 ^ 2 / 385 + 6 * a1 ^ 3 / 55) / c1
        c(13) = 761 / 831600.0! + 937 * a1 / 1663200.0! + (1 / 35 + 6 * a1 / 35 + 11 * a1 ^ 2 / 70 + 3 * a1 ^ 3 / 70) / c1
        c(14) = 197 / 415800.0! + 103 * a1 / 332640.0! - (1 / 35 + 6 * a1 / 35 + 17 * a1 ^ 2 / 70 + a1 ^ 3 / 10) / c1
        c(15) = 233 / 831600.0! + 97 * a1 / 554400.0! + (1 / 35 + 3 * a1 / 35 + a1 ^ 2 / 14 + 2 * a1 ^ 3 / 105) / c1
        c(16) = c(1) * c(7) * c(12) + c(2) * c(8) * c(3) + c(3) * c(8) * c(2) - (c(3) ^ 2 * c(7) + c(8) ^ 2 * c(1) + c(2) ^ 2 * c(12))
        c(17) = c(4) * c(7) * c(12) + c(2) * c(8) * c(13) + c(3) * c(8) * c(9)
        c(17) = (c(17) - (c(13) * c(7) * c(3) + c(8) ^ 2 * c(4) + c(12) * c(2) * c(9))) / c(16)
        c(18) = c(5) * c(7) * c(12) + c(2) * c(8) * c(14) + c(3) * c(8) * c(10)
        c(18) = (c(18) - (c(14) * c(7) * c(3) + c(8) ^ 2 * c(5) + c(12) * c(2) * c(10))) / c(16)
        c(19) = c(6) * c(7) * c(12) + c(2) * c(8) * c(15) + c(3) * c(8) * c(11)
        c(19) = (c(19) - (c(15) * c(7) * c(3) + c(8) ^ 2 * c(6) + c(12) * c(2) * c(11))) / c(16)
        c(20) = c(1) * c(9) * c(12) + c(4) * c(8) * c(3) + c(3) * c(13) * c(2)
        c(20) = (c(20) - (c(3) ^ 2 * c(9) + c(13) * c(8) * c(1) + c(12) * c(4) * c(2))) / c(16)
        c(21) = c(1) * c(10) * c(12) + c(5) * c(8) * c(3) + c(3) * c(14) * c(2)
        c(21) = (c(21) - (c(3) ^ 2 * c(10) + c(14) * c(8) * c(1) + c(12) * c(5) * c(2))) / c(16)
        c(22) = c(1) * c(11) * c(12) + c(6) * c(8) * c(3) + c(3) * c(15) * c(2)
        c(22) = (c(22) - (c(3) ^ 2 * c(11) + c(15) * c(8) * c(1) + c(12) * c(6) * c(2))) / c(16)
        c(23) = c(1) * c(7) * c(13) + c(2) * c(9) * c(3) + c(4) * c(8) * c(2)
        c(23) = (c(23) - (c(3) * c(7) * c(4) + c(8) * c(9) * c(1) + c(2) ^ 2 * c(13))) / c(16)
        c(24) = c(1) * c(7) * c(14) + c(2) * c(10) * c(3) + c(5) * c(8) * c(2)
        c(24) = (c(24) - (c(3) * c(7) * c(5) + c(8) * c(10) * c(1) + c(2) ^ 2 * c(14))) / c(16)
        c(25) = c(1) * c(7) * c(15) + c(2) * c(11) * c(3) + c(6) * c(8) * c(2)
        c(25) = (c(25) - (c(3) * c(7) * c(6) + c(8) * c(11) * c(1) + c(2) ^ 2 * c(15))) / c(16)
        c(26) = -(c1 / 4) ^ 0.25
        c(27) = c(20) - c(17) - 5 / 12 - c(17) * (c1 / 4) ^ 0.25
        c(28) = c(22) - c(19) - 1 / 12 - c(19) * (c1 / 4) ^ 0.25
        c(29) = -(c1 / 4) ^ 0.5
        c(30) = -(c1 / 4) ^ 0.75
        c(31) = 3 * a1 / 2 + c(17) * (c1 / 4) ^ 0.75
        c(32) = 0.5 + c(19) * (c1 / 4) ^ 0.75
        c(33) = 0.5 * c(26) * c(32) + c(28) * c(31) * c(29) - (0.5 * c(30) * c(28) + c(32) * c(27) * c(29))
        c(34) = 1 / 12 + c(18) - c(21) + c(18) * (c1 / 4) ^ 0.25
        c(35) = -c(18) * (c1 / 4) ^ 0.75
        c(36) = (c(28) * c(35) * c(29) - c(32) * c(34) * c(29)) / c(33)
        c(37) = (0.5 * c(26) * c(35) + c(34) * c(31) * c(29) - (0.5 * c(30) * c(34) + c(35) * c(27) * c(29))) / c(33)
        c(38) = 0 : c(39) = 0 : c(40) = 0
        c(41) = c(17) * c(36) + c(18) + c(19) * c(37)
        c(42) = c(20) * c(36) + c(21) + c(22) * c(37)
        c(43) = c(23) * c(36) + c(24) + c(25) * c(37)
        c(44) = 1 / 4 + c(37) / 12 + c(36) / 4 - c(43) / 5 - 3 * c(42) / 2 - c(41)
        c(45) = c(41) * (1 / 2 + a1 / 6) + c(42) * (1 / 4 + 11 * a1 / 84) + c(43) * (1 / 70 + a1 / 105)
        c(46) = c(45) - c(36) * (7 / 120 + a1 / 36 + 3 * a1 / c1) - 1 / 40 - a1 / 72 - c(37) * (1 / 60 + a1 / 120 + 1 / c1)
        F = -c(46) / ((c1 / 2.73) ^ 0.25 * (1 + a1) ^ 3 / c1)
        V = c(44) / ((2.73 / c1) ^ 0.25 * (1 + a1) ^ 3)
        F1 = c(36) / (1 + a1)
        F2 = c(18) * (1 / 2 + a1 / 6) + c(21) * (1 / 4 + 11 * a1 / 84) + c(24) * (1 / 70 + a1 / 105) - (1 / 40 + a1 / 72)
        F2 = -F2 / ((c1 / 2.73) ^ 0.25 * (1 + a1) ^ 3 / c1)
        V2 = (1 / 4 - c(24) / 5 - 3 * c(21) / 2 - c(18)) / ((2.73 / c1) ^ 0.25 * (1 + a1) ^ 3)

        phi = Max(F1, 1)


    End Sub

    Sub Init_Gaskets()
        '
        ' initialize the list with gasket factors (acc. EN and ASME)
        ' with the hard coded data; once at beginning of the program
        ' this is basically an array with vbGasket class objects
        ' the current selected gasket is gasket_type
        '
        gasketlist = New ArrayList()
        gasketlist.Add(New vbGasket("user defined", 0, 0))
        gasketlist.Add(New vbGasket("elastomer without fabric (rubber),  <75 IRH", 0.5, 0.0))
        gasketlist.Add(New vbGasket("elastomer without fabric (rubber),  >75 IRH", 1.0, 1.4))
        gasketlist.Add(New vbGasket("asbestos, 3.2 mm	", 2.0, 11.0))
        gasketlist.Add(New vbGasket("asbestos, 1.6 mm	", 2.75, 25.5))
        gasketlist.Add(New vbGasket("asbestos, 0.8 mm	", 3.5, 44.8))
        gasketlist.Add(New vbGasket("elastomer (rubber) with cotton fabric	", 1.25, 2.8))
        gasketlist.Add(New vbGasket("rubber with asbestos fabric (3-ply)	", 2.25, 15.2))
        gasketlist.Add(New vbGasket("rubber with asbestos fabric (2-ply)	", 2.5, 20.0))
        gasketlist.Add(New vbGasket("rubber with asbestos fabric (1-ply)	", 2.75, 25.5))
        gasketlist.Add(New vbGasket("vegetable fibre	", 1.75, 7.6))
        gasketlist.Add(New vbGasket("spiral wound metal, with filler (carbon)	", 2.5, 69.0))
        gasketlist.Add(New vbGasket("spiral wound metal, with filler (SS/monel)	", 3.0, 69.0))
        gasketlist.Add(New vbGasket("corrugated metal, asb. insert, soft aluminium	", 2.5, 20.0))
        gasketlist.Add(New vbGasket("corrugated metal, asb. insert, soft copper	", 2.75, 25.5))
        gasketlist.Add(New vbGasket("corrugated metal, asb. insert, soft steel	", 3.0, 31.0))
        gasketlist.Add(New vbGasket("corrugated metal, asb. insert, monel or chrome	", 3.25, 37.9))
        gasketlist.Add(New vbGasket("corrugated metal, asb. insert, stainless steel	", 3.5, 44.8))
        gasketlist.Add(New vbGasket("corrugated metal, jacketed filled, soft aluminium	", 2.75, 25.5))
        gasketlist.Add(New vbGasket("corrugated metal, jacketed filled, soft copper 	", 3.0, 31.0))
        gasketlist.Add(New vbGasket("corrugated metal, jacketed filled, soft steel	", 3.25, 37.9))
        gasketlist.Add(New vbGasket("corrugated metal, jacketed filled, monel or chrome	", 3.5, 44.8))
        gasketlist.Add(New vbGasket("corrugated metal, jacketed filled, stainless steel	", 3.75, 52.4))
        gasketlist.Add(New vbGasket("flat metal jacketed, asbestos filled, soft aluminium	", 3.25, 37.9))
        gasketlist.Add(New vbGasket("flat metal jacketed, asbestos filled, soft copper	", 3.5, 44.8))
        gasketlist.Add(New vbGasket("flat metal jacketed, asbestos filled, soft steel	", 3.75, 52.4))
        gasketlist.Add(New vbGasket("flat metal jacketed, asbestos filled, monel	", 3.5, 55.1))
        gasketlist.Add(New vbGasket("flat metal jacketed, asbestos filled, 4 to 6 chrome	", 3.75, 62.0))
        gasketlist.Add(New vbGasket("flat metal jacketed, asbestos filled, stainless steel	", 3.75, 62.0))
        gasketlist.Add(New vbGasket("grooved metal, soft aluminium	", 3.25, 37.9))
        gasketlist.Add(New vbGasket("grooved metal, soft copper	", 3.5, 44.8))
        gasketlist.Add(New vbGasket("grooved metal, soft steel	", 3.75, 52.4))
        gasketlist.Add(New vbGasket("grooved metal, monel or chrome	", 3.75, 62.0))
        gasketlist.Add(New vbGasket("grooved metal, stainless steel	", 4.25, 69.5))
        gasketlist.Add(New vbGasket("solid flat metal, soft aluminium	", 4.0, 60.6))
        gasketlist.Add(New vbGasket("solid flat metal, soft copper	", 4.75, 89.5))
        gasketlist.Add(New vbGasket("solid flat metal, soft steel	", 5.5, 124.0))
        gasketlist.Add(New vbGasket("solid flat metal, monel or chrome	", 6.0, 150.0))
        gasketlist.Add(New vbGasket("solid flat metal, stainless steel	", 6.5, 179.0))
        gasketlist.Add(New vbGasket("ring type joint, iron soft steel	", 5.5, 124.0))
        gasketlist.Add(New vbGasket("ring type joint, monel or chrome	", 6.0, 150.0))
        gasketlist.Add(New vbGasket("ring type joint, stainless steel	", 6.5, 179.0))
        gasketlist.Add(New vbGasket("rubber O-ring < 75 IRH	", 0.0, 0.7))
        gasketlist.Add(New vbGasket("rubber O-ring > 75 IRH	", 0.25, 1.4))
        gasketlist.Add(New vbGasket("rubber square ring < 75 IRH	", 0.0, 1.0))
        gasketlist.Add(New vbGasket("rubber square ring > 75 IRH	", 0.25, 2.8))
        gasketlist.Add(New vbGasket("rubber T-ring < 75 IRH	", 0.0, 1.0))
        gasketlist.Add(New vbGasket("rubber T-ring > 75 IRH	", 0.25, 2.8))
        gasketlist.Add(New vbGasket("user defined --------------	", 0.0, 0.0))
        gasketlist.Add(New vbGasket("self energizing types (incl. weld type)	", 0.0, 0.0))
        gasketlist.Add(New vbGasket("flexicarb MRG	", 2.0, 17.24))
        gasketlist.Add(New vbGasket("flexicarb Flexpro	", 2.0, 17.24))
        gasketlist.Add(New vbGasket("flexicarb SR", 2.0, 17.24))
        gasketlist.Add(New vbGasket("flexicarb ST", 2.0, 17.24))
        gasketlist.Add(New vbGasket("kammprofile SS low pressure", 2.0, 22.0))
        gasketlist.Add(New vbGasket("kammprofile SS med pressure", 2.0, 45.5))
        gasketlist.Add(New vbGasket("kammprofile SS high pressure", 2.0, 69.0))






    End Sub


End Class
