using Biopark.CpaSurvey.Application.Common.Validators;
using Biopark.CpaSurvey.Application.Eixos.Commands.CriarPergunta;
using Biopark.CpaSurvey.Domain.Entities.Eixos;
using Biopark.CpaSurvey.Domain.Interfaces.Infrastructure;
using FluentValidation;

namespace Biopark.CpaSurvey.Application.Usuarios.Commands.CriarUsuario;

public class CriarUsuarioCommandValidator : ValidatorBase<CriarUsuarioCommand>
{
    public CriarUsuarioCommandValidator (IUnitOfWork unitOfWork) : base(unitOfWork)
    {
        RuleFor(p => p.Login)
            .NotEmpty()
            .MinimumLength(2)
            .MaximumLength(200);

        RuleFor(p => p.Senha)
            .NotEmpty()
            .MinimumLength(2)
            .MaximumLength(30);

        RuleFor(p => p.Role)
            .IsInEnum();
    }
}