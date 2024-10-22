﻿using Biopark.CpaSurvey.Domain.Entities.Cursos;
using FluentAssertions;
using NUnit.Framework;

namespace Biopark.CpaSurvey.UnitTests.Cursos;

public partial class CursoTest
{
    private Curso _curso;

    [SetUp]
    public void CursoTestsSetUp()
    {
        var model = CursoFactory.GetCursoNovoModel();
        _curso = new Curso(model);
    }

    [Test]
    public void DeveCorrigirNomeComSucesso()
    {
        var novoNome = "Novo Nome";

        _curso.CorrigirNome(novoNome);

        _curso.Nome.Should().Be(novoNome);
    }
}
