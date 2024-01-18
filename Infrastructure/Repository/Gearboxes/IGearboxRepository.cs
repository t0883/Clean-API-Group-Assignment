using Domain.Models.Gearboxes;

namespace Infrastructure.Repository.Gearboxes
{
    public interface IGearboxRepository
    {
        Task<Gearbox> AddGearbox(Gearbox gearbox);
        Task<List<Gearbox>> GetAllGearboxes();
        Task<Gearbox?> GetGearboxById(Guid id);
    }
}
