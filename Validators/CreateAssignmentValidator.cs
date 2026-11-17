using brilliant_lms.Models.Requests;
using FluentValidation;
using System.Text;

namespace brilliant_lms.Validators
{
    public class CreateAssignmentValidator : AbstractValidator<CreateAssignmentRequest>
    {
        public CreateAssignmentValidator()
        {
            RuleFor(request => request.Title)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Please enter an assignment title.")
                .MaximumLength(200).WithMessage("Title must be 200 characters or fewer.");

            RuleFor(request => request.Instructions)
                .Must(instructions => Encoding.UTF8.GetByteCount(instructions ?? "") <= 65535)
                .WithMessage("The instructions are too long. Please shorten them.");

            RuleFor(request => request.DueAt)
                .NotNull().WithMessage("Please select a due date.");

            RuleFor(request => request.MaxPoints)
                .GreaterThan(0).WithMessage("Maximum points must be greater than zero.")
                .LessThanOrEqualTo(99999999.99M).WithMessage("Maximum points is too large.")
                .Must(points => decimal.Round(points, 2) == points)
                .WithMessage("Maximum points can have up to two decimal places.");

            RuleForEach(request => request.AttachmentLinks)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Please enter an attachment link.")
                .MaximumLength(2000).WithMessage("Attachment link must be 2000 characters or fewer.")
                .Must(IsValidLink).WithMessage("Each attachment must be a valid HTTP or HTTPS link, one per line.");
        }

        private bool IsValidLink(string link)
        {
            return Uri.TryCreate(link, UriKind.Absolute, out Uri? address)
                && (address.Scheme == Uri.UriSchemeHttp || address.Scheme == Uri.UriSchemeHttps);
        }
    }
}
