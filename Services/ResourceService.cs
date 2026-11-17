using brilliant_lms.Models.Entities;
using brilliant_lms.Models.Requests;
using brilliant_lms.Models.Responses;
using brilliant_lms.Repositories;
using brilliant_lms.Validators;
using FluentValidation;

namespace brilliant_lms.Services
{
    public class ResourceService
    {
        private ResourceRepository resourceRepository = new ResourceRepository();
        private CreateResourceValidator createResourceValidator = new CreateResourceValidator();
        private UpdateResourceValidator updateResourceValidator = new UpdateResourceValidator();

        public async Task<List<ResourceDirectoryItem>> GetClassroomResourcesAsync(int userId, int classroomId)
        {
            return await resourceRepository.GetClassroomResourcesAsync(userId, classroomId);
        }

        public async Task<Resource> CreateAsync(int userId, int classroomId, CreateResourceRequest request)
        {
            await createResourceValidator.ValidateAndThrowAsync(request);

            Resource resource = new Resource
            {
                UploaderId = userId,
                ClassroomId = classroomId,
                Title = request.Title,
                Description = request.Description,
                LinkUrl = request.AttachmentLinks[0]
            };
            return await resourceRepository.CreateAsync(resource, request.AttachmentLinks);
        }

        public async Task<Resource> UpdateAsync(int userId, int classroomId, int resourceId, UpdateResourceRequest request)
        {
            await updateResourceValidator.ValidateAndThrowAsync(request);

            Resource resource = new Resource
            {
                Id = resourceId,
                UploaderId = userId,
                ClassroomId = classroomId,
                Title = request.Title,
                Description = request.Description,
                LinkUrl = request.AttachmentLinks[0]
            };
            return await resourceRepository.UpdateAsync(resource, request.AttachmentLinks);
        }

        public async Task DeleteAsync(int userId, int classroomId, int resourceId)
        {
            await resourceRepository.DeleteAsync(userId, classroomId, resourceId);
        }
    }
}
