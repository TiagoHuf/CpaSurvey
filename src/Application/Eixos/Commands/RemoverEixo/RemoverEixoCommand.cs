using Biopark.CpaSurvey.Domain.Entities.Eixos;
using Biopark.CpaSurvey.Domain.Interfaces.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Biopark.CpaSurvey.Application.Eixos.Commands.RemoverEixo;

public class RemoverEixoCommand : IRequest
{
    public long EixoId { get; set; }
}

public class RemoverEixoCommandHandler : IRequestHandler<RemoverEixoCommand>
{
    private readonly IUnitOfWork _unitOfWork;

    public RemoverEixoCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(RemoverEixoCommand request, CancellationToken cancellationToken)
    {
        var repository = _unitOfWork.GetRepository<Eixo>();

        var eixo = await repository
            .FindBy(c => c.Id == request.EixoId)
            .FirstAsync(cancellationToken);

        repository.Delete(eixo);

        await _unitOfWork.CommitAsync();

        return Unit.Value;
    }
}