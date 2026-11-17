using brilliant_lms.Models.Requests;
using FluentValidation;

namespace brilliant_lms.Validators
{
    public class GradeSubmissionValidator : AbstractValidator<GradeSubmissionRequest>
    {
        public GradeSubmissionValidator()
        {
            RuleFor(request => request.Score).NotNull().When(request => !request.ReturnWork).WithMessage("Enter a grade before saving.");
            RuleFor(request => request.Score).GreaterThanOrEqualTo(0).LessThanOrEqualTo(99999999.99m)
                .Must(score => score == null || decimal.Round(score.Value, 2) == score).WithMessage("Use up to two decimal places.");
            RuleFor(request => request.Feedback).Must(feedback => System.Text.Encoding.UTF8.GetByteCount(feedback) <= 65535)
                .WithMessage("Feedback is too long.");
        }
    }
}
