using Domain.Models.Brands;
using MediatR;

namespace Application.Commands.Brands.UpdateBrand
{
    public class UpdateBrandByIdCommand : IRequest<Brand>
    {
        public UpdateBrandByIdCommand(Brand brandToUpdate)
        {
            BrandName = brandToUpdate.BrandName;
            Id = brandToUpdate.BrandId;
        }

        public string BrandName { get; }
        public Guid Id { get; }
    }
}
