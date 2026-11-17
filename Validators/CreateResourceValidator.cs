using brilliant_lms.Models.Requests;
using FluentValidation;
using System.Text;

namespace brilliant_lms.Validators
{
    public class CreateResourceValidator : AbstractValidator<CreateResourceRequest>
    {
        public CreateResourceValidator()
        {
            RuleFor(request => request.Title)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Please enter an resource title.")
                .MaximumLength(200).WithMessage("Title must be 200 characters or fewer.");

            RuleFor(request => request.Description)
                .Must(description => Encoding.UTF8.GetByteCount(description ?? "") <= 65535)
                .WithMessage("The description are too long. Please shorten them.");

            RuleFor(request => request.AttachmentLinks)
                .NotEmpty().WithMessage("Please add at least one attachment link.");

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
