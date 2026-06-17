using Core.Interfaces;
using Core.SMTP;
using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;

namespace Core.Services;

public class SmtpService : ISmtpService
{
    public async Task<bool> SendEmailAsync(EmailMessage message)
    {
        var emailMessage = new MimeMessage();

        emailMessage.From.Add(new MailboxAddress("Glovo", EmailConfiguration.From));
        emailMessage.To.Add(new MailboxAddress("", message.To));
        emailMessage.Subject = message.Subject;

        emailMessage.Body = new TextPart("html")
        {
            Text = message.Body
        };

        using var client = new SmtpClient();

        try
        {
            await client.ConnectAsync(
                EmailConfiguration.SmtpServer,
                EmailConfiguration.Port,
                SecureSocketOptions.StartTls
            );

            await client.AuthenticateAsync(
                EmailConfiguration.UserName,
                EmailConfiguration.Password
            );

            await client.SendAsync(emailMessage);

            await client.DisconnectAsync(true);

            return true;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error sending email: {ex.Message}");
            return false;
        }
    }
}