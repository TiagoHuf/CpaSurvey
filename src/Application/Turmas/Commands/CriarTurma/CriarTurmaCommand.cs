using Biopark.CpaSurvey.Domain.Entities.Turma;
using Biopark.CpaSurvey.Domain.Interfaces.Infrastructure;
using Biopark.CpaSurvey.Domain.Models.Turma;
using MediatR;

namespace Biopark.CpaSurvey.Application.Turmas.Commands.CriarTurma;

public class CriarTurmaCommand : IRequest<Turma>{

    public string Nome { get; set; }

    public long CursoId { get; set; }
}

public class CriarTurmaCommandHandler : IRequestHandler<CriarTurmaCommand, Turma> 
{ 
    private readonly IUnitOfWork _unitOfWork;
    public CriarTurmaCommandHandler(IUnitOfWork unitOfWork) 
    { 
        _unitOfWork = unitOfWork;
    }

    public async Task<Turma> Handle(CriarTurmaCommand request, CancellationToken cancellationToken)
    {
        var model = CriarModelo(request);

        var turmaInserir = new Turma(model);

        var repositoryTurma = _unitOfWork.GetRepository<Turma>();

        repositoryTurma.Add(turmaInserir);

        await _unitOfWork.CommitAsync();

        return turmaInserir;
    }

    public TurmaModel CriarModelo(CriarTurmaCommand request)
    {
        var model = new TurmaModel
        {
            Nome = request.Nome,
            CursoId = request.CursoId,
        };

        return model;
    }
}
