using Biopark.CpaSurvey.Domain.Entities.Alunos;
using Biopark.CpaSurvey.Domain.Entities.Respostas;
using Biopark.CpaSurvey.Domain.Interfaces.Infrastructure;
using Biopark.CpaSurvey.Domain.Models.Respostas;
using Biopark.CpaSurvey.DomainService.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace Biopark.CpaSurvey.Application.Respostas.Commands.SalvarResposta;

public class SalvarRespostaCommand : IRequest<Resposta>
{
    public string Descricao { get; set; }

    public int Valor { get; set; }

    public long PerguntaId { get; set; }

    public long AlunoId { get; set; }
}

public class SalvarResposaCommandHandler : IRequestHandler<SalvarRespostaCommand, Resposta>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IUser _user;

    public SalvarResposaCommandHandler(IUnitOfWork unitOfWork, IUser user)
    {
        _unitOfWork = unitOfWork;
        _user = user;
    }

    public async Task<Resposta> Handle(SalvarRespostaCommand request, CancellationToken cancellationToken)
    {
        var claims = _user.GetClaimsIdentity();

        var ra = claims.First(c => c.Type == ClaimTypes.SerialNumber);
        var email = claims.First(c => c.Type == ClaimTypes.Email);

        var repositoryAluno = _unitOfWork.GetRepository<Aluno>();

        var aluno = await repositoryAluno
            .FindBy(
                c =>
                    c.Ra == ra.Value &&
                    c.Email == email.Value)
            .FirstAsync(cancellationToken);

        request.AlunoId = aluno.Id;

        var model = CriaModelo(request);

        var RespostaInserir = new Resposta(model);

        var repositoryResposta = _unitOfWork.GetRepository<Resposta>();

        repositoryResposta.Add(RespostaInserir);

        await _unitOfWork.CommitAsync();

        return RespostaInserir;
    }

    public RespostaModel CriaModelo(SalvarRespostaCommand request)
    {
        var model = new RespostaModel
        {
            Descricao = request.Descricao,
            Valor = request.Valor,
            PerguntaId = request.PerguntaId,
            AlunoId = request.AlunoId,
        };

        return model;
    }
}