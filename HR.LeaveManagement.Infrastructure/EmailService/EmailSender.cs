using HR.LeaveManagement.Application.Contracts.Email;
using HR.LeaveManagement.Application.Models.Email;
using Microsoft.Extensions.Options;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace HR.LeaveManagement.Infrastructure.EmailService;

public class EmailSender : IEmailSender
{
  public EmailSender(IOptions<EmailSettings> emailSettings)
  {
    _emailSettings = emailSettings.Value;
  }

  private EmailSettings _emailSettings { get; }

  public async Task<bool> SendEmail(EmailMessage email)
  {
    var client = new SendGridClient(_emailSettings.ApiKey);
    var to = new EmailAddress(email.To);
    var from = new EmailAddress
    {
      Email = _emailSettings.FromAddress,
      Name = _emailSettings.FromName
    };

    var message = MailHelper.CreateSingleEmail(from, to, email.Subject, email.Body, email.Body);
    var response = await client.SendEmailAsync(message);

    return response.IsSuccessStatusCode;
  }
}