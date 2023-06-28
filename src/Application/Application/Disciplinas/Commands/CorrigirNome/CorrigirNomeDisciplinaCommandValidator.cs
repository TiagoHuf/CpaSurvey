using Biopark.CpaSurvey.Application.Common.Validators;
using Biopark.CpaSurvey.Domain.Entities.Disciplinas;
using Biopark.CpaSurvey.Domain.Interfaces.Infrastructure;
using FluentValidation;

namespace Biopark.CpaSurvey.Application.Disciplinas.Commands.CorrigirNome;

public class CorrigirNomeDisciplinaCommandValidator : ValidatorBase<CorrigirNomeDisciplinaCommand>
{
    public CorrigirNomeDisciplinaCommandValidator(IUnitOfWork unitOfWork) : base(unitOfWork)
    {
        RuleFor(p => p.Nome)
            .NotEmpty()
            .MinimumLength(2)
            .MaximumLength(50);

        RuleFor(p => p.DisciplinaId)
            .MustExists<CorrigirNomeDisciplinaCommand, Disciplina>(unitOfWork);
    }
}