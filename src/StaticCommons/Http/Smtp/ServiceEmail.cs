using System;
using System.Linq;
using MailKit.Net.Smtp;
using MimeKit;

namespace StaticCommons.Http.Smtp
{
    public class Email
    {
        public static void SendSmtpEmail(EmailContent emailContent)
        {
            try
            {
                var emailMessage = new MimeMessage();
                emailMessage.From.Add(new MailboxAddress(emailContent.From.Name, emailContent.From.Address));
                emailMessage.To.Add(new MailboxAddress(emailContent.To.Name, emailContent.To.Address));
                emailMessage.Subject = emailContent.Content.Subject;
                emailMessage.Body = new TextPart("plain") { Text = emailContent.Content.Message };

                if (emailContent.Content.Attachments.Any())
                {
                    var builder = new BodyBuilder
                    {
                        TextBody = emailContent.Content.Message,
                    };

                    foreach (var contentAttachment in emailContent.Content.Attachments)
                    {
                        builder.Attachments.Add(contentAttachment);
                    }

                    emailMessage.Body = builder.ToMessageBody();
                }

                var client = new SmtpClient();

                client.Connect(emailContent.Connect.Host);
                client.AuthenticationMechanisms.Remove("XOAUTH2");
                client.Authenticate(emailContent.Connect.UserName, emailContent.Connect.Password);
                client.Send(emailMessage);
                client.Disconnect(true);
            }
            catch (Exception e)
            {
                throw new Exception(e.ToString());
            }
        }
    }
}
