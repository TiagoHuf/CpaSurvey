using Biopark.CpaSurvey.Application.Common.Validators;
using Biopark.CpaSurvey.Application.Perguntas.Commands.CorrigirDescricao;
using Biopark.CpaSurvey.Domain.Entities.Perguntas;
using Biopark.CpaSurvey.Domain.Interfaces.Infrastructure;
using FluentValidation;

namespace Biopark.CpaSurvey.Application.Perguntas.Commands.CorrigirDescricao;

public class CorrigirDescricaoPerguntaCommandValidator : ValidatorBase<CorrigirDescricaoPerguntaCommand>
{
    public CorrigirDescricaoPerguntaCommandValidator(IUnitOfWork unitOfWork) : base(unitOfWork)
    {
        RuleFor(p => p.Descricao)
            .NotEmpty()
            .MinimumLength(2)
            .MaximumLength(200);

        RuleFor(p => p.PerguntaId)
            .MustExists<CorrigirDescricaoPerguntaCommand, Pergunta>(unitOfWork);
    }
}