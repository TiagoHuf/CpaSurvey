using Biopark.CpaSurvey.Domain.Entities.Cursos;
using Biopark.CpaSurvey.Domain.Interfaces.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Biopark.CpaSurvey.Application.Cursos.Commands.Queries.GetCurso;

public class GetCursoQuery : IRequest<Curso>
{
    public long CursoId { get; set; }
}

public class GetCursoQueryHandler : IRequestHandler<GetCursoQuery, Curso>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetCursoQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public Task<Curso> Handle(GetCursoQuery request, CancellationToken cancellationToken)
    {
        var repository = _unitOfWork.GetRepository<Curso>();

        var Curso = repository
            .FindBy(c => c.Id == request.CursoId)
            .FirstAsync(cancellationToken);

        return Curso;
    }
}