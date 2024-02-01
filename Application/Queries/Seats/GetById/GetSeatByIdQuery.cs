using Domain.Models.Seats;
using MediatR;

namespace Application.Queries.Seats.GetById
{
    public class GetSeatByIdQuery : IRequest<Seat>
    {
        public GetSeatByIdQuery(Guid seatId)
        {
            SeatId = seatId;
        }
        public Guid SeatId { get; }
    }
}
