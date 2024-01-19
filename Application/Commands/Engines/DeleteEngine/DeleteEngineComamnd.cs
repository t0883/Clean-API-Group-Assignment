using Domain.Models.Engines;
using MediatR;

namespace Application.Commands.Engines.DeleteEngine
{
    public class DeleteEngineCommand : IRequest<Engine>
    {
        public DeleteEngineCommand(Guid engineId)
        {
            EngineId = engineId;
        }

        public Guid EngineId { get; }
    }
}