namespace Biopark.CpaSurvey.Domain.Entities.Usuarios;

/// <summary>
/// Tipos de permissão por usuário.
/// </summary>
public enum Role
{
    /// <summary>
    /// Usuário com permissão total.
    /// </summary>
    Admin,

    /// <summary>
    /// Usuário com permissão para gerenciar avaliações.
    /// </summary>
    Professor,

    /// <summary>
    /// Usuário com permissão para votar.
    /// </summary>
    Aluno
}