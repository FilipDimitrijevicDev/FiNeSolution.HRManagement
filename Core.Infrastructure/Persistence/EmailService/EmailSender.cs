using Core.Application.Common.Models;
using Core.Application.Common.Email;
using Microsoft.Extensions.Options;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace Core.Infrastructure.Persistence.EmailService;

public class EmailSender : IEmailSender
{
    public EmailSettings _emailSettings { get; }

    public EmailSender(IOptions<EmailSettings> emailSettings)
    { 
        _emailSettings = emailSettings.Value;
    }

    public async Task<bool> SendEmail(EmailMessage email)
    {
        var client = new SendGridClient(_emailSettings.ApiKey);
        var to = new EmailAddress(email.To);
        var from = new EmailAddress
        {
            Email = "dimitrijevicfilip995n@gmail.com",
            Name = _emailSettings.FromName
        };

        var message = MailHelper.CreateSingleEmail(from, to, email.Subject, email.Body, email.Body);

        var response = await client.SendEmailAsync(message);

        return response.IsSuccessStatusCode;
    }
}


