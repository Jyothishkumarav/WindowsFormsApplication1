using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApplication1.Core;
using WindowsFormsApplication1.Utitity;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        private string inputFileName;
        private string outputFileName;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (!MacVerification.GetMACAddress2())
            {
                MessageBox.Show("Un-authorised User");
                Application.Exit();
            }
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
        }

        private void inputFileLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            openFileDialog1.Filter = "Excel Files (.xlsx)|*.xlsx|All Files (*.*)|*.*";
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {

                string s = openFileDialog1.FileName;
                inputFileLabel.Text = s;
                Console.WriteLine(s);

            }

           

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                // IWebDriver driver = new ChromeDriver();
                //driver.Url = "http://stackoverflow.com/questions/25778228/selenium-driver-url-vs-driver-navigate-gotourl";
                //string fileName = "C:\\Users\\310251316\\Desktop\\TEst.xlsx";
                //string fileNameop = "C:\\Users\\310251316\\Desktop\\output.xlsx";
                outputFileName = IExcelReader.CreateOutPutExcelFile(inputFileLabel.Text);
                if (outputFileName.Length == 0)
                {
                    MessageBox.Show("Unable to Create File");
                    throw new Exception("Unable to create excel file");
                }
                //string fileName = inputFileLabel.Text;
                //string fileNameop = outputFileName;
                string year = comboBox1.SelectedItem.ToString();

                if (inputFileName.ToLower().Contains("xlsx") && outputFileName.ToLower().Contains("xlsx") && year.Length != 0)
                {
                    EFiller filler = new EFiller(inputFileName, outputFileName, year);
                    filler.DoLogin();
                    MessageBox.Show("Data generated successfully", "Tax-Report", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    SendEmail();

                }
                else
                {
                    MessageBox.Show("Please select Input and OutPut File Locations");
                }

                //IExcelReader.ReadExcelData(fileName);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to Create File 2");
            }
        }

        private void SendEmail()
         {
            if (emailAdds.Text.Length > 0)
            {
                notifyIcn.Text = "Sending email";
                string emailAddsText= emailAdds.Text;
                if (emailAdds.Text.Contains(";"))
                {
                     emailAddsText = emailAdds.Text.Replace(';', ',');
                }
                   
             MailSender.SendEmail(emailAddsText, outputFileName);
             notifyIcn.Text = "Mail has sent";
                
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            openFileDialog1.Filter = "Excel Files (.xlsx)|*.xlsx|All Files (*.*)|*.*";
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {

                string s = openFileDialog1.FileName;
                outputLabel.Text = s;
                Console.WriteLine(s);

            }

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Excel Files (.xlsx)|*.xlsx|All Files (*.*)|*.*";
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {

                var text=openFileDialog1.SafeFileName;
                fileName.Text = text;
                fileName.Visible = true;
                //btnUserList.Text = openFileDialog1.SafeFileName;
                string s = openFileDialog1.FileName;
                inputFileName = s;
                inputFileLabel.Text = s;
                Console.WriteLine(s);

            }

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click_1(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            ProcessStartInfo sInfo = new ProcessStartInfo("http://www.alzonesoftware.com/");
            Process.Start(sInfo);
        }

        private void pictureBox1_MouseHover(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.Hand;
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
           // Cursor.Current = Cursors.Default;
        }

        private void pictureBox1_MouseEnter(object sender, EventArgs e)
        {


        }
    }
}
