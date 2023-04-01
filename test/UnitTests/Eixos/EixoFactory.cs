using Biopark.CpaSurvey.Domain.Models.Eixos;

namespace Biopark.CpaSurvey.UnitTests.Eixos;

public class EixoFactory
{
    public static EixoModel GetEixoNovoModel()
    {
        return new EixoModel
        {
            Nome = "Nome Teste",
            Descricao = "Descrição teste",
        };
    }
}