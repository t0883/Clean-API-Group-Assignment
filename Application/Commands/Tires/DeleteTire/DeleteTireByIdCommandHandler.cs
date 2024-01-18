using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using Infrastructure.Repository.Tires;

namespace Application.Commands.Tires.DeleteTire
{
    public class DeleteTireByIdCommandHandler : IRequestHandler<DeleteTireByIdCommand, Unit>
    {
        private readonly ITireRepository _tireRepository;

        public DeleteTireByIdCommandHandler(ITireRepository tireRepository)
        {
            _tireRepository = tireRepository ?? throw new ArgumentNullException(nameof(tireRepository));
        }

        public async Task<Unit> Handle(DeleteTireByIdCommand request, CancellationToken cancellationToken)
        {
            await _tireRepository.DeleteTireById(request.TireId);

            return Unit.Value;
        }
    }
}
