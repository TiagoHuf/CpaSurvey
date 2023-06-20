using Biopark.CpaSurvey.Domain.Entities.Usuarios;
using Biopark.CpaSurvey.Domain.Interfaces.Infrastructure;
using Biopark.CpaSurvey.Domain.Interfaces.Services;
using Biopark.CpaSurvey.Domain.Models.Autenticacao;
using Biopark.CpaSurvey.DomainService.Interfaces;
using Microsoft.EntityFrameworkCore;
using SecureIdentity.Password;

namespace Biopark.CpaSurvey.DomainService.Services.Autenticacao;

public class AutenticacaoService : IAutenticacaoService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ITokenService _tokenService;

    public AutenticacaoService(IUnitOfWork unitOfWork, ITokenService tokenService)
    {
        _unitOfWork = unitOfWork;
        _tokenService = tokenService;
    }

    public async Task<LoginResponseModel> LoginAsync(CredenciaisModel credenciais, CancellationToken cancellationToken)
    {
        var repository = _unitOfWork.GetRepository<Usuario>();

        var usuario = await repository
            .FindBy(c => c.Login == credenciais.Email)
            .FirstOrDefaultAsync(cancellationToken);

        if(usuario is null)
        {
            return new LoginResponseModel
            {
                IsAutenticado = false,
                Token = null,
                Mensagem = "Credenciais inválidas.",
            };
        }

        if(!PasswordHasher.Verify(usuario.SenhaHash, credenciais.Senha)){
            return new LoginResponseModel
            {
                IsAutenticado = false,
                Token = null,
                Mensagem = "Credenciais inválidas.",
            };
        }

        var token = _tokenService.GenerateToken(usuario);

        return new LoginResponseModel
        {
            IsAutenticado = true,
            Token = token,
        };
    }
}