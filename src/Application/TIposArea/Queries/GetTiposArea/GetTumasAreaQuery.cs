using Biopark.CpaSurvey.Domain.Entities.Tipo;
using Biopark.CpaSurvey.Domain.Interfaces.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Biopark.CpaSurvey.Application.Tipos.Queries.GetTipos;

public class GetTiposQuery : IRequest<List<TipoArea>>
{
}

public class GetTiposQueryHandler : IRequestHandler<GetTiposQuery, List<TipoArea>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetTiposQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<List<TipoArea>> Handle(GetTiposQuery request, CancellationToken cancellationToken)
    {
        var repository = _unitOfWork.GetRepository<TipoArea>();

        var tipos = await repository
            .GetAll()
            .ToListAsync(cancellationToken);

        return tipos;
    }
}