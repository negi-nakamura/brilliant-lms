using brilliant_lms.Models.Requests;
using FluentValidation;

namespace brilliant_lms.Validators
{
    public class SubmitAssignmentValidator : AbstractValidator<SubmitAssignmentRequest>
    {
        public SubmitAssignmentValidator()
        {
            RuleFor(request => request.AnswerText)
                .Must((request, answer) => !string.IsNullOrWhiteSpace(answer) || request.AttachmentLinks.Count > 0)
                .WithMessage("Enter an answer or add an attachment link.")
                .Must(answer => System.Text.Encoding.UTF8.GetByteCount(answer) <= 65535)
                .WithMessage("Your answer is too long.");
            RuleForEach(request => request.AttachmentLinks).NotEmpty().MaximumLength(2000)
                .Must(link => Uri.TryCreate(link, UriKind.Absolute, out Uri? address) &&
                    (address.Scheme == Uri.UriSchemeHttp || address.Scheme == Uri.UriSchemeHttps))
                .WithMessage("Enter a valid HTTP or HTTPS attachment link.");
        }
    }
}
