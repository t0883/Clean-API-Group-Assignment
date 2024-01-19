using Domain.Models.Brands;
using Infrastructure.Repository.Brands;
using MediatR;

namespace Application.Commands.Brands.DeleteBrand
{
    public class DeleteBrandByNameCommandHandler : IRequestHandler<DeleteBrandByNameCommand, Brand>
    {
        private readonly IBrandRepository _brandRepository;

        public DeleteBrandByNameCommandHandler(IBrandRepository brandRepository)
        {
            _brandRepository = brandRepository;
        }


        public async Task<Brand> Handle(DeleteBrandByNameCommand request, CancellationToken cancellationToken)
        {
            var result = await _brandRepository.DeleteBrandByName(request.BrandName);

            return await Task.FromResult(result);
        }
    }
}
