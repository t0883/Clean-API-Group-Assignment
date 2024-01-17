using Domain.Models.Engines;
using MediatR;

namespace Application.Commands.Engines.DeleteEngine
{
    public class DeleteEngineCommand : IRequest<Engine>
    {
        public DeleteEngineCommand(string engineFuel, int horsePower)
        {
            EngineFuel = engineFuel;
            HorsePower = horsePower;
        }

        public string EngineFuel { get; }
        public int HorsePower { get; }
    }
}