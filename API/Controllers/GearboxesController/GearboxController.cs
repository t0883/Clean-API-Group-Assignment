using Application.Commands.Brands.UpdateBrand;
using Application.Commands.Gearboxes.AddGearbox;
using Application.Commands.Gearboxes.DeleteGearbox;
using Application.Commands.Gearboxes.UpdateGearbox;
using Application.Commands.Tires.DeleteTire;
using Application.Dtos;
using Application.Queries.Gearboxes.GetAll;
using Application.Queries.Gearboxes.GetById;
using Domain.Models.Brands;
using Domain.Models.Gearboxes;
using MediatR;
using Microsoft.AspNetCore.Authorization;
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

        [HttpPut]
        [Route("updateGearboxById")]
        [ProducesResponseType(typeof(Gearbox), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateGearboxById([FromBody] Gearbox gearboxToUpdate)
        {
            return Ok(await _mediator.Send(new UpdateGearboxByIdCommand(gearboxToUpdate)));
        }

        [HttpDelete]
        [Route("deleteGearboxById/{gearboxId}")]
        public async Task<IActionResult> DeletegearboxById(Guid gearboxId)
        {
            var deletedGearbox = await _mediator.Send(new DeleteGearboxByIdCommand(gearboxId));

            if (deletedGearbox == null)
            {
                return NotFound($"Bird with ID {gearboxId} not found.");
            }

            return Ok(deletedGearbox);
        }
    }
}
