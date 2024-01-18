using MediatR;
using System.Collections.Generic;
using Domain.Models.Tires;

namespace Application.Queries.Tires.GetByBrand
{
    public class GetTireByBrandQuery : IRequest<List<Tire>>
    {
        public GetTireByBrandQuery(string brandName)
        {
            BrandName = brandName;
        }

        public string BrandName { get; }
    }
}
