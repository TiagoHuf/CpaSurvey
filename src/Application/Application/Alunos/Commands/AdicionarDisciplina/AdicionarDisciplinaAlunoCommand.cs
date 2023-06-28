using Biopark.CpaSurvey.Domain.Entities.Alunos;
using Biopark.CpaSurvey.Domain.Entities.Disciplinas;
using Biopark.CpaSurvey.Domain.Interfaces.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Biopark.CpaSurvey.Application.Alunos.Commands.AdicionarDisciplina;

public class AdicionarDisciplinaAlunoCommand : IRequest
{
    public long AlunoId { get; set; }

    public long DisciplinaId { get; set; }
}

public class AdicionarDisciplinaAlunoCommandHandler : IRequestHandler<AdicionarDisciplinaAlunoCommand>
{
    private readonly IUnitOfWork _unitOfWork;

    public AdicionarDisciplinaAlunoCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(AdicionarDisciplinaAlunoCommand request, CancellationToken cancellationToken)
    {
        var repository = _unitOfWork.GetRepository<Aluno>();

        var aluno = await repository
            .FindBy(c => c.Id == request.AlunoId)
            .FirstAsync(cancellationToken);

        var disciplina = await BuscaDisciplina(request.DisciplinaId, cancellationToken);

        aluno.AdicionarDisciplina(disciplina);

        await _unitOfWork.CommitAsync();

        return Unit.Value;
    }

    public async Task<Disciplina> BuscaDisciplina(long id, CancellationToken cancellationToken)
    {
        var repository = _unitOfWork.GetRepository<Disciplina>();

        var disciplina = await repository
           .FindBy(c => c.Id == id)
           .FirstAsync(cancellationToken);

        return disciplina;
    }
}