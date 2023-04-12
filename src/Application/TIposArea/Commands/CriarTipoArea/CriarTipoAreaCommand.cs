using Biopark.CpaSurvey.Domain.Entities.Tipo;
using Biopark.CpaSurvey.Domain.Interfaces.Infrastructure;
using Biopark.CpaSurvey.Domain.Models.Tipo;
using MediatR;

namespace Biopark.CpaSurvey.Application.TiposArea.Commands.CriarTipoArea;

public class CriarTipoAreaCommand : IRequest<TipoArea>
{
    public string Nome { get; set; }
}

public class CriarTipoCommandHandler : IRequestHandler<CriarTipoAreaCommand, TipoArea>
{
    private readonly IUnitOfWork _unitOfWork;
    public CriarTipoCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<TipoArea> Handle(CriarTipoAreaCommand request, CancellationToken cancellationToken)
    {
        var model = CriarModelo(request);

        var tipoInserir = new TipoArea(model);

        var repositoryTipo = _unitOfWork.GetRepository<TipoArea>();

        repositoryTipo.Add(tipoInserir);

        await _unitOfWork.CommitAsync();

        return tipoInserir;
    }

    public TipoAreaModel CriarModelo(CriarTipoAreaCommand request)
    {
        var model = new TipoAreaModel
        {
            Nome = request.Nome
        };

        return model;
    }
}