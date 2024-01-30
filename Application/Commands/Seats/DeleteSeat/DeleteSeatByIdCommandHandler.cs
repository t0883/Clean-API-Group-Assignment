using Infrastructure.Repository.Seats;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.Seats.DeleteSeat
{
    public class DeleteSeatByIdCommandHandler : IRequestHandler<DeleteSeatByIdCommand, Unit>
    {
        private readonly ISeatRepository _seatRepository;

        public DeleteSeatByIdCommandHandler(ISeatRepository seatRepository)
        {
            _seatRepository = seatRepository ?? throw new ArgumentNullException(nameof(seatRepository));
        }

        public async Task<Unit> Handle(DeleteSeatByIdCommand request, CancellationToken cancellationToken)
        {
            await _seatRepository.DeleteSeatById(request.SeatId);

            return Unit.Value;
        }
    }
