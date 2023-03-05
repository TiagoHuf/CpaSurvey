using Biopark.CpaSurvey.Application.Common.Validators;
using Biopark.CpaSurvey.Domain.Entities.Eixos;
using Biopark.CpaSurvey.Domain.Interfaces.Infrastructure;
using FluentValidation;

namespace Biopark.CpaSurvey.Application.Perguntas.Commands.CriarPergunta;

public class CriarPerguntaCommandValidator : ValidatorBase<CriarPerguntaCommand>
{
    public CriarPerguntaCommandValidator(IUnitOfWork unitOfWork) : base(unitOfWork)
    {
        RuleFor(p => p.Descricao)
            .NotEmpty()
            .MinimumLength(2)
            .MinimumLength(200);

        RuleFor(p => p.TipoResposta)
            .IsInEnum();

        RuleFor(p => p.EixoId)
            .MustExists<CriarPerguntaCommand, Eixo>(unitOfWork);
    }
}