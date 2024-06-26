using System.Net;
using System.Net.Mail;

namespace DotnetSmtp
{
    public class EmailManager : IEmailManager
    {
        public bool EmailTrigger()
        {
            


            try
            {
                string attachmentFilePath = "C:/Users/GOD/source/repos/Cloud Cost Analysis.xlsx";
                // Set up the SMTP client
                SmtpClient smtpClient = new SmtpClient("smtp.sendgrid.net")
                {
                    Port = 587, // or 465 for SSL
                    Credentials = new NetworkCredential("apikey", ""),
                    EnableSsl = true,
                };

                // Create the email message
                MailMessage mail = new MailMessage
                {
                    From = new MailAddress("sivadev2025@gmail.com"),
                    Subject = "Testing",
                    Body = "Testing",
                    IsBodyHtml = true, // Set to true if the body contains HTML
                };

                mail.To.Add("bala.ecom2019@gmail.com");

                // Add the attachment
                if (File.Exists(attachmentFilePath))
                {
                    Attachment attachment = new Attachment(attachmentFilePath);
                    mail.Attachments.Add(attachment);
                }
                else
                {
                    Console.WriteLine("Attachment file not found.");
                    return false;
                }

                // Send the email
                smtpClient.Send(mail);
                Console.WriteLine("Email sent successfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error sending email: " + ex.Message);
            }


            return true;
        }
    }
}
