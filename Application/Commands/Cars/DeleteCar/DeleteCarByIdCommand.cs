using Domain.Models.Cars;
using MediatR;

namespace Application.Commands.Cars.DeleteCar
{
    public class DeleteCarByIdCommand : IRequest<Car>
    {
        public DeleteCarByIdCommand(Guid carId)
        {
            CarId = carId;
        }

        public Guid CarId { get; }
    }
}
