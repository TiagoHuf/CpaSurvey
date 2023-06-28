using Biopark.CpaSurvey.Domain.Entities.Usuarios;
using Biopark.CpaSurvey.Domain.Interfaces.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Biopark.CpaSurvey.Application.Usuarios.Commands.CorrigirRole;
public class CorrigirRoleUsuarioCommand : IRequest
{
    public long UsarioId { get; set; }

    public Role Role { get; set; }
}

public class CorrigirRoleUsuarioCommandHandler : IRequestHandler<CorrigirRoleUsuarioCommand>
{
    private readonly IUnitOfWork _unitOfWork;

    public CorrigirRoleUsuarioCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(CorrigirRoleUsuarioCommand request, CancellationToken cancellationToken)
    {
        var repository = _unitOfWork.GetRepository<Usuario>();

        var usuario = await repository
            .FindBy(c => c.Id == request.UsarioId)
            .FirstAsync(cancellationToken);

        usuario.CorrigirRole(request.Role);

        await _unitOfWork.CommitAsync();

        return Unit.Value;
    }
}