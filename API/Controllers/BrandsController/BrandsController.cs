using Application.Commands.Brands.AddBrand;
using Application.Dtos;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.BrandsController
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : ControllerBase
    {
        internal readonly IMediator _mediator;
        public BrandsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Route("addNewBrand")]
        public async Task<IActionResult> AddBrand([FromBody] BrandDto brand)
        {
            if (brand == null || brand.BrandName == "string")
            {
                return BadRequest();
            }

            return Ok(await _mediator.Send(new AddBrandCommand(brand)));
        }
    }
}
