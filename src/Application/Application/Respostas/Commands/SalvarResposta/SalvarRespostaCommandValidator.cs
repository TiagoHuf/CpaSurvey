using Biopark.CpaSurvey.Application.Common.Validators;
using Biopark.CpaSurvey.Application.Eixos.Commands.CriarPergunta;
using Biopark.CpaSurvey.Domain.Entities.Alunos;
using Biopark.CpaSurvey.Domain.Entities.Perguntas;
using Biopark.CpaSurvey.Domain.Interfaces.Infrastructure;
using FluentValidation;

namespace Biopark.CpaSurvey.Application.Respostas.Commands.SalvarResposta;

public class SalvarRespostaCommandValidator : ValidatorBase<SalvarRespostaCommand>
{
    public SalvarRespostaCommandValidator(IUnitOfWork unitOfWork) : base(unitOfWork)
    {
        RuleFor(r => r.Descricao)
            .NotEmpty()
            .MinimumLength(2)
            .MaximumLength(500);

        RuleFor(r => r.Valor)
            .LessThanOrEqualTo(10)
            .GreaterThanOrEqualTo(0);

        RuleFor(p => p.AlunoId)
            .MustExists<SalvarRespostaCommand, Aluno>(unitOfWork);

        RuleFor(p => p.PerguntaId)
            .MustExists<SalvarRespostaCommand, Pergunta>(unitOfWork);
    }
}