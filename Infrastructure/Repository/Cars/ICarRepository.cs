using Domain.Models.Cars;

namespace Infrastructure.Repository.Cars
{
    public interface ICarRepository
    {
        Task<Car> AddCar(Car car);
        Task<List<Car>> GetAllCars();

    }
}
