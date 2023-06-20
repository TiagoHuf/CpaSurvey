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

        result.Add(new Claim(ClaimTypes.Role, usuario.Role.ToString()));

        return result;
    }
}