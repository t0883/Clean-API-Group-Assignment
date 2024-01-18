using Domain.Models.Engines;
using MediatR;

namespace Application.Commands.Engines.UpdateEngine
{
	public class UpdateEngineCommand : IRequest<Engine>
    {
        public UpdateEngineCommand(Engine engineToUpdate)
        {
            EngineId = engineToUpdate.EngineId;
            EngineName = engineToUpdate.EngineName;
            EngineFuel = engineToUpdate.EngineFuel;
            HorsePower = engineToUpdate.HorsePower;
        }

        public Guid EngineId { get; }
        public string EngineName { get; }
        public int HorsePower { get; }
        public string EngineFuel { get; }
	}
}

