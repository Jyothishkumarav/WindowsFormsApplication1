using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1.Core
{
   public static class MailSender
    {
        private const string MAIL_FROM = "alzonesoftware.taxcalculator@gmail.com";
        private const string MAIL_BODY = "Tax-Status Report";
        private const string USER_NAME = "alzonesoftware.taxcalculator@gmail.com";
        private const string USER_PWD = "AnuLijith@2016";
        
        public static bool SendEmail(string address,string filePath)
        {
            try
            {
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress(MAIL_FROM, "TaxReport");
                mail.To.Add(address);
                mail.Subject = "Tax Details - " + Convert.ToDateTime(DateTime.Now.ToString()).ToString("dd - MM - yyyy hh: mm tt");
                mail.Body = MAIL_BODY;
                System.Net.Mail.Attachment attachment;
                attachment = new System.Net.Mail.Attachment(filePath);
                mail.Attachments.Add(attachment);
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com", 587);
                SmtpServer.UseDefaultCredentials = true;
                SmtpServer.Credentials = new System.Net.NetworkCredential(USER_NAME, USER_PWD);
                SmtpServer.EnableSsl = true;
                SmtpServer.Send(mail);
                //Debug.WriteLine("Mail send sucessfully");
                return true;
            }
            catch(Exception e)
            {
                return false; 
            }
        }

    }
}
