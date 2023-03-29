using Biopark.CpaSurvey.Domain.Entities.Cursos;
using Biopark.CpaSurvey.Domain.Interfaces.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;
namespace Biopark.CpaSurvey.Application.Cursos.Commands.Queries.GetCursos;  
public class GetCursosQuery : IRequest<List<Curso>>
{
}

public class GetCursosQueryHandler :
    IRequestHandler<GetCursosQuery, List<Curso>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetCursosQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<List<Curso>> Handle(
        GetCursosQuery request,
        CancellationToken cancellationToken)
    {
        var repository = _unitOfWork.GetRepository<Curso>();

        var cursos = await repository
            .GetAll()
            .ToListAsync(cancellationToken);

        return cursos;
    }
}