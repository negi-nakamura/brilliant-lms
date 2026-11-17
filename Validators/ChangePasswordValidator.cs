using brilliant_lms.Models.Requests;
using FluentValidation;

namespace brilliant_lms.Validators
{
    public class ChangePasswordValidator : AbstractValidator<ChangePasswordRequest>
    {
        public ChangePasswordValidator()
        {
            RuleFor(request => request.CurrentPassword)
                .NotEmpty().WithMessage("Please enter your current password.");

            RuleFor(request => request.NewPassword)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Please enter a new password.")
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
                .Equal(request => request.NewPassword).WithMessage("The passwords do not match.");
            RuleFor(request => request.NewPassword)
                .NotEqual(request => request.CurrentPassword)
                .WithMessage("New password must be different from your current password.");
        }
    }
}
