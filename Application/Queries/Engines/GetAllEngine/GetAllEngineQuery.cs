using Domain.Models.Engines;
using MediatR;

namespace Application.Commands.Engines.Queries.GetAll
{
    public class GetAllEngineQuery : IRequest<List<Engine>>
    {

    }
}

