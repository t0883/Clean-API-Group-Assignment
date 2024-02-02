using Domain.Models.Brands;
using Domain.Models.Engines;
using Domain.Models.Gearboxes;
using Domain.Models.Seats;
using Domain.Models.Tires;
using Domain.Models.Users;
using Microsoft.EntityFrameworkCore;

namespace Domain.Models.Cars
{
    public class Car
    {
        public Guid CarId { get; set; }
        public string Name { get; set; }
        [DeleteBehavior(DeleteBehavior.Restrict)]
        public Brand Brand { get; set; }
        [DeleteBehavior(DeleteBehavior.Restrict)]
        public Gearbox Gearbox { get; set; }
        [DeleteBehavior(DeleteBehavior.Restrict)]
        public Tire Tire { get; set; }
        [DeleteBehavior(DeleteBehavior.Restrict)]
        public Engine Engine { get; set; }
        [DeleteBehavior(DeleteBehavior.Restrict)]
        public Seat Seat { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        [DeleteBehavior(DeleteBehavior.Restrict)]
        public User CreatedBy { get; set; }
    }
}
