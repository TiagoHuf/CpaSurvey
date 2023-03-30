using Biopark.CpaSurvey.Domain.Entities.Tipo;
using Biopark.CpaSurvey.Domain.Interfaces.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Biopark.CpaSurvey.Application.Tipos.Queries.GetTipo;

public class GetTipoQuery : IRequest<Tipo>
{
    public long TipoId { get; set; }
}

public class GetTipoQueryHandler : IRequestHandler<GetTipoQuery, Tipo>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetTipoQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public Task<Tipo> Handle(GetTipoQuery request, CancellationToken cancellationToken)
    {
        var repository = _unitOfWork.GetRepository<Tipo>();

        var tipo = repository
            .FindBy(c => c.Id == request.TipoId)
            .FirstAsync(cancellationToken);

        return tipo;
    }
}