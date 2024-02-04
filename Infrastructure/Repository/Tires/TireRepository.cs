using Domain.Models.Brands;
using Domain.Models.Tires;
using Infrastructure.Database.SqlDatabase;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository.Tires
{
    public class TireRepository : ITireRepository
    {
        private readonly SqlServer _sqlServer;

        public TireRepository(SqlServer sqlServer)
        {
            _sqlServer = sqlServer ?? throw new ArgumentNullException(nameof(sqlServer));
        }

        public async Task<Tire> AddTire(Tire tire)
        {
            try
            {
                Tire tireToCreate = tire;

                Brand? brandToConnect = await _sqlServer.Brands.Where(b => b.BrandName == tire.Brand.BrandName).FirstOrDefaultAsync();

                if (brandToConnect == null)
                {
                    throw new Exception("There is no Brand with that name in the database.");
                }

                tireToCreate.Brand = brandToConnect;

                var result = _sqlServer.Tires.Add(tire);

                await _sqlServer.SaveChangesAsync();

                return await Task.FromResult(result.Entity);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Tire> DeleteTireById(Guid tireId)
        {
            try
            {
                Tire? tireToRemove = await _sqlServer.Tires.Where(t => t.TireId == tireId).FirstOrDefaultAsync();

                if (tireToRemove == null)
                {
                    throw new Exception("There is no tire with that Id in the database.");
                }

                var result = _sqlServer.Tires.Remove(tireToRemove);

                await _sqlServer.SaveChangesAsync();

                return await Task.FromResult(result.Entity);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<Tire>> GetAllTires()
        {
            try
            {
                var result = await _sqlServer.Tires.Include(t => t.Brand).ToListAsync();

                if (result == null)
                {
                    throw new Exception("There are no tires in the database.");
                }

                return await Task.FromResult(result);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Tire> GetTireById(Guid tireId)
        {
            try
            {
                var result = await _sqlServer.Tires.Include(t => t.Brand).Where(t => t.TireId == tireId).FirstOrDefaultAsync();

                if (result == null)
                {
                    throw new Exception("There is no tire with that Id in the database.");
                }

                return await Task.FromResult(result);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<Tire>> GetTireByBrand(string brandName)
        {
            try
            {
                var result = await _sqlServer.Tires.Include(t => t.Brand).Where(t => t.Brand.BrandName == brandName).ToListAsync();

                if (result.Count == 0)
                {
                    throw new Exception("There is no tires with that brand in the database.");
                }

                return await Task.FromResult(result);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Tire> UpdateTire(Tire tireToUpdate)
        {
            try
            {
                Tire? tireInDatabase = await _sqlServer.Tires.Where(t => t.TireId == tireToUpdate.TireId).FirstOrDefaultAsync();

                if (tireInDatabase == null)
                {
                    throw new Exception("There is no tire with that Id in the database");
                }

                if (tireInDatabase.TireModel != tireToUpdate.TireModel) { tireInDatabase.TireModel = tireToUpdate.TireModel; }

                // Lägg till uppdatering för andra egenskaper här om det behövs

                var result = _sqlServer.Tires.Update(tireInDatabase);

                await _sqlServer.SaveChangesAsync();

                return await Task.FromResult(result.Entity);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
