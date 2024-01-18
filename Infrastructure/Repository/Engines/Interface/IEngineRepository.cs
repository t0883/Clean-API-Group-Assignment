using Domain.Models.Engines;

namespace Infrastructure.Repository.Engines.Interface
{
    public interface IEngineRepository
    {
        Task<Engine> AddEngine(Engine engine);
        Task<List<Engine>> GetAllEngines();
        Task<Engine> GetEngineById(string EngineName, string EngineFuel, int HorsePower);
        Task<Engine> UpdateEngine(Engine brandToUpdate);
        Task<Engine> DeleteEngine(string engineName, string engineFuel, int horsePower);

    }
}