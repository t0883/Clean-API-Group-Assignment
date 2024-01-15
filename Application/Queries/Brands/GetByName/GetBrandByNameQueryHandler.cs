using Domain.Models.Brands;
using Infrastructure.Repository.Brands;
using MediatR;

namespace Application.Queries.Brands.GetByName
{
    public class GetBrandByNameQueryHandler : IRequestHandler<GetBrandByNameQuery, Brand>
    {
        private readonly IBrandRepository _brandRepository;

        public GetBrandByNameQueryHandler(IBrandRepository brandRepository)
        {
            _brandRepository = brandRepository;
        }


        public async Task<Brand> Handle(GetBrandByNameQuery request, CancellationToken cancellationToken)
        {
            return await _brandRepository.GetBrandByName(request.BrandName);
        }
    }
}
