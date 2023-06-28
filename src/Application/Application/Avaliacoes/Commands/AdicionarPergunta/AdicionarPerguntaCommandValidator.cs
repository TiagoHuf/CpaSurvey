using Biopark.CpaSurvey.Application.Common.Validators;
using Biopark.CpaSurvey.Domain.Entities.Avaliacoes;
using Biopark.CpaSurvey.Domain.Entities.Perguntas;
using Biopark.CpaSurvey.Domain.Interfaces.Infrastructure;

namespace Biopark.CpaSurvey.Application.Avaliacoes.Commands.AdicionarPergunta;

public class AdicionarPerguntaCommandValidator : ValidatorBase<AdicionarPerguntaCommand>
{
    public AdicionarPerguntaCommandValidator(IUnitOfWork unitOfWork) : base(unitOfWork)
    {
        RuleFor(a => a.AvaliacaoId)
            .MustExists<AdicionarPerguntaCommand, Avaliacao>(unitOfWork);

        RuleFor(a => a.PerguntaId)
            .MustExists<AdicionarPerguntaCommand, Pergunta>(unitOfWork);
    }
}
