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
                var result = _sqlServer.GearBoxes.Add(gearbox);

                await _sqlServer.SaveChangesAsync();

                return await Task.FromResult(result.Entity);
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
                return await Task.FromResult(await _sqlServer.GearBoxes.ToListAsync());
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
                return await Task.FromResult(await _sqlServer.GearBoxes.Where(g => g.GearboxId == id).FirstOrDefaultAsync());
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }
    }
}
