using Application.Commands.Tires.AddTire;
using Application.Commands.Tires.DeleteTire;
using Application.Commands.Tires.UpdateTire;
using Application.Queries.Tires.GetAll;
using Application.Queries.Tires.GetById;
using Application.Queries.Tires.GetByBrand;
using Application.Dtos;
using Domain.Models.Tires;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace API.Controllers.TiresController
{
    [Route("api/[controller]")]
    [ApiController]
    public class TiresController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TiresController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpPost]
        [Route("addNewTire")]
        public async Task<IActionResult> AddTire([FromBody] TireDto tire)
        {
            if (tire == null || string.IsNullOrWhiteSpace(tire.TireModel))
            {
                return BadRequest();
            }

            return Ok(await _mediator.Send(new AddTireCommand(tire)));
        }

        [HttpGet]
        [Route("getAllTires")]
        public async Task<IActionResult> GetAllTires()
        {
            return Ok(await _mediator.Send(new GetAllTiresQuery()));
        }

        [HttpGet]
        [Route("getTireById/{tireId}")]
        public async Task<IActionResult> GetTireById(Guid tireId)
        {
            return Ok(await _mediator.Send(new GetTireByIdQuery(tireId)));
        }

        [HttpGet]
        [Route("getTireByBrand/{brandName}")]
        public async Task<IActionResult> GetTireByBrand(string brandName)
        {
            return Ok(await _mediator.Send(new GetTireByBrandQuery(brandName)));
        }

        [HttpPut]
        [Route("updateTireById")]
        public async Task<IActionResult> UpdateTireById([FromBody] Tire tireToUpdate)
        {
            return Ok(await _mediator.Send(new UpdateTireByIdCommand(tireToUpdate)));
        }

        [HttpDelete]
        [Route("deleteTireById/{tireId}")]
        public async Task<IActionResult> DeleteTireById(Guid tireId)
        {
            await _mediator.Send(new DeleteTireByIdCommand(tireId));

            return NoContent();
        }
    }
}
