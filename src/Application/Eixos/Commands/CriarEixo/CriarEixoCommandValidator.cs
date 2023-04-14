using Biopark.CpaSurvey.Application.Common.Validators;
using Biopark.CpaSurvey.Application.Eixos.Commands.CriarEixo;
using Biopark.CpaSurvey.Domain.Interfaces.Infrastructure;
using FluentValidation;

namespace Biopark.CpaSurvey.Application.Perguntas.Commands.CriarEixo;

public class CriarEixoCommandValidator : ValidatorBase<CriarEixoCommand>
{
    public CriarEixoCommandValidator(IUnitOfWork unitOfWork) : base(unitOfWork)
    {
        RuleFor(p => p.Nome)
            .NotEmpty()
            .MinimumLength(2)
            .MinimumLength(50);

        RuleFor(p => p.Descricao)
            .NotEmpty()
            .MinimumLength(2)
            .MinimumLength(200);
    }
}