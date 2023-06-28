using Biopark.CpaSurvey.Application.Common.Validators;
using Biopark.CpaSurvey.Domain.Entities.Alunos;
using Biopark.CpaSurvey.Domain.Interfaces.Infrastructure;
using FluentValidation;

namespace Biopark.CpaSurvey.Application.Alunos.Commands.CorrigirRa;

public class CorrigirRaAlunoCommandValidator : ValidatorBase<CorrigirRaAlunoCommand>
{
    public CorrigirRaAlunoCommandValidator(IUnitOfWork unitOfWork) : base(unitOfWork)
    {
        RuleFor(p => p.Ra)
            .NotEmpty()
            .MinimumLength(1)
            .MaximumLength(8);

        RuleFor(p => p.AlunoId)
            .MustExists<CorrigirRaAlunoCommand, Aluno>(unitOfWork);
    }
}