using MediatR;
using System.Collections.Generic;
using Domain.Models.Tires;

namespace Application.Queries.Tires.GetAll
{
    public class GetAllTiresQuery : IRequest<List<Tire>>
    {
    }
}
