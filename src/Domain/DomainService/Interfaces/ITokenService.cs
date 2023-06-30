using Biopark.CpaSurvey.Domain.Entities.Alunos;
using Biopark.CpaSurvey.Domain.Entities.Usuarios;

namespace Biopark.CpaSurvey.DomainService.Interfaces;

public interface ITokenService
{
    string GenerateToken(Usuario usuario);

    string GenerateResponseToken(Aluno aluno, DateTime evaluationEnd);
}