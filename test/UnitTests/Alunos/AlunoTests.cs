﻿using Biopark.CpaSurvey.Domain.Entities.Usuarios;
using FluentAssertions;
using NUnit.Framework;

namespace Biopark.CpaSurvey.UnitTests.Alunos;

public class AlunoTests : TestBase
{
    [Test]
    public void ConstrutorDeveCriarPerguntaComSucesso()
    {
        var model = AlunoFactory.GetAlunoNovoModel();

        var aluno = new Aluno(model);

        aluno.Should().NotBeNull();
        aluno.Nome.Should().Be(model.Nome);
        aluno.Ra.Should().Be(model.Ra);
        aluno.IsAtivo.Should().BeTrue();
    }
}