using Biopark.CpaSurvey.Domain.Entities.Disciplinas;
using Biopark.CpaSurvey.Domain.Interfaces.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Biopark.CpaSurvey.Application.Disciplinas.Commands.CorrigirNome;

public class CorrigirNomeDisciplinaCommand : IRequest
{
    public long DisciplinaId { get; set; }

    public string Nome { get; set; }
}

public class CorrigirNomeDisciplinaCommandHandler : IRequestHandler<CorrigirNomeDisciplinaCommand>
{
    private readonly IUnitOfWork _unitOfWork;

    public CorrigirNomeDisciplinaCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(CorrigirNomeDisciplinaCommand request, CancellationToken cancellationToken)
    {
        var repository = _unitOfWork.GetRepository<Disciplina>();

        var disciplina = await repository
            .FindBy(c => c.Id == request.DisciplinaId)
            .FirstAsync(cancellationToken);

        disciplina.CorrigirNome(request.Nome);

        await _unitOfWork.CommitAsync();

        return Unit.Value;
    }
}