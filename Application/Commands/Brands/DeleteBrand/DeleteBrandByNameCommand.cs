using Domain.Models.Brands;
using MediatR;

namespace Application.Commands.Brands.DeleteBrand
{
    public class DeleteBrandByNameCommand : IRequest<Brand>
    {
        public DeleteBrandByNameCommand(string brandName)
        {
            BrandName = brandName;
        }

        public string BrandName { get; }
    }
}
