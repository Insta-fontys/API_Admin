using System;
using System.Threading.Tasks;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Configuration;
using MimeKit;

namespace API.Services
{
    public class MailService
    {
        private readonly MailboxAddress myGramEmail = new("MyGram", "info.mygram@gmail.com");
        private readonly string emailPassword;

        public MailService(IConfiguration configuration)
        {
            emailPassword = configuration["EmailPassword"];
        }

        public void SendUserCreatedMail(string username, string email, string password)
        {
            var userCreatedMail = new MimeMessage();

            userCreatedMail.From.Add(myGramEmail);
            userCreatedMail.To.Add(new MailboxAddress(username, email));
            userCreatedMail.Subject = "Your account has been created.";

            var builder = new BodyBuilder
            {
                HtmlBody = "Hello " + username + "Your generated password = " + password
            };

            userCreatedMail.Body = builder.ToMessageBody();

            SendEmail(userCreatedMail);
        }

        private async Task SendEmail(MimeMessage email)
        {
            try
            {
                using var client = new SmtpClient();
                await client.ConnectAsync("smtp.gmail.com", 465, true);
                client.AuthenticationMechanisms.Remove("XOAUTH2");
                await client.AuthenticateAsync(myGramEmail.Address, emailPassword);
                await client.SendAsync(email);
                await client.DisconnectAsync(true);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
