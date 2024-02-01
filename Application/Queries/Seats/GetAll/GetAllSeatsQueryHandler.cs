using Application.Queries.Seats.GetAll;
using Domain.Models.Seats;
using Infrastructure.Repository.Seats;
using MediatR;

namespace Application.Queries.Seats.GetAll
{
    public class GetAllSeatsQueryHandler : IRequestHandler<GetAllSeatsQuery, List<Seat>>
    {
        private readonly ISeatRepository _seatRepository;

        public GetAllSeatsQueryHandler(ISeatRepository seatRepository)
        {
            _seatRepository = seatRepository;
        }

        public async Task<List<Seat>> Handle(GetAllSeatsQuery request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(await _seatRepository.GetAllSeats());
        }
    }
}