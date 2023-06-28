using Biopark.CpaSurvey.Domain.Entities.Usuarios;
using Biopark.CpaSurvey.Domain.Interfaces.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Biopark.CpaSurvey.Application.Usuarios.Commands.RemoverUsuario;

public class RemoverUsuarioCommand : IRequest
{
    public long UsuarioId { get; set; }
}

public class RemoverUsuarioCommandHandler : IRequestHandler<RemoverUsuarioCommand>
{
    private readonly IUnitOfWork _unitOfWork;

    public RemoverUsuarioCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(RemoverUsuarioCommand request, CancellationToken cancellationToken)
    {
        var repository = _unitOfWork.GetRepository<Usuario>();

        var usuario = await repository
            .FindBy(c => c.Id == request.UsuarioId)
            .FirstAsync(cancellationToken);

        repository.Delete(usuario);

        await _unitOfWork.CommitAsync();

        return Unit.Value;
    }
}