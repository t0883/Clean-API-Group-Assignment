using Domain.Models.Brands;
using Infrastructure.Repository.Brands;
using MediatR;

namespace Application.Commands.Brands.AddBrand
{
    public class AddBrandCommandHandler : IRequestHandler<AddBrandCommand, Brand>
    {

        private readonly IBrandRepository _brandRepository;
        public AddBrandCommandHandler(IBrandRepository brandRepository)
        {
            _brandRepository = brandRepository;
        }

        public async Task<Brand> Handle(AddBrandCommand request, CancellationToken cancellationToken)
        {
            Brand brandToCreate = new Brand { BrandId = new Guid(), BrandName = request.NewBrand.BrandName };

            var result = await _brandRepository.AddBrand(brandToCreate);

            return await Task.FromResult(result);

        }
    }
}
