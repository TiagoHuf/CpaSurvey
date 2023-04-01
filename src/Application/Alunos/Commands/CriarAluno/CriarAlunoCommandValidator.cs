using Biopark.CpaSurvey.Application.Common.Validators;
using Biopark.CpaSurvey.Application.Alunos.Commands.CriarAluno;
using Biopark.CpaSurvey.Domain.Interfaces.Infrastructure;
using FluentValidation;

namespace Biopark.CpaSurvey.Application.Alunos.Commands.CriarAluno;

public class CriarAlunoCommandValidator : ValidatorBase<CriarAlunoCommand>
{
    public CriarAlunoCommandValidator(IUnitOfWork unitOfWork) : base(unitOfWork)
    {
        RuleFor(p => p.Nome)
            .NotEmpty()
            .MinimumLength(2)
            .MaximumLength(50);

        RuleFor(p => p.Ra)
            .NotEmpty()
            .MinimumLength(8)
            .MaximumLength(8);
    }
}
