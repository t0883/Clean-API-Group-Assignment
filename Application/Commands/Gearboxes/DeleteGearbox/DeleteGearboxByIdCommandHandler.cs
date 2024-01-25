using Domain.Models.Gearboxes;
using Infrastructure.Repository.Gearboxes;
using MediatR;

namespace Application.Commands.Gearboxes.DeleteGearbox
{
    public class DeleteGearboxByIdCommandHandler : IRequestHandler<DeleteGearboxByIdCommand, Gearbox>
    {
        private readonly IGearboxRepository _gearboxRepository;

        public DeleteGearboxByIdCommandHandler(IGearboxRepository gearboxRepository)
        {
            _gearboxRepository = gearboxRepository;
        }
        public async Task<Gearbox> Handle(DeleteGearboxByIdCommand request, CancellationToken cancellationToken)
        {
            var result = await _gearboxRepository.DeleteGearbox(request.Id);
            return await Task.FromResult(result);

            //var gearboxToDelete = await _gearboxRepository.GetGearboxById(request.Id);

            //if (gearboxToDelete == null)
            //{
            //    return await Task.FromResult<Gearbox>(null!);
            //}

            //await _gearboxRepository.DeleteGearbox(gearboxToDelete);

            //return gearboxToDelete;
        }
    }
}
