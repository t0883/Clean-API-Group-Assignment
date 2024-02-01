using Domain.Models.Seats;
using MediatR;

namespace Application.Queries.Seats.GetAll
{
    public class GetAllSeatsQuery : IRequest<List<Seat>>
    {
    }
}
