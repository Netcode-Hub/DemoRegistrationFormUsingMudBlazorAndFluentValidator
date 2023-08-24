using FluentValidation;
namespace DemoRegistrationFormUsingMudBlazorAndFluentValidator.Models
{
    public class RegistrationModelValidation : AbstractValidator<RegistrationModel>
    {
        public RegistrationModelValidation()
        {
            RuleFor(x=> x.Name).NotEmpty();
            RuleFor(x => x.Email).NotEmpty();
            RuleFor(x => x.PhoneNumber).NotEmpty();
            RuleFor(x => x.Password).NotEmpty().MinimumLength(5).MaximumLength(10).Matches(@"[A-Z]+").Matches(@"[a-z]+").Matches(@"[0-9]+").Matches(@"[\@\!\?\.\*]+");
            RuleFor(x => x.ConfirmPassword).NotEmpty().Equal(_=> _.Password);
            
        }

        public Func<object, string, Task<IEnumerable<string>>> ValidateValue => async (model, propertyName) =>
        {
            var result = await ValidateAsync(ValidationContext<RegistrationModel>.CreateWithOptions((RegistrationModel)model, x => x.IncludeProperties(propertyName)));
            if (result.IsValid)
                return Array.Empty<string>();
            return result.Errors.Select(e => e.ErrorMessage);
        };
    }
}
