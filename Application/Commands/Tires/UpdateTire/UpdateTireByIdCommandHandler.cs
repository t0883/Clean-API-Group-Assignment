using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Domain.Models.Tires;
using Infrastructure.Repository.Tires;

namespace Application.Commands.Tires.UpdateTire
{
    public class UpdateTireByIdCommandHandler : IRequestHandler<UpdateTireByIdCommand, Unit>
    {
        private readonly ITireRepository _tireRepository;

        public UpdateTireByIdCommandHandler(ITireRepository tireRepository)
        {
            _tireRepository = tireRepository;
        }

        public async Task<Unit> Handle(UpdateTireByIdCommand request, CancellationToken cancellationToken)
        {
            var updatedTire = new Tire
            {
                TireModel = request.TireModel,
                Brand = request.Brand,
                TireSize = request.TireSize,
                TireTreadDepth = request.TireTreadDepth,
                TireId = request.TireId
            };

            await _tireRepository.UpdateTire(updatedTire);

            return Unit.Value;
        }
    }
}
