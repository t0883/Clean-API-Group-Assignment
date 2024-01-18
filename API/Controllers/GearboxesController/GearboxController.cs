using Application.Commands.Gearboxes.AddGearbox;
using Application.Dtos;
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

                // Return success response with the created Gearbox
                return Ok(result);
            }
            catch (Exception ex)
            {
                // Return error response if something goes wrong
                return BadRequest(ex.Message);
            }
        }
    }
}
