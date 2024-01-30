using FluentValidation;

namespace Application.Validator.IntValidation
{
    public class IntValidator : AbstractValidator<int>
    {
        public IntValidator()
        {
            RuleFor(i => i).NotEmpty().WithMessage("Number cannot be empty").GreaterThanOrEqualTo(0).WithMessage("Field cannot be empty");
        }
    }
}