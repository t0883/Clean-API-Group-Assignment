using Application.Dtos;
using MediatR;
using Domain.Models.Engines;

namespace Application.Commands.Engines.AddEngine
{
    public class AddEngineCommand : IRequest<Engine>
    {
        public AddEngineCommand(EngineDto newEngine)
        {
            NewEngine = newEngine;
        }

        public EngineDto NewEngine { get; }
    }
}