using brilliant_lms.Models.Requests;
using FluentValidation;

namespace brilliant_lms.Validators
{
    public class AddMemberValidator : AbstractValidator<AddMemberRequest>
    {
        public AddMemberValidator()
        {
            RuleFor(request => request.Email)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Please enter the member's email.")
                .EmailAddress().WithMessage("Please enter a valid email address.")
                .MaximumLength(255).WithMessage("Email must be 255 characters or fewer.");

            RuleFor(request => request.Role)
                .Must(role => role == "Student" || role == "Teacher")
                .WithMessage("Please select Student or Teacher.");
        }
    }
}
