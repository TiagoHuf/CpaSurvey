using Biopark.CpaSurvey.Domain.Models.Avaliacoes;
using System;

namespace Biopark.CpaSurvey.UnitTests.Avaliacoes;

public class AvaliacaoFactory
{
    public static AvaliacaoModel GetAvaliacaoNovaModel()
    {
        return new AvaliacaoModel
        {
            Nome = "Avaliação teste",
            DataInicio = DateTime.Now,
            DataFim = DateTime.Now,
            DisciplinaId = 1,
        };
    }
}