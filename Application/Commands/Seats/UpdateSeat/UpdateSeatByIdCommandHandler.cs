using Domain.Models.Seats;
using Infrastructure.Repository.Seats;
using MediatR;

namespace Application.Commands.Seats.UpdateSeat
{
    public class UpdateSeatByIdCommandHandler : IRequestHandler<UpdateSeatByIdCommand, Seat>
    {
        private readonly ISeatRepository _seatRepository;

        public UpdateSeatByIdCommandHandler(ISeatRepository seatRepository)
        {
            _seatRepository = seatRepository;
        }

        public async Task<Seat> Handle(UpdateSeatByIdCommand request, CancellationToken cancellationToken)
        {
            var updatedSeat = new Seat
            {
                SeatName = request.SeatName,
                Brand = request.Brand,
                SeatColor = request.SeatColor,
                SeatMaterial = request.SeatMaterial
            };

            var result = await _seatRepository.UpdateSeat(updatedSeat);

            return await Task.FromResult(result);
        }
    }
}