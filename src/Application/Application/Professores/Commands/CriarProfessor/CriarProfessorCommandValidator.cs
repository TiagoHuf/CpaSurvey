using Biopark.CpaSurvey.Application.Alunos.Commands.CriarAluno;
using Biopark.CpaSurvey.Application.Common.Validators;
using Biopark.CpaSurvey.Domain.Interfaces.Infrastructure;
using FluentValidation;

namespace Biopark.CpaSurvey.Application.Eixos.Commands.CriarProfessor;

public class CriarProfessorCommandValidator : ValidatorBase<CriarProfessorCommand>
{
    public CriarProfessorCommandValidator(IUnitOfWork unitOfWork) : base(unitOfWork)
    {
        RuleFor(p => p.Nome)
            .NotEmpty()
            .MinimumLength(2)
            .MaximumLength(50);
    }
}