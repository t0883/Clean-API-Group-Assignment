using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.SeatsController
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeatsController : ControllerBase
    {
        internal readonly IMediator _mediator;
        public SeatsController(IMediator mediator)
        {
            _mediator = mediator;
        }
    }
}
