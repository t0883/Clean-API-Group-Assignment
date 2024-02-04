using Domain.Models.Brands;
using Domain.Models.Engines;
using Domain.Models.Gearboxes;
using Domain.Models.Seats;
using Domain.Models.Tires;
using Domain.Models.Users;

namespace Application.Dtos
{
    public class CarDto
    {
        public required string CarName { get; set; }
        public required Brand BrandName { get; set; }
        public required Gearbox GearboxId { get; set; }
        public required Tire TireId { get; set; }
        public required Engine EngineId { get; set; }
        public required Seat SeatId { get; set; }
        public required User UserId { get; set; }

    }
}
