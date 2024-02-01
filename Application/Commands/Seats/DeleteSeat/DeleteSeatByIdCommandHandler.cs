using Domain.Models.Seats;
using Infrastructure.Repository.Seats;
using MediatR;

namespace Application.Commands.Seats.DeleteSeat
{
    public class DeleteSeatByIdCommandHandler : IRequestHandler<DeleteSeatByIdCommand, Seat>
    {
        private readonly ISeatRepository _seatRepository;

        public DeleteSeatByIdCommandHandler(ISeatRepository seatRepository)
        {
            _seatRepository = seatRepository ?? throw new ArgumentNullException(nameof(seatRepository));
        }

        public async Task<Seat> Handle(DeleteSeatByIdCommand request, CancellationToken cancellationToken)
        {
            var result = await _seatRepository.DeleteSeatById(request.SeatId);

            return await Task.FromResult(result);
        }
    }
}
