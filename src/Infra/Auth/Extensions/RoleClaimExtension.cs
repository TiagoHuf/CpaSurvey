using Biopark.CpaSurvey.Domain.Entities.Alunos;
using Biopark.CpaSurvey.Domain.Entities.Usuarios;
using System.Security.Claims;

namespace Biopark.CpaSurvey.Infra.Auth.Extensions;

public static class RoleClaimExtension
{
    public static IEnumerable<Claim> GetClaims(this Usuario usuario)
    {
        var result = new List<Claim>
        {
            new (ClaimTypes.Name, usuario.Login),
        };

        return result;
    }

    public static IEnumerable<Claim> GetResponseClaims(this Aluno aluno)
    {
        var result = new List<Claim>
        {
            new (ClaimTypes.SerialNumber, aluno.Ra),
            new (ClaimTypes.Email, aluno.Email),
            new (ClaimTypes.Role, Role.Aluno.ToString())
        };

        return result;
    }
}