using Application.Commands.Engines.AddEngine;
using Application.Commands.Engines.DeleteEngine;
using Application.Commands.Engines.UpdateEngine;
using Application.Dtos;
using Domain.Models.Engines;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Application.Commands.Engines.Queries.GetAll;
using Application.Commands.Engines.QuerieEngine.GetByIdEngine;
using Application.Validator.GuidValidation;
using Application.Validator.StringValidation;
using Application.Validator.IntValidation;
using FluentValidation;

namespace API.Controllers.EnginesController
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnginesController : ControllerBase
    {
        internal readonly IMediator _mediator;
        internal readonly GuidValidator _guidValidator;
        internal readonly StringValidator _stringValidator;
        internal readonly IntValidator _intValidator;

        public EnginesController(IMediator mediator, GuidValidator guidValidator, StringValidator stringValidator, IntValidator intValidator)
        {
            _mediator = mediator;
            _guidValidator = guidValidator;
            _stringValidator = stringValidator;
            _intValidator = intValidator;
        }
        [HttpPost]
        [Route("addNewEngine")]
        public async Task<IActionResult> AddEngine([FromBody] EngineDto engine)
        {
            var validatedEngineName = _stringValidator.Validate(engine.EngineName);
            if (!validatedEngineName.IsValid)
            {
                return BadRequest(validatedEngineName.Errors.ConvertAll(errors => errors.ErrorMessage));
            }
            var validatedHorsePower = _intValidator.Validate(engine.HorsePower);
            if (!validatedHorsePower.IsValid)
            {
                return BadRequest(validatedHorsePower.Errors.ConvertAll(errors => errors.ErrorMessage));
            }
            return Ok(await _mediator.Send(new AddEngineCommand(engine)));
        }
        [HttpGet]
        [Route("getAllEngine")]
        public async Task<IActionResult> GetAllEngines()
        {
            return Ok(await _mediator.Send(new GetAllEngineQuery()));
        }
        [HttpGet]
        [Route("getEngineById")]
        public async Task<IActionResult> GetEngineById(Guid engineId)
        {
            var validatedEngineId = _guidValidator.Validate(engineId);

            if (!validatedEngineId.IsValid)
            {
                return BadRequest(validatedEngineId.Errors.Select(error => error.ErrorMessage));
            }
            return Ok(await _mediator.Send(new GetEngineByIdQuery(engineId)));
        }
        [HttpPut]
        [Route("updateEngine")]
        public async Task<IActionResult> UpdateEngine([FromBody] Engine engineToUpdate)
        {
            try
            {
                var validatedEngineId = _guidValidator.Validate(engineToUpdate.EngineId);
                if (!validatedEngineId.IsValid)
                {
                    return BadRequest(validatedEngineId.Errors.ConvertAll(errors => errors.ErrorMessage));
                }
                var validatedHorsePower = _intValidator.Validate(engineToUpdate.HorsePower);
                if (!validatedHorsePower.IsValid)
                {
                    return BadRequest(validatedHorsePower.Errors.ConvertAll(errors => errors.ErrorMessage));
                }
                return Ok(await _mediator.Send(new UpdateEngineCommand(engineToUpdate)));
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }
        [HttpDelete]
        [Route("deleteEngine")]
        public async Task<IActionResult> DeleteEngine(Guid engineId)
        {
            var validatedEngineId = _guidValidator.Validate(engineId);
            if (!validatedEngineId.IsValid)
            {
                return BadRequest(validatedEngineId.Errors.Select(error => error.ErrorMessage));
            }
            await _mediator.Send(new DeleteEngineCommand(engineId));
            return NoContent();
        }
    }
}
