using Biopark.CpaSurvey.Domain.Entities.Usuarios;
using FluentAssertions;
using NUnit.Framework;

namespace Biopark.CpaSurvey.UnitTests.Usuarios;

public partial class UsuarioTests
{
    private Usuario _usuario;

    [SetUp]
    public void UsuarioTestsSetUp()
    {
        var model = UsuarioFactory.GetUsuarioNovaModel();
        _usuario = new Usuario(model);
    }

    [Test]
    public void DeveCorrigirLoginComSucesso()
    {
        var NovoLogin = "NovoLogin";

        _usuario.CorrigirLogin(NovoLogin);

        _usuario.Login.Should().Be(NovoLogin);
    }

    [Test]
    public void DeveCorrigirSenhaComSucesso()
    {
        var NovaSenha = "NovaSenha";

        _usuario.CorrigirSenha(NovaSenha);

        _usuario.SenhaHash.Should().Be(NovaSenha);
    }

    [Test]
    public void DeveCorrigirRoleComSucesso()
    {
        var NovaRole = Role.Professor;

        _usuario.CorrigirRole(NovaRole);

        _usuario.Role.Should().Be(NovaRole);
    }
}
