using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;
using CSBoltLib;

//
/*'   20-7-2009 started with input screen in VB
    ' 27-7-2009 added loose flange type; tested and looks OK
    ' 15-11-2009 added gasket factor class and arraylist
    ' 9-12-2009 added bolt database
    ' 7-11-2014 added testcondition calculation; checked with VES software
    '
    ' TODO:  
    '           check bolt database met TEMA
    '           berekening bolt torque 
    '           laden en saven 
    '           berekening voor externe druk
    '           koppeling met materiaal database
    '           plot of flange (met doorsnede)
*/
//      21-9-2015   started with C# version
//                  uses CSBoltLib.dll for bolt database
//
//      12-1-2022   continued translate from VB example, rearranged code and made GIT repository
//

namespace prjFlangeCS
{
    public partial class MainForm : Form
    {
        #region Initialising
        //this is the object we are working with
        clFlange myFlange;

        CSBoltLib.BoltClass myBolt = new BoltClass();
        
        CultureInfo myCulture = CultureInfo.CurrentCulture;


      

        public MainForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Load the form, fill in the comboboxes
        /// create a new flange object
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_Load(object sender, EventArgs e)
        {
            //initialise the form
            myFlange = new clFlange();
            

            //combobox flange type 

            cbType.Items.Clear();
            foreach (string s in clFlange.flangeName)
                cbType.Items.Add(s);

            cbType.SelectedIndex = 0;


            ClearInput();


        }



        #endregion


        #region Input Handling

        /// <summary>
        /// copy the input from the form text fields to the object
        /// </summary>
        private void ReadInput()
        {
            //get all input from the comboboxes
            myFlange.myType = (clFlange.typeflange)cbType.SelectedIndex;

            //get all input from the textboxes
            try
            {
                //tab 1
                myFlange.Pd = double.Parse(Text_P.Text);
                myFlange.Td = double.Parse(Text_Temp.Text);

                //Pt = CDbl(Text_Pt.Text)  test pressure niet nodig in ASME, grijs laten
                //materiaal: allowables invullen
                myFlange.Sfa = double.Parse(Text_Sfa.Text);
                myFlange.Sfo = double.Parse(Text_Sfo.Text);

                myFlange.A = double.Parse(Text_A.Text);
                myFlange.tn = double.Parse(Text_t.Text);
                myFlange.Bn = double.Parse(Text_B.Text);
                myFlange.C = double.Parse(Text_C.Text);
                myFlange.ca = double.Parse(Text_ca.Text);
                myFlange.fall = double.Parse(Text_fa.Text);
                myFlange.h1 = double.Parse(Text_h1.Text);
                myFlange.g0n = double.Parse(Text_g0.Text);
                myFlange.g1n = double.Parse(Text_g1.Text);

                //fl_mat = Text_material.Text
                //tab 2
                myFlange.G = double.Parse(Text_Go.Text);
                myFlange.Gi = double.Parse(Text_Gi.Text);
                myFlange.m = double.Parse(Text_m.Text);
                myFlange.y = double.Parse(Text_y.Text);

                myFlange.gpf = double.Parse(Text_Gpf.Text);

                //tab 3
                //gasket_type = cbGasket.SelectedIndex
                myFlange.nbolts = int.Parse(Text_nb.Text);

                myFlange.Sa = double.Parse(Text_Sa.Text);
                myFlange.Sb = double.Parse(Text_Sb.Text);

                //ready to start calculation
                myFlange.bInitialised = true;


            }
            catch (Exception)
            {
                MessageBox.Show("\n Not enough input for calculation. You must enter a value", "Wrong Input", 
                                MessageBoxButtons.OK, 
                                MessageBoxIcon.Information);
            }


        }


