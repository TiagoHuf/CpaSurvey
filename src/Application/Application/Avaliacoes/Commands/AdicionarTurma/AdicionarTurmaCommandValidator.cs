using Biopark.CpaSurvey.Application.Common.Validators;
using Biopark.CpaSurvey.Domain.Entities.Avaliacoes;
using Biopark.CpaSurvey.Domain.Entities.Turmas;
using Biopark.CpaSurvey.Domain.Interfaces.Infrastructure;

namespace Biopark.CpaSurvey.Application.Avaliacoes.Commands.AdicionarTurma;

public class AdicionarTurmaCommandValidator : ValidatorBase<AdicionarTurmaCommand>
{
    public AdicionarTurmaCommandValidator(IUnitOfWork unitOfWork) : base(unitOfWork)
    {
        RuleFor(a => a.AvaliacaoId)
            .MustExists<AdicionarTurmaCommand, Avaliacao>(unitOfWork);

        RuleFor(a => a.TurmaId)
            .MustExists<AdicionarTurmaCommand, Turma>(unitOfWork);
    }
}
