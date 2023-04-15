using Biopark.CpaSurvey.Domain.Entities.Usuarios;
using Biopark.CpaSurvey.Domain.Interfaces.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Biopark.CpaSurvey.Application.Alunos.Commands.RemoverAluno;

public class RemoverAlunoCommand : IRequest
{
    public long AlunoId { get; set; }
}

public class RemoverAlunoCommandHandler : IRequestHandler<RemoverAlunoCommand>
{
    private readonly IUnitOfWork _unitOfWork;

    public RemoverAlunoCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(RemoverAlunoCommand request, CancellationToken cancellationToken)
    {
        var repository = _unitOfWork.GetRepository<Aluno>();

        var aluno = await repository
            .FindBy(c => c.Id == request.AlunoId)
            .FirstAsync(cancellationToken);

        repository.Delete(aluno);

        await _unitOfWork.CommitAsync();

        return Unit.Value;
    }
}