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
            try
            {

                var validatedBrand = _stringValidator.Validate(brand.BrandName);

                if (!validatedBrand.IsValid)
                {
                    return BadRequest(validatedBrand.Errors.ConvertAll(errors => errors.ErrorMessage));
                }

                return Ok(await _mediator.Send(new AddBrandCommand(brand)));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpGet]
        [Route("getAllBrands")]
        public async Task<IActionResult> GetAllBrands()
        {
            try
            {
                List<Brand> brands = await _mediator.Send(new GetAllBrandsQuery());

                if (brands == null)
                {
                    throw new Exception("An error occured while getting brands from database");
                }

                return Ok(brands);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpGet]
        [Route("getBrandByName/{brandName}")]
        public async Task<IActionResult> GetBrandByName(string brandName)
        {
            try
            {
                Brand brand = await _mediator.Send(new GetBrandByNameQuery(brandName));

                if (brand == null)
                {
                    throw new Exception("There is no brand with that name in the database");
                }

                return Ok(brand);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }

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

                Brand updatedBrand = await _mediator.Send(new UpdateBrandByIdCommand(brandToUpdate));

                return Ok(updatedBrand);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("deleteBrandByName/{brandName}")]
        public async Task<IActionResult> DeleteBrandByName(string brandName)
        {
            try
            {
                await _mediator.Send(new DeleteBrandByNameCommand(brandName));

                return NoContent();
            }
            catch (Exception)
            {
                return NoContent();
            }

        }
    }
}
