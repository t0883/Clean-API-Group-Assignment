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
                bool isBrandNameUnique = await IsBrandNameUnique(brand);

                if (!isBrandNameUnique)
                {
                    throw new ArgumentException($"Brand with {brand.BrandName} does already exist in the database");
                }

                var result = _sqlServer.Brands.Add(brand);

                await _sqlServer.SaveChangesAsync();

                return await Task.FromResult(result.Entity);

            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Brand> DeleteBrandByName(string brandName)
        {
            try
            {
                Brand? brandToRemove = await _sqlServer.Brands.Where(b => b.BrandName == brandName).FirstOrDefaultAsync();

                if (brandToRemove == null)
                {
                    throw new ArgumentException($"{brandName} does not exist");
                }

                var result = _sqlServer.Brands.Remove(brandToRemove);

                await _sqlServer.SaveChangesAsync();

                return await Task.FromResult(result.Entity);
            }
            catch (Exception)
            {

                throw;
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
                Brand? brand = await _sqlServer.Brands.Where(b => b.BrandName == brandName).FirstOrDefaultAsync();

                if (brand == null)
                {
                    throw new ArgumentException($"{brandName} does not exist in the database");
                }

                return await Task.FromResult(brand);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<bool> IsBrandNameUnique(Brand brand)
        {
            try
            {
                return !await _sqlServer.Brands.AnyAsync(b => b.BrandName == brand.BrandName);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Brand> UpdateBrandById(Brand brandToUpdate)
        {
            try
            {
                Brand? brandInDatabase = await _sqlServer.Brands.Where(b => b.BrandId == brandToUpdate.BrandId).FirstOrDefaultAsync();

                if (brandInDatabase == null)
                {
                    throw new ArgumentException($"Brand with Id {brandToUpdate.BrandId} does not exist in the database");
                }

                if (brandInDatabase.BrandName != brandToUpdate.BrandName) { brandInDatabase.BrandName = brandToUpdate.BrandName; }

                var result = _sqlServer.Brands.Update(brandInDatabase);

                _sqlServer.SaveChanges();

                return await Task.FromResult(result.Entity);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
