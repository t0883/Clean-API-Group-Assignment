using Application.Commands.Brands.AddBrand;
using Application.Commands.Brands.UpdateBrand;
using Application.Dtos;
using Application.Queries.Brands.GetAll;
using Application.Queries.Brands.GetByName;
using Domain.Models.Brands;
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

        [HttpGet]
        [Route("getAllBrands")]
        public async Task<IActionResult> GetAllBrands()
        {
            return Ok(await _mediator.Send(new GetAllBrandsQuery()));
        }

        [HttpGet]
        [Route("getBrandByName/{brandName}")]
        public async Task<IActionResult> GetBrandByName(string brandName)
        {
            return Ok(await _mediator.Send(new GetBrandByNameQuery(brandName)));
        }

        [HttpPut]
        [Route("updateBrandById")]
        public async Task<IActionResult> UpdateBrandById([FromBody] Brand brandToUpdate)
        {
            return Ok(await _mediator.Send(new UpdateBrandByIdCommand(brandToUpdate)));
        }
    }
}
