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
    }
}
