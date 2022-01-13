using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prjFlangeCS
{
    public class clFlange
    {
         public enum typeflange {fl_integral, fl_loose, fl_slipon};
         public static string[] flangeName = { "integral", "loose", "slipon" };


        public bool bInitialised { get; set; }      //is the input complete to start the calculation

        //public struct myDouble
        //{
        //   public double operating;
        //   public double testing;
        //}
        //onder ASME is alleen een berekening voor operating (design) + gasket seating dus niet ook voor testing
        #region Properties

        //every property has a private field which allocates the memory
        //and simple properties are automatically implemented
        //===input parameters

        public double Ar;           // bolt root area
        public double d;            // bolt nominal diameter
        public String sBoltName;    // bolt name
        public double Emin, Rmin;   // min distances for bolt to edge
        public double headsize;     //           'sleutelwijdte
        public double minspacing;   //         'bolt min spacing (uit bolt database)
        public double maxspacing;   //         'bolt max spacing (acc. PD5500 3.8.4.3)

        public double spacing;      //            'actual bolt spacing (calculated)


        //'input variables FLANGE
        public double Pd, Td;       //design pressure and temperature
        public double Sfo, Sfa;      //allowable stress flange
        public double Sb, Sa;       //allowable stress bolt
        public double nu;           //poisson ratio 
      
        public double Bn, tn, g0n, g1n;     //nominale (nieuwe) afmetingen 
        public double A, h, C, Go, Gi;
        public double B;
        public double g0, g1;        // As myDouble               

        public double fall, ca;         //allowance on face and corrosion allowance
        public double h1;

        public double m, y;             //gasket factors
        public double gpf;              //  ' gasket partition factor
        public int nbolts;              //  'number of bolts
    
        public String fl_mat, bolt_mat;
        public typeflange myType;                       //type: integral, loose, slipon
        public short gasket_type, bolt_size;            //index number 
        

        //=== calculated variables

        public double f, fa, ftest, fb, fba, fbtest;     //  'allowable stresses
        public double fbo, fbt;
        public double b0, be, G, Dig;
        public double N;                                //gasket contact width
        public double Eact, Ract;                       // 'bolt distances

        public double H, Hp, Hg, Hd, Ht;
        public double hd1, hg1, ht1, hl;
        public double W;
        public double Wm1,Wm2;                          //Wm1 = Wop, Wm2 = Wa

        public double Am, Ab;                           //Am = Abmin, Ab = actual area
        public double Ma, Mop;


        public double Cf, K, I0;
        public double a1, c1;
        public double betaT, betaU, betaY;
        public double betaF, betaV;
        public double betafl, betavl;

        public double phi, lambda;
        public double Ma1, Mop1, Mtest;

        public double sigmaha, sigmara, sigmaca;
        public double sigmaho, sigmaro, sigmaco;
        public double sigmaht, sigmart, sigmact;

        public double k1;
        
        #endregion



        public clFlange()
        {
            bInitialised = false;
        }

        /// <summary>
        /// create example input for testing 
        /// </summary>
        public void ExampleInput()
        {

            myType = clFlange.typeflange.fl_integral;


            //tab 1
            Pd = 0.59;
            Td = 225;

                //Pt = CDbl(Text_Pt.Text)  test pressure niet nodig in ASME, grijs laten
                //materiaal: allowables invullen
            Sfa = 115.1;
            Sfo = 78.6;

            A = 3800;
            tn = 185;
            Bn = 3594;
            
            ca = 0;
            fall = 0;
            h1 = 60;
            g0n = 20;
            g1n = 25;

            fl_mat = "SA266 gr.2";

            //tab 2
            Go = 3670;
            Gi = 3638;
            gasket_type = 1;        //index number
            m = 3.75;
            y = 52.4;
            gpf = 1.0;

            

            //tab 3
           
            C = 3725;
            nbolts = 120;
            bolt_size = 1;
            Sa = 172.4;
            Sb = 172.4;
            Ar = 355.5;
            bolt_mat = "SA193 B7";

            minspacing = 52.4;

         }

        public void Calculate()
        {
            //do nothing when input is not ready
            if (!bInitialised)
                return;

            //gasket contact width
            N = (Go - Gi)/2;

            //effective gasket width
            b0 = N / 2;                         // 'for RTJ b0 = w/8

            if (b0 <= 6.3) 
                be = b0;
            else
                be = 2.52 * Math.Sqrt(b0);
        
            //gasket reaction diameter
            G = (Go + Gi)/2;

            //flange actual thickness;
            h = tn - fall;

        //'====== check bolt distances to hub (R) and flange od (E)
        //'note boltspacing wordt al eerder apart berekend voor update in frmFlangeInput
            Eact = (A - C) / 2;
            Ract = (C - Bn) / 2 - g1n;

        //'======berekening voor operating (design pressure, corroded, design temperature)

            B = Bn + 2 * ca;

            g0 = g0n - ca;
            g1 = g1n - ca;

            //basic flange and bolt loads calculation

            //hydrostatic end load due to pressure
            H = Math.PI / 4 * G * G * Pd;

            //contact load on gasket surfaces
            Hp = 2 * Math.PI * G * be * m * Pd;     // * gpf

            //hydrostatic end load at flange id
            Hd = Math.PI / 4 * B * B * Pd;

            //pressure force on flange face
            Ht = H - Hd;

            //operating bolt load
            Wm1 = Math.Max(H + Hp, 0);

            //gasket seating bolt load
            Wm2 = y * b0 * Math.PI * G;

            //required bolt area

            Am = Math.Max(Wm1 / Sb, Wm2 / Sa);

            Ab = nbolts * Ar;

            //distance to end pressure reaction
            if (myType == typeflange.fl_integral) 
                hd1 = (C - B - g1) / 2;
            else
                hd1 = (C - B) / 2;
        
            //distance to gasket load reaction
            hg1 = (C - G) / 2;

            //distance to face pressure reaction
            ht1 = (2 * C - B - G) / 4;


            //flange design bolt load, gasket seating
            W = 0.5 * (Am + Ab) * Sa;

            //gasket load for operating condition
            Hg = Wm1 - H;


            Ma = W * hg1;

            Mop = Hd * hd1 + Ht * ht1 + Hg * hg1;

            Cf = 1;       //          'eigenlijk nog boutdiameter erbij 

            K = A / B;
            I0 = Math.Sqrt(B * g0);

            //'bepaal flens stress factors from subroutine
            //'alleen voor een hubbed flange
            a1 = g1 / g0 - 1;
            c1 = 48 * (1 - nu * nu) * Math.Pow(h1 / I0,4);

            //berekenfactoren(a1.operating, c1.operating, betaF.operating, betaV.operating, phi.operating, betafl, betavl)

        //'formule van EN13445 (lijkt op ASME)
        //betaT.operating = (K.operating ^ 2 * (1 + 8.55246 * Log10(K.operating)) - 1) / ((1.0472 + 1.9448 * K.operating ^ 2) * (K.operating - 1))

        //betaU.operating = (K.operating ^ 2 * (1 + 8.55246 * Log10(K.operating)) - 1) / ((1.36136 * (K.operating ^ 2 - 1) * (K.operating - 1)))

        //betaY.operating = (1 / (K.operating - 1)) * (0.66845 + 5.7169 * (K.operating ^ 2 * Log10(K.operating) / (K.operating ^ 2 - 1)))

        //Ma1 = Ma.operating * Cf.operating / B.operating
        //Mop1 = Mop.operating * Cf.operating / B.operating

        //If fl_type = typeflange.fl_integral Then
        //    lambda.operating = (e * betaF.operating + I0.operating) / (betaT.operating * I0.operating) + (e ^ 3 * betaV.operating) / (betaU.operating * I0.operating * g0.operating ^ 2)
        //Else

        //    lambda.operating = (e * betafl + I0.operating) / (betaT.operating * I0.operating) + (e ^ 3 * betavl) / (betaU.operating * I0.operating * g0.operating ^ 2)
        //End If

        //'stress factor
        //If B.operating < 1000 Then
        //    k1.operating = 1
        //ElseIf B.operating > 2000 Then
        //    k1.operating = 1.333
        //Else
        //    k1.operating = 0.6666 * (1 + B.operating / 2000)
        //End If

        //'bereken nu de flange stresses

            switch(myType)
            {
                case typeflange.fl_integral:
                    sigmaha = (phi * Ma1) / (lambda * g1 * g1);
                    sigmaho = (phi * Mop1) / (lambda * g1 * g1);

                    sigmara = (1.3333 * h * betaF + I0) / (lambda * h * h * I0) * Ma1;
                    sigmaro = (1.3333 * h * betaF + I0) / (lambda * h * h * I0) * Mop1;

                    sigmaca = ((betaY * Ma1) / h * h) - (sigmara * (K * K + 1) / (K * K - 1));
                    sigmaco = ((betaY * Mop1) / h * h) - (sigmaro * (K * K + 1) / (K * K - 1));
                    break;

                case typeflange.fl_loose:
                    sigmaha = 0;
                    sigmaho = 0;

                    sigmara = 0;
                    sigmaro = 0;

                    sigmaca = ((betaY * Ma1) / h * h);
                    sigmaco = ((betaY * Mop1) / h * h );
                    break;

                case typeflange.fl_slipon:
                    sigmaha = (phi * Ma1) / (lambda * g1 * g1);
                    sigmaho = (phi * Mop1) / (lambda * g1 *g1);

                    sigmara = (1.3333 * h * betaF + I0) / (lambda * h * h * I0) * Ma1;
                    sigmaro = (1.3333 * h * betaF + I0) / (lambda * h * h * I0) * Mop1;

                    sigmaca = ((betaY * Ma1) / h * h) - (sigmara * (K * K + 1) / (K * K - 1));
                    sigmaco = ((betaY * Mop1) / h * h) - (sigmaro * (K * K + 1) / (K * K - 1));
                    break;

            }


        }//end calculate

        private void berekenfactoren()
        {
        //     '----------------------------------------------------------------------------------
        //' berekening vormfactoren voor BS5500 of EN13445 part 11 flensberekening
        //' overgenomen uit BSFLENS.BAS
        //' deze formule staat o.a. in ASME VIII div.1 app.2 en ook in EN13445

        //'260 Print "     * Datum:  23 oktober 1996;         Auteur: M. Beernink.   *"
        //'270 Print "     * Laatste wijziging:               Level:  0              *"
        //'280 Print "     ***********************************************************"
        //'  routine getest, is OK
        //' aangepast met return variabelen
        //'----------------------------------------------------------------------------------

        //Dim c(70) As Double

        double[] c = new double[70];
       
        double F1;


        //'21000 '   BEREKENING VORMFAKTOREN.


        c[1] = 1 / 3 + a1 / 12;
        c[2] = 5 / 42 + 17 * a1 / 336;
        c[3] = 1 / 210 + a1 / 360;
        c[4] = 11 / 360 + 59 * a1 / 5040 + (1 + 3 * a1) / c1;
        c[5] = 1 / 90 + 5 * a1 / 1008 - Math.Pow(1 + a1,3)  / c1;
        c[6] = 1 / 120 + 17 * a1 / 5040 + 1 / c1;
        c[7] = 215 / 2772 + 51 * a1 / 1232 + (60 / 7 + 225 * a1 / 14 + 75 * a1 * a1 / 7 + 5 * Math.Pow(a1,3) / 2) / c1;
        c[8] = 31 / 6930 + 128 * a1 / 45045.0 + (6 / 7 + 15 * a1 / 7 + 12 * a1 * a1 / 7 + 5 * Math.Pow(a1, 3) / 11) / c1;
        c[9] = 533 / 30240 + 653 * a1 / 73920.0 + (1 / 2 + 33 * a1 / 14 + 39 * a1 * a1 / 28 + 25 * Math.Pow(a1, 3) / 84) / c1;
        c[10] = 29 / 3780 + 3 * a1 / 704 - (1 / 2 + 33 * a1 / 14 + 81 * a1 * a1 / 28 + 13 * Math.Pow(a1, 3) / 12) / c1;
        c[11] = 31 / 6048 + 1763 * a1 / 665280.0 + (1 / 2 + 6 * a1 / 7 + 15 * a1 * a1 / 28 + 5 * Math.Pow(a1, 3) / 42) / c1;
        c[12] = 1 / 2925 + 71 * a1 / 300300.0 + (8 / 35 + 18 * a1 / 35 + 156 * a1 * a1 / 385 + 6 * Math.Pow(a1, 3) / 55) / c1;
        c[13] = 761 / 831600.0 + 937 * a1 / 1663200.0 + (1 / 35 + 6 * a1 / 35 + 11 * a1 * a1 / 70 + 3 * Math.Pow(a1, 3) / 70) / c1;
        c[14] = 197 / 415800.0 + 103 * a1 / 332640.0 - (1 / 35 + 6 * a1 / 35 + 17 * a1 * a1 / 70 + Math.Pow(a1, 3) / 10) / c1;
        c[15] = 233 / 831600.0 + 97 * a1 / 554400.0 + (1 / 35 + 3 * a1 / 35 + a1 * a1 / 14 + 2 * Math.Pow(a1, 3) / 105) / c1;
        c[16] = c[1] * c[7] * c[12] + c[2] * c[8] * c[3] + c[3] * c[8] * c[2] - (c[3] * c[3] * c[7] + c[8] * c[8] * c[1] + c[2] * c[2] * c[12]);
        c[17] = c[4] * c[7] * c[12] + c[2] * c[8] * c[13] + c[3] * c[8] * c[9];
        c[17] = (c[17] - (c[13] * c[7] * c[3] + c[8] * c[8] * c[4] + c[12] * c[2] * c[9])) / c[16];
        c[18] = c[5] * c[7] * c[12] + c[2] * c[8] * c[14] + c[3] * c[8] * c[10];
        c[18] = (c[18] - (c[14] * c[7] * c[3] + c[8] * c[8] * c[5] + c[12] * c[2] * c[10])) / c[16];
        c[19] = c[6] * c[7] * c[12] + c[2] * c[8] * c[15] + c[3] * c[8] * c[11];
        c[19] = (c[19] - (c[15] * c[7] * c[3] + c[8] * c[8] * c[6] + c[12] * c[2] * c[11])) / c[16];
        c[20] = c[1] * c[9] * c[12] + c[4] * c[8] * c[3] + c[3] * c[13] * c[2];
        c[20] = (c[20] - (c[3] * c[3] * c[9] + c[13] * c[8] * c[1] + c[12] * c[4] * c[2])) / c[16];
        c[21] = c[1] * c[10] * c[12] + c[5] * c[8] * c[3] + c[3] * c[14] * c[2];
        //    c[21] = (c(21) - (c(3) ^ 2 * c(10) + c(14) * c(8) * c(1) + c(12) * c(5) * c(2))) / c(16);
        //    c(22) = c(1) * c(11) * c(12) + c(6) * c(8) * c(3) + c(3) * c(15) * c(2);
        //    c(22) = (c(22) - (c(3) ^ 2 * c(11) + c(15) * c(8) * c(1) + c(12) * c(6) * c(2))) / c(16);
        //    c(23) = c(1) * c(7) * c(13) + c(2) * c(9) * c(3) + c(4) * c(8) * c(2);
        //    c(23) = (c(23) - (c(3) * c(7) * c(4) + c(8) * c(9) * c(1) + c(2) ^ 2 * c(13))) / c(16);
        //    c(24) = c(1) * c(7) * c(14) + c(2) * c(10) * c(3) + c(5) * c(8) * c(2);
        //    c(24) = (c(24) - (c(3) * c(7) * c(5) + c(8) * c(10) * c(1) + c(2) ^ 2 * c(14))) / c(16);
        //    c(25) = c(1) * c(7) * c(15) + c(2) * c(11) * c(3) + c(6) * c(8) * c(2);
        //    c(25) = (c(25) - (c(3) * c(7) * c(6) + c(8) * c(11) * c(1) + c(2) ^ 2 * c(15))) / c(16);
        //    c(26) = -(c1 / 4) ^ 0.25;
        //    c(27) = c(20) - c(17) - 5 / 12 - c(17) * (c1 / 4) ^ 0.25;
        //    c(28) = c(22) - c(19) - 1 / 12 - c(19) * (c1 / 4) ^ 0.25;
        //    c(29) = -(c1 / 4) ^ 0.5;
        //    c(30) = -(c1 / 4) ^ 0.75;
        //    c(31) = 3 * a1 / 2 + c(17) * (c1 / 4) ^ 0.75;
        //    c(32) = 0.5 + c(19) * (c1 / 4) ^ 0.75;
        //    c(33) = 0.5 * c(26) * c(32) + c(28) * c(31) * c(29) - (0.5 * c(30) * c(28) + c(32) * c(27) * c(29));
        //    c(34) = 1 / 12 + c(18) - c(21) + c(18) * (c1 / 4) ^ 0.25;
        //    c(35) = -c(18) * (c1 / 4) ^ 0.75;
        //    c(36) = (c(28) * c(35) * c(29) - c(32) * c(34) * c(29)) / c(33);
        //    c(37) = (0.5 * c(26) * c(35) + c(34) * c(31) * c(29) - (0.5 * c(30) * c(34) + c(35) * c(27) * c(29))) / c(33);
        //c(38) = 0 : c(39) = 0 : c(40) = 0;
        //    c(41) = c(17) * c(36) + c(18) + c(19) * c(37);
        //    c(42) = c(20) * c(36) + c(21) + c(22) * c(37);
        //    c(43) = c(23) * c(36) + c(24) + c(25) * c(37);
        //    c(44) = 1 / 4 + c(37) / 12 + c(36) / 4 - c(43) / 5 - 3 * c(42) / 2 - c(41);
        //    c(45) = c(41) * (1 / 2 + a1 / 6) + c(42) * (1 / 4 + 11 * a1 / 84) + c(43) * (1 / 70 + a1 / 105);
        //    c(46) = c(45) - c(36) * (7 / 120 + a1 / 36 + 3 * a1 / c1) - 1 / 40 - a1 / 72 - c(37) * (1 / 60 + a1 / 120 + 1 / c1);
        //    f = -c(46) / ((c1 / 2.73) ^ 0.25 * (1 + a1) ^ 3 / c1);
        //    V = c(44) / ((2.73 / c1) ^ 0.25 * (1 + a1) ^ 3);
        //    F1 = c(36) / (1 + a1);
        //    F2 = c(18) * (1 / 2 + a1 / 6) + c(21) * (1 / 4 + 11 * a1 / 84) + c(24) * (1 / 70 + a1 / 105) - (1 / 40 + a1 / 72);
        //    F2 = -F2 / ((c1 / 2.73) ^ 0.25 * (1 + a1) ^ 3 / c1);
        //    V2 = (1 / 4 - c(24) / 5 - 3 * c(21) / 2 - c(18)) / ((2.73 / c1) ^ 0.25 * (1 + a1) ^ 3);

        //    phi = Max(F1, 1);



        }



    }
}
