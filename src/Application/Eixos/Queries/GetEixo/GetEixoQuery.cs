using Biopark.CpaSurvey.Domain.Entities.Eixos;
using Biopark.CpaSurvey.Domain.Interfaces.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Biopark.CpaSurvey.Application.Eixos.Queries.GetEixo
{
    public class GetEixoQuery : IRequest<Eixo>
    {
        public long EixoId { get; set; }
    }

    public class GetEixoQueryHandler : IRequestHandler<GetEixoQuery, Eixo>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetEixoQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task<Eixo> Handle(GetEixoQuery request, CancellationToken cancellationToken)
        {
            var repository = _unitOfWork.GetRepository<Eixo>();

            var eixo = repository
                .FindBy(c => c.Id == request.EixoId)
                .FirstAsync(cancellationToken);

            return eixo;
        }
    }
}