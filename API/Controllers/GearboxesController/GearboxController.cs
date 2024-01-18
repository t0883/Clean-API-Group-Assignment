using Application.Commands.Gearboxes.AddGearbox;
using Application.Dtos;
using Application.Queries.Gearboxes.GetAll;
using Application.Queries.Gearboxes.GetById;
using Domain.Models.Gearboxes;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.GearboxesController
{
    [Route("api/[controller]")]
    [ApiController]
    public class GearboxController : ControllerBase
    {
        internal readonly IMediator _mediator;
        public GearboxController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Route("addNewGearbox")]
        [ProducesResponseType(typeof(Gearbox), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AddGearbox([FromBody] GearboxDto gearbox)
        {
            try
            {
                var command = new AddGearboxCommand(gearbox);
                var result = await _mediator.Send(command);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("getAllGearboxes")]
        public async Task<IActionResult> GetAllGearboxess()
        {
            return Ok(await _mediator.Send(new GetAllGearboxesQuery()));
        }

        [HttpGet]
        [Route("getGearboxById/{gearboxId}")]
        public async Task<IActionResult> GetGearboxById(Guid gearboxId)
        {
            return Ok(await _mediator.Send(new GetGearboxByIdQuery(gearboxId)));
        }
    }
}
