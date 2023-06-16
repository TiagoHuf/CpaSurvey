using Biopark.CpaSurvey.Application.Common.Validators;
using Biopark.CpaSurvey.Application.Perguntas.Commands.CorrigirDescricao;
using Biopark.CpaSurvey.Domain.Entities.Perguntas;
using Biopark.CpaSurvey.Domain.Entities.Usuarios;
using Biopark.CpaSurvey.Domain.Interfaces.Infrastructure;
using FluentValidation;

namespace Biopark.CpaSurvey.Application.Usuarios.Commands.CorrigirLogin;

public class CorrigirLoginUsuarioCommandValidator : ValidatorBase<CorrigirLoginUsuarioCommand>
{
    public CorrigirLoginUsuarioCommandValidator(IUnitOfWork unitOfWork) : base(unitOfWork)
    {
        RuleFor(p => p.Login)
            .NotEmpty()
            .MinimumLength(2)
            .MaximumLength(200);

        RuleFor(p => p.UsarioId)
            .MustExists<CorrigirLoginUsuarioCommand, Usuario>(unitOfWork);
    }
}