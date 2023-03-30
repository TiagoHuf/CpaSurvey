using Biopark.CpaSurvey.Domain.Entities.Tipo;
using Biopark.CpaSurvey.Domain.Interfaces.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Biopark.CpaSurvey.Application.Tipos.Queries.GetTipos;

public class GetTiposQuery : IRequest<List<Tipo>>
{
}

public class GetTiposQueryHandler : IRequestHandler<GetTiposQuery, List<Tipo>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetTiposQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<List<Tipo>> Handle(GetTiposQuery request, CancellationToken cancellationToken)
    {
        var repository = _unitOfWork.GetRepository<Tipo>();

        var tipos = await repository
            .GetAll()
            .ToListAsync(cancellationToken);

        return tipos;
    }
}