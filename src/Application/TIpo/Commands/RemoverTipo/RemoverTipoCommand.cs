using Biopark.CpaSurvey.Domain.Entities.Tipo;
using Biopark.CpaSurvey.Domain.Interfaces.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Biopark.CpaSurvey.Application.TIpo.Commands.RemoverTipo;

public class RemoverTipoCommand : IRequest
{
    public long TipoId { get; set; }
}

public class RemoverTipoCommandHandler : IRequestHandler<RemoverTipoCommand>
{
    private readonly IUnitOfWork _unitOfWork;

    public RemoverTipoCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(RemoverTipoCommand request, CancellationToken cancellationToken)
    {
        var repository = _unitOfWork.GetRepository<Tipo>();

        var tipo = await repository
            .FindBy(c => c.Id == request.TipoId)
            .FirstAsync(cancellationToken);

        repository.Delete(tipo);

        await _unitOfWork.CommitAsync();

        return Unit.Value;
    }
}