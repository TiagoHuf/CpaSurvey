using Biopark.CpaSurvey.Domain.Entities.Usuarios;
using Biopark.CpaSurvey.Domain.Interfaces.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Biopark.CpaSurvey.Application.Usuarios.Queries.GetUsuarios;
public class GetUsuariosQuery : IRequest<List<Usuario>>
{
}

public class GetUsuariosQueryHandler :
    IRequestHandler<GetUsuariosQuery, List<Usuario>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetUsuariosQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<List<Usuario>> Handle(
        GetUsuariosQuery request,
        CancellationToken cancellationToken)
    {
        var repository = _unitOfWork.GetRepository<Usuario>();

        var usuarios = await repository
            .GetAll()
            .ToListAsync(cancellationToken);

        return usuarios;
    }
}
