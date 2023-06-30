using Biopark.CpaSurvey.Domain.Entities.Avaliacoes;
using Biopark.CpaSurvey.Domain.Entities.Turmas;
using Biopark.CpaSurvey.Domain.Interfaces.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Biopark.CpaSurvey.Application.Avaliacoes.Queries.GetTurmasAvaliacao;

public class GetTurmasAvaliacaoQuery : IRequest<List<TurmasAvaliacaoModelView>>
{
    public long AvaliacaoId { get; set; }
}

public class GetTurmasAvaliacaoQueryHandler : IRequestHandler<GetTurmasAvaliacaoQuery, List<TurmasAvaliacaoModelView>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetTurmasAvaliacaoQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<List<TurmasAvaliacaoModelView>> Handle(GetTurmasAvaliacaoQuery request, CancellationToken cancellationToken)
    {
        var repository = _unitOfWork.GetRepository<Avaliacao>();

        var avaliacao = await repository
            .FindBy(c => c.Id == request.AvaliacaoId)
            .Include(a => a.Turmas)
            .FirstAsync(cancellationToken);

        var turmaRepository = _unitOfWork.GetRepository<Turma>();

        var turmas = await turmaRepository
            .GetAll()
            .Include(p => p.Curso)
            .ToListAsync(cancellationToken);

        List<TurmasAvaliacaoModelView> turmasView = new ();

        foreach (Turma turmaAll in turmas)
        {
            var turmaNova = new TurmasAvaliacaoModelView
            {
                Id = turmaAll.Id,
                Nome = turmaAll.Nome,
                Curso = turmaAll.Curso.Nome,
                IsNaAvaliacao = false,
            };

            foreach (Turma turmaAvaliacao in avaliacao.Turmas)
            {
                if (turmaAll.Id == turmaAvaliacao.Id)
                {
                    turmaNova.IsNaAvaliacao = true;
                    break;
                }
            }

            turmasView.Add(turmaNova);
        }

        return turmasView;
    }
}