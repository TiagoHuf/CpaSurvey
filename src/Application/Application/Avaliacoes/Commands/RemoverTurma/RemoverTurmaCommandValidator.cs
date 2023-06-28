using Biopark.CpaSurvey.Application.Common.Validators;
using Biopark.CpaSurvey.Domain.Entities.Avaliacoes;
using Biopark.CpaSurvey.Domain.Entities.Turmas;
using Biopark.CpaSurvey.Domain.Interfaces.Infrastructure;

namespace Biopark.CpaSurvey.Application.Avaliacoes.Commands.RemoverTurma;

public class RemoverTurmaCommandValidator : ValidatorBase<RemoverTurmaCommand>
{
    public RemoverTurmaCommandValidator(IUnitOfWork unitOfWork) : base(unitOfWork)
    {
        RuleFor(a => a.AvaliacaoId)
            .MustExists<RemoverTurmaCommand, Avaliacao>(unitOfWork);

        RuleFor(a => a.TurmaId)
            .MustExists<RemoverTurmaCommand, Turma>(unitOfWork);
    }
}