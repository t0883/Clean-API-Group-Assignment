using Domain.Models.Brands;
using Domain.Models.Cars;
using Domain.Models.Engines;
using Domain.Models.Gearboxes;
using Domain.Models.Seats;
using Domain.Models.Tires;
using Domain.Models.Users;
using Infrastructure.Database.SqlDatabase;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository.Cars
{
    public class CarRepository : ICarRepository
    {
        private readonly SqlServer _sqlServer;

        public CarRepository(SqlServer sqlServer)
        {
            _sqlServer = sqlServer;
        }

        public async Task<Car> AddCar(Car car)
        {
            try
            {
                Brand? brandToConnect = await _sqlServer.Brands.Where(b => b.BrandName == car.Brand.BrandName).FirstOrDefaultAsync();

                if (brandToConnect == null)
                {
                    throw new Exception($"There is no brand with the name {car.Brand.BrandName} in the database.");
                }

                Gearbox? gearboxToConnect = await _sqlServer.GearBoxes.Where(g => g.GearboxId == car.Gearbox.GearboxId).FirstOrDefaultAsync();

                if (gearboxToConnect == null)
                {
                    throw new Exception($"There is no gearbox with Id {car.Gearbox.GearboxId} in the database.");
                }

                Tire? tireToConnect = await _sqlServer.Tires.Where(t => t.TireId == car.Tire.TireId).FirstOrDefaultAsync();

                if (tireToConnect == null)
                {
                    throw new Exception($"There is no tire with Id {car.Tire.TireId} in the database.");
                }

                Seat? seatToConnect = await _sqlServer.Seats.Where(s => s.SeatId == car.Seat.SeatId).FirstOrDefaultAsync();

                if (seatToConnect == null)
                {
                    throw new Exception($"There is no seat with Id {car.Seat.SeatId} in the database.");
                }

                User? userToConnect = await _sqlServer.Users.Where(u => u.UserId == car.CreatedBy.UserId).FirstOrDefaultAsync();
                if (userToConnect == null)
                {
                    throw new Exception($"There is no user with Id {car.CreatedBy.UserId} in the database");
                }

                Engine? engineToConnect = await _sqlServer.Engines.Where(e => e.EngineId == car.Engine.EngineId).FirstOrDefaultAsync();

                if (engineToConnect == null)
                {
                    throw new Exception($"There is no engine with Id {car.Engine.EngineId} in the database");
                }

                Car carToCreate = new Car { Brand = brandToConnect, Seat = seatToConnect, Engine = engineToConnect, Gearbox = gearboxToConnect, Tire = tireToConnect, CarId = car.CarId, CreatedAt = DateTime.UtcNow, CreatedBy = userToConnect, Name = car.Name, UpdatedAt = DateTime.UtcNow };

                var result = _sqlServer.Cars.Add(carToCreate);

                await _sqlServer.SaveChangesAsync();

                return await Task.FromResult(result.Entity);

            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<List<Car>> GetAllCars()
        {
            try
            {
                var result = await _sqlServer.Cars.Include(b => b.Brand).Include(e => e.Engine).Include(u => u.CreatedBy).Include(g => g.Gearbox).Include(s => s.Seat).Include(t => t.Tire).ToListAsync();

                if (result.Count == 0)
                {
                    throw new Exception("There are no cars in the database.");
                }

                return await Task.FromResult(result);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
