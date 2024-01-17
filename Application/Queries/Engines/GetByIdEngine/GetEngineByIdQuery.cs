using Domain.Models.Engines;
using MediatR;

namespace Application.Commands.Engines.QuerieEngine.GetByIdEngine
{
    public class GetEngineByIdQuery : IRequest<Engine>
    {
        public GetEngineByIdQuery(string engineFuel, int horsePower)
        {

            EngineFuel = engineFuel;
            HorsePower = horsePower;

        }

        public string EngineFuel { get; }
        public int HorsePower { get; }
    }
}