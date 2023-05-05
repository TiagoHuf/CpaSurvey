using Biopark.CpaSurvey.Domain.Entities.Alunos;
using Biopark.CpaSurvey.Domain.Interfaces.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Biopark.CpaSurvey.Application.Alunos.Commands.Ativar;

public class AtivarAlunoCommand : IRequest
{
    public long AlunoId { get; set; }
}

public class AtivarAlunoCommandHandler : IRequestHandler<AtivarAlunoCommand>
{
    private readonly IUnitOfWork _unitOfWork;

    public AtivarAlunoCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(AtivarAlunoCommand request, CancellationToken cancellationToken)
    {
        var repository = _unitOfWork.GetRepository<Aluno>();

        var aluno = await repository
            .FindBy(c => c.Id == request.AlunoId)
            .FirstAsync(cancellationToken);

        aluno.Ativar();

        await _unitOfWork.CommitAsync();

        return Unit.Value;
    }
}