﻿using Application.Commands.Tires.AddTire;
using Application.Commands.Tires.DeleteTire;
using Application.Commands.Tires.UpdateTire;
using Application.Dtos;
using Application.Queries.Tires.GetAll;
using Application.Queries.Tires.GetByBrand;
using Application.Queries.Tires.GetById;
using Application.Validator.GuidValidation;
using Application.Validator.StringValidation;
using Domain.Models.Tires;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.TiresController
{
    [Route("api/[controller]")]
    [ApiController]
    public class TiresController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly GuidValidator _guidValidator;
        private readonly StringValidator _stringValidator;

        public TiresController(IMediator mediator, GuidValidator guidValidator, StringValidator stringValidator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _guidValidator = guidValidator ?? throw new ArgumentNullException(nameof(guidValidator));
            _stringValidator = stringValidator ?? throw new ArgumentNullException(nameof(stringValidator));
        }

        [HttpPost]
        [Route("addNewTire")]
        public async Task<IActionResult> AddTire([FromBody] TireDto tire)
        {
            try
            {

                var validatedTireModel = _stringValidator.Validate(tire.TireModel);
                var validatedBrand = _stringValidator.Validate(tire.Brand.BrandName);

                if (!validatedTireModel.IsValid || !validatedBrand.IsValid)
                {
                    var errors = validatedTireModel.Errors.Concat(validatedBrand.Errors).Select(error => error.ErrorMessage);
                    return BadRequest(errors);
                }

                return Ok(await _mediator.Send(new AddTireCommand(tire)));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("getAllTires")]
        public async Task<IActionResult> GetAllTires()
        {
            try
            {
                return Ok(await _mediator.Send(new GetAllTiresQuery()));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("getTireById/{tireId}")]
        public async Task<IActionResult> GetTireById(Guid tireId)
        {
            try
            {
                var validatedTireId = _guidValidator.Validate(tireId);

                if (!validatedTireId.IsValid)
                {
                    return BadRequest(validatedTireId.Errors.ConvertAll(errors => errors.ErrorMessage));
                }

                return Ok(await _mediator.Send(new GetTireByIdQuery(tireId)));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpGet]
        [Route("getTireByBrand/{brandName}")]
        public async Task<IActionResult> GetTireByBrand(string brandName)
        {
            try
            {
                var validatedBrand = _stringValidator.Validate(brandName);

                if (!validatedBrand.IsValid)
                {
                    return BadRequest(validatedBrand.Errors.ConvertAll(errors => errors.ErrorMessage));
                }

                return Ok(await _mediator.Send(new GetTireByBrandQuery(brandName)));

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }

        [HttpPut]
        [Route("updateTireById")]
        public async Task<IActionResult> UpdateTireById([FromBody] Tire tireToUpdate)
        {
            try
            {
                var validatedTireId = _guidValidator.Validate(tireToUpdate.TireId);

                if (!validatedTireId.IsValid)
                {
                    return BadRequest(validatedTireId.Errors.ConvertAll(errors => errors.ErrorMessage));
                }

                return Ok(await _mediator.Send(new UpdateTireByIdCommand(tireToUpdate)));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("deleteTireById/{tireId}")]
        public async Task<IActionResult> DeleteTireById(Guid tireId)
        {
            try
            {
                var validatedTireId = _guidValidator.Validate(tireId);

                if (!validatedTireId.IsValid)
                {
                    return BadRequest(validatedTireId.Errors.ConvertAll(errors => errors.ErrorMessage));
                }

                await _mediator.Send(new DeleteTireByIdCommand(tireId));

                return NoContent();

            }
            catch (Exception)
            {
                return NoContent();
            }
        }
    }
}
