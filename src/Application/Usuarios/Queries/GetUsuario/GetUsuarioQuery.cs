using Biopark.CpaSurvey.Domain.Entities.Usuarios;
using Biopark.CpaSurvey.Domain.Interfaces.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Biopark.CpaSurvey.Application.Usuarios.Queries.GetUsuario;

public class GetUsuarioQuery : IRequest<Usuario>
{
    public long UsuarioId { get; set; }
}

public class GetUsuarioQueryHandler : IRequestHandler<GetUsuarioQuery, Usuario>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetUsuarioQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public Task<Usuario> Handle(GetUsuarioQuery request, CancellationToken cancellationToken)
    {
        var repository = _unitOfWork.GetRepository<Usuario>();

        var usuario = repository
            .FindBy(c => c.Id == request.UsuarioId)
            .FirstAsync(cancellationToken);

        return usuario;
    }
}