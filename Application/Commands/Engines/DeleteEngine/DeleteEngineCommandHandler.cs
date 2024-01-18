using MediatR;
using Infrastructure.Repository.Engines.Interface;
using Domain.Models.Engines;

namespace Application.Commands.Engines.DeleteEngine
{
    public class DeleteEngineCommandHandler : IRequestHandler<DeleteEngineCommand, Engine>
    {
        private readonly IEngineRepository _engineRepository;

        public DeleteEngineCommandHandler(IEngineRepository engineRepository)
        {
            _engineRepository = engineRepository;
        }

        public async Task<Engine> Handle(DeleteEngineCommand request, CancellationToken cancellationToken)
        {
            var result = await _engineRepository.DeleteEngine(request.EngineFuel, request.EngineName, request.HorsePower);
            return await Task.FromResult(result);
        }
    }
}
