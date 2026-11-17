using brilliant_lms.Models.Requests;
using brilliant_lms.Models.Entities;
using brilliant_lms.Repositories;
using brilliant_lms.Validators;
using FluentValidation;

namespace brilliant_lms.Services
{
    public class AuthService
    {
        AuthRepository authRepository = new AuthRepository();
        LoginValidator loginValidator = new LoginValidator();
        RegisterValidator registerValidator = new RegisterValidator();

        public async Task<User> LoginAsync(LoginRequest request)
        {
            await loginValidator.ValidateAndThrowAsync(request);
            return await authRepository.LoginAsync(request.Email, request.Password);
        }

        public async Task<User> RegisterAsync(RegisterRequest request)
        {
            await registerValidator.ValidateAndThrowAsync(request);

            User user = new()
            {
                FirstName = request.FirstName,
                MiddleName = string.IsNullOrWhiteSpace(request.MiddleName) ? null : request.MiddleName,
                LastName = request.LastName,
                Email = request.Email,
                Password = request.Password
            };

            return await authRepository.RegisterAsync(user);
        }

        public async Task ChangePasswordAsync(int userId, ChangePasswordRequest request)
        {
            await new ChangePasswordValidator().ValidateAndThrowAsync(request);
            await authRepository.ChangePasswordAsync(userId, request.CurrentPassword, request.NewPassword);
        }
    }
}
