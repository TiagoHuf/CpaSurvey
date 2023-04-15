using Biopark.CpaSurvey.Domain.Entities.TiposArea;
using Biopark.CpaSurvey.Domain.Interfaces.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Biopark.CpaSurvey.Application.TiposArea.Commands.CorrigirNome;

public class CorrigirNomeTipoAreaCommand : IRequest
{
    public long TipoAreaId { get; set; }

    public string Nome { get; set; }
}

public class CorrigirNomeTipoAreaoCommandHandler : IRequestHandler<CorrigirNomeTipoAreaCommand>
{
    private readonly IUnitOfWork _unitOfWork;

    public CorrigirNomeTipoAreaoCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(CorrigirNomeTipoAreaCommand request, CancellationToken cancellationToken)
    {
        var repository = _unitOfWork.GetRepository<TipoArea>();

        var tipoArea = await repository
            .FindBy(c => c.Id == request.TipoAreaId)
            .FirstAsync(cancellationToken);

        tipoArea.CorrigirNome(request.Nome);

        await _unitOfWork.CommitAsync();

        return Unit.Value;
    }
}