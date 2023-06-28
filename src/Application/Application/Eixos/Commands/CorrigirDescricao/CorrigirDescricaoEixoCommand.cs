using Biopark.CpaSurvey.Domain.Entities.Eixos;
using Biopark.CpaSurvey.Domain.Interfaces.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Biopark.CpaSurvey.Application.Eixos.Commands.CorrigirDescricao;

public class CorrigirDescricaoEixoCommand : IRequest
{
    public long EixoId { get; set; }

    public string Descricao { get; set; }
}

public class CorrigirDescricaoEixoCommandHandler : IRequestHandler<CorrigirDescricaoEixoCommand>
{
    private readonly IUnitOfWork _unitOfWork;

    public CorrigirDescricaoEixoCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(CorrigirDescricaoEixoCommand request, CancellationToken cancellationToken)
    {
        var repository = _unitOfWork.GetRepository<Eixo>();

        var eixo = await repository
            .FindBy(c => c.Id == request.EixoId)
            .FirstAsync(cancellationToken);

        eixo.CorrigirDescricao(request.Descricao);

        await _unitOfWork.CommitAsync();

        return Unit.Value;
    }
}