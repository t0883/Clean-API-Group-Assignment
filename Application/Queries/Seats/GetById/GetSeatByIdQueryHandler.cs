using Domain.Models.Seats;
using Infrastructure.Repository.Seats;
using MediatR;

namespace Application.Queries.Seats.GetById
{
    public class GetSeatByIdQueryHandler : IRequestHandler<GetSeatByIdQuery, Seat?>
    {
        private readonly ISeatRepository _seatRepository;

        public GetSeatByIdQueryHandler(ISeatRepository seatRepository)
        {
            _seatRepository = seatRepository;
        }

        public async Task<Seat?> Handle(GetSeatByIdQuery request, CancellationToken cancellationToken)
        {
            return await _seatRepository.GetSeatById(request.SeatId);
        }

    }
}
