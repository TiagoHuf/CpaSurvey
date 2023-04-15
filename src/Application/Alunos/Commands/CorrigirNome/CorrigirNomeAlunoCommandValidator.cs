using Biopark.CpaSurvey.Application.Common.Validators;
using Biopark.CpaSurvey.Domain.Entities.Alunos;
using Biopark.CpaSurvey.Domain.Interfaces.Infrastructure;
using FluentValidation;

namespace Biopark.CpaSurvey.Application.Alunos.Commands.CorrigirNome;

public class CorrigirNomeAlunoCommandValidator : ValidatorBase<CorrigirNomeAlunoCommand>
{
    public CorrigirNomeAlunoCommandValidator(IUnitOfWork unitOfWork) : base(unitOfWork)
    {
        RuleFor(p => p.Nome)
            .NotEmpty()
            .MinimumLength(2)
            .MaximumLength(50);

        RuleFor(p => p.AlunoId)
            .MustExists<CorrigirNomeAlunoCommand, Aluno>(unitOfWork);
    }
}