using Biopark.CpaSurvey.Domain.Entities.Usuarios;

namespace Biopark.CpaSurvey.DomainService.Interfaces;

public interface ITokenService
{
    string GenerateToken(Usuario usuario);
}