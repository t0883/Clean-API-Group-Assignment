using Domain.Models.Seats;
using MediatR;

namespace Application.Commands.Seats.DeleteSeat
{
    public class DeleteSeatByIdCommand : IRequest<Seat>
    {
        public DeleteSeatByIdCommand(Guid seatId)
        {
            SeatId = seatId;
        }

        public Guid SeatId { get; }
    }
}
