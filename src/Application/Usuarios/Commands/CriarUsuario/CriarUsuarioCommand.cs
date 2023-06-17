using Biopark.CpaSurvey.Domain.Entities.Usuarios;
using Biopark.CpaSurvey.Domain.Interfaces.Infrastructure;
using Biopark.CpaSurvey.Domain.Models.Usuarios;
using MediatR;

namespace Biopark.CpaSurvey.Application.Usuarios.Commands.CriarUsuario;

public class CriarUsuarioCommand : IRequest<Usuario>
{
    public string Login { get; set; }

    public string Senha{ get; set; }

    public Role Role{ get; set; }
}

public class CriarUsuarioCommandHandler : IRequestHandler<CriarUsuarioCommand, Usuario>
{
    private readonly IUnitOfWork _unitOfWork;

    public CriarUsuarioCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Usuario> Handle(CriarUsuarioCommand request, CancellationToken cancellationToken)
    {
        var model = CriaModelo(request);

        var usuarioInserir = new Usuario(model);

        var repositoryUsuario = _unitOfWork.GetRepository<Usuario>();

        repositoryUsuario.Add(usuarioInserir);

        await _unitOfWork.CommitAsync();

        return usuarioInserir;
    }

    public UsuairoModel CriaModelo(CriarUsuarioCommand request)
    {
        var model = new UsuairoModel
        {
            Login = request.Login,
            Senha = request.Senha,
            Role = request.Role,
        };

        return model;
    }
}