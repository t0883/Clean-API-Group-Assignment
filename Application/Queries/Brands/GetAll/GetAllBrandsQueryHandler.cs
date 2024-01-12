using Domain.Models.Brands;
using Infrastructure.Repository.Brands;
using MediatR;

namespace Application.Queries.Brands.GetAll
{
    public class GetAllBrandsQueryHandler : IRequestHandler<GetAllBrandsQuery, List<Brand>>
    {
        private readonly IBrandRepository _brandRepository;

        public GetAllBrandsQueryHandler(IBrandRepository brandRepository)
        {
            _brandRepository = brandRepository;
        }

        public async Task<List<Brand>> Handle(GetAllBrandsQuery request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(await _brandRepository.GetAllBrands());
        }
    }
}
