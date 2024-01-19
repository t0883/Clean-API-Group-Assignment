using Domain.Models.Gearboxes;
using MediatR;

namespace Application.Commands.Gearboxes.DeleteGearbox
{
    public class DeleteGearboxByIdCommand : IRequest<Gearbox>
    {
        public DeleteGearboxByIdCommand(Guid id)
        {
            Id = id;
        }
        public Guid Id { get; }
    }
}
