using Biopark.CpaSurvey.Application.Common.Validators;
using Biopark.CpaSurvey.Domain.Entities.Usuarios;
using Biopark.CpaSurvey.Domain.Interfaces.Infrastructure;
using FluentValidation;

namespace Biopark.CpaSurvey.Application.Usuarios.Commands.CorrigirRole;
public class CorrigirRoleUsuarioCommandValidator : ValidatorBase<CorrigirRoleUsuarioCommand>
{
    public CorrigirRoleUsuarioCommandValidator(IUnitOfWork unitOfWork) : base(unitOfWork)
    {
        RuleFor(p => p.Role)
            .IsInEnum();

        RuleFor(p => p.UsarioId)
            .MustExists<CorrigirRoleUsuarioCommand, Usuario>(unitOfWork);
    }
}
