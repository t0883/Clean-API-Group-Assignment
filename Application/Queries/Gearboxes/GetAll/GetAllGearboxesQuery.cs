using Domain.Models.Gearboxes;
using MediatR;

namespace Application.Queries.Gearboxes.GetAll
{
    public class GetAllGearboxesQuery : IRequest<List<Gearbox>>
    {
    }
}
