using Domain.Models.Gearboxes;
using Infrastructure.Repository.Gearboxes;
using MediatR;

namespace Application.Queries.Gearboxes.GetById
{
    public class GetGearboxByIdQueryHandler : IRequestHandler<GetGearboxByIdQuery, Gearbox?>
    {
        private readonly IGearboxRepository _gearboxRepository;

        public GetGearboxByIdQueryHandler(IGearboxRepository gearboxRepository)
        {
            _gearboxRepository = gearboxRepository;
        }

        public async Task<Gearbox?> Handle(GetGearboxByIdQuery request, CancellationToken cancellationToken)
        {
            return await _gearboxRepository.GetGearboxById(request.GearboxId);
        }

    }
}
