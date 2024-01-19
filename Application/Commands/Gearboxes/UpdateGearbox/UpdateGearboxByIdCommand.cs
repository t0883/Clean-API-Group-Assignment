using Domain.Models.Brands;
using Domain.Models.Gearboxes;
using MediatR;

namespace Application.Commands.Gearboxes.UpdateGearbox
{
    public class UpdateGearboxByIdCommand : IRequest<Gearbox>
    {
        public UpdateGearboxByIdCommand(Gearbox gearboxToUpdate)
        {
            GearboxModel = gearboxToUpdate.GearboxModel;
            GearboxBrand = gearboxToUpdate.Brand;
            SixGears = gearboxToUpdate.SixGears;
            Id = gearboxToUpdate.GearboxId;
        }
        public string GearboxModel { get; }
        public Brand GearboxBrand { get; }
        public bool SixGears { get; }
        public Guid Id { get; }

    }
}
