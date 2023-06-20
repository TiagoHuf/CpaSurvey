using Biopark.CpaSurvey.Domain.Interfaces;
using Biopark.CpaSurvey.Domain.Models.Usuarios;

namespace Biopark.CpaSurvey.Domain.Entities.Usuarios;

public partial class Usuario : BaseEntity<long>, IAggregateRoot
{
    public Usuario(UsuairoModel model)
    {
        Login = model.Login;
        SenhaHash = model.Senha;
        Role = model.Role;
    }

    private Usuario() 
    {
        // Necessário para o EntityFramework.
    }

    public string Login { get; private set; }

    public string SenhaHash { get; private set; }

    public Role Role { get; private set; }
}