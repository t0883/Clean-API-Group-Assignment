using Domain.Models.Engines;
using MediatR;

namespace Application.Commands.Engines.QuerieEngine.GetByIdEngine
{
    public class GetEngineByIdQuery : IRequest<Engine>
    {
        public GetEngineByIdQuery(Guid engineId)
        {
            EngineId = engineId;
        }

        public Guid EngineId { get; }
    }
}