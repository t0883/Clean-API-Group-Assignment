using Application.Dtos;
using Domain.Models.Seats;
using MediatR;

namespace Application.Commands.Seats.AddSeat
{
    public class AddSeatCommand : IRequest<Seat>
    {
        public AddSeatCommand(SeatDto newSeat)
        {
            NewSeat = newSeat;
        }

        public SeatDto NewSeat { get; }
    }
}
