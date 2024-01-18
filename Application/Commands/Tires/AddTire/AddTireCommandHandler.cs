using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Dtos;
using Domain.Models.Tires;
using Infrastructure.Repository.Tires;

namespace Application.Commands.Tires.AddTire
{
    public class AddTireCommandHandler : IRequestHandler<AddTireCommand, Unit>
    {
        private readonly ITireRepository _tireRepository;

        public AddTireCommandHandler(ITireRepository tireRepository)
        {
            _tireRepository = tireRepository ?? throw new ArgumentNullException(nameof(tireRepository));
        }

        public async Task<Unit> Handle(AddTireCommand request, CancellationToken cancellationToken)
        {
            var newTire = new Tire
            {
                TireModel = request.NewTire.TireModel,
                Brand = request.NewTire.Brand,
                TireSize = request.NewTire.TireSize,
                TireTreadDepth = request.NewTire.TireTreadDepth
            };

            await _tireRepository.AddTire(newTire);

            return Unit.Value;
        }
    }
}
