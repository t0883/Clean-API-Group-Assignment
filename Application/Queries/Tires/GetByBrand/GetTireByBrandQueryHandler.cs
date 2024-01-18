using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.Queries.Tires.GetByBrand;
using Domain.Models.Tires;
using Infrastructure.Repository.Tires;

namespace Application.Queries.Tires.GetByBrand
{
    public class GetTireByBrandQueryHandler : IRequestHandler<GetTireByBrandQuery, List<Tire>>
    {
        private readonly ITireRepository _tireRepository;

        public GetTireByBrandQueryHandler(ITireRepository tireRepository)
        {
            _tireRepository = tireRepository ?? throw new System.ArgumentNullException(nameof(tireRepository));
        }

        public async Task<List<Tire>> Handle(GetTireByBrandQuery request, CancellationToken cancellationToken)
        {
            return await _tireRepository.GetTireByBrand(request.BrandName);
        }
    }
}
