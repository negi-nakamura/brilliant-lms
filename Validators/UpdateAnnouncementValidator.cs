using brilliant_lms.Models.Requests;
using FluentValidation;
using System.Text;

namespace brilliant_lms.Validators
{
    public class UpdateAnnouncementValidator : AbstractValidator<UpdateAnnouncementRequest>
    {
        public UpdateAnnouncementValidator()
        {
            RuleFor(request => request.Content)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Please enter your announcement.")
                .Must(content => Encoding.UTF8.GetByteCount(content) <= 65535)
                .WithMessage("The announcement is too long. Please shorten it.");
        }
    }
}
