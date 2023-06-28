using Biopark.CpaSurvey.Application.Common.Validators;
using Biopark.CpaSurvey.Domain.Entities.Turmas;
using Biopark.CpaSurvey.Domain.Interfaces.Infrastructure;

namespace Biopark.CpaSurvey.Application.Turmas.Commands.RemoverTurma;

public class RemoverTurmaCommandValidator : ValidatorBase<RemoverTurmaCommand>
{
    public RemoverTurmaCommandValidator(IUnitOfWork unitOfWork) : base(unitOfWork)
    {
        RuleFor(p => p.TurmaId)
            .MustExists<RemoverTurmaCommand, Turma>(unitOfWork);
    }
}