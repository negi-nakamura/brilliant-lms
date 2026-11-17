using brilliant_lms.Models.Requests;
using FluentValidation;

namespace brilliant_lms.Validators
{
    public class LoginValidator : AbstractValidator<LoginRequest>
    {
        public LoginValidator()
        {
            RuleFor(request => request.Email)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Please enter your email.")
                .MaximumLength(255).WithMessage("Email must be 255 characters or fewer.")
                .EmailAddress().WithMessage("Please enter a valid email.");

            RuleFor(request => request.Password)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Please enter your password.")
                .MaximumLength(255).WithMessage("Password must be 255 characters or fewer.");
        }
    }
}
