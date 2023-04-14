using Biopark.CpaSurvey.Domain.Entities.TipoArea;
using Biopark.CpaSurvey.Domain.Interfaces.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Biopark.CpaSurvey.Application.Tipos.Queries.GetTipo;

public class GetTipoAreaQuery : IRequest<TipoArea>
{
    public long TipoId { get; set; }
}

public class GetTipoQueryHandler : IRequestHandler<GetTipoAreaQuery, TipoArea>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetTipoQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public Task<TipoArea> Handle(GetTipoAreaQuery request, CancellationToken cancellationToken)
    {
        var repository = _unitOfWork.GetRepository<TipoArea>();

        var tipo = repository
            .FindBy(c => c.Id == request.TipoId)
            .FirstAsync(cancellationToken);

        return tipo;
    }
}