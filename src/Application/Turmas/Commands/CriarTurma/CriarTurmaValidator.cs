using Biopark.CpaSurvey.Application.Common.Validators;
using Biopark.CpaSurvey.Domain.Interfaces.Infrastructure;
using FluentValidation;

namespace Biopark.CpaSurvey.Application.Turmas.Commands.CriarTurma;

public class CriarTurmaValidator : ValidatorBase<CriarTurmaCommand>
{
    public CriarTurmaValidator(IUnitOfWork unitOfWork) : base(unitOfWork)
    {
        RuleFor(p => p.Nome)
            .NotEmpty()
            .MinimumLength(5)
            .MaximumLength(200);

        //RuleFor(p => p.CursoId)
        //    .MustExists<CriarTurmaCommand, Curso>(unitOfWork);
    }
}