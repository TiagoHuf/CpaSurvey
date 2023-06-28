using Biopark.CpaSurvey.Application.Common.Validators;
using Biopark.CpaSurvey.Domain.Entities.Alunos;
using Biopark.CpaSurvey.Domain.Entities.Turmas;
using Biopark.CpaSurvey.Domain.Interfaces.Infrastructure;

namespace Biopark.CpaSurvey.Application.Alunos.Commands.AdicionarTurma;

public class AdicionarTurmaAlunoCommandValidator : ValidatorBase<AdicionarTurmaAlunoCommand>
{
    public AdicionarTurmaAlunoCommandValidator(IUnitOfWork unitOfWork) : base(unitOfWork)
    {
        RuleFor(p => p.AlunoId)
            .MustExists<AdicionarTurmaAlunoCommand, Aluno>(unitOfWork);

        RuleFor(p => p.TurmaId)
            .MustExists<AdicionarTurmaAlunoCommand, Turma>(unitOfWork);
    }
}