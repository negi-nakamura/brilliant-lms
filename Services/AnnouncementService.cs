using brilliant_lms.Models.Entities;
using brilliant_lms.Models.Requests;
using brilliant_lms.Repositories;
using brilliant_lms.Validators;
using FluentValidation;
using brilliant_lms.Models.Responses;

namespace brilliant_lms.Services
{
    public class AnnouncementService
    {
        private AnnouncementRepository announcementRepository = new AnnouncementRepository();
        private UpdateAnnouncementValidator updateAnnouncementValidator = new UpdateAnnouncementValidator();
        private CreateAnnouncementValidator createAnnouncementValidator = new CreateAnnouncementValidator();

        public async Task<List<AnnouncementDirectoryItem>> GetClassroomAnnouncementsAsync(int userId, int classroomId)
        {
            return await announcementRepository.GetClassroomAnnouncementsAsync(userId, classroomId);
        }

        public async Task<AnnouncementLikeState> SetLikeAsync(int userId, int announcementId, bool liked)
        {
            return await announcementRepository.SetLikeAsync(userId, announcementId, liked);
        }

        public async Task<Announcement> UpdateAsync(int userId, int classroomId, int announcementId, UpdateAnnouncementRequest request)
        {
            await updateAnnouncementValidator.ValidateAndThrowAsync(request);

            Announcement announcement = new Announcement
            {
                Id = announcementId,
                AuthorId = userId,
                ClassroomId = classroomId,
                Content = request.Content
            };
            return await announcementRepository.UpdateAsync(announcement);
        }

        public async Task DeleteAsync(int userId, int classroomId, int announcementId)
        {
            await announcementRepository.DeleteAsync(userId, classroomId, announcementId);
        }

        public async Task<Announcement> CreateAsync(int userId, int classroomId, CreateAnnouncementRequest request)
        {
            await createAnnouncementValidator.ValidateAndThrowAsync(request);

            Announcement announcement = new Announcement
            {
                AuthorId = userId,
                ClassroomId = classroomId,
                Content = request.Content
            };
            return await announcementRepository.CreateAsync(announcement);
        }
    }
}
