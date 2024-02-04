using Domain.Models.Cars;
using Infrastructure.Repository.Cars;
using MediatR;

namespace Application.Queries.Cars.GetAll
{
    public class GetAllCarsQueryHandler : IRequestHandler<GetAllCarsQuery, List<Car>>
    {
        private readonly ICarRepository _carRepository;

        public GetAllCarsQueryHandler(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }

        public async Task<List<Car>> Handle(GetAllCarsQuery request, CancellationToken cancellationToken)
        {
            List<Car> cars = await _carRepository.GetAllCars();

            return await Task.FromResult(cars);
        }
    }
}
