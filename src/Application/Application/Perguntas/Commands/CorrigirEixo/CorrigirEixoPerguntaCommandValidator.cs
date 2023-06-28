using Biopark.CpaSurvey.Application.Common.Validators;
using Biopark.CpaSurvey.Domain.Entities.Eixos;
using Biopark.CpaSurvey.Domain.Entities.Perguntas;
using Biopark.CpaSurvey.Domain.Interfaces.Infrastructure;

namespace Biopark.CpaSurvey.Application.Perguntas.Commands.CorrigirEixo;

public class CorrigirEixoPerguntaCommandValidator : ValidatorBase<CorrigirEixoPerguntaCommand>
{
    public CorrigirEixoPerguntaCommandValidator(IUnitOfWork unitOfWork) : base(unitOfWork)
    {
        RuleFor(p => p.PerguntaId)
            .MustExists<CorrigirEixoPerguntaCommand, Pergunta>(unitOfWork);

        RuleFor(p => p.EixoId)
            .MustExists<CorrigirEixoPerguntaCommand, Eixo>(unitOfWork);
    }
}