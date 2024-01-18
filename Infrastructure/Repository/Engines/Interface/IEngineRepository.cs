using Domain.Models.Engines;

namespace Infrastructure.Repository.Engines.Interface
{
    public interface IEngineRepository
    {
        Task<Engine> AddEngine(Engine engine);
        Task<List<Engine>> GetAllEngines();
        Task<Engine> GetEngineById(Guid EngineId);
        Task<Engine> UpdateEngine(Engine brandToUpdate);
        Task<Engine> DeleteEngine(Guid EngineId);

    }
}