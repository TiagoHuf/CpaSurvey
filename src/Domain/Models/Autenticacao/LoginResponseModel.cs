namespace Biopark.CpaSurvey.Domain.Models.Autenticacao;

public class LoginResponseModel
{
    public string Token { get; set; }

    public string Mensagem { get; set; }

    public bool IsAutenticado { get; set; }
}