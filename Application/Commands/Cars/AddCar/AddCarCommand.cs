using Application.Dtos;
using Domain.Models.Cars;
using MediatR;

namespace Application.Commands.Cars.AddCar
{
    public class AddCarCommand : IRequest<Car>
    {
        public AddCarCommand(CarDto newCar)
        {
            NewCar = newCar;
        }
        public CarDto NewCar { get; }
    }
}
