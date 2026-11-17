using brilliant_lms.Models.Requests;
using FluentValidation;

namespace brilliant_lms.Validators
{
    public class UpdateClassroomValidator : AbstractValidator<UpdateClassroomRequest>
    {
        public UpdateClassroomValidator()
        {
            RuleFor(request => request.Name)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Please enter a class name.")
                .MaximumLength(150).WithMessage("Class name must be 150 characters or fewer.");
            RuleFor(request => request.Section).MaximumLength(100).WithMessage("Section must be 100 characters or fewer.");
            RuleFor(request => request.Subject).MaximumLength(150).WithMessage("Subject must be 150 characters or fewer.");
            RuleFor(request => request.Room).MaximumLength(100).WithMessage("Room must be 100 characters or fewer.");
            RuleFor(request => request.Schedule).MaximumLength(200).WithMessage("Schedule must be 200 characters or fewer.");
            RuleFor(request => request.Level).MaximumLength(100).WithMessage("Level must be 100 characters or fewer.");
        }
    }
}
