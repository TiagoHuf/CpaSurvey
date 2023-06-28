using Biopark.CpaSurvey.Domain.Entities.Alunos;
using Biopark.CpaSurvey.Domain.Interfaces.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Biopark.CpaSurvey.Application.Alunos.Commands.Inativar;

public class InativarAlunoCommand : IRequest
{
    public long AlunoId { get; set; }
}

public class InativarAlunoCommandHandler : IRequestHandler<InativarAlunoCommand>
{
    private readonly IUnitOfWork _unitOfWork;

    public InativarAlunoCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(InativarAlunoCommand request, CancellationToken cancellationToken)
    {
        var repository = _unitOfWork.GetRepository<Aluno>();

        var aluno = await repository
            .FindBy(c => c.Id == request.AlunoId)
            .FirstAsync(cancellationToken);

        aluno.Inativar();

        await _unitOfWork.CommitAsync();

        return Unit.Value;
    }
}