using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace DARS.Automation_.Utilities
{
    [TestFixture]
    public class SendEmail
    {
        [Test]
        public void sendEmail(string ToEmail)
        {
            try
            {
                MailMessage mail = new MailMessage();
                string FromEmail = "akash.trivedi@thegatewaycorp.co.in";
                string password = "Ruchi#1994";
                string Subject = "DARS Automation report_"+DateTime.Now.ToString("dd-MMM-yyyy-HH:mm:ss");
                string contentBody = "<h1>DARS Automation Report</h1>" +
                    "<br><h3>Click Below to open the Report:</h3>" +
                        "<br><h4>" + DateTime.Now.ToString("dd-MMM-yyyy-HH:mm:ss") +"</h4>";
                string Report = "C:/Users/akash.trivedi/source/repos/BerteloSteen-Automation/BerteloSteen(Automation)/Test_Execution_Reports/Test_Execution_Reports/index.html";
                mail.From = new MailAddress(FromEmail);
                mail.To.Add(ToEmail);
                mail.Subject = Subject;
                mail.Body = contentBody;
                mail.IsBodyHtml = true;
                mail.Attachments.Add(new Attachment(@Report));
                SmtpClient smtp = new SmtpClient("smtp.live.com", 587);
                smtp.Credentials = new NetworkCredential(FromEmail, password);
                smtp.EnableSsl = true;
                smtp.Send(mail);
            }
            catch (Exception e)
            {
                Console.WriteLine("MailMessage is :" + e.StackTrace);
                throw;
            }
        }
    }
}
