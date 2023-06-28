using Biopark.CpaSurvey.Domain.Entities.Alunos;
using Biopark.CpaSurvey.Domain.Interfaces.Infrastructure;
using MediatR;

namespace Biopark.CpaSurvey.Application.Alunos.Commands.CorrigirNome;

public class CorrigirNomeAlunoCommand : IRequest
{
    public long AlunoId { get; set; }

    public string Nome { get; set; }
}

public class CorrigirNomeAlunoCommandHandler : IRequestHandler<CorrigirNomeAlunoCommand>
{
    private readonly IUnitOfWork _unitOfWork;

    public CorrigirNomeAlunoCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(CorrigirNomeAlunoCommand request, CancellationToken cancellationToken)
    {
        var repository = _unitOfWork.GetRepository<Aluno>();

        var aluno = await repository
            .GetAsync(request.AlunoId);

        aluno.CorrigirNome(request.Nome);

        await _unitOfWork.CommitAsync();

        return Unit.Value;
    }
}