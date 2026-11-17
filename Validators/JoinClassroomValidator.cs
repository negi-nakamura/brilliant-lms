using brilliant_lms.Models.Requests;
using FluentValidation;

namespace brilliant_lms.Validators
{
    public class JoinClassroomValidator : AbstractValidator<JoinClassroomRequest>
    {
        public JoinClassroomValidator()
        {
            RuleFor(request => request.JoinCode)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Please enter a class code.")
                .MaximumLength(12).WithMessage("Class code must be 12 characters or fewer.")
                .Matches("^[A-Za-z0-9]+$").WithMessage("Class code must contain only letters and numbers.");
        }
    }
}
