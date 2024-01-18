using Application.Dtos;
using Domain.Models.Gearboxes;
using MediatR;

namespace Application.Commands.Gearboxes.AddGearbox
{
    public class AddGearboxCommand : IRequest<Gearbox>
    {
        public AddGearboxCommand(GearboxDto newGearbox)
        {
            NewGearbox = newGearbox;
        }

        public GearboxDto NewGearbox { get; }
    }
}
