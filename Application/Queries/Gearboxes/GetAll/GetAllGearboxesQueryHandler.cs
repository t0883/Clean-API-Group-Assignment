using Domain.Models.Gearboxes;
using Infrastructure.Repository.Gearboxes;
using MediatR;

namespace Application.Queries.Gearboxes.GetAll
{
    public class GetAllGeaxesQueryHandler : IRequestHandler<GetAllGearboxesQuery, List<Gearbox>>
    {
        private readonly IGearboxRepository _gearboxRepository;

        public GetAllGeaxesQueryHandler(IGearboxRepository gearboxRepository)
        {
            _gearboxRepository = gearboxRepository;
        }

        public async Task<List<Gearbox>> Handle(GetAllGearboxesQuery request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(await _gearboxRepository.GetAllGearboxes());
        }
    }
}
