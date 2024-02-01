using Application.Commands.Seats.AddSeat;
using Application.Dtos;
using Application.Validator.GuidValidation;
using Application.Validator.StringValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.SeatsController
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeatsController : ControllerBase
    {
        internal readonly IMediator _mediator;
        internal readonly GuidValidator _guidValidator;
        internal readonly StringValidator _stringValidator;
        public SeatsController(IMediator mediator, GuidValidator guidValidator, StringValidator stringValidator)
        {
            _mediator = mediator;
            _guidValidator = guidValidator;
            _stringValidator = stringValidator;
        }

        [HttpPost]
        [Route("addNewSeat")]
        public async Task<IActionResult> AddSeat([FromBody] SeatDto seat)
        {
            var validatedSeatName = _stringValidator.Validate(seat.SeatName);
            if (!validatedSeatName.IsValid)
            {
                return BadRequest(validatedSeatName.Errors.ConvertAll(errors => errors.ErrorMessage));
            }
            var validatedSeatColor = _stringValidator.Validate(seat.SeatColor);
            if (!validatedSeatColor.IsValid)
            {
                return BadRequest(validatedSeatColor.Errors.ConvertAll(errors => errors.ErrorMessage));
            }
            var validatedSeatMaterial = _stringValidator.Validate(seat.SeatMaterial);
            if (!validatedSeatMaterial.IsValid)
            {
                return BadRequest(validatedSeatMaterial.Errors.ConvertAll(errors => errors.ErrorMessage));
            }
            return Ok(await _mediator.Send(new AddSeatCommand(seat)));
        }
    }
}
