using brilliant_lms.Models.Requests;
using FluentValidation;

namespace brilliant_lms.Validators
{
    public class RegisterValidator : AbstractValidator<RegisterRequest>
    {
        string NamePattern = @"\A\p{L}[\p{L}\p{M}]*(?: \p{L}[\p{L}\p{M}]*)*\z";

        public RegisterValidator()
        {
            RuleFor(request => request.FirstName)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Please enter your first name.")
                .MaximumLength(120).WithMessage("First name must be 120 characters or fewer.")
                .Matches(NamePattern).WithMessage("First name must contain only letters and single spaces between words.");

            RuleFor(request => request.MiddleName)
                .Cascade(CascadeMode.Stop)
                .MaximumLength(120).WithMessage("Middle name must be 120 characters or fewer.")
                .Matches(NamePattern).WithMessage("Middle name must contain only letters and single spaces between words.")
                .When(request => !string.IsNullOrEmpty(request.MiddleName));

            RuleFor(request => request.LastName)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Please enter your last name.")
                .MaximumLength(120).WithMessage("Last name must be 120 characters or fewer.")
                .Matches(NamePattern).WithMessage("Last name must contain only letters and single spaces between words.");

            RuleFor(request => request.Email)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Please enter your email.")
                .MaximumLength(255).WithMessage("Email must be 255 characters or fewer.")
                .EmailAddress().WithMessage("Please enter a valid email.");

            RuleFor(request => request.Password)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Please enter a password.")
                .MinimumLength(8).WithMessage("Password must be at least 8 characters.")
                .MaximumLength(255).WithMessage("Password must be 255 characters or fewer.")
                .Must(password => !password.Any(char.IsWhiteSpace)).WithMessage("Password must not contain spaces or other whitespace.")
                .Matches(@"\p{Lu}").WithMessage("Password must contain at least one uppercase letter.")
                .Matches(@"\p{Ll}").WithMessage("Password must contain at least one lowercase letter.")
                .Matches("[0-9]").WithMessage("Password must contain at least one number (0-9).")
                .Matches(@"[\p{P}\p{S}]").WithMessage("Password must contain at least one symbol, such as !, @, or #.");

            RuleFor(request => request.ConfirmPassword)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Please confirm your password.")
                .Equal(request => request.Password).WithMessage("The passwords do not match.");
        }
    }
}
