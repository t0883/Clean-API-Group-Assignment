using Domain.Models.Tires;
using Infrastructure.Repository.Tires;
using MediatR;

namespace Application.Commands.Tires.UpdateTire
{
    public class UpdateTireByIdCommandHandler : IRequestHandler<UpdateTireByIdCommand, Tire>
    {
        private readonly ITireRepository _tireRepository;

        public UpdateTireByIdCommandHandler(ITireRepository tireRepository)
        {
            _tireRepository = tireRepository;
        }

        public async Task<Tire> Handle(UpdateTireByIdCommand request, CancellationToken cancellationToken)
        {
            var updatedTire = new Tire
            {
                TireModel = request.TireModel,
                Brand = request.Brand,
                TireSize = request.TireSize,
                TireTreadDepth = request.TireTreadDepth,
                TireId = request.TireId
            };

            var result = await _tireRepository.UpdateTire(updatedTire);

            return await Task.FromResult(result);
        }
    }
}
