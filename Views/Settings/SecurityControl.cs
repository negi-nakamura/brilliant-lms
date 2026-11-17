using brilliant_lms.Models.Entities;
using brilliant_lms.Models.Requests;
using brilliant_lms.Services;
using brilliant_lms.Utilities;
using FluentValidation;

namespace brilliant_lms.Views.Settings
{
    public partial class SecurityControl : UserControl
    {
        private readonly User user;
        private AuthService authService = new AuthService();
        private bool changingPassword;

        public SecurityControl(User user)
        {
            this.user = user;
            InitializeComponent();
            InitializeControl();
        }

        private void InitializeControl()
        {
            changePasswordButton.Enabled = !changingPassword;
        }

        private async void changePasswordButton_Click(object sender, EventArgs e)
        {
            if (changingPassword) return;

            ChangePasswordRequest request = new ChangePasswordRequest
            {
                CurrentPassword = currentPasswordInput.Text,
                NewPassword = newPasswordInput.Text,
                ConfirmPassword = confirmPasswordInput.Text
            };

            SetBusy(true);

            try
            {
                await authService.ChangePasswordAsync(user.Id, request);

                currentPasswordInput.Text = "";
                newPasswordInput.Text = "";
                confirmPasswordInput.Text = "";

                FeedbackDialog.Success(FindForm()!, "Password changed", "Your password has been updated successfully.");
            }
            catch (ValidationException exception)
            {
                FeedbackDialog.Error(FindForm()!, "Password change failed", exception.Errors.First().ErrorMessage);
            }
            catch (InvalidOperationException exception)
            {
                FeedbackDialog.Error(FindForm()!, "Password change failed", exception.Message);
            }
            catch (Exception)
            {
                FeedbackDialog.Error(FindForm()!, "Password change failed", "Unable to change your password. Please try again.");
            }
            finally
            {
                SetBusy(false);
            }
        }

        private void SetBusy(bool busy)
        {
            changingPassword = busy;

            currentPasswordInput.Enabled = !busy;
            newPasswordInput.Enabled = !busy;
            confirmPasswordInput.Enabled = !busy;

            changePasswordButton.Loading = busy;
            changePasswordButton.Enabled = !busy;
        }
    }
}
