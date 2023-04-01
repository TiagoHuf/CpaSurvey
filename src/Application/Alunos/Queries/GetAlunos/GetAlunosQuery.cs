using Biopark.CpaSurvey.Domain.Entities.Usuarios;
using Biopark.CpaSurvey.Domain.Interfaces.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Biopark.CpaSurvey.Application.Alunos.Queries.GetAlunos;
public class GetAlunosQuery : IRequest<List<Aluno>>
{
}

public class GetAlunosQueryHandler :
    IRequestHandler<GetAlunosQuery, List<Aluno>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAlunosQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<List<Aluno>> Handle(
        GetAlunosQuery request,
        CancellationToken cancellationToken)
    {
        var repository = _unitOfWork.GetRepository<Aluno>();

        var alunos = await repository
            .GetAll()
            .ToListAsync(cancellationToken);

        return alunos;
    }
}