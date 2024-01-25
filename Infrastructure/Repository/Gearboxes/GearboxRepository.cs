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
                if (gearbox.Brand == null)
                {
                    throw new ArgumentException("Gearbox must have a valid Brand.");
                }

                Gearbox gearboxToCreate = gearbox;

                Brand brandToConnect = await _sqlServer.Brands.Where(b => b.BrandName == gearbox.Brand.BrandName).FirstOrDefaultAsync();

                if (brandToConnect == null)
                {
                    throw new ArgumentException("Specified Brand does not exist.");
                }

                gearboxToCreate.Brand = brandToConnect;

                var reslut = _sqlServer.GearBoxes.Add(gearboxToCreate);

                await _sqlServer.SaveChangesAsync();

                return await Task.FromResult(reslut.Entity);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
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
                return await Task.FromResult(await _sqlServer.GearBoxes.Include(g => g.Brand).Where(g => g.GearboxId == id).FirstOrDefaultAsync());
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public async Task<Gearbox> UpdateGearboxById(Gearbox gearbox)
        {
            try
            {
                Gearbox existingGearbox = await _sqlServer.GearBoxes
                    .Where(g => g.GearboxId == gearbox.GearboxId)
                    .FirstOrDefaultAsync() ?? throw new ArgumentException("Gearbox not found.");

                existingGearbox.GearboxModel = gearbox.GearboxModel;
                existingGearbox.Brand = gearbox.Brand;
                existingGearbox.SixGears = gearbox.SixGears;

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
            //_sqlServer.GearBoxes.Remove(gearbox);
            //await _sqlServer.SaveChangesAsync();
            //return gearbox;

            try
            {
                Gearbox? gearboxToRemove = await _sqlServer.GearBoxes.Where(g => g.GearboxId == gearboxId).FirstOrDefaultAsync();

                if (gearboxToRemove == null)
                {
                    throw new ArgumentException("There is no engine with that Id in the database");
                }

                var result = _sqlServer.GearBoxes.Remove(gearboxToRemove);

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
