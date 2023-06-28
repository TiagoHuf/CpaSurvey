using Biopark.CpaSurvey.Domain.Entities.Alunos;
using Biopark.CpaSurvey.Domain.Interfaces.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Biopark.CpaSurvey.Application.Alunos.Commands.CorrigirRa;

public class CorrigirRaAlunoCommand : IRequest
{
    public long AlunoId { get; set; }

    public string Ra { get; set; }
}

public class CorrigirRaAlunoCommandHandler : IRequestHandler<CorrigirRaAlunoCommand>
{
    private readonly IUnitOfWork _unitOfWork;

    public CorrigirRaAlunoCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(CorrigirRaAlunoCommand request, CancellationToken cancellationToken)
    {
        var repository = _unitOfWork.GetRepository<Aluno>();

        var aluno = await repository
            .FindBy(c => c.Id == request.AlunoId)
            .FirstAsync(cancellationToken);

        aluno.CorrigirRa(request.Ra);

        await _unitOfWork.CommitAsync();

        return Unit.Value;
    }
}