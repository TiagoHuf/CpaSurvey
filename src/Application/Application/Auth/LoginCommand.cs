using Biopark.CpaSurvey.Domain.Interfaces.Services;
using Biopark.CpaSurvey.Domain.Models.Autenticacao;
using MediatR;

namespace Biopark.CpaSurvey.Application.Auth;

public class LoginCommand : IRequest<LoginResultadoViewModel>
{
    public string Email { get; set; }

    public string Senha { get; set; }
}

public class LoginCommandHandler : IRequestHandler<LoginCommand, LoginResultadoViewModel>
{
    private readonly IAutenticacaoService _autenticacaoService;

    public LoginCommandHandler(IAutenticacaoService autenticacaoService)
    {
        _autenticacaoService = autenticacaoService;
    }

    public async Task<LoginResultadoViewModel> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        var loginModel = new CredenciaisModel
        {
            Email = request.Email,
            Senha = request.Senha,
        };

        var resultado = await _autenticacaoService.LoginAsync(loginModel, cancellationToken);

        return new LoginResultadoViewModel
        {
            IsAutenticado = resultado.IsAutenticado,
            Token = resultado.Token,
            Mensagem = resultado.Mensagem,
        };
    }
}