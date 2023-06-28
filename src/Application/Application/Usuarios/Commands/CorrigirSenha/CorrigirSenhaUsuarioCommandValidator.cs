using Biopark.CpaSurvey.Application.Common.Validators;
using Biopark.CpaSurvey.Domain.Entities.Usuarios;
using Biopark.CpaSurvey.Domain.Interfaces.Infrastructure;
using FluentValidation;

namespace Biopark.CpaSurvey.Application.Usuarios.Commands.CorrigirSenha;

public class CorrigirSenhaUsuarioCommandValidator : ValidatorBase<CorrigirSenhaUsuarioCommand>
{
    public CorrigirSenhaUsuarioCommandValidator(IUnitOfWork unitOfWork) : base(unitOfWork)
    {
        RuleFor(p => p.Senha)
            .NotEmpty()
            .MinimumLength(2)
            .MaximumLength(30);

        RuleFor(p => p.UsarioId)
            .MustExists<CorrigirSenhaUsuarioCommand, Usuario>(unitOfWork);
    }
}