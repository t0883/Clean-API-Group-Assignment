using Application.Commands.Brands.AddBrand;
using Application.Commands.Brands.DeleteBrand;
using Application.Commands.Brands.UpdateBrand;
using Application.Dtos;
using Application.Queries.Brands.GetAll;
using Application.Queries.Brands.GetByName;
using Application.Validator.GuidValidation;
using Application.Validator.StringValidation;
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
        internal readonly GuidValidator _guidValidator;
        internal readonly StringValidator _stringValidator;
        public BrandsController(IMediator mediator, GuidValidator guidValidator, StringValidator stringValidator)
        {
            _mediator = mediator;
            _guidValidator = guidValidator;
            _stringValidator = stringValidator;
        }

        [HttpPost]
        [Route("addNewBrand")]
        public async Task<IActionResult> AddBrand([FromBody] BrandDto brand)
        {
            var validatedBrand = _stringValidator.Validate(brand.BrandName);

            if (!validatedBrand.IsValid)
            {
                return BadRequest(validatedBrand.Errors.ConvertAll(errors => errors.ErrorMessage));
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
            try
            {
                var validatedBrand = _guidValidator.Validate(brandToUpdate.BrandId);

                if (!validatedBrand.IsValid)
                {
                    return BadRequest(validatedBrand.Errors.ConvertAll(errors => errors.ErrorMessage));
                }

                return Ok(await _mediator.Send(new UpdateBrandByIdCommand(brandToUpdate)));
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        [HttpDelete]
        [Route("deleteBrandByName/{brandName}")]
        public async Task<IActionResult> DeleteBrandByName(string brandName)
        {
            await _mediator.Send(new DeleteBrandByNameCommand(brandName));

            return NoContent();
        }
    }
}
