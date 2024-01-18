using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Models.Tires;

namespace Infrastructure.Repository.Tires
{
    public interface ITireRepository
    {
        Task<Tire> AddTire(Tire tire);
        Task<List<Tire>> GetAllTires();
        Task<Tire> GetTireById(Guid tireId);
        Task<List<Tire>> GetTireByBrand(string brandName);
        Task<Tire> UpdateTire(Tire tireToUpdate);
        Task<Tire> DeleteTireById(Guid tireId);
    }
}
