using Domain.Models.Seats;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository.Seats
{
    public interface ISeatRepository
    {
        Task<Seat> AddSeat(Seat seat);
        Task<List<Seat>> GetAllSeats();
        Task<Seat> GetSeatById(Guid SeatId);
        Task<List<Seat>> GetSeatByName(string Name);
        Task<Seat> UpdateSeat(Seat SeatToUpdate);
        Task<Seat> DeleteSeatById(Guid SeatId);
    }
}
