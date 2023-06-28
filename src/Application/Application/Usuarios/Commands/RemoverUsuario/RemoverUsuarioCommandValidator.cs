using Biopark.CpaSurvey.Application.Common.Validators;
using Biopark.CpaSurvey.Domain.Entities.Usuarios;
using Biopark.CpaSurvey.Domain.Interfaces.Infrastructure;

namespace Biopark.CpaSurvey.Application.Usuarios.Commands.RemoverUsuario;

public class RemoverUsuarioCommandValidator : ValidatorBase<RemoverUsuarioCommand>
{
    public RemoverUsuarioCommandValidator(IUnitOfWork unitOfWork) : base(unitOfWork)
    {
        RuleFor(p => p.UsuarioId)
            .MustExists<RemoverUsuarioCommand, Usuario>(unitOfWork);
    }
}