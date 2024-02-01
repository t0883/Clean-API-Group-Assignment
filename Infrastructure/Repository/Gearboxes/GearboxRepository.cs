using Domain.Models.Brands;
using Domain.Models.Gearboxes;
using Infrastructure.Database.SqlDatabase;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository.Gearboxes
{
    public class GearboxRepository : IGearboxRepository
    {
        private readonly SqlServer _sqlServer;
        public GearboxRepository(SqlServer sqlServer)
        {
            _sqlServer = sqlServer;
        }

        public async Task<Gearbox> AddGearbox(Gearbox gearbox)
        {
            try
            {
                Gearbox gearboxToCreate = gearbox;

                Brand brandToConnect = await _sqlServer.Brands.Where(b => b.BrandName == gearbox.Brand.BrandName).FirstOrDefaultAsync();

                if (brandToConnect == null)
                {
                    throw new ArgumentException($"Specified Brand {gearbox.Brand.BrandName} does not exist.");
                }

                gearboxToCreate.Brand = brandToConnect;

                var reslut = _sqlServer.GearBoxes.Add(gearboxToCreate);

                await _sqlServer.SaveChangesAsync();

                return await Task.FromResult(reslut.Entity);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<Gearbox>> GetAllGearboxes()
        {
            try
            {
                return await Task.FromResult(await _sqlServer.GearBoxes.Include(g => g.Brand).ToListAsync());
            }
            catch (Exception ex)
            {

                throw new ArgumentException(ex.Message);
            }
        }

        public async Task<Gearbox?> GetGearboxById(Guid id)
        {
            try
            {
                Gearbox? gearbox = await _sqlServer.GearBoxes.Include(g => g.Brand).Where(b => b.GearboxId == id).FirstOrDefaultAsync();

                if (gearbox == null)
                {
                    throw new ArgumentException($"{id} does not exist in the database.");
                }

                return await Task.FromResult(gearbox);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Gearbox> UpdateGearboxById(Gearbox gearboxToUpdate)
        {
            try
            {
                Gearbox? existingGearbox = await _sqlServer.GearBoxes.Where(g => g.GearboxId == gearboxToUpdate.GearboxId).FirstOrDefaultAsync();
                if (existingGearbox == null)
                {
                    throw new ArgumentException($"Gearbox with Id {existingGearbox.GearboxId} does not exist in the database.");
                }

                existingGearbox.GearboxModel = gearboxToUpdate.GearboxModel;
                existingGearbox.Brand = gearboxToUpdate.Brand;
                existingGearbox.SixGears = gearboxToUpdate.SixGears;

                await _sqlServer.SaveChangesAsync();

                return await Task.FromResult(existingGearbox);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public async Task<Gearbox> DeleteGearbox(Guid gearboxId)
        {
            try
            {
                Gearbox? gearboxToRemove = await _sqlServer.GearBoxes.Where(g => g.GearboxId == gearboxId).FirstOrDefaultAsync();

                if (gearboxToRemove == null)
                {
                    throw new ArgumentException($"There is no gearbox with Id {gearboxId} in the database");
                }

                var result = _sqlServer.GearBoxes.Remove(gearboxToRemove);

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
