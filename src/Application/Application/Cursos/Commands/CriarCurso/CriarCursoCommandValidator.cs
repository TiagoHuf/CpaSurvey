using Biopark.CpaSurvey.Application.Common.Validators;
using Biopark.CpaSurvey.Domain.Interfaces.Infrastructure;
using FluentValidation;

namespace Biopark.CpaSurvey.Application.Cursos.Commands.CriarCurso;

public class CriarCursoCommandValidator : ValidatorBase<CriarCursoCommand>
{
    public CriarCursoCommandValidator(IUnitOfWork unitOfWork) : base(unitOfWork)
    {
        RuleFor(p => p.Nome)
            .NotEmpty()
            .MinimumLength(2)
            .MaximumLength(50);
    }
}