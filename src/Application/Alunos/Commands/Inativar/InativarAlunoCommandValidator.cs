using Biopark.CpaSurvey.Application.Common.Validators;
using Biopark.CpaSurvey.Domain.Entities.Alunos;
using Biopark.CpaSurvey.Domain.Interfaces.Infrastructure;

namespace Biopark.CpaSurvey.Application.Alunos.Commands.Inativar;

public class InativarAlunoCommandValidator : ValidatorBase<InativarAlunoCommand>
{
    public InativarAlunoCommandValidator(IUnitOfWork unitOfWork) : base(unitOfWork)
    {
        RuleFor(p => p.AlunoId)
            .MustExists<InativarAlunoCommand, Aluno>(unitOfWork);
    }
}