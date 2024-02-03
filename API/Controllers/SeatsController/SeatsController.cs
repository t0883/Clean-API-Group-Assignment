using Application.Commands.Seats.AddSeat;
using Application.Commands.Seats.DeleteSeat;
using Application.Commands.Seats.UpdateSeat;
using Application.Dtos;
using Application.Queries.Seats.GetAll;
using Application.Queries.Seats.GetById;
using Application.Validator.GuidValidation;
using Application.Validator.StringValidation;
using Domain.Models.Seats;
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
        [HttpGet]
        [Route("getAllSeats")]
        public async Task<IActionResult> GetAllSeats()
        {
            return Ok(await _mediator.Send(new GetAllSeatsQuery()));
        }
        [HttpGet]
        [Route("getSeatById/{seatId}")]
        public async Task<IActionResult> GetSeatById(Guid seatId)
        {
            try
            {
                var validationResult = _guidValidator.Validate(seatId);
                if (!validationResult.IsValid)
                {
                    return BadRequest(validationResult.Errors.ConvertAll(error => error.ErrorMessage));
                }

                var result = await _mediator.Send(new GetSeatByIdQuery(seatId));

                return Ok(result);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
        [HttpPut]
        [Route("updateSeat")]
        public async Task<IActionResult> UpdateSeatById([FromBody] Seat seatToUpdate)
        {
            try
            {
                var validatedSeatId = _guidValidator.Validate(seatToUpdate.SeatId);
                if (!validatedSeatId.IsValid)
                {
                    return BadRequest(validatedSeatId.Errors.ConvertAll(errors => errors.ErrorMessage));
                }
                return Ok(await _mediator.Send(new UpdateSeatByIdCommand(seatToUpdate)));
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }
        [HttpDelete]
        [Route("deleteSeat")]
        public async Task<IActionResult> DeleteSeat(Guid seatId)
        {
            var validatedSeatId = _guidValidator.Validate(seatId);
            if (!validatedSeatId.IsValid)
            {
                return BadRequest(validatedSeatId.Errors.Select(error => error.ErrorMessage));
            }
            await _mediator.Send(new DeleteSeatByIdCommand(seatId));
            return NoContent();
        }
    }
}
