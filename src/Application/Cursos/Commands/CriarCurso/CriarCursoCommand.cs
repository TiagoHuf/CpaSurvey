using Biopark.CpaSurvey.Domain.Entities.Cursos;
using Biopark.CpaSurvey.Domain.Interfaces.Infrastructure;
using Biopark.CpaSurvey.Domain.Models.Curso;
using MediatR;


namespace Biopark.CpaSurvey.Application.Cursos.Commands.CriarCurso;
public class CriarCursoCommand : IRequest<Curso>
{
    public string Nome { get; set; }

}

public class CriarCursoCommandHandler : IRequestHandler<CriarCursoCommand, Curso>
{
    private readonly IUnitOfWork _unitOfWork;

    public CriarCursoCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Curso> Handle(CriarCursoCommand request, CancellationToken cancellationToken)
    {
        var model = CriaModelo(request);

        var CursoInserir = new Curso(model);

        var repositoryCursos = _unitOfWork.GetRepository<CursosModel>();

        repositoryCursos.Add(CursoInserir);

        await _unitOfWork.CommitAsync();

        return CursoInserir;
    }

    public CursosModel CriaModelo(CriarCursoCommand request)
    {
        var model = new CursosModel
        {
            Nome = request.Nome,
        };

        return model;
    }
}
