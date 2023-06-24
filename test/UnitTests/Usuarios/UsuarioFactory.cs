using Biopark.CpaSurvey.Domain.Entities.Usuarios;
using Biopark.CpaSurvey.Domain.Models.Usuarios;

namespace Biopark.CpaSurvey.UnitTests.Usuarios;

public class UsuarioFactory
{
    public static UsuairoModel GetUsuarioNovaModel()
    {
        return new UsuairoModel
        {
            Login = "Loginteste",
            Senha = "123456",
            Role = Role.Admin,
        };
    }
}
