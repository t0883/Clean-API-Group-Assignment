using Domain.Models.Cars;
using Infrastructure.Repository.Cars;
using MediatR;

namespace Application.Commands.Cars.AddCar
{
    public class AddCarCommandHandler : IRequestHandler<AddCarCommand, Car>
    {
        private readonly ICarRepository _carRepository;

        public AddCarCommandHandler(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }

        public async Task<Car> Handle(AddCarCommand request, CancellationToken cancellationToken)
        {
            Car carToCreate = new Car { Brand = request.NewCar.BrandName, Engine = request.NewCar.EngineId, Seat = request.NewCar.SeatId, Tire = request.NewCar.TireId, Name = request.NewCar.CarName, CarId = Guid.NewGuid(), CreatedBy = request.NewCar.UserId, Gearbox = request.NewCar.GearboxId };

            var result = await _carRepository.AddCar(carToCreate);

            return await Task.FromResult(result);
        }
    }
}
