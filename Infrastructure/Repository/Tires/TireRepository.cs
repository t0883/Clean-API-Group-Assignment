using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
                var result = _sqlServer.Tires.Add(tire);

                await _sqlServer.SaveChangesAsync();

                return await Task.FromResult(result.Entity);
            }
            catch (Exception)
            {
                throw new ArgumentException($"An error occurred while adding tire with ID {tire.TireId}. Please check if the tire with ID {tire.TireId} doesn't already exist in the database.");
            }
        }

        public async Task<Tire> DeleteTireById(Guid tireId)
        {
            try
            {
                Tire tireToRemove = await _sqlServer.Tires.Where(t => t.TireId == tireId).FirstOrDefaultAsync();

                var result = _sqlServer.Tires.Remove(tireToRemove);

                await _sqlServer.SaveChangesAsync();

                return await Task.FromResult(result.Entity);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public async Task<List<Tire>> GetAllTires()
        {
            try
            {
                return await Task.FromResult(await _sqlServer.Tires.ToListAsync());
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public async Task<Tire> GetTireById(Guid tireId)
        {
            try
            {
                return await Task.FromResult(await _sqlServer.Tires.Where(t => t.TireId == tireId).FirstOrDefaultAsync());
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public async Task<List<Tire>> GetTireByBrand(string brandName)
        {
            try
            {
                return await Task.FromResult(await _sqlServer.Tires.Where(t => t.Brand.BrandName == brandName).ToListAsync());
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public async Task<Tire> UpdateTire(Tire tireToUpdate)
        {
            try
            {
                Tire tireInDatabase = await _sqlServer.Tires.Where(t => t.TireId == tireToUpdate.TireId).FirstOrDefaultAsync();

                if (tireInDatabase.TireModel != tireToUpdate.TireModel) { tireInDatabase.TireModel = tireToUpdate.TireModel; }

                // Lägg till uppdatering för andra egenskaper här om det behövs

                var result = _sqlServer.Tires.Update(tireInDatabase);

                await _sqlServer.SaveChangesAsync();

                return await Task.FromResult(result.Entity);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }
    }
}
