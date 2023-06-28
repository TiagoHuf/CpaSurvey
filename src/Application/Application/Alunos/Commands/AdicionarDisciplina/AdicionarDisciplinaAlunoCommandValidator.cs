using Biopark.CpaSurvey.Application.Common.Validators;
using Biopark.CpaSurvey.Domain.Entities.Alunos;
using Biopark.CpaSurvey.Domain.Entities.Disciplinas;
using Biopark.CpaSurvey.Domain.Interfaces.Infrastructure;

namespace Biopark.CpaSurvey.Application.Alunos.Commands.AdicionarDisciplina;

public class AdicionarDisciplinaAlunoCommandValidator : ValidatorBase<AdicionarDisciplinaAlunoCommand>
{
    public AdicionarDisciplinaAlunoCommandValidator(IUnitOfWork unitOfWork) : base(unitOfWork)
    {
        RuleFor(p => p.AlunoId)
            .MustExists<AdicionarDisciplinaAlunoCommand, Aluno>(unitOfWork);

        RuleFor(p => p.DisciplinaId)
            .MustExists<AdicionarDisciplinaAlunoCommand, Disciplina>(unitOfWork);
    }
}