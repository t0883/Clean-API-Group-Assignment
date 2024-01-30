using Domain.Models.Seats;
using Infrastructure.Repository.Seats;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.Seats.AddSeat
{
    public class AddSeatCommandHandler : IRequestHandler<AddSeatCommand, Unit>
    {
        private readonly ISeatRepository _seatRepository;

        public AddSeatCommandHandler(ISeatRepository seatRepository)
        {
            _seatRepository = seatRepository ?? throw new ArgumentNullException(nameof(seatRepository));
        }

        public async Task<Unit> Handle(AddSeatCommand request, CancellationToken cancellationToken)
        {
            var newSeat= new Seat
            {
                SeatName = request.NewSeat.SeatName,
                Brand = request.NewSeat.Brand,
                SeatColor = request.NewSeat.SeatColor,
                SeatMaterial = request.NewSeat.SeatMaterial
            };

            await _seatRepository.AddSeat(newSeat);

            return Unit.Value;
        }
    }
}
