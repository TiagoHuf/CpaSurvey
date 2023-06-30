using Biopark.CpaSurvey.Domain.Entities.Alunos;
using Biopark.CpaSurvey.Domain.Entities.Avaliacoes;
using Biopark.CpaSurvey.Domain.Interfaces.Infrastructure;
using Biopark.CpaSurvey.DomainService.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace Biopark.CpaSurvey.Application.Respostas.Queries.GetAvaliacoesAluno;

public class GetAvaliacoesAlunoQuery : IRequest<List<Avaliacao>>
{
}

public class GetAvaliacoesAlunoQueryHandler :
    IRequestHandler<GetAvaliacoesAlunoQuery, List<Avaliacao>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IUser _user;

    public GetAvaliacoesAlunoQueryHandler(IUnitOfWork unitOfWork, IUser user)
    {
        _unitOfWork = unitOfWork;
        _user = user;
    }

    public async Task<List<Avaliacao>> Handle(
        GetAvaliacoesAlunoQuery request,
        CancellationToken cancellationToken)
    {
        var alunoRepository = _unitOfWork.GetRepository<Aluno>();

        var claims = _user.GetClaimsIdentity();

        var ra = claims.First(c => c.Type == ClaimTypes.SerialNumber);
        var email = claims.First(c => c.Type == ClaimTypes.Email);

        var aluno = await alunoRepository
            .FindBy(c => c.Ra == ra.Value && c.Email == email.Value)
            .Include(a => a.Respostas)
            .Include(a => a.Turmas).ThenInclude(t => t.Avaliacoes)
            .FirstAsync(cancellationToken);


        if (aluno != null)
        {
            var avaliacoes = aluno.Turmas.SelectMany(turma => turma.Avaliacoes).ToList();
            // Faça o que você precisa com a lista de avaliações

            return avaliacoes;
        }

        return null;
    }
}