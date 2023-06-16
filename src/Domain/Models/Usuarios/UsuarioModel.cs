using System.Security.Principal;

namespace Biopark.CpaSurvey.Domain.Models.Usuarios;

public class UsuairoModel
{
    public string Login { get; set; }

    public string Senha { get; set; }

    public Role Role { get; set; }
}
