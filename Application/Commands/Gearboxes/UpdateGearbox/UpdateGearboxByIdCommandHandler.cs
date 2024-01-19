using Domain.Models.Brands;
using Domain.Models.Gearboxes;
using Infrastructure.Repository.Brands;
using Infrastructure.Repository.Gearboxes;
using MediatR;

namespace Application.Commands.Gearboxes.UpdateGearbox
{
    public class UpdateGearboxByIdCommandHandler : IRequestHandler<UpdateGearboxByIdCommand, Gearbox>
    {
        private readonly IGearboxRepository _gearboxRepository;
        private readonly IBrandRepository _brandRepository;
        public UpdateGearboxByIdCommandHandler(IGearboxRepository gearboxRepository, IBrandRepository brandRepository)
        {
            _gearboxRepository = gearboxRepository;
            _brandRepository = brandRepository;
        }

        public async Task<Gearbox> Handle(UpdateGearboxByIdCommand request, CancellationToken cancellationToken)
        {
            try
            {
                Gearbox? existingGearbox = await _gearboxRepository.GetGearboxById(request.Id);
                if (existingGearbox == null)
                {
                    throw new ArgumentException("Gearbox not found.");
                }

                Brand existingBrand = await _brandRepository.GetBrandByName(request.GearboxBrand.BrandName);
                if (existingBrand == null)
                {
                    throw new ArgumentException("Brand not found.");
                }

                existingGearbox.GearboxModel = request.GearboxModel ?? existingGearbox.GearboxModel;
                existingGearbox.Brand = existingBrand;
                existingGearbox.SixGears = request.SixGears;

                Gearbox updatedGearbox = await _gearboxRepository.UpdateGearboxById(existingGearbox);

                return updatedGearbox;
            }
            catch (Exception ex)
            {
                throw;
            }

        }
    }
}
