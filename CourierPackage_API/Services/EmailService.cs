using CourierPackage_API.Interfaces;
using System.Net;
using System.Net.Mail;

namespace CourierPackage_API.Services
{
   
    public class EmailService : IEmailService
    {
        private readonly IConfiguration _configuration;

        public EmailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task SendEmailAsync(
            string toEmail,
            string subject,
            string body)
        {
            var smtpServer =
                _configuration["EmailSettings:SmtpServer"];

            var senderEmail =
                _configuration["EmailSettings:SenderEmail"];

            var appPassword =
                _configuration["EmailSettings:AppPassword"];

            var port = int.Parse(
                _configuration["EmailSettings:Port"]!);

            using var smtpClient = new SmtpClient(smtpServer, port)
            {
                Credentials = new NetworkCredential(
                    senderEmail,
                    appPassword),

                EnableSsl = true
            };

            using var mailMessage = new MailMessage
            {
                From = new MailAddress(senderEmail!),
                Subject = subject,
                Body = body,
                IsBodyHtml = true
            };

            mailMessage.To.Add(toEmail);

            await smtpClient.SendMailAsync(mailMessage);
        }
    }
}
