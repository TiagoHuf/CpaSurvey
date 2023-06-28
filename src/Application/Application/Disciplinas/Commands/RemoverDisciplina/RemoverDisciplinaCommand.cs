using Biopark.CpaSurvey.Domain.Entities.Disciplinas;
using Biopark.CpaSurvey.Domain.Interfaces.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Biopark.CpaSurvey.Application.Disciplinas.Commands.RemoverDisciplina;

public class RemoverDisciplinaCommand : IRequest
{
    public long DisciplinaId { get; set; }
}

public class RemoverDisciplinaCommandHandler : IRequestHandler<RemoverDisciplinaCommand>
{
    private readonly IUnitOfWork _unitOfWork;

    public RemoverDisciplinaCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(RemoverDisciplinaCommand request, CancellationToken cancellationToken)
    {
        var repository = _unitOfWork.GetRepository<Disciplina>();

        var disciplina = await repository
            .FindBy(c => c.Id == request.DisciplinaId)
            .FirstAsync(cancellationToken);

        repository.Delete(disciplina);

        await _unitOfWork.CommitAsync();

        return Unit.Value;
    }
}