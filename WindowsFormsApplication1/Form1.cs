using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

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
            // IWebDriver driver = new ChromeDriver();
            //driver.Url = "http://stackoverflow.com/questions/25778228/selenium-driver-url-vs-driver-navigate-gotourl";
            //string fileName = "C:\\Users\\310251316\\Desktop\\TEst.xlsx";
            //string fileNameop = "C:\\Users\\310251316\\Desktop\\output.xlsx";
            string fileName = inputFileLabel.Text;
            string fileNameop = outputLabel.Text;
            string year = comboBox1.SelectedItem.ToString();
           
            if(fileName.ToLower().Contains("xlsx") && fileNameop.ToLower().Contains("xlsx") && year.Length!=0)
            {
                EFiller filler = new EFiller(fileName, fileNameop, year);
                filler.DoLogin();
                MessageBox.Show("Data generated successfully","Tax-Report",MessageBoxButtons.OK,MessageBoxIcon.Information);
                SendEmail();

            }
            else
            {
                MessageBox.Show("Please select Input and OutPut File Locations");
            }
            
            //IExcelReader.ReadExcelData(fileName);
        }

        private void SendEmail()
         {
            if (emailAdds.Text.Length > 0)
            {
                notifyIcn.Text = "Sending emial";
                if (emailAdds.Text.Contains(";"))
                {
                    string emailAddsText=emailAdds.Text.Replace(';',',');
                    MailSender.SendEmail(emailAddsText, outputLabel.Text);
                    notifyIcn.Text = "Mail has sent";
                }
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
    }
}
