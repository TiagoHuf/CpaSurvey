﻿using Biopark.CpaSurvey.Domain.Entities.Turmas;
using FluentAssertions;
using NUnit.Framework;

namespace Biopark.CpaSurvey.UnitTests.Turmas
{
    public partial class TurmasTests
    {
        private Turma _turma;

        [SetUp]
        public void TurmaTestsSetUp()
        {
            var model = TurmaFactory.GetTurmaNovaModel("Nova Turma");
            _turma = new Turma(model);
        }

        [Test]
        public void DeveCorrigirNomeComSucesso()
        {
            var NovoNome = "Novo nome";

            _turma.CorrigirNome(NovoNome);

            _turma.Nome.Should().Be(NovoNome);
        }
    }
}