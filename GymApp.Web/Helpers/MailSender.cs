using System.Net;
using System.Net.Mail;

namespace GymApp.Web.Helpers
{
    public static class MailSender
    {
        private const string SenderMail = "ferhat.gzr96@outlook.com";  //const = sabit değer için kullanılıyor.
        private const string SenderPassword = "Ferhat1296";

        public static void SendMail(string fullName, List<string> mailAddresses)
        {
            try
            {
                MailMessage mailMessage = new MailMessage();
                mailMessage.From = new MailAddress(SenderMail);

                for (int i = 0; i < mailAddresses.Count; i++)
                {
                    mailMessage.To.Add(mailAddresses[i]);
                }
                mailMessage.Subject = "Hoş Geldiniz";
                mailMessage.Body = $"Merhaba {fullName}, \nSitemize hoş geldiniz.";
                mailMessage.IsBodyHtml = true;


                SmtpClient smtpClient = new SmtpClient();
                smtpClient.Host = "smtp-mail.outlook.com";
                smtpClient.Port = 587;
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = new NetworkCredential(SenderMail, SenderPassword);
                smtpClient.EnableSsl = true;

                smtpClient.Send(mailMessage);
                Console.WriteLine("Email Sent Successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }

        }
    }
}