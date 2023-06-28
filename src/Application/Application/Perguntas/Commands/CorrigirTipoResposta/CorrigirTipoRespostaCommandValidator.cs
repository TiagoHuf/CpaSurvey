using Biopark.CpaSurvey.Application.Common.Validators;
using Biopark.CpaSurvey.Domain.Entities.Perguntas;
using Biopark.CpaSurvey.Domain.Interfaces.Infrastructure;
using FluentValidation;

namespace Biopark.CpaSurvey.Application.Perguntas.Commands.CorrigirTipoResposta;

public class CorrigirTipoRespostaPerguntaCommandValidator : ValidatorBase<CorrigirTipoRespostaPerguntaCommand>
{
    public CorrigirTipoRespostaPerguntaCommandValidator(IUnitOfWork unitOfWork) : base(unitOfWork)
    {
        RuleFor(p => p.TipoResposta)
            .IsInEnum();

        RuleFor(p => p.PerguntaId)
            .MustExists<CorrigirTipoRespostaPerguntaCommand, Pergunta>(unitOfWork);
    }
}