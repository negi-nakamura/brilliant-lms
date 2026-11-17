using brilliant_lms.Models.Entities;
using brilliant_lms.Models.Requests;
using brilliant_lms.Models.Responses;
using brilliant_lms.Repositories;
using brilliant_lms.Utilities;
using brilliant_lms.Validators;
using FluentValidation;

namespace brilliant_lms.Services
{
    public class ReportService
    {
        private ReportRepository reportRepository = new ReportRepository();
        private ReportFilterValidator reportFilterValidator = new ReportFilterValidator();

        public async Task<ClassroomReport> GetClassroomReportAsync(int userId, int classroomId, ReportFilterRequest request)
        {
            await reportFilterValidator.ValidateAndThrowAsync(request);
            ClassroomReportData data = await reportRepository.GetClassroomReportAsync(userId, classroomId);
            return CalculateReport(data, request, DateTime.Now);
        }

        private ClassroomReport CalculateReport(ClassroomReportData data, ReportFilterRequest request, DateTime now)
        {
            List<Assignment> assignments = data.Assignments.Where(assignment =>
                (request.AssignmentId == null || assignment.Id == request.AssignmentId) &&
                (request.FromDate == null || assignment.CreatedAt.Date >= request.FromDate.Value.Date) &&
                (request.ToDate == null || assignment.CreatedAt.Date <= request.ToDate.Value.Date)).ToList();
            List<MemberDirectoryItem> students = data.Students.Where(student =>
                request.StudentId == null || student.UserId == request.StudentId).ToList();
            ClassroomReport report = new ClassroomReport
            {
                AvailableAssignments = data.Assignments,
                AvailableStudents = data.Students,
                StudentCount = students.Count,
                AssignmentCount = assignments.Count
            };
            ILookup<int, Submission> submissions = data.Submissions.ToLookup(submission => submission.AssignmentId);
            foreach (Assignment assignment in assignments)
            {
                foreach (MemberDirectoryItem student in students)
                {
                    Submission? submission = submissions[assignment.Id].FirstOrDefault(item => item.StudentId == student.UserId);
                    if (submission == null) submission = new Submission();
                    StudentAssignmentReportItem item = new StudentAssignmentReportItem
                    {
                        Id = assignment.Id,
                        Title = assignment.Title,
                        CreatedAt = assignment.CreatedAt,
                        DueAt = assignment.DueAt,
                        MaxPoints = assignment.MaxPoints,
                        StudentId = student.UserId,
                        SubmittedAt = submission.SubmittedAt,
                        Score = submission.SubmittedAt == null ? null : submission.Score,
                        Status = SubmissionStatusFormatter.GetStatus(submission, assignment.DueAt, now),
                        IsLate = submission.SubmittedAt != null && assignment.DueAt != null && submission.SubmittedAt > assignment.DueAt
                    };
                    report.StudentAssignments.Add(item);
                }
            }
            foreach (Assignment assignment in assignments)
            {
                List<StudentAssignmentReportItem> work = report.StudentAssignments.Where(item => item.Id == assignment.Id).ToList();
                List<decimal> scores = work.Where(item => item.Score != null).Select(item => item.Score!.Value).ToList();
                AssignmentReportItem item = new AssignmentReportItem
                {
                    Id = assignment.Id,
                    Title = assignment.Title,
                    DueAt = assignment.DueAt,
                    MaxPoints = assignment.MaxPoints,
                    StudentCount = students.Count,
                    SubmittedCount = work.Count(item => item.SubmittedAt != null),
                    MissingCount = work.Count(item => item.Status == "Missing"),
                    GradedCount = scores.Count,
                    AverageScore = scores.Count == 0 ? null : scores.Average()
                };
                report.Assignments.Add(item);
            }
            foreach (MemberDirectoryItem student in students)
            {
                List<StudentAssignmentReportItem> work = report.StudentAssignments.Where(item => item.StudentId == student.UserId).ToList();
                List<decimal> percentages = work.Where(item => item.Score != null && item.MaxPoints > 0)
                    .Select(item => item.Score!.Value / item.MaxPoints * 100).ToList();
                StudentReportItem item = new StudentReportItem
                {
                    Id = student.Id,
                    UserId = student.UserId,
                    FirstName = student.FirstName,
                    MiddleName = student.MiddleName,
                    LastName = student.LastName,
                    Email = student.Email,
                    AssignmentCount = assignments.Count,
                    SubmittedCount = work.Count(item => item.SubmittedAt != null),
                    MissingCount = work.Count(item => item.Status == "Missing"),
                    LateCount = work.Count(item => item.IsLate),
                    GradedCount = work.Count(item => item.Score != null),
                    AverageGrade = percentages.Count == 0 ? null : percentages.Average()
                };
                report.Students.Add(item);
            }
            report.SubmittedCount = report.StudentAssignments.Count(item => item.SubmittedAt != null);
            report.GradedCount = report.StudentAssignments.Count(item => item.Score != null);
            report.MissingCount = report.StudentAssignments.Count(item => item.Status == "Missing");
            return report;
        }
    }
}
