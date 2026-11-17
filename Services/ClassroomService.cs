using brilliant_lms.Models.Entities;
using brilliant_lms.Models.Requests;
using brilliant_lms.Repositories;
using brilliant_lms.Validators;
using FluentValidation;
using brilliant_lms.Models.Responses;

namespace brilliant_lms.Services
{
    public class ClassroomService
    {
        private ClassroomRepository classroomRepository = new ClassroomRepository();
        private CreateClassroomValidator createClassroomValidator = new CreateClassroomValidator();
        private JoinClassroomValidator joinClassroomValidator = new JoinClassroomValidator();
        private UpdateClassroomValidator updateClassroomValidator = new UpdateClassroomValidator();

        public async Task<List<ClassroomDirectoryItem>> GetStudentClassroomsAsync(int userId)
        {
            return await classroomRepository.GetStudentClassroomsAsync(userId);
        }

        public async Task<List<ClassroomDirectoryItem>> GetTeacherClassroomsAsync(int userId)
        {
            return await classroomRepository.GetTeacherClassroomsAsync(userId);
        }

        public async Task<ClassroomDirectoryItem> GetClassroomDetailsAsync(int userId, int classroomId)
        {
            return await classroomRepository.GetClassroomDetailsAsync(userId, classroomId);
        }

        public async Task<Classroom> UpdateAsync(int userId, int classroomId, UpdateClassroomRequest request)
        {
            await updateClassroomValidator.ValidateAndThrowAsync(request);
            Classroom classroom = new Classroom
            {
                Id = classroomId,
                Name = request.Name,
                Section = string.IsNullOrWhiteSpace(request.Section) ? null : request.Section,
                Subject = string.IsNullOrWhiteSpace(request.Subject) ? null : request.Subject,
                Room = string.IsNullOrWhiteSpace(request.Room) ? null : request.Room,
                Schedule = string.IsNullOrWhiteSpace(request.Schedule) ? null : request.Schedule,
                Level = string.IsNullOrWhiteSpace(request.Level) ? null : request.Level
            };
            return await classroomRepository.UpdateAsync(userId, classroom);
        }

        public async Task<List<ClassroomDirectoryItem>> GetArchivedStudentClassroomsAsync(int userId)
        {
            return await classroomRepository.GetArchivedStudentClassroomsAsync(userId);
        }

        public async Task<List<ClassroomDirectoryItem>> GetArchivedTeacherClassroomsAsync(int userId)
        {
            return await classroomRepository.GetArchivedTeacherClassroomsAsync(userId);
        }

        public async Task UnarchiveAsync(int userId, int classroomId)
        {
            await classroomRepository.UnarchiveAsync(userId, classroomId);
        }

        public async Task DeleteArchivedAsync(int userId, int classroomId)
        {
            await classroomRepository.DeleteArchivedAsync(userId, classroomId);
        }

        public async Task LeaveAsync(int userId, int classroomId)
        {
            await classroomRepository.LeaveAsync(userId, classroomId);
        }

        public async Task ArchiveAsync(int userId, int classroomId)
        {
            await classroomRepository.ArchiveAsync(userId, classroomId);
        }

        public async Task<Classroom> CreateAsync(int userId, CreateClassroomRequest request)
        {
            await createClassroomValidator.ValidateAndThrowAsync(request);

            Classroom classroom = new Classroom
            {
                OwnerId = userId,
                Name = request.Name
            };
            return await classroomRepository.CreateAsync(classroom);
        }

        public async Task<Classroom> JoinAsync(int userId, JoinClassroomRequest request)
        {
            await joinClassroomValidator.ValidateAndThrowAsync(request);
            return await classroomRepository.JoinAsync(userId, request.JoinCode.ToUpperInvariant());
        }
    }
}
