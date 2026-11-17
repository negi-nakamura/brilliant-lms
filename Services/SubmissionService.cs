using brilliant_lms.Models.Entities;
using brilliant_lms.Models.Requests;
using brilliant_lms.Models.Responses;
using brilliant_lms.Repositories;
using brilliant_lms.Utilities;
using brilliant_lms.Validators;
using FluentValidation;

namespace brilliant_lms.Services
{
    public class SubmissionService
    {
        private SubmissionRepository submissionRepository = new SubmissionRepository();
        private GradeSubmissionValidator gradeSubmissionValidator = new GradeSubmissionValidator();
        private SubmitAssignmentValidator submitAssignmentValidator = new SubmitAssignmentValidator();

        public async Task<List<SubmissionDirectoryItem>> GetAssignmentSubmissionsAsync(int userId, Assignment assignment)
        {
            List<SubmissionDirectoryItem> submissions = await submissionRepository.GetAssignmentSubmissionsAsync(userId, assignment.Id);
            foreach (SubmissionDirectoryItem submission in submissions)
            {
                submission.Status = SubmissionStatusFormatter.GetStatus(submission, assignment.DueAt, DateTime.Now);
                submission.IsLate = submission.SubmittedAt != null && assignment.DueAt != null && submission.SubmittedAt > assignment.DueAt;
            }
            return submissions;
        }

        public async Task<SubmissionDirectoryItem> GetStudentSubmissionAsync(int userId, Assignment assignment)
        {
            SubmissionDirectoryItem submission = await submissionRepository.GetStudentSubmissionAsync(userId, assignment.Id);
            submission.Status = SubmissionStatusFormatter.GetStatus(submission, assignment.DueAt, DateTime.Now);
            submission.IsLate = submission.SubmittedAt != null && assignment.DueAt != null && submission.SubmittedAt > assignment.DueAt;
            return submission;
        }

        public async Task SubmitAsync(int userId, int assignmentId, SubmitAssignmentRequest request)
        {
            await submitAssignmentValidator.ValidateAndThrowAsync(request);
            await submissionRepository.SubmitAsync(userId, assignmentId, request);
        }

        public async Task GradeAsync(int userId, int assignmentId, int submissionId, GradeSubmissionRequest request)
        {
            await gradeSubmissionValidator.ValidateAndThrowAsync(request);
            await submissionRepository.GradeAsync(userId, assignmentId, submissionId, request);
        }
    }
}
