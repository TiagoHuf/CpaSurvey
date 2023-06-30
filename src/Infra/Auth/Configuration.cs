namespace Biopark.CpaSurvey.Infra.Auth;

public static class Configuration
{
    public static string JwtKey { get; set; } = "ZmVkYCY3ZDg4NjNiNFhkMTk3YjkyO8dkNDkyYjcwOGL";

    public static SmtpConfiguration Smtp = new ();

    public class SmtpConfiguration
    {
        public string Host { get; set; }

        public int Port { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }
    }
}