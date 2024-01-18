using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.Queries.Tires.GetAll;
using Domain.Models.Tires;
using Infrastructure.Repository.Tires;

namespace Application.Queries.Tires.GetAll
{
    public class GetAllTiresQueryHandler : IRequestHandler<GetAllTiresQuery, List<Tire>>
    {
        private readonly ITireRepository _tireRepository;

        public GetAllTiresQueryHandler(ITireRepository tireRepository)
        {
            _tireRepository = tireRepository ?? throw new System.ArgumentNullException(nameof(tireRepository));
        }

        public async Task<List<Tire>> Handle(GetAllTiresQuery request, CancellationToken cancellationToken)
        {
            return await _tireRepository.GetAllTires();
        }
    }
}
