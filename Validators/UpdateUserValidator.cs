using brilliant_lms.Models.Requests;
using FluentValidation;

namespace brilliant_lms.Validators
{
    public class UpdateUserValidator : AbstractValidator<UpdateUserRequest>
    {
        private const string NamePattern = @"\A\p{L}[\p{L}\p{M}]*(?: \p{L}[\p{L}\p{M}]*)*\z";

        public UpdateUserValidator()
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

        }
    }
}
