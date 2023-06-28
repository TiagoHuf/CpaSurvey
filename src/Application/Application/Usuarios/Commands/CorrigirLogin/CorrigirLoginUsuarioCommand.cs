using Biopark.CpaSurvey.Domain.Entities.Usuarios;
using Biopark.CpaSurvey.Domain.Interfaces.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Biopark.CpaSurvey.Application.Usuarios.Commands.CorrigirLogin;

public class CorrigirLoginUsuarioCommand : IRequest
{
    public long UsarioId { get; set; }

    public string Login { get; set; }
}

public class CorrigirLoginUsuarioCommandHandler : IRequestHandler<CorrigirLoginUsuarioCommand>
{
    private readonly IUnitOfWork _unitOfWork;

    public CorrigirLoginUsuarioCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(CorrigirLoginUsuarioCommand request, CancellationToken cancellationToken)
    {
        var repository = _unitOfWork.GetRepository<Usuario>();

        var usuario = await repository
            .FindBy(c => c.Id == request.UsarioId)
            .FirstAsync(cancellationToken);

        usuario.CorrigirLogin(request.Login);

        await _unitOfWork.CommitAsync();

        return Unit.Value;
    }
}