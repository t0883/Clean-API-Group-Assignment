﻿using Domain.Models.Engines;
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
                var result = _sqlServer.Engines.Add(engine);

                await _sqlServer.SaveChangesAsync();

                return await Task.FromResult(result.Entity);

            }
            catch (Exception)
            {
                throw new ArgumentException($"An error occured while adding {engine.EngineFuel}. Please check if {engine.EngineFuel} doesnt already exist in the database.");
            }
        }

        public async Task<Engine> DeleteEngine(string engineFuel, int horsePower)
        {
            try
            {
                Engine engineToRemove = await _sqlServer.Engines.Where(b => b.EngineFuel == engineFuel && b.HorsePower == horsePower).FirstOrDefaultAsync();

                var result = _sqlServer.Engines.Remove(engineToRemove);

                await _sqlServer.SaveChangesAsync();

                return await Task.FromResult(result.Entity);
            }
            catch (Exception ex)
            {

                throw new ArgumentException(ex.Message);
            }
        }

        public async Task<List<Engine>> GetAllEngines()
        {
            try
            {
                return await Task.FromResult(await _sqlServer.Engines.ToListAsync());
            }
            catch (Exception ex)
            {

                throw new ArgumentException(ex.Message);
            }
        }

        public async Task<Engine> GetEngineById(string EngineFuel, int HorsePower)
        {
            try
            {
                return await Task.FromResult(await _sqlServer.Engines.Where(b => b.EngineFuel == EngineFuel && b.HorsePower == HorsePower).FirstOrDefaultAsync());
            }
            catch (Exception ex)
            {

                throw new ArgumentException(ex.Message);
            }
        }

        public async Task<Engine> UpdateEngine(Engine engineToUpdate)
        {
            try
            {
                Engine engineInDatabase = await _sqlServer.Engines.Where(b => b.EngineId == engineToUpdate.EngineId).FirstOrDefaultAsync();

                if (engineInDatabase.EngineFuel != engineToUpdate.EngineFuel) { engineInDatabase.EngineFuel = engineToUpdate.EngineFuel; }

                if (engineInDatabase.HorsePower != engineToUpdate.HorsePower) { engineInDatabase.HorsePower = engineToUpdate.HorsePower; }

                var result = _sqlServer.Engines.Update(engineInDatabase);

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