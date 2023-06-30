using System.Security.Claims;

namespace Biopark.CpaSurvey.DomainService.Interfaces;

public interface IUser
{
    string Name { get; }

    bool IsAuthenticated();

    IEnumerable<Claim> GetClaimsIdentity();
}