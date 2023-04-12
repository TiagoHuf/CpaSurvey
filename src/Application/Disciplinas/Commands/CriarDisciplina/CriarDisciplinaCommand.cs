using Biopark.CpaSurvey.Domain.Entities.Disciplinas;
using Biopark.CpaSurvey.Domain.Interfaces.Infrastructure;
using Biopark.CpaSurvey.Domain.Models.Disciplinas;
using MediatR;

namespace Biopark.CpaSurvey.Application.Disciplinas.Commands.CriarDisciplina;

public class CriarDisciplinaCommand : IRequest<Disciplina>
{
    public string Nome { get; set; }

    public string Descricao { get; set; }
}

public class CriarDisciplinaCommandHandler : IRequestHandler<CriarDisciplinaCommand, Disciplina>
{
    private readonly IUnitOfWork _unitOfWork;

    public CriarDisciplinaCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Disciplina> Handle(CriarDisciplinaCommand request, CancellationToken cancellationToken)
    {
        var model = CriaModelo(request);

        var disciplinaInserir = new Disciplina(model);

        var repositorydisciplina = _unitOfWork.GetRepository<Disciplina>();

        repositorydisciplina.Add(disciplinaInserir);

        await _unitOfWork.CommitAsync();

        return disciplinaInserir;
    }

    public DisciplinasModel CriaModelo(CriarDisciplinaCommand request)
    {
        var model = new DisciplinasModel
        {
            Nome = request.Nome,
        };

        return model;
    }
}