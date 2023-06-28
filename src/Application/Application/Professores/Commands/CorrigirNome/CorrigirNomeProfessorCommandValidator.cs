using Biopark.CpaSurvey.Application.Common.Validators;
using Biopark.CpaSurvey.Domain.Entities.Professores;
using Biopark.CpaSurvey.Domain.Interfaces.Infrastructure;
using FluentValidation;

namespace Biopark.CpaSurvey.Application.Professores.Commands.CorrigirNome;

public class CorrigirNomeProfessorCommandValidator : ValidatorBase<CorrigirNomeProfessorCommand>
{
    public CorrigirNomeProfessorCommandValidator(IUnitOfWork unitOfWork) : base(unitOfWork)
    {
        RuleFor(p => p.Nome)
            .NotEmpty()
            .MinimumLength(2)
            .MaximumLength(50);

        RuleFor(p => p.ProfessorId)
            .MustExists<CorrigirNomeProfessorCommand, Professor>(unitOfWork);
    }
}