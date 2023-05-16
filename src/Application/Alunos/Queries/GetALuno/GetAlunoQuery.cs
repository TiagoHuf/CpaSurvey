using Biopark.CpaSurvey.Domain.Entities.Alunos;
using Biopark.CpaSurvey.Domain.Interfaces.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Biopark.CpaSurvey.Application.Alunos.Queries.GetAluno;

public class GetAlunoQuery : IRequest<Aluno>
{
    public long AlunoId { get; set; }
}

public class GetAlunoQueryHandler : IRequestHandler<GetAlunoQuery, Aluno>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAlunoQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public Task<Aluno> Handle(GetAlunoQuery request, CancellationToken cancellationToken)
    {
        var repository = _unitOfWork.GetRepository<Aluno>();

        var aluno = repository
            .FindBy(c => c.Id == request.AlunoId)
            .Include(a => a.Curso)
            .Include(a => a.Disciplinas).ThenInclude(d => d.Disciplina)
            .Include(a => a.Turmas)
            .FirstAsync(cancellationToken);

        return aluno;
    }
}