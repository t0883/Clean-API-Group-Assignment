using FluentValidation;

namespace Application.Validator.GearboxModelValidation
{
    public class GearboxModelValidator : AbstractValidator<string>
    {
        public GearboxModelValidator()
        {
            RuleFor(gearboxModel => gearboxModel)
                .Must(BeAValidGearboxModel).WithMessage("Invalid gearbox model! Must be 'Manual' or 'Automatic'!");
        }

        private bool BeAValidGearboxModel(string gearboxModel)
        {
            // Här kan du definiera de giltiga värdena för gearboxModel
            return gearboxModel == "Manual" || gearboxModel == "Automatic";
        }

    }
}
