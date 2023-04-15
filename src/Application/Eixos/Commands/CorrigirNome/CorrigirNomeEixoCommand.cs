using Biopark.CpaSurvey.Domain.Entities.Eixos;
using Biopark.CpaSurvey.Domain.Interfaces.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Biopark.CpaSurvey.Application.Eixos.Commands.CorrigirNome;

public class CorrigirNomeEixoCommand : IRequest
{
    public long EixoId { get; set; }

    public string Nome { get; set; }
}

public class CorrigirNomeEixoCommandHandler : IRequestHandler<CorrigirNomeEixoCommand>
{
    private readonly IUnitOfWork _unitOfWork;

    public CorrigirNomeEixoCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(CorrigirNomeEixoCommand request, CancellationToken cancellationToken)
    {
        var repository = _unitOfWork.GetRepository<Eixo>();

        var eixo = await repository
            .FindBy(c => c.Id == request.EixoId)
            .FirstAsync(cancellationToken);

        eixo.CorrigirNome(request.Nome);

        await _unitOfWork.CommitAsync();

        return Unit.Value;
    }
}