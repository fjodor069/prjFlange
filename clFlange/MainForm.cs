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
/*' 20-7-2009 started with input screen in VB
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


namespace prjFlangeCS
{
    public partial class MainForm : Form
    {
        //members
        clFlange myFlange;

        CSBoltLib.BoltClass myBolt = new BoltClass();
        
        CultureInfo myCulture = CultureInfo.CurrentCulture;

        public MainForm()
        {
            InitializeComponent();
        }

        private void cmdCalc_Click(object sender, EventArgs e)
        {
            //get all input from the comboboxes
            myFlange.myType = (clFlange.typeflange)cbType.SelectedIndex; 

            //get all input from the textboxes
            try
            {
                myFlange.Pd = double.Parse(Text_P.Text);
                myFlange.Td = double.Parse(Text_T.Text);

                //Pt = CDbl(Text_Pt.Text)  test pressure niet nodig in ASME
                //materiaal: allowables invullen
                myFlange.Sfa = double.Parse(Text_Sfa.Text);
                myFlange.Sfo = double.Parse(Text_Sfo.Text);
                    
                myFlange.A = double.Parse(Text_A.Text);
                myFlange.hn = double.Parse(Text_h.Text);
                myFlange.Bn = double.Parse(Text_B.Text);
                myFlange.C = double.Parse(Text_C.Text);
                myFlange.ca = double.Parse(Text_ca.Text);
                myFlange.fall = double.Parse(Text_fa.Text);
                myFlange.h1 = double.Parse(Text_h1.Text);
                myFlange.g0n = double.Parse(Text_g0.Text);
                myFlange.g1n = double.Parse(Text_g1.Text);

        //fl_mat = Text_material.Text
                myFlange.G = double.Parse(Text_G.Text);
                myFlange.Gi = double.Parse(Text_Gi.Text);
                myFlange.m = double.Parse(Text_m.Text);
                myFlange.y = double.Parse(Text_y.Text);

                myFlange.gpf = double.Parse(Text_Gpf.Text);

                //gasket_type = cbGasket.SelectedIndex
                myFlange.nbolts = int.Parse(Text_nb.Text);

                myFlange.Sa = double.Parse(Text_Sa.Text);
                myFlange.Sb = double.Parse(Text_Sb.Text);
                   

            }
            catch (Exception ex)
            {
                MessageBox.Show("---> You must enter a value <---","Wrong Input",MessageBoxButtons.OK, MessageBoxIcon.Information   );
            }



            //and start calculating
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            //open bolt dialog (from CSBoltLib.dll)
            frmSelectBolt myDialog = new frmSelectBolt();

            //de database moet staan in \clFlange\bin\Debug of in startup path
            myDialog.sDataFile = "\\Cea_bolt.mdb";
            myDialog.sDataPath = Application.StartupPath;
            myDialog.ShowDialog ();
            myBolt = myDialog.myBolt;
            Text_boltsize.Text = myBolt.szDiameter;

        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            //initialise the form
            //'combobox flange type 

            cbType.Items.Clear(); 
            foreach (string s in clFlange.flangeName  )
                cbType.Items.Add(s);
            
            cbType.SelectedIndex = 0;

            myFlange = new clFlange();

        }
    }
}
