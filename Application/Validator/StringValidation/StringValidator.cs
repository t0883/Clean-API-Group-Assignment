using FluentValidation;

namespace Application.Validator.StringValidation
{
    public class StringValidator : AbstractValidator<string>
    {
        public StringValidator()
        {
            RuleFor(s => s).NotEmpty().WithMessage("String cannot be empty").NotEqual("string").WithMessage("Name cant be string");
        }
    }
}
