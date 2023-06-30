using Biopark.CpaSurvey.DomainService.Interfaces;
using System.Net;
using System.Net.Mail;

namespace Biopark.CpaSurvey.Infra.Auth.Services;

public class EmailService : IEmailService
{
    public bool Send(
        string toName,
        string toEmail,
        string subject,
        string body)
    {
        string fromName = "Cpa Survey";
        string fromEmail = "CpaSurveyMail@gmail.com";

        var smtpClient = new SmtpClient(Configuration.Smtp.Host, Configuration.Smtp.Port);

        smtpClient.Credentials = new NetworkCredential(Configuration.Smtp.Username, Configuration.Smtp.Password);
        smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
        smtpClient.EnableSsl = true;

        var mail = new MailMessage();

        mail.From = new MailAddress(fromEmail, fromName);
        mail.To.Add(new MailAddress(toEmail, toName));
        mail.Subject = subject;
        mail.Body = body;
        mail.IsBodyHtml = true;

        try
        {
            smtpClient.Send(mail);
            return true;
        }
        catch (Exception ex)
        {
            return false;
        }
    }
}