using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.Seats.DeleteSeat
{
    public class DeleteSeatByIdCommand : IRequest<Unit>
    {
        public DeleteSeatByIdCommand(Guid seatId)
        {
            SeatId = seatId;
        }

        public Guid SeatId { get; }
    }
}
