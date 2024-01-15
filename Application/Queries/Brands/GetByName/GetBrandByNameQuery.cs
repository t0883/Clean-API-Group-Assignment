using Domain.Models.Brands;
using MediatR;

namespace Application.Queries.Brands.GetByName
{
    public class GetBrandByNameQuery : IRequest<Brand>
    {
        public GetBrandByNameQuery(string brandName)
        {

            BrandName = brandName;

        }

        public string BrandName { get; }
    }
}
