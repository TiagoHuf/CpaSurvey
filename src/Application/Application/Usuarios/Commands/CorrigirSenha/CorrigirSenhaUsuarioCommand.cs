using Biopark.CpaSurvey.Domain.Entities.Usuarios;
using Biopark.CpaSurvey.Domain.Interfaces.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Biopark.CpaSurvey.Application.Usuarios.Commands.CorrigirSenha;

public class CorrigirSenhaUsuarioCommand : IRequest
{
    public long UsarioId { get; set; }

    public string Senha { get; set; }
}

public class CorrigirSenhaUsuarioCommandHandler : IRequestHandler<CorrigirSenhaUsuarioCommand>
{
    private readonly IUnitOfWork _unitOfWork;

    public CorrigirSenhaUsuarioCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(CorrigirSenhaUsuarioCommand request, CancellationToken cancellationToken)
    {
        var repository = _unitOfWork.GetRepository<Usuario>();

        var usuario = await repository
            .FindBy(c => c.Id == request.UsarioId)
            .FirstAsync(cancellationToken);

        usuario.CorrigirSenha(request.Senha);

        await _unitOfWork.CommitAsync();

        return Unit.Value;
    }
}