        /// <summary>
        /// fill in the input text fields with values from current object
        /// //  'update this form's input cells with current input values
        /// and other controls like comboboxes
        /// also when loaded from a file
        /// formatting of text fields
        /// </summary>
        private void FillInput()
        {

            //tab 1 input
            Text_P.Text = myFlange.Pd.ToString("0.00");
            Text_Temp.Text = myFlange.Td.ToString("0.00");
            //Text_Pt.Text = CStr(Pt)
            //cbType.SelectedIndex = .fl_type

            Text_Sfa.Text = myFlange.Sfa.ToString("0.00");
            Text_Sfo.Text = myFlange.Sfo.ToString("0.00");

            Text_A.Text = myFlange.A.ToString("0.00");
            Text_t.Text = myFlange.tn.ToString("0.00");
            Text_B.Text = myFlange.Bn.ToString("0.00");
            Text_ca.Text = myFlange.ca.ToString("0.00");
            Text_fa.Text = myFlange.fall.ToString("0.00");
            Text_h1.Text = myFlange.h1.ToString("0.00");
            Text_g0.Text = myFlange.g0n.ToString("0.00");
            Text_g1.Text = myFlange.g1n.ToString("0.00");

            //tab 2 input
            Text_Go.Text = myFlange.Go.ToString("0.00");
            Text_Gi.Text = myFlange.Gi.ToString("0.00");

            //cbGasket.SelectedIndex = .gasket_type
            Text_m.Text = myFlange.m.ToString("0.00");
            Text_y.Text = myFlange.y.ToString("0.00");

            //tab 3 input
            Text_C.Text = myFlange.C.ToString("0.00");
            Text_nb.Text = myFlange.nbolts.ToString("0.00");

            //Text_boltsize.Text = .sBoltName
            //'bolt data van frmSelectBolt dialog
            //'invoer velden voor bolt bijwerken
            
            Text_boltsize.Text = myBolt.szDiameter;
            Text_Ar.Text = myFlange.Ar.ToString("0.00");

            //If(myBoltMaterial IsNot Nothing) Then

            //    Text_bolt.Text = .bolt_mat
            //End If

            //'Text_bolt.Text = .bolt_mat

            //'Text_Sa.Text = .Sa.ToString
            //'Text_Sb.Text = .Sb.ToString
                                                               

            //'bolt cirkel plaatje bijwerken
            //Panel1.Refresh()
            //'bolt spacing weergeven
            //myFlange.calcSpacing()


            //With StatusStrip1
            //    .Items.Clear()
            //    .Items.Add("min. spacing : " & Format(myFlange.minspacing, "#.00"))
            //    .Items.Add("actual spacing : " & Format(myFlange.spacing, "#0.00"))
            //    .Items.Add("max spacing : " & Format(myFlange.maxspacing, "#0.00"))
            //    .Items(0).AutoSize = True
            //    .Items(1).AutoSize = True
            //    .Items(2).AutoSize = True
            //End With

        }


        /// <summary>
        /// 
        /// </summary>
        private void ClearInput()
        {
            //tab 1 input
            Text_P.Text = String.Empty;
            Text_Temp.Text = String.Empty;
            //Text_Pt.Text = CStr(Pt)
            //cbType.SelectedIndex = .fl_type

            Text_Sfa.Text = String.Empty;
            Text_Sfo.Text = String.Empty;

            Text_A.Text = String.Empty;
            Text_t.Text = String.Empty;
            Text_B.Text = String.Empty;
            Text_ca.Text = String.Empty;
            Text_fa.Text = String.Empty;
            Text_h1.Text = String.Empty;
            Text_g0.Text = String.Empty;
            Text_g1.Text = String.Empty;

            //tab 2 input
            Text_Go.Text = String.Empty;
            Text_Gi.Text = String.Empty;

            //cbGasket.SelectedIndex = .gasket_type
            Text_m.Text = String.Empty;
            Text_y.Text = String.Empty;

            //tab 3 input
            Text_C.Text = String.Empty;
            Text_nb.Text = String.Empty;

            //Text_boltsize.Text = .sBoltName
            //'bolt data van frmSelectBolt dialog
            //'invoer velden voor bolt bijwerken

            Text_boltsize.Text = String.Empty;
            Text_Ar.Text = String.Empty;

        }

        #endregion



        #region Form Event Handlers

        /// <summary>
        /// start the calculation
        /// read input from textboxes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdCalc_Click(object sender, EventArgs e)
        {

            //pushed the calculation button
            ReadInput();

            myFlange.calculate();

            //printresult
            
        }
            
                

        private void cmdSelectBolt_Click(object sender, EventArgs e)
        {
            //open bolt dialog (from CSBoltLib.dll)
            frmSelectBolt myDialog = new frmSelectBolt();

            //de database moet staan in \clFlange\bin\Debug of in startup path
            myDialog.sDataFile = "\\Cea_bolt.mdb";
            myDialog.sDataPath = Application.StartupPath;
            myDialog.ShowDialog();
            myBolt = myDialog.myBolt;
            Text_boltsize.Text = myBolt.szDiameter;
        }

        #endregion

        /// <summary>
        /// exit the program
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
