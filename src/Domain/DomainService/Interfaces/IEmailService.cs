namespace Biopark.CpaSurvey.DomainService.Interfaces;

public interface IEmailService
{
    bool Send(string toName, string toEmail, string subject, string body);
}