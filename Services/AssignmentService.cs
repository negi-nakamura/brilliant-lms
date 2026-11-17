using brilliant_lms.Models.Entities;
using brilliant_lms.Models.Requests;
using brilliant_lms.Models.Responses;
using brilliant_lms.Repositories;
using brilliant_lms.Validators;
using FluentValidation;

namespace brilliant_lms.Services
{
    public class AssignmentService
    {
        private AssignmentRepository assignmentRepository = new AssignmentRepository();
        private CreateAssignmentValidator createAssignmentValidator = new CreateAssignmentValidator();
        private UpdateAssignmentValidator updateAssignmentValidator = new UpdateAssignmentValidator();

        public async Task<List<AssignmentDirectoryItem>> GetClassroomAssignmentsAsync(int userId, int classroomId)
        {
            return await assignmentRepository.GetClassroomAssignmentsAsync(userId, classroomId);
        }

        public async Task<Assignment> CreateAsync(int userId, int classroomId, CreateAssignmentRequest request)
        {
            await createAssignmentValidator.ValidateAndThrowAsync(request);

            Assignment assignment = new Assignment
            {
                CreatorId = userId,
                ClassroomId = classroomId,
                Title = request.Title,
                Instructions = request.Instructions,
                DueAt = request.DueAt,
                MaxPoints = request.MaxPoints
            };
            return await assignmentRepository.CreateAsync(assignment, request.AttachmentLinks);
        }

        public async Task<Assignment> UpdateAsync(int userId, int classroomId, int assignmentId, UpdateAssignmentRequest request)
        {
            await updateAssignmentValidator.ValidateAndThrowAsync(request);

            Assignment assignment = new Assignment
            {
                Id = assignmentId,
                CreatorId = userId,
                ClassroomId = classroomId,
                Title = request.Title,
                Instructions = request.Instructions,
                DueAt = request.DueAt,
                MaxPoints = request.MaxPoints
            };
            return await assignmentRepository.UpdateAsync(assignment, request.AttachmentLinks);
        }

        public async Task DeleteAsync(int userId, int classroomId, int assignmentId)
        {
            await assignmentRepository.DeleteAsync(userId, classroomId, assignmentId);
        }
    }
}
