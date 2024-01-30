using Application.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.Seats.AddSeat
{
    public class AddSeatCommand : IRequest<Unit>
    {
        public AddSeatCommand(SeatDto newSeat)
        {
            NewSeat = newSeat;
        }

        public SeatDto NewSeat { get; }
    }
}
