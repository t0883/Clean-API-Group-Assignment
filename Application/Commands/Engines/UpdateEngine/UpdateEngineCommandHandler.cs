using Domain.Models.Engines;
using Infrastructure.Repository.Engines.Interface;
using MediatR;

namespace Application.Commands.Engines.UpdateEngine
{
	public class UpdateEngineCommandHandler : IRequestHandler<UpdateEngineCommand, Engine>
    {
        private readonly IEngineRepository _engineRepository;

        public UpdateEngineCommandHandler(IEngineRepository engineRepository)
        {
            _engineRepository = engineRepository;
        }

        public async Task<Engine> Handle(UpdateEngineCommand request, CancellationToken cancellationToken)
        {
            Engine engineToUpdate = new Engine { EngineId = request.EngineId, EngineName = request.EngineName, EngineFuel = request.EngineFuel, HorsePower = request.HorsePower };

            var result = await _engineRepository.UpdateEngine(engineToUpdate);

            return await Task.FromResult(result);
        }
    }
}