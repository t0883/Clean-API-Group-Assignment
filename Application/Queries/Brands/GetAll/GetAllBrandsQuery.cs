using Domain.Models.Brands;
using MediatR;

namespace Application.Queries.Brands.GetAll
{
    public class GetAllBrandsQuery : IRequest<List<Brand>>
    {
    }
}
