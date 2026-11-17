using brilliant_lms.Models.Entities;
using brilliant_lms.Models.Requests;
using brilliant_lms.Repositories;
using brilliant_lms.Validators;
using FluentValidation;

namespace brilliant_lms.Services
{
    public class UserService
    {
        UserRepository userRepository = new UserRepository();
        UpdateUserValidator updateUserValidator = new UpdateUserValidator();

        public async Task<User> UpdateInformationAsync(int userId, UpdateUserRequest request)
        {
            await updateUserValidator.ValidateAndThrowAsync(request);

            User user = new User()
            {
                Id = userId,
                FirstName = request.FirstName,
                MiddleName = string.IsNullOrWhiteSpace(request.MiddleName) ? null : request.MiddleName,
                LastName = request.LastName,
                Email = request.Email
            };
            return await userRepository.UpdateInformationAsync(user);
        }
    }
}
