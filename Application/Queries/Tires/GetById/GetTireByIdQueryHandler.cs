using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Queries.Tires.GetById;
using Domain.Models.Tires;
using Infrastructure.Repository.Tires;

namespace Application.Queries.Tires.GetById
{
    public class GetTireByIdQueryHandler : IRequestHandler<GetTireByIdQuery, Tire>
    {
        private readonly ITireRepository _tireRepository;

        public GetTireByIdQueryHandler(ITireRepository tireRepository)
        {
            _tireRepository = tireRepository ?? throw new System.ArgumentNullException(nameof(tireRepository));
        }

        public async Task<Tire> Handle(GetTireByIdQuery request, CancellationToken cancellationToken)
        {
            return await _tireRepository.GetTireById(request.TireId);
        }
    }
}
