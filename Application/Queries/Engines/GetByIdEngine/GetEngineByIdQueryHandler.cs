using Domain.Models.Engines;
using Infrastructure.Repository.Engines.Interface;
using MediatR;

namespace Application.Commands.Engines.QuerieEngine.GetByIdEngine
{
    public class GetEngineByIdQueryHandler : IRequestHandler<GetEngineByIdQuery, Engine>
    {
        private readonly IEngineRepository _engineRepository;

        public GetEngineByIdQueryHandler(IEngineRepository engineRepository)
        {
            _engineRepository = engineRepository;
        }


        public async Task<Engine> Handle(GetEngineByIdQuery request, CancellationToken cancellationToken)
        {
            return await _engineRepository.GetEngineById(request.EngineFuel, request.HorsePower);
        }
    }
}