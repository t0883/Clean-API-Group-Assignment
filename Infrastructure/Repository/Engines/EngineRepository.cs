using Domain.Models.Brands;
using Domain.Models.Engines;
using Infrastructure.Database.SqlDatabase;
using Infrastructure.Repository.Engines.Interface;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository.Engines
{
    public class EngineRepository : IEngineRepository
    {
        private readonly SqlServer _sqlServer;

        public EngineRepository(SqlServer sqlServer)
        {
            _sqlServer = sqlServer;
        }

        public async Task<Engine> AddEngine(Engine engine)
        {
            try
            {
                if (engine.Brand == null)
                {
                    throw new ArgumentException("Engine must have a valid Brand");
                }

                Engine engineToCreate = engine;

                Brand? brandToConnect = await _sqlServer.Brands.Where(b => b.BrandName == engine.Brand.BrandName).FirstOrDefaultAsync();

                if (brandToConnect == null)
                {
                    throw new ArgumentException("Specified Brand does not exist");
                }

                engineToCreate.Brand = brandToConnect;

                var result = _sqlServer.Engines.Add(engine);

                await _sqlServer.SaveChangesAsync();

                return await Task.FromResult(result.Entity);

            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Engine> DeleteEngine(Guid EngineId)
        {
            try
            {
                Engine? engineToRemove = await _sqlServer.Engines.Where(b => b.EngineId == EngineId).FirstOrDefaultAsync();

                if (engineToRemove == null)
                {
                    throw new ArgumentException("There is no engine with that Id in the database");
                }

                var result = _sqlServer.Engines.Remove(engineToRemove);

                await _sqlServer.SaveChangesAsync();

                return await Task.FromResult(result.Entity);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<List<Engine>> GetAllEngines()
        {
            try
            {
                return await Task.FromResult(await _sqlServer.Engines.Include(b => b.Brand).ToListAsync());
            }
            catch (Exception ex)
            {

                throw new ArgumentException(ex.Message);
            }
        }

        public async Task<Engine> GetEngineById(Guid EngineId)
        {
            try
            {
                Engine? engine = await _sqlServer.Engines.Include(b => b.Brand).Where(e => e.EngineId == EngineId).FirstOrDefaultAsync();

                if (engine == null)
                {
                    throw new ArgumentException("There is no engine with that Id in the database");
                }

                return await Task.FromResult(engine);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<Engine> UpdateEngine(Engine engineToUpdate)
        {
            try
            {
                Engine? engineInDatabase = await _sqlServer.Engines.Include(b => b.Brand).Where(b => b.EngineId == engineToUpdate.EngineId).FirstOrDefaultAsync();

                if (engineInDatabase == null)
                {
                    throw new ArgumentException("There is no engine with that Id in the database");
                }

                if (engineInDatabase.EngineName != engineToUpdate.EngineName) { engineInDatabase.EngineName = engineToUpdate.EngineName; }

                if (engineInDatabase.EngineFuel != engineToUpdate.EngineFuel) { engineInDatabase.EngineFuel = engineToUpdate.EngineFuel; }

                if (engineInDatabase.HorsePower != engineToUpdate.HorsePower) { engineInDatabase.HorsePower = engineToUpdate.HorsePower; }

                if (engineInDatabase.Brand != engineToUpdate.Brand)
                {
                    Brand? brandToConnect = await _sqlServer.Brands.Where(b => b.BrandName == engineToUpdate.Brand.BrandName).FirstOrDefaultAsync();

                    if (brandToConnect == null)
                    {
                        throw new ArgumentException("There is no Brand with that name in the database");
                    }

                    engineInDatabase.Brand = brandToConnect;
                }

                var result = _sqlServer.Engines.Update(engineInDatabase);

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