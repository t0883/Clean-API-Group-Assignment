using Domain.Models.Seats;
using Infrastructure.Repository.Seats;
using MediatR;

namespace Application.Commands.Seats.AddSeat
{
    public class AddSeatCommandHandler : IRequestHandler<AddSeatCommand, Seat>
    {
        private readonly ISeatRepository _seatRepository;

        public AddSeatCommandHandler(ISeatRepository seatRepository)
        {
            _seatRepository = seatRepository ?? throw new ArgumentNullException(nameof(seatRepository));
        }

        public async Task<Seat> Handle(AddSeatCommand request, CancellationToken cancellationToken)
        {
            var newSeat = new Seat
            {
                SeatName = request.NewSeat.SeatName,
                Brand = request.NewSeat.Brand,
                SeatColor = request.NewSeat.SeatColor,
                SeatMaterial = request.NewSeat.SeatMaterial
            };

            await _seatRepository.AddSeat(newSeat);

            return await Task.FromResult(newSeat);
        }
    }
}
