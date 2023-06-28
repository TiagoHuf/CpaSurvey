using Biopark.CpaSurvey.Domain.Entities.Cursos;
using Biopark.CpaSurvey.Domain.Interfaces.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Biopark.CpaSurvey.Application.Cursos.Commands.RemoverCurso;
public class RemoverCursoCommand : IRequest
{
    public long CursoId { get; set; }
}

public class RemoverCursoCommandHandler : IRequestHandler<RemoverCursoCommand>
{
    private readonly IUnitOfWork _unitOfWork;

    public RemoverCursoCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(RemoverCursoCommand request, CancellationToken cancellationToken)
    {
        var repository = _unitOfWork.GetRepository<Curso>();

        var curso = await repository
            .FindBy(c => c.Id == request.CursoId)
            .FirstAsync(cancellationToken);

        repository.Delete(curso);

        await _unitOfWork.CommitAsync();

        return Unit.Value;
    }
}