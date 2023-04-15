using Biopark.CpaSurvey.Domain.Entities.Cursos;
using Biopark.CpaSurvey.Domain.Interfaces.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Biopark.CpaSurvey.Application.Cursos.Commands.CorrigirNome;

public class CorrigirNomeCursoCommand : IRequest
{
    public long CursoId { get; set; }

    public string Nome { get; set; }
}

public class CorrigirNomeCursoCommandHandler : IRequestHandler<CorrigirNomeCursoCommand>
{
    private readonly IUnitOfWork _unitOfWork;

    public CorrigirNomeCursoCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(CorrigirNomeCursoCommand request, CancellationToken cancellationToken)
    {
        var repository = _unitOfWork.GetRepository<Curso>();

        var curso = await repository
            .FindBy(c => c.Id == request.CursoId)
            .FirstAsync(cancellationToken);

        curso.CorrigirNome(request.Nome);

        await _unitOfWork.CommitAsync();

        return Unit.Value;
    }
}