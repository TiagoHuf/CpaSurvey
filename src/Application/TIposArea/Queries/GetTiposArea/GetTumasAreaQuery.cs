using Biopark.CpaSurvey.Domain.Entities.TiposArea;
using Biopark.CpaSurvey.Domain.Interfaces.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Biopark.CpaSurvey.Application.TiposArea.Queries.GetTipos;

public class GetTiposAreaQuery : IRequest<List<TipoArea>>
{
}

public class GetTiposQueryHandler : IRequestHandler<GetTiposAreaQuery, List<TipoArea>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetTiposQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<List<TipoArea>> Handle(GetTiposAreaQuery request, CancellationToken cancellationToken)
    {
        var repository = _unitOfWork.GetRepository<TipoArea>();

        var tipos = await repository
            .GetAll()
            .ToListAsync(cancellationToken);

        return tipos;
    }
}