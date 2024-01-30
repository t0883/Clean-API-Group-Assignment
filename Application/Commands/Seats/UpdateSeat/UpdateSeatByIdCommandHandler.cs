using Application.Commands.Seats.UpdateSeat;
using Domain.Models.Seats;
using Infrastructure.Repository.Seats;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.Seats.UpdateSeat
{
    public class UpdateSeatByIdCommandHandler : IRequestHandler<UpdateSeatByIdCommand, Unit>
    {
        private readonly ISeatRepository _seatRepository;

        public UpdateSeatByIdCommandHandler(ISeatRepository seatRepository)
        {
            _seatRepository = seatRepository;
        }

        public async Task<Unit> Handle(UpdateSeatByIdCommand request, CancellationToken cancellationToken)
        {
            var updatedSeat = new Seat
            {
                SeatName = request.SeatName,
                Brand = request.Brand,
                SeatColor = request.SeatColor,
                SeatMaterial = request.SeatMaterial
            };

            await _seatRepository.UpdateSeat(updatedSeat);

            return Unit.Value;
        }
    }
