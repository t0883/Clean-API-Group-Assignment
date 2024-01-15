using Domain.Models.Brands;

namespace Infrastructure.Repository.Brands
{
    public interface IBrandRepository
    {
        Task<Brand> AddBrand(Brand brand);
        Task<List<Brand>> GetAllBrands();
        Task<Brand> GetBrandByName(string brandName);
    }
}
