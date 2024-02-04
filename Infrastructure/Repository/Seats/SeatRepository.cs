using Domain.Models.Seats;
using Infrastructure.Database.SqlDatabase;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository.Seats
{
    public class SeatRepository : ISeatRepository
    {
        private readonly SqlServer _sqlServer;

        public SeatRepository(SqlServer sqlServer)
        {
            _sqlServer = sqlServer ?? throw new ArgumentNullException(nameof(sqlServer));
        }

        public async Task<Seat> AddSeat(Seat seat)
        {
            try
            {
                var result = _sqlServer.Seats.Add(seat);

                await _sqlServer.SaveChangesAsync();

                return await Task.FromResult(result.Entity);
            }
            catch (Exception)
            {
                throw new ArgumentException($"An error occurred while adding seat with ID {seat.SeatId}. Please check if the seat with ID {seat.SeatId} doesn't already exist in the database.");
            }
        }

        public async Task<Seat> DeleteSeatById(Guid seatId)
        {
            try
            {
                Seat? seatToRemove = await _sqlServer.Seats.Where(t => t.SeatId == seatId).FirstOrDefaultAsync();

                if (seatToRemove == null)
                {
                    throw new Exception($"The is no seat with Id {seatId} in the database.");
                }

                var result = _sqlServer.Seats.Remove(seatToRemove);

                await _sqlServer.SaveChangesAsync();

                return await Task.FromResult(result.Entity);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<Seat>> GetAllSeats()
        {
            try
            {
                return await Task.FromResult(await _sqlServer.Seats.Include(b => b.Brand).ToListAsync());
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public async Task<Seat> GetSeatById(Guid seatId)
        {
            try
            {
                Seat? result = await _sqlServer.Seats.Include(b => b.Brand).Where(t => t.SeatId == seatId).FirstOrDefaultAsync();
                if (result == null)
                {
                    throw new Exception($"There is no seat with Id {seatId} in the database.");
                }

                return await Task.FromResult(result);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<List<Seat>> GetSeatByName(string seatName)
        {
            try
            {
                var result = await _sqlServer.Seats.Where(t => t.SeatName == seatName).ToListAsync();

                if (result == null)
                {
                    throw new Exception($"There are no seats with seatname {seatName} in the database");
                }


                return await Task.FromResult(result);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Seat> UpdateSeat(Seat seatToUpdate)
        {
            try
            {
                Seat? seatInDatabase = await _sqlServer.Seats.Where(t => t.SeatId == seatToUpdate.SeatId).FirstOrDefaultAsync();

                if (seatInDatabase == null)
                {
                    throw new Exception($"There is no seat with Id {seatToUpdate.SeatId} in the database.");
                }

                if (seatInDatabase.SeatName != seatToUpdate.SeatName)
                {
                    seatInDatabase.SeatName = seatToUpdate.SeatName;
                }

                if (seatInDatabase.SeatColor != seatToUpdate.SeatColor)
                {
                    seatInDatabase.SeatColor = seatToUpdate.SeatColor;
                }

                if (seatInDatabase.SeatMaterial != seatToUpdate.SeatMaterial)
                {
                    seatInDatabase.SeatMaterial = seatToUpdate.SeatMaterial;
                }

                // Lägg till uppdatering för andra egenskaper här om det behövs

                var result = _sqlServer.Seats.Update(seatInDatabase);

                await _sqlServer.SaveChangesAsync();

                return await Task.FromResult(result.Entity);
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
