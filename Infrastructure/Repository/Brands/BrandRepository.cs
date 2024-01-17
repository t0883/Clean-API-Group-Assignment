using Domain.Models.Brands;
using Infrastructure.Database.SqlDatabase;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository.Brands
{
    public class BrandRepository : IBrandRepository
    {
        private readonly SqlServer _sqlServer;
        public BrandRepository(SqlServer sqlServer)
        {
            _sqlServer = sqlServer;
        }

        public async Task<Brand> AddBrand(Brand brand)
        {
            try
            {
                var result = _sqlServer.Brands.Add(brand);

                await _sqlServer.SaveChangesAsync();

                return await Task.FromResult(result.Entity);

            }
            catch (Exception)
            {
                throw new ArgumentException($"An error occured while adding {brand.BrandName}. Please check if {brand.BrandName} doesnt already exist in the database.");
            }
        }

        public async Task<Brand> DeleteBrandByName(string brandName)
        {
            try
            {
                Brand brandToRemove = await _sqlServer.Brands.Where(b => b.BrandName == brandName).FirstOrDefaultAsync();

                var result = _sqlServer.Brands.Remove(brandToRemove);

                await _sqlServer.SaveChangesAsync();

                return await Task.FromResult(result.Entity);
            }
            catch (Exception ex)
            {

                throw new ArgumentException(ex.Message);
            }
        }

        public async Task<List<Brand>> GetAllBrands()
        {
            try
            {
                return await Task.FromResult(await _sqlServer.Brands.ToListAsync());
            }
            catch (Exception ex)
            {

                throw new ArgumentException(ex.Message);
            }
        }

        public async Task<Brand> GetBrandByName(string brandName)
        {
            try
            {
                return await Task.FromResult(await _sqlServer.Brands.Where(b => b.BrandName == brandName).FirstOrDefaultAsync());
            }
            catch (Exception ex)
            {

                throw new ArgumentException(ex.Message);
            }
        }

        public async Task<Brand> UpdateBrandById(Brand brandToUpdate)
        {
            try
            {
                Brand brandInDatabase = await _sqlServer.Brands.Where(b => b.BrandId == brandToUpdate.BrandId).FirstOrDefaultAsync();

                if (brandInDatabase.BrandName != brandToUpdate.BrandName) { brandInDatabase.BrandName = brandToUpdate.BrandName; }

                var result = _sqlServer.Brands.Update(brandInDatabase);

                _sqlServer.SaveChanges();

                return await Task.FromResult(result.Entity);
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
