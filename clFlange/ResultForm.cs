using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace prjFlangeCS
{
    public partial class ResultForm : Form
    {

        private clFlange mfl;

        public ResultForm(clFlange mfl)
        {
            InitializeComponent();

            this.mfl = mfl;
        }

        /// <summary>
        ///  saves the output as rich text format from RTB1 richtextbox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            //    'saves the output as rich text format from RTB1 richtextbox
            //'
            //Dim saveFileDialog1 As New SaveFileDialog()

            //saveFileDialog1.Filter = "RTF|*.rtf|Plain text|*.txt"
            //saveFileDialog1.Title = "Save Report File"
            //saveFileDialog1.ShowDialog()

            //If saveFileDialog1.FileName<> String.Empty Then
            //    RTB1.SaveFile(saveFileDialog1.FileName)

            //End If
        }

        /// <summary>
        /// close the form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ResultForm_Activated(object sender, EventArgs e)
        {
            //fill the richtextbox with output
            
            PrintResults();

        }

        #region output

        private void PrintResults()
        {
            RTB1.Clear();

            RTB1.AppendText("==== Flange Calculation ==== \n\n");

            RTB1.AppendText("Date: " + DateTime.Now.ToLongDateString() + "\n");

            RTB1.AppendText("acc. ASME BPVC \n\n");

            RTB1.AppendText("=== Input Summary ===\n\n");


            RTB1.AppendText("Description of flange type  :  \t");
            switch (mfl.myType)
            {
                case clFlange.typeflange.fl_integral:
                    RTB1.AppendText("Integral");
                    break;
                case clFlange.typeflange.fl_loose:
                    RTB1.AppendText("Loose");
                    break;
                case clFlange.typeflange.fl_slipon:
                    RTB1.AppendText("Slip on");
                    break;
            }
                       
            RTB1.AppendText("\n\n");

            RTB1.AppendText("design pressure (pd)    : \t"  + mfl.Pd.ToString("0.00") + " MPa \n");
            RTB1.AppendText("design temperature (td) : \t" + mfl.Td.ToString("0.00") + " °C \n");
                                                                    




        }


        #endregion


    }
}
