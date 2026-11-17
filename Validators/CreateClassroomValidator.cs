using brilliant_lms.Models.Requests;
using FluentValidation;

namespace brilliant_lms.Validators
{
    public class CreateClassroomValidator : AbstractValidator<CreateClassroomRequest>
    {
        public CreateClassroomValidator()
        {
            RuleFor(request => request.Name)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Please enter a class name.")
                .MaximumLength(150).WithMessage("Class name must be 150 characters or fewer.");
        }
    }
}
