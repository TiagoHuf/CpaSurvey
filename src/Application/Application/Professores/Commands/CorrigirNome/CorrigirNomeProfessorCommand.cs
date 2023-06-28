using Biopark.CpaSurvey.Domain.Entities.Professores;
using Biopark.CpaSurvey.Domain.Interfaces.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Biopark.CpaSurvey.Application.Professores.Commands.CorrigirNome;

public class CorrigirNomeProfessorCommand : IRequest
{
    public long ProfessorId { get; set; }

    public string Nome { get; set; }
}

public class CorrigirNomeProfessorCommandHandler : IRequestHandler<CorrigirNomeProfessorCommand>
{
    private readonly IUnitOfWork _unitOfWork;

    public CorrigirNomeProfessorCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(CorrigirNomeProfessorCommand request, CancellationToken cancellationToken)
    {
        var repository = _unitOfWork.GetRepository<Professor>();

        var professor = await repository
            .FindBy(c => c.Id == request.ProfessorId)
            .FirstAsync(cancellationToken);

        professor.CorrigirNome(request.Nome);

        await _unitOfWork.CommitAsync();

        return Unit.Value;
    }
}