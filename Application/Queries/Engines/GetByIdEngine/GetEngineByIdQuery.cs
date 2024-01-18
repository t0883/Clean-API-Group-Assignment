using Domain.Models.Engines;
using MediatR;

namespace Application.Commands.Engines.QuerieEngine.GetByIdEngine
{
    public class GetEngineByIdQuery : IRequest<Engine>
    {
        public GetEngineByIdQuery(string engineName, string engineFuel, int horsePower)
        {
            EngineName = engineName;
            EngineFuel = engineFuel;
            HorsePower = horsePower;
        }

        public string EngineName { get; }
        public string EngineFuel { get; }
        public int HorsePower { get; }
    }
}