using Application.Commands.Engines.AddEngine;
using Application.Commands.Engines.DeleteEngine;
using Application.Commands.Engines.UpdateEngine;
using Application.Dtos;
using Domain.Models.Engines;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Application.Commands.Engines.Queries.GetAll;
using Application.Commands.Engines.QuerieEngine.GetByIdEngine;
using Azure.Core;

namespace API.Controllers.EnginesController
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnginesController : ControllerBase
    {
        internal readonly IMediator _mediator;

        public EnginesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Route("addNewEngine")]
        public async Task<IActionResult> AddEngine([FromBody] EngineDto engineDto)
        {
            if (engineDto == null || engineDto.EngineFuel == null)
            {
                return BadRequest();
            }

            var command = new AddEngineCommand(engineDto);
            var result = await _mediator.Send(command);

            return Ok(result);
        }

        [HttpGet]
        [Route("getAllEngine")]
        public async Task<IActionResult> GetAllEngines()
        {
            return Ok(await _mediator.Send(new GetAllEngineQuery()));
        }

        [HttpGet]
        [Route("getEngineById")]
        public async Task<IActionResult> GetEngineById(string engineFuel, string engineName, int horsePower)
        {
            return Ok(await _mediator.Send(new GetEngineByIdQuery(engineName, engineFuel, horsePower)));
        }

        [HttpPut]
        [Route("updateEngine")]
        public async Task<IActionResult> UpdateEngine([FromBody] Engine engineToUpdate)
        {
            return Ok(await _mediator.Send(new UpdateEngineCommand(engineToUpdate)));
        }

        [HttpDelete]
        [Route("deleteEngine")]
        public async Task<IActionResult> DeleteEngine(string engineName, string engineFuel, int horsePower)
        {
            await _mediator.Send(new DeleteEngineCommand(engineName, engineFuel, horsePower));
            return NoContent();
        }
    }
}