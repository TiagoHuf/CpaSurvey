using Biopark.CpaSurvey.Application.Common.Validators;
using Biopark.CpaSurvey.Domain.Entities.Alunos;
using Biopark.CpaSurvey.Domain.Interfaces.Infrastructure;

namespace Biopark.CpaSurvey.Application.Alunos.Commands.Ativar;

public class AtivarAlunoCommandValidator : ValidatorBase<AtivarAlunoCommand>
{
    public AtivarAlunoCommandValidator(IUnitOfWork unitOfWork) : base(unitOfWork)
    {
        RuleFor(p => p.AlunoId)
            .MustExists<AtivarAlunoCommand, Aluno>(unitOfWork);
    }
}