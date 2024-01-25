using Domain.Models.Brands;

namespace Infrastructure.Repository.Brands
{
    public interface IBrandRepository
    {
        Task<Brand> AddBrand(Brand brand);
        Task<List<Brand>> GetAllBrands();
        Task<Brand> GetBrandByName(string brandName);
        Task<Brand> UpdateBrandById(Brand brandToUpdate);
        Task<Brand> DeleteBrandByName(string brandName);
        Task<bool> IsBrandNameUnique(Brand brand);
    }
}
