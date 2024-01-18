using Domain.Models.Gearboxes;
using Infrastructure.Repository.Gearboxes;
using MediatR;

namespace Application.Commands.Gearboxes.AddGearbox
{
    public class AddGearboxCommandHandler : IRequestHandler<AddGearboxCommand, Gearbox>
    {
        private readonly IGearboxRepository _gearboxRepository;

        public AddGearboxCommandHandler(IGearboxRepository gearboxRepository)
        {
            _gearboxRepository = gearboxRepository;
        }

        public async Task<Gearbox> Handle(AddGearboxCommand request, CancellationToken cancellationToken)
        {
            Gearbox gearboxToCreate = new Gearbox
            {
                GearboxId = Guid.NewGuid(),
                GearboxModel = request.NewGearbox.GearboxModel,
                SixGears = request.NewGearbox.SixGears,
                Brand = request.NewGearbox.Brand,
            };

            var result = await _gearboxRepository.AddGearbox(gearboxToCreate);

            return await Task.FromResult(result);
        }
    }
}
