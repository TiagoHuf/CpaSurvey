using Biopark.CpaSurvey.Domain.Entities.Eixos;
using Biopark.CpaSurvey.Domain.Interfaces.Infrastructure;
using Biopark.CpaSurvey.Domain.Models.Eixos;
using MediatR;

namespace Biopark.CpaSurvey.Application.Eixos.Commands.CriarEixo;
public class CriarEixoCommand : IRequest<Eixo>
{
    public string Nome { get; set; }

    public string Descricao { get; set; }
}

public class CriarEixoCommandHandler : IRequestHandler<CriarEixoCommand, Eixo>
{
    private readonly IUnitOfWork _unitOfWork;

    public CriarEixoCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Eixo> Handle(CriarEixoCommand request, CancellationToken cancellationToken)
    {
        var model = CriaModelo(request);

        var eixoInserir = new Eixo(model);

        var repositoryEixo = _unitOfWork.GetRepository<Eixo>();

        repositoryEixo.Add(eixoInserir);

        await _unitOfWork.CommitAsync();

        return eixoInserir;
    }

    public EixoModel CriaModelo(CriarEixoCommand request)
    {
        var model = new EixoModel
        {
            Nome = request.Nome,
            Descricao = request.Descricao,
        };

        return model;
    }
}