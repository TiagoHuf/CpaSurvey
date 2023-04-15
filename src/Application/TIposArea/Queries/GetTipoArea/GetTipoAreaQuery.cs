using Biopark.CpaSurvey.Domain.Entities.TiposArea;
using Biopark.CpaSurvey.Domain.Interfaces.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Biopark.CpaSurvey.Application.TiposArea.Queries.GetTipo;

public class GetTipoAreaQuery : IRequest<TipoArea>
{
    public long TipoAreaId { get; set; }
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
            .FindBy(c => c.Id == request.TipoAreaId)
            .FirstAsync(cancellationToken);

        return tipo;
    }
}