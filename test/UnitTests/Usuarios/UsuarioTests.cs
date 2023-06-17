using Biopark.CpaSurvey.Domain.Entities.Usuarios;
using FluentAssertions;
using NUnit.Framework;

namespace Biopark.CpaSurvey.UnitTests.Usuarios;

public partial class UsuarioTests
{
    [Test]
    public void ConstrutorDeveCriarUsuarioComSucesso()
    {
        var model = UsuarioFactory.GetUsuarioNovaModel();

        var usuario = new Usuario(model);

        usuario.Should().NotBeNull();
        usuario.Login.Should().Be(model.Login);
        usuario.Senha.Should().Be(model.Senha);
        usuario.Role.Should().Be(model.Role);
    }
}