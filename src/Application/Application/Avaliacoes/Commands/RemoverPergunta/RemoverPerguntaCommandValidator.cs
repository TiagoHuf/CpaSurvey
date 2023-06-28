using Biopark.CpaSurvey.Application.Common.Validators;
using Biopark.CpaSurvey.Domain.Entities.Avaliacoes;
using Biopark.CpaSurvey.Domain.Entities.Perguntas;
using Biopark.CpaSurvey.Domain.Interfaces.Infrastructure;

namespace Biopark.CpaSurvey.Application.Avaliacoes.Commands.RemoverPergunta;

public class RemoverPerguntaCommandValidator : ValidatorBase<RemoverPerguntaCommand>
{
    public RemoverPerguntaCommandValidator(IUnitOfWork unitOfWork) : base(unitOfWork)
    {
        RuleFor(a => a.AvaliacaoId)
            .MustExists<RemoverPerguntaCommand, Avaliacao>(unitOfWork);

        RuleFor(a => a.PerguntaId)
            .MustExists<RemoverPerguntaCommand, Pergunta>(unitOfWork);
    }
}