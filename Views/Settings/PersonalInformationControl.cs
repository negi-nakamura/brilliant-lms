using brilliant_lms.Models.Entities;
using brilliant_lms.Models.Requests;
using brilliant_lms.Services;
using brilliant_lms.Utilities;
using FluentValidation;

namespace brilliant_lms.Views.Settings
{
    public partial class PersonalInformationControl : UserControl
    {
        private readonly User user;
        private UserService userService = new UserService();
        private bool updating;

        public PersonalInformationControl(User user)
        {
            this.user = user;
            InitializeComponent();
            InitializeControl();
        }

        private void InitializeControl()
        {
            firstNameInput.Text = user.FirstName;
            middleNameInput.Text = user.MiddleName ?? "";
            lastNameInput.Text = user.LastName;
            emailInput.Text = user.Email;
            updateButton.Enabled = !updating;
        }

        private async void updateButton_Click(object sender, EventArgs e)
        {
            if (updating) return;

            UpdateUserRequest request = new UpdateUserRequest()
            {
                FirstName = firstNameInput.Text.Trim(),
                MiddleName = middleNameInput.Text.Trim(),
                LastName = lastNameInput.Text.Trim(),
                Email = emailInput.Text.Trim()
            };

            SetBusy(true);

            try
            {
                User updated = await userService.UpdateInformationAsync(user.Id, request);

                user.FirstName = updated.FirstName;
                user.MiddleName = updated.MiddleName;
                user.LastName = updated.LastName;
                user.Email = updated.Email;

                FeedbackDialog.Success(FindForm()!, "Update successful", "Your personal information has been updated successfully.");
            }
            catch(ValidationException exception)
            {
                FeedbackDialog.Error(FindForm()!, "Update failed", exception.Errors.First().ErrorMessage);
            }
            catch(InvalidOperationException exception)
            {
                FeedbackDialog.Error(FindForm()!, "Update failed", exception.Message);
            }
            catch (Exception exception)
            {
                FeedbackDialog.Error(FindForm()!, "Update failed", exception.Message);
            }
            finally
            {
                SetBusy(false);
            }
        }

        private void SetBusy(bool busy)
        {
            updating = busy;

            firstNameInput.Enabled = !busy;
            middleNameInput.Enabled = !busy;
            lastNameInput.Enabled = !busy;
            emailInput.Enabled = !busy;

            updateButton.Loading = busy;
            updateButton.Enabled = !busy;
        }
    }
}
