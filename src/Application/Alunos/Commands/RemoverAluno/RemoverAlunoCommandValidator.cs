using Biopark.CpaSurvey.Application.Common.Validators;
using Biopark.CpaSurvey.Domain.Entities.Alunos;
using Biopark.CpaSurvey.Domain.Interfaces.Infrastructure;

namespace Biopark.CpaSurvey.Application.Alunos.Commands.RemoverAluno;

public class RemoverAlunoCommandValidator : ValidatorBase<RemoverAlunoCommand>
{
    public RemoverAlunoCommandValidator(IUnitOfWork unitOfWork) : base(unitOfWork)
    {
        RuleFor(p => p.AlunoId)
            .MustExists<RemoverAlunoCommand, Aluno>(unitOfWork);
    }
}