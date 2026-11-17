using brilliant_lms.Models.Requests;
using FluentValidation;

namespace brilliant_lms.Validators
{
    public class ReportFilterValidator : AbstractValidator<ReportFilterRequest>
    {
        public ReportFilterValidator()
        {
            RuleFor(request => request.AssignmentId).GreaterThan(0).When(request => request.AssignmentId != null);
            RuleFor(request => request.StudentId).GreaterThan(0).When(request => request.StudentId != null);
            RuleFor(request => request.ToDate)
                .Must((request, date) => request.FromDate == null || date == null || date.Value.Date >= request.FromDate.Value.Date)
                .WithMessage("The end date must be on or after the start date.");
        }
    }
}
