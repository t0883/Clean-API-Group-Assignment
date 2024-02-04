using Domain.Models.Tires;
using Infrastructure.Repository.Tires;
using MediatR;

namespace Application.Commands.Tires.AddTire
{
    public class AddTireCommandHandler : IRequestHandler<AddTireCommand, Tire>
    {
        private readonly ITireRepository _tireRepository;

        public AddTireCommandHandler(ITireRepository tireRepository)
        {
            _tireRepository = tireRepository ?? throw new ArgumentNullException(nameof(tireRepository));
        }

        public async Task<Tire> Handle(AddTireCommand request, CancellationToken cancellationToken)
        {
            var newTire = new Tire
            {
                TireModel = request.NewTire.TireModel,
                Brand = request.NewTire.Brand,
                TireSize = request.NewTire.TireSize,
                TireTreadDepth = request.NewTire.TireTreadDepth
            };

            var result = await _tireRepository.AddTire(newTire);

            return await Task.FromResult(result);
        }
    }
}
