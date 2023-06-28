using Biopark.CpaSurvey.Application.Common.Validators;
using Biopark.CpaSurvey.Domain.Entities.Turmas;
using Biopark.CpaSurvey.Domain.Interfaces.Infrastructure;
using FluentValidation;

namespace Biopark.CpaSurvey.Application.Turmas.Commands.CorrigirNome;

public class CorrigirNomeTurmaCommandValidator : ValidatorBase<CorrigirNomeTurmaCommand>
{
    public CorrigirNomeTurmaCommandValidator(IUnitOfWork unitOfWork) : base(unitOfWork)
    {
        RuleFor(p => p.Nome)
            .NotEmpty()
            .MinimumLength(2)
            .MaximumLength(50);

        RuleFor(p => p.TurmaId)
            .MustExists<CorrigirNomeTurmaCommand, Turma>(unitOfWork);
    }
}