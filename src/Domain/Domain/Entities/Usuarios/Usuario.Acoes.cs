﻿namespace Biopark.CpaSurvey.Domain.Entities.Usuarios;

public partial class Usuario
{
    public void CorrigirLogin(string login)
    {
        Login = login;
    }

    public void CorrigirSenha(string senha)
    {
        SenhaHash = senha;
    }

    public void CorrigirRole(Role role)
    {
        Role = role;
    }
}