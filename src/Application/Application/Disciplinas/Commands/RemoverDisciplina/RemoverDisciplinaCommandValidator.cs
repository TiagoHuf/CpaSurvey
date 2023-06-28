using Biopark.CpaSurvey.Application.Common.Validators;
using Biopark.CpaSurvey.Domain.Entities.Disciplinas;
using Biopark.CpaSurvey.Domain.Interfaces.Infrastructure;

namespace Biopark.CpaSurvey.Application.Disciplinas.Commands.RemoverDisciplina;

public class RemoverDisciplinaCommandValidator : ValidatorBase<RemoverDisciplinaCommand>
{
    public RemoverDisciplinaCommandValidator(IUnitOfWork unitOfWork) : base(unitOfWork)
    {
        RuleFor(p => p.DisciplinaId)
            .MustExists<RemoverDisciplinaCommand, Disciplina>(unitOfWork);
    }
}