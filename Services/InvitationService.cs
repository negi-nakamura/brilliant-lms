using brilliant_lms.Models.Requests;
using brilliant_lms.Models.Responses;
using brilliant_lms.Repositories;
using brilliant_lms.Validators;
using FluentValidation;

namespace brilliant_lms.Services
{
    public class InvitationService
    {
        private InvitationRepository invitationRepository = new InvitationRepository();
        private AddMemberValidator addMemberValidator = new AddMemberValidator();

        public async Task SendAsync(int userId, int classroomId, AddMemberRequest request)
        {
            await addMemberValidator.ValidateAndThrowAsync(request);
            await invitationRepository.SendAsync(userId, classroomId, request);
        }

        public async Task<List<InvitationDirectoryItem>> GetPendingInvitationsAsync(int userId)
        {
            return await invitationRepository.GetPendingInvitationsAsync(userId);
        }

        public async Task<List<InvitationDirectoryItem>> GetDeclinedInvitationsAsync(int userId)
        {
            return await invitationRepository.GetDeclinedInvitationsAsync(userId);
        }

        public async Task AcceptAsync(int userId, int invitationId)
        {
            await invitationRepository.AcceptAsync(userId, invitationId);
        }

        public async Task DeclineAsync(int userId, int invitationId)
        {
            await invitationRepository.DeclineAsync(userId, invitationId);
        }
        public async Task<List<InvitationDirectoryItem>> GetSentPendingInvitationsAsync(int userId)
        {
            return await invitationRepository.GetSentPendingInvitationsAsync(userId);
        }

        public async Task<List<InvitationDirectoryItem>> GetSentDeclinedInvitationsAsync(int userId)
        {
            return await invitationRepository.GetSentDeclinedInvitationsAsync(userId);
        }

        public async Task CancelAsync(int userId, int invitationId)
        {
            await invitationRepository.CancelAsync(userId, invitationId);
        }

        public async Task ResendAsync(int userId, int invitationId)
        {
            await invitationRepository.ResendAsync(userId, invitationId);
        }

    }
}
