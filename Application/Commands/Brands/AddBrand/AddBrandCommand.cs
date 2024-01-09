using Application.Dtos;
using Domain.Models.Brands;
using MediatR;

namespace Application.Commands.Brands.AddBrand
{
    public class AddBrandCommand : IRequest<Brand>
    {
        public AddBrandCommand(BrandDto newBrand)
        {
            NewBrand = newBrand;
        }

        public BrandDto NewBrand { get; }
    }
}
