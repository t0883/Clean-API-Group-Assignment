using Application.Commands.Engines.Queries.GetAll;
using Domain.Models.Engines;
using Infrastructure.Repository.Engines.Interface;
using MediatR;

namespace Application.Commands.Engines.QuerieEngine.GetAll
{
    public class GetAllEngineQueryHandler : IRequestHandler<GetAllEngineQuery, List<Engine>>
    {
        private readonly IEngineRepository _engineRepository;

        public GetAllEngineQueryHandler(IEngineRepository engineRepository)
        {
            _engineRepository = engineRepository;
        }

        public async Task<List<Engine>> Handle(GetAllEngineQuery request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(await _engineRepository.GetAllEngines());
        }

    }
}