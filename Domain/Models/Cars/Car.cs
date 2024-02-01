using Domain.Models.Brands;
using Domain.Models.Engines;
using Domain.Models.Gearboxes;
using Domain.Models.Seats;
using Domain.Models.Tires;
using Domain.Models.Users;

namespace Domain.Models.Cars
{
    public class Car
    {
        public Guid CarId { get; set; }
        public string Name { get; set; }
        public Brand Brand { get; set; }
        public Gearbox Gearbox { get; set; }
        public Tire Tire { get; set; }
        public Engine Engine { get; set; }
        public Seat Seat { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public User CreatedBy { get; set; }
    }
}
