using Domain.Models.Engines;
using Infrastructure.Repository.Engines.Interface;
using MediatR;

namespace Application.Commands.Engines.AddEngine
{
    public class AddEngineCommandHandler : IRequestHandler<AddEngineCommand, Engine>
    {
        private readonly IEngineRepository _engineRepository;

        public AddEngineCommandHandler(IEngineRepository engineRepository)
        {
            _engineRepository = engineRepository;
        }

        public async Task<Engine> Handle(AddEngineCommand request, CancellationToken cancellationToken)
        {
            Engine engineToCreate = new Engine { EngineId = Guid.NewGuid(), EngineFuel = request.NewEngine.EngineFuel, HorsePower = request.NewEngine.HorsePower };

            var result = await _engineRepository.AddEngine(engineToCreate);

            return await Task.FromResult(result);
        }
    }
}