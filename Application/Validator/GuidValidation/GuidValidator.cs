using FluentValidation;

namespace Application.Validator.GuidValidation
{
    public class GuidValidator : AbstractValidator<Guid>
    {
        public GuidValidator()
        {
            RuleFor(guid => guid).NotNull().WithMessage("Guid cannot be null").NotEmpty().WithMessage("Guid cannot be empty").NotEqual(Guid.Empty).WithMessage("Thats not a guid");
        }

    }
}
