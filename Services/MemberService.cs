using brilliant_lms.Models.Responses;
using brilliant_lms.Repositories;

namespace brilliant_lms.Services
{
    public class MemberService
    {
        private MemberRepository memberRepository = new MemberRepository();

        public async Task<List<MemberDirectoryItem>> GetClassroomMembersAsync(int userId, int classroomId)
        {
            return await memberRepository.GetClassroomMembersAsync(userId, classroomId);
        }

        public async Task RemoveAsync(int userId, int classroomId, int memberId)
        {
            await memberRepository.RemoveAsync(userId, classroomId, memberId);
        }
    }
}
