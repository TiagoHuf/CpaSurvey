using Biopark.CpaSurvey.Domain.Entities.Alunos;
using Biopark.CpaSurvey.Domain.Entities.Respostas;
using Biopark.CpaSurvey.Domain.Interfaces.Infrastructure;
using Biopark.CpaSurvey.DomainService.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Biopark.CpaSurvey.Application.Respostas.Queries.GetResposta;

public class GetRespostaQuery : IRequest<string>
{
    public long RespostaId { get; set; }
}

public class GetRespostaQueryHandler : IRequestHandler<GetRespostaQuery, string>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ITokenService _tokenService;

    public GetRespostaQueryHandler(IUnitOfWork unitOfWork, ITokenService tokenService)
    {
        _unitOfWork = unitOfWork;
        _tokenService = tokenService;
    }

    public async Task<string> Handle(GetRespostaQuery request, CancellationToken cancellationToken)
    {
        var repository = _unitOfWork.GetRepository<Aluno>();

        var aluno = await repository
            .FindBy(c => c.Id == request.RespostaId)
            .FirstAsync(cancellationToken);

        var token =  _tokenService.GenerateResponseToken(aluno, DateTime.Now.AddDays(30));

        return token;
    }
}