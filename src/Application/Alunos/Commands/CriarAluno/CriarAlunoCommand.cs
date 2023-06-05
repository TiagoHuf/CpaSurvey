using Biopark.CpaSurvey.Domain.Entities.Alunos;
using Biopark.CpaSurvey.Domain.Interfaces.Infrastructure;
using Biopark.CpaSurvey.Domain.Models.Alunos;
using MediatR;

namespace Biopark.CpaSurvey.Application.Alunos.Commands.CriarAluno;

public class CriarAlunoCommand : IRequest<Aluno>
{
    public string Nome { get; set; }

    public string Ra { get; set; }

    public string Email { get; set; }

    public long CursoId { get; set; }
}

public class CriarAlunoCommandHandler : IRequestHandler<CriarAlunoCommand, Aluno>
{
    private readonly IUnitOfWork _unitOfWork;

    public CriarAlunoCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Aluno> Handle(CriarAlunoCommand request, CancellationToken cancellationToken)
    {
        var model = CriaModelo(request);

        var alunoInserir = new Aluno(model);

        var repositoryaluno = _unitOfWork.GetRepository<Aluno>();

        repositoryaluno.Add(alunoInserir);

        await _unitOfWork.CommitAsync();

        return alunoInserir;
    }

    public AlunoModel CriaModelo(CriarAlunoCommand request)
    {
        var model = new AlunoModel
        {
            Nome = request.Nome,
            Ra = request.Ra,
            Email = request.Email,
            CursoId = request.CursoId,
        };

        return model;
    }
}