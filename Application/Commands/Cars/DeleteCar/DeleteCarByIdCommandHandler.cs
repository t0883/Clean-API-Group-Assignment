using Domain.Models.Cars;
using Infrastructure.Repository.Cars;
using MediatR;

namespace Application.Commands.Cars.DeleteCar
{
    public class DeleteCarByIdCommandHandler : IRequestHandler<DeleteCarByIdCommand, Car>
    {
        private readonly ICarRepository _carRepository;

        public DeleteCarByIdCommandHandler(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }

        public async Task<Car> Handle(DeleteCarByIdCommand request, CancellationToken cancellationToken)
        {
            var result = await _carRepository.DeleteCarById(request.CarId);

            return await Task.FromResult(result);

        }
    }
}
