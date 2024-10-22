﻿using Biopark.CpaSurvey.Application.Common.Validators;
using Biopark.CpaSurvey.Domain.Interfaces.Infrastructure;
using FluentValidation;

namespace Biopark.CpaSurvey.Application.Eixos.Commands.CriarEixo;

public class CriarEixoCommandValidator : ValidatorBase<CriarEixoCommand>
{
    public CriarEixoCommandValidator(IUnitOfWork unitOfWork) : base(unitOfWork)
    {
        RuleFor(p => p.Nome)
            .NotEmpty()
            .MinimumLength(2)
            .MaximumLength(50);

        RuleFor(p => p.Descricao)
            .NotEmpty()
            .MinimumLength(2)
            .MaximumLength(200);
    }
}