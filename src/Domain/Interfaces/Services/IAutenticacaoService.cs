using Biopark.CpaSurvey.Domain.Models.Autenticacao;

namespace Biopark.CpaSurvey.Domain.Interfaces.Services;

/// <summary>
/// Serviço para a autenticação.
/// </summary>
public interface IAutenticacaoService
{
    /// <summary>
    /// Realiza o login de um usuário através das credenciais providas.
    /// </summary>
    /// <param name="credenciais">Credenciais do usuário.</param>
    /// <returns>Resultado da tentativa de acesso.</returns>
    Task<LoginResponseModel> LoginAsync(CredenciaisModel credenciais, CancellationToken cancellationToken);
}