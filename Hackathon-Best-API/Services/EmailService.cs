using Hackathon_Best_API.Interfaces;
using MailKit.Net.Smtp;
using MimeKit;


namespace Hackathon_Best_API.Services
{
    public class EmailService : IEmailService
    {
        public bool SendEmail(string to, string subject, string body)
        {
            try
            {
                var message = new MimeMessage();
                message.From.Add(new MailboxAddress(name: "LearnPulse", address: "ionuttufan04@gmail.com"));
                message.To.Add(new MailboxAddress(name: "", address: to));
                message.Subject = subject;

                message.Body = new TextPart("plain")
                {
                    Text = body
                };

                using (var client = new SmtpClient())
                {
                    client.Connect(host: "smtp.gmail.com", port: 465, useSsl: true);
                    client.Authenticate(userName: "ionuttufan04@gmail.com", password: "jtey txmc srps atog");
                    client.Send(message);

                    client.Disconnect(quit: true);

                }
            }
            catch (Exception)
            {

                return false;
            }
            return true;
        }
    }
}
