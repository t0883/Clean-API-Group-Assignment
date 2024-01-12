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
    }
}
