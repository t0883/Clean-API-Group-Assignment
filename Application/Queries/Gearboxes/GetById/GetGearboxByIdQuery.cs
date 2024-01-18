using Domain.Models.Gearboxes;
using MediatR;

namespace Application.Queries.Gearboxes.GetById
{
    public class GetGearboxByIdQuery : IRequest<Gearbox>
    {
        public GetGearboxByIdQuery(Guid gearboxId)
        {
            GearboxId = gearboxId;
        }
        public Guid GearboxId { get; }
    }
}
