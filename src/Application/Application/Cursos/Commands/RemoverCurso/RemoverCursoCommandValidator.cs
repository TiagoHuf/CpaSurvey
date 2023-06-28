using Biopark.CpaSurvey.Application.Common.Validators;
using Biopark.CpaSurvey.Domain.Entities.Cursos;
using Biopark.CpaSurvey.Domain.Interfaces.Infrastructure;

namespace Biopark.CpaSurvey.Application.Cursos.Commands.RemoverCurso;

public class RemoverCursoCommandValidator : ValidatorBase<RemoverCursoCommand>
{
    public RemoverCursoCommandValidator(IUnitOfWork unitOfWork) : base(unitOfWork)
    {
        RuleFor(p => p.CursoId)
            .MustExists<RemoverCursoCommand, Curso>(unitOfWork);
    }
}