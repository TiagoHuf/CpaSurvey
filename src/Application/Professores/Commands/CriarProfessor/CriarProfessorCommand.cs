using Biopark.CpaSurvey.Domain.Entities.Professores;
using Biopark.CpaSurvey.Domain.Interfaces.Infrastructure;
using Biopark.CpaSurvey.Domain.Models.Professores;
using MediatR;

namespace Biopark.CpaSurvey.Application.Alunos.Commands.CriarAluno;

public class CriarProfessorCommand : IRequest<Professor>
{
    public string Nome { get; set; }
}

public class CriarProfessorCommandHandler : IRequestHandler<CriarProfessorCommand, Professor>
{
    private readonly IUnitOfWork _unitOfWork;

    public CriarProfessorCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Professor> Handle(CriarProfessorCommand request, CancellationToken cancellationToken)
    {
        var model = CriaModelo(request);

        var professorInserir = new Professor(model);

        var repositoryProfessor = _unitOfWork.GetRepository<Professor>();

        repositoryProfessor.Add(professorInserir);

        await _unitOfWork.CommitAsync();

        return professorInserir;
    }

    public ProfessorModel CriaModelo(CriarProfessorCommand request)
    {
        var model = new ProfessorModel
        {
            Nome = request.Nome,
        };

        return model;
    }
}