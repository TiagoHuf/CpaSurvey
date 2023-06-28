namespace Biopark.CpaSurvey.Infra.Auth.Services;

public class LoginResponseModel
{
    public string Token { get; set; }

    public string Mensagem { get; set; }

    public bool IsAutenticado { get; set; }
}