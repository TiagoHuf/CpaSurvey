using Biopark.CpaSurvey.Application.Common.Validators;
using Biopark.CpaSurvey.Domain.Entities.Cursos;
using Biopark.CpaSurvey.Domain.Entities.Professores;
using Biopark.CpaSurvey.Domain.Interfaces.Infrastructure;
using FluentValidation;

namespace Biopark.CpaSurvey.Application.Disciplinas.Commands.CriarDisciplina;

public class CriarDisciplinaCommandValidator : ValidatorBase<CriarDisciplinaCommand>
{
    public CriarDisciplinaCommandValidator(IUnitOfWork unitOfWork) : base(unitOfWork)
    {
        RuleFor(p => p.Nome)
            .NotEmpty()
            .MinimumLength(2)
            .MaximumLength(50);

        RuleFor(p => p.ProfessorId)
            .MustExists<CriarDisciplinaCommand, Professor>(unitOfWork);

        RuleFor(p => p.CursoId)
            .MustExists<CriarDisciplinaCommand, Curso>(unitOfWork);
    }
}