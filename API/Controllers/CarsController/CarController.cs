using Application.Commands.Cars.AddCar;
using Application.Dtos;
using Application.Queries.Cars.GetAll;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.CarsController
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        internal readonly IMediator _mediator;

        public CarController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Route("addNewCar")]
        public async Task<IActionResult> AddCar([FromBody] CarDto car)
        {
            try
            {
                return Ok(await _mediator.Send(new AddCarCommand(car)));

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("getAllCars")]
        public async Task<IActionResult> GetAllCars()
        {
            try
            {
                return Ok(await _mediator.Send(new GetAllCarsQuery()));
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }


    }

}
