using Application.Commands.Gearboxes.AddGearbox;
using Application.Commands.Gearboxes.DeleteGearbox;
using Application.Commands.Gearboxes.UpdateGearbox;
using Application.Commands.Tires.DeleteTire;
using Application.Dtos;
using Application.Queries.Gearboxes.GetAll;
using Application.Queries.Gearboxes.GetById;
using Application.Validator.GearboxModelValidation;
using Application.Validator.GuidValidation;
using Application.Validator.StringValidation;
using Domain.Models.Gearboxes;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.GearboxesController
{
    [Route("api/[controller]")]
    [ApiController]
    public class GearboxController : ControllerBase
    {
        internal readonly IMediator _mediator;
        internal readonly GuidValidator _guidValidator;
        internal readonly StringValidator _stringValidator;
        internal readonly GearboxModelValidator _gearboxModelValidator;
        public GearboxController(IMediator mediator, GuidValidator guidValidator, StringValidator stringValidator, GearboxModelValidator gearboxModelValidator)
        {
            _mediator = mediator;
            _guidValidator = guidValidator;
            _stringValidator = stringValidator;
            _gearboxModelValidator = gearboxModelValidator;
        }

        [HttpPost]
        [Route("addNewGearbox")]
        [ProducesResponseType(typeof(Gearbox), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AddGearbox([FromBody] GearboxDto gearbox)
        {
            try
            {
                var gearboxModelValidationResult = new GearboxModelValidator().Validate(gearbox.GearboxModel);
                var brandNameValidationResult = _stringValidator.Validate(gearbox.Brand.BrandName);

                //Kan köra || , det är egentligen snyggare men tänker att en lista kan vara rimlig för att skapa möjlighet att implementera ifall man adderar saker till gearbox.
                var validationErrors = new List<string>();

                if (!gearboxModelValidationResult.IsValid)
                    validationErrors.AddRange(gearboxModelValidationResult.Errors.Select(error => error.ErrorMessage));

                if (!brandNameValidationResult.IsValid)
                    validationErrors.AddRange(brandNameValidationResult.Errors.Select(error => error.ErrorMessage));

                if (validationErrors.Any())
                    return BadRequest(validationErrors);

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
            try
            {
                var validationResult = _guidValidator.Validate(gearboxId);
                if (!validationResult.IsValid)
                {
                    return BadRequest(validationResult.Errors.ConvertAll(error => error.ErrorMessage));
                }

                var result = await _mediator.Send(new GetGearboxByIdQuery(gearboxId));

                return Ok(result);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPut]
        [Route("updateGearboxById")]
        [ProducesResponseType(typeof(Gearbox), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateGearboxById([FromBody] Gearbox gearboxToUpdate)
        {
            try
            {
                //Validation for string an guid inputs.
                var gearboxIdValidationResult = _guidValidator.Validate(gearboxToUpdate.GearboxId);
                var gearboxModelValidationResult = _stringValidator.Validate(gearboxToUpdate.GearboxModel);
                var brandValidationResult = _stringValidator.Validate(gearboxToUpdate.Brand.BrandName);

                var validationErrors = new List<string>();

                if (!gearboxIdValidationResult.IsValid)
                    validationErrors.AddRange(gearboxIdValidationResult.Errors.Select(error => error.ErrorMessage));

                if (!gearboxModelValidationResult.IsValid)
                    validationErrors.AddRange(gearboxModelValidationResult.Errors.Select(error => error.ErrorMessage));

                if (!brandValidationResult.IsValid)
                    validationErrors.AddRange(brandValidationResult.Errors.Select(error => error.ErrorMessage));

                if (validationErrors.Any())
                    return BadRequest(validationErrors);

                Gearbox updatedGearbox = await _mediator.Send(new UpdateGearboxByIdCommand(gearboxToUpdate));

                return Ok(updatedGearbox);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("deleteGearboxById/{gearboxId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteGearboxById(Guid gearboxId)
        {
            var validateGearbox = _guidValidator.Validate(gearboxId);

            if (!validateGearbox.IsValid)
            {
                return BadRequest(validateGearbox.Errors.ConvertAll(errors => errors.ErrorMessage));
            }

            try
            {
                await _mediator.Send(new DeleteGearboxByIdCommand(gearboxId));

                return NoContent();
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
