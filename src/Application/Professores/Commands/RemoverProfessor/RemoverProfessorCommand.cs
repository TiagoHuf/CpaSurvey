using Biopark.CpaSurvey.Domain.Entities.Professores;
using Biopark.CpaSurvey.Domain.Interfaces.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Biopark.CpaSurvey.Application.Professores.Commands.RemoverProfessor;

public class RemoverProfessorCommand : IRequest
{
    public long ProfessorId { get; set; }
}

public class RemoverProfessorCommandHandler : IRequestHandler<RemoverProfessorCommand>
{
    private readonly IUnitOfWork _unitOfWork;

    public RemoverProfessorCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(RemoverProfessorCommand request, CancellationToken cancellationToken)
    {
        var repository = _unitOfWork.GetRepository<Professor>();

        var professor = await repository
            .FindBy(c => c.Id == request.ProfessorId)
            .FirstAsync(cancellationToken);

        repository.Delete(professor);

        await _unitOfWork.CommitAsync();

        return Unit.Value;
    }
}