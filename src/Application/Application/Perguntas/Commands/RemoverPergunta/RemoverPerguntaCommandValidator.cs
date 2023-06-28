using Biopark.CpaSurvey.Application.Common.Validators;
using Biopark.CpaSurvey.Application.Eixos.Commands.CriarPergunta;
using Biopark.CpaSurvey.Domain.Entities.Perguntas;
using Biopark.CpaSurvey.Domain.Interfaces.Infrastructure;

namespace Biopark.CpaSurvey.Application.Perguntas.Commands.RemoverPergunta;

public class RemoverPerguntaCommandValidator : ValidatorBase<RemoverPerguntaCommand>
{
    public RemoverPerguntaCommandValidator(IUnitOfWork unitOfWork) : base(unitOfWork)
    {
        RuleFor(p => p.PerguntaId)
            .MustExists<RemoverPerguntaCommand, Pergunta>(unitOfWork);
    }
}