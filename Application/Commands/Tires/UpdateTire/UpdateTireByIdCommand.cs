using Domain.Models.Brands;
using Domain.Models.Tires;
using MediatR;
using System;

namespace Application.Commands.Tires.UpdateTire
{
    public class UpdateTireByIdCommand : IRequest<Unit>
    {
        public UpdateTireByIdCommand(Tire tireToUpdate)
        {
            TireModel = tireToUpdate.TireModel;
            Brand = tireToUpdate.Brand;
            TireSize = tireToUpdate.TireSize;
            TireTreadDepth = tireToUpdate.TireTreadDepth;
            TireId = tireToUpdate.TireId;
        }

        public string TireModel { get; }
        public Brand Brand { get; }
        public string TireSize { get; }
        public decimal TireTreadDepth { get; }
        public Guid TireId { get; }
    }
}
