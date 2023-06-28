using Biopark.CpaSurvey.Application.Common.Validators;
using Biopark.CpaSurvey.Domain.Entities.Eixos;
using Biopark.CpaSurvey.Domain.Interfaces.Infrastructure;

namespace Biopark.CpaSurvey.Application.Eixos.Commands.RemoverEixo;

public class RemoverEixoCommandValidator : ValidatorBase<RemoverEixoCommand>
{
    public RemoverEixoCommandValidator(IUnitOfWork unitOfWork) : base(unitOfWork)
    {
        RuleFor(p => p.EixoId)
            .MustExists<RemoverEixoCommand, Eixo>(unitOfWork);
    }
}