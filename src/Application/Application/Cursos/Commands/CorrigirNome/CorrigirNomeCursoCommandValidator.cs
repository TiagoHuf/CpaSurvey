using Biopark.CpaSurvey.Application.Common.Validators;
using Biopark.CpaSurvey.Domain.Entities.Cursos;
using Biopark.CpaSurvey.Domain.Interfaces.Infrastructure;
using FluentValidation;

namespace Biopark.CpaSurvey.Application.Cursos.Commands.CorrigirNome;

public class CorrigirNomeCursoCommandValidator : ValidatorBase<CorrigirNomeCursoCommand>
{
    public CorrigirNomeCursoCommandValidator(IUnitOfWork unitOfWork) : base(unitOfWork)
    {
        RuleFor(p => p.Nome)
            .NotEmpty()
            .MinimumLength(2)
            .MaximumLength(50);

        RuleFor(p => p.CursoId)
            .MustExists<CorrigirNomeCursoCommand, Curso>(unitOfWork);
    }
}