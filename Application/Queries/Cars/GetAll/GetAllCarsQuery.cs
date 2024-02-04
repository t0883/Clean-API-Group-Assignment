using Domain.Models.Cars;
using MediatR;

namespace Application.Queries.Cars.GetAll
{
    public class GetAllCarsQuery : IRequest<List<Car>>
    {
    }
}
