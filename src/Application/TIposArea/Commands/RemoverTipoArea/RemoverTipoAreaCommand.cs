using Biopark.CpaSurvey.Domain.Entities.Tipo;
using Biopark.CpaSurvey.Domain.Interfaces.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Biopark.CpaSurvey.Application.TIpo.Commands.RemoverTipo;

public class RemoverTipoAreaCommand : IRequest
{
    public long TipoId { get; set; }
}

public class RemoverTipoCommandHandler : IRequestHandler<RemoverTipoAreaCommand>
{
    private readonly IUnitOfWork _unitOfWork;

    public RemoverTipoCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(RemoverTipoAreaCommand request, CancellationToken cancellationToken)
    {
        var repository = _unitOfWork.GetRepository<TipoArea>();

        var tipo = await repository
            .FindBy(c => c.Id == request.TipoId)
            .FirstAsync(cancellationToken);

        repository.Delete(tipo);

        await _unitOfWork.CommitAsync();

        return Unit.Value;
    }
}