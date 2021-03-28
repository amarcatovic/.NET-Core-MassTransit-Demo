using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using MimeKit;

namespace Order.Email.Communication
{
    public class EmailSender : IEmailSender
    {
        private readonly MimeMessage _mail;
        private readonly IOptions<ConnectionData> _connectionDataOptions;

        public EmailSender(IOptions<ConnectionData> connectionDataOptions)
        {
            _connectionDataOptions = connectionDataOptions;
            _mail = new MimeMessage();
            _mail.From.Add(new MailboxAddress(_connectionDataOptions.Value.UserName, _connectionDataOptions.Value.Sender));
        }

        public async Task SendOrderConfirmationEmailAsync(Domain.Models.Order order)
        {
            _mail.To.Add(new MailboxAddress("Reciever", "amar_catovic@hotmail.com"));
            _mail.Subject = order.ProductName;

            try
            {
                using var client = new MailKit.Net.Smtp.SmtpClient();
                await client.ConnectAsync("smtp.gmail.com", 587, false);
                await client.AuthenticateAsync(_connectionDataOptions.Value.UserName, _connectionDataOptions.Value.Password);
                await client.SendAsync(_mail);
                await client.DisconnectAsync(true);
            }
            catch (SmtpException exception)
            {
                System.Console.WriteLine(exception.Message);
            }
        }
    }
}
