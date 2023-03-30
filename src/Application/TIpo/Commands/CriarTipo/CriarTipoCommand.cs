using Biopark.CpaSurvey.Domain.Entities.Tipo;
using Biopark.CpaSurvey.Domain.Interfaces.Infrastructure;
using Biopark.CpaSurvey.Domain.Models.Tipo;
using MediatR;

namespace Biopark.CpaSurvey.Application.TIpo.Commands.CriarTipo;
public class CriarTipoCommand : IRequest<Tipo>
{

    public string Nome { get; set; }
}

public class CriarTipoCommandHandler : IRequestHandler<CriarTipoCommand, Tipo>
{
    private readonly IUnitOfWork _unitOfWork;
    public CriarTipoCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Tipo> Handle(CriarTipoCommand request, CancellationToken cancellationToken)
    {
        var model = CriarModelo(request);

        var tipoInserir = new Tipo(model);

        var repositoryTipo = _unitOfWork.GetRepository<Tipo>();

        repositoryTipo.Add(tipoInserir);

        await _unitOfWork.CommitAsync();

        return tipoInserir;
    }

    public TipoModel CriarModelo(CriarTipoCommand request)
    {
        var model = new TipoModel
        {
            Nome = request.Nome,
        };

        return model;
    }
}