using Domain.Models.Brands;
using Domain.Models.Gearboxes;

namespace Infrastructure.Repository.Gearboxes
{
    public interface IGearboxRepository
    {
        Task<Gearbox> AddGearbox(Gearbox gearbox);
        Task<List<Gearbox>> GetAllGearboxes();
        Task<Gearbox?> GetGearboxById(Guid id);
        Task<Gearbox> UpdateGearboxById(Gearbox gearboxToUpdate);
        Task<Gearbox> DeleteGearbox(Gearbox gearboxToDelete);
    }
}
