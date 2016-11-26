using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.IO.Compression;


namespace MagdalenaPolakLab1Calculator
{
    public partial class CalculatorWindow : Form
    {
        
        Double eqtValue = 0;
        String operation = "";
        String wholeEqt = "";
        bool operationPressed = false;
       
        public CalculatorWindow()
        {
            InitializeComponent();
        }

        private void CalculatorWindow_Load(object sender, EventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if((textBoxEqt.Text == "0") || (operationPressed))
            {
                textBoxEqt.Clear();
               
            } 
          
            Button b = (Button)sender;
            textBoxEqt.Text += b.Text;
            wholeEqt += b.Text;
            operationPressed = false;
        }

        private void buttonCE_Click(object sender, EventArgs e)
        {
            textBoxEqt.Text = "0";
        }

        private void buttonPlus_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            operation = b.Text;
            eqtValue = Double.Parse(textBoxEqt.Text);
            labelViewEqt.Text = eqtValue + " " +operation;
            wholeEqt += operation;
            operationPressed = true;
        }
        
private void buttonResult_Click(object sender, EventArgs e)
        {
                      
            labelViewEqt.Text = "";
            try
            {
                switch (operation)
                {
                    case "+":
                        textBoxEqt.Text = (eqtValue += Double.Parse(textBoxEqt.Text)).ToString();
                        break;
                    case "-":
                        textBoxEqt.Text = (eqtValue -= Double.Parse(textBoxEqt.Text)).ToString();
                        break;
                    case "*":
                        textBoxEqt.Text = (eqtValue *= Double.Parse(textBoxEqt.Text)).ToString();
                        break;
                    case "/":
                        textBoxEqt.Text = (eqtValue /= Double.Parse(textBoxEqt.Text)).ToString();
                        break;
                    default:
                        break;
                }
                   
                        
                            wholeEqt += "=" + textBoxEqt.Text + Environment.NewLine;
                            if (eqtValue == double.PositiveInfinity)
                            {
                                System.Diagnostics.Process.Start("https://www.youtube.com/watch?v=z2CIiES_xxk&ab_channel=FutureShock");

                            }
                            if (eqtValue == 666)
                            {
                                MessageBox.Show("Are you a devil one??? If so then go to hell!!!", "666", MessageBoxButtons.YesNo, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2);

                            }
                            if (eqtValue == 17)
                            {
                                labelViewEqt.Text = "My favourite number! Thanks ;)";
                            }
                            if (eqtValue == 3.14)
                            {
                                Image myimage = new Bitmap(@"C:\Users\DELL\Documents\Visual Studio 2015\Projects\MagdalenaPolakLab1Calculator\pi.png");
                                this.BackgroundImage = myimage;
                            }
                            if (doubleIsInt(eqtValue) && isPrime(eqtValue))
                            {
                                MessageBox.Show("Do you know it's a prime number? :D", "Prime", MessageBoxButtons.OKCancel, MessageBoxIcon.Information, MessageBoxDefaultButton.Button3);

                            }

                        
                
            }
            catch(Exception )
            {
                MessageBox.Show("Error");
            }
           

       
     
        }

        private void buttonC_Click(object sender, EventArgs e)
        {
            textBoxEqt.Text = "0";
            eqtValue = 0;
        }
        public static bool isPrime(double number)
        {
            if (number == 1) return false;
            if (number == 2) return true;

            var boundary = (int)Math.Floor(Math.Sqrt(number));

            for (int i = 2; i <= boundary; ++i)
            {
                if (number % i == 0) return false;
            }

            return true;
        }
        private bool doubleIsInt(double variable)
        {
            return (variable == Math.Floor(variable)) && !Double.IsInfinity(variable);
         }
            
        
           private void buttonSave_Click(object sender, EventArgs e)
        {
            using (StreamWriter writeEqt = new StreamWriter(@"equatations.txt", true))

            {
                writeEqt.WriteLine();
                writeEqt.WriteLine("*********** "+DateTime.Now+ " ***********");
                writeEqt.Write(wholeEqt);
                writeEqt.Close();
              
            }
            using (FileStream fs = new FileStream("equatation.zip", FileMode.Create))
            using (ZipArchive arch = new ZipArchive(fs, ZipArchiveMode.Create))
            {
                arch.CreateEntryFromFile("equatations.txt", "equatations.txt");


            }


            //ZipFile.ExtractToDirectory(zipPath, extractPath);
            // ZipFile.CreateFromDirectory(@"C:\Users\DELL\Documents\Visual Studio 2015\Projects\MagdalenaPolakLab1Calculator\MagdalenaPolakLab1Calculator\bin\Debug\equatations.txt", @"C:\Users\DELL\Documents\Visual Studio 2015\Projects\MagdalenaPolakLab1Calculator\MagdalenaPolakLab1Calculator\bin\Debug\equatations.zip");


        }
        
    }
}
