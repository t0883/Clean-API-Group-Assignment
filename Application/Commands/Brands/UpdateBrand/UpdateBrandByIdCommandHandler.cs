using Domain.Models.Brands;
using Infrastructure.Repository.Brands;
using MediatR;

namespace Application.Commands.Brands.UpdateBrand
{
    public class UpdateBrandByIdCommandHandler : IRequestHandler<UpdateBrandByIdCommand, Brand>
    {
        private readonly IBrandRepository _brandRepository;
        public UpdateBrandByIdCommandHandler(IBrandRepository brandRepository)
        {
            _brandRepository = brandRepository;
        }

        public async Task<Brand> Handle(UpdateBrandByIdCommand request, CancellationToken cancellationToken)
        {
            Brand brandToUpdate = new Brand { BrandId = request.Id, BrandName = request.BrandName };

            var result = await _brandRepository.UpdateBrandById(brandToUpdate);

            return await Task.FromResult(result);
        }
    }
}
