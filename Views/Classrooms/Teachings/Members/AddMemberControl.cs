using brilliant_lms.Models.Entities;
using brilliant_lms.Models.Requests;
using brilliant_lms.Services;
using brilliant_lms.Utilities;
using FluentValidation;

namespace brilliant_lms.Views.Classrooms.Teachings.Members
{
    public partial class AddMemberControl : UserControl
    {
        private User user;
        private Classroom classroom;
        private InvitationService invitationService = new InvitationService();
        private bool loading;
        public bool InvitationSent;

        public AddMemberControl(User user, Classroom classroom)
        {
            this.user = user;
            this.classroom = classroom;
            InitializeComponent();
            InitializeControl();
        }

        private void InitializeControl()
        {
            roleSelect.Items.Add("Student");
            roleSelect.Items.Add("Teacher");
            roleSelect.SelectedIndex = 0;
        }

        private async void addButton_Click(object sender, EventArgs e)
        {
            if (loading) return;
            AddMemberRequest request = new AddMemberRequest
            {
                Email = emailInput.Text.Trim(),
                Role = roleSelect.SelectedValue as string ?? ""
            };
            SetBusy(true);
            try
            {
                await invitationService.SendAsync(user.Id, classroom.Id, request);
                InvitationSent = true;
                FeedbackDialog.Success(FindForm()!, "Invitation sent", "The user must accept your invitation before joining the class.");
                FindForm()?.Close();
            }
            catch (ValidationException exception)
            {
                FeedbackDialog.Error(FindForm()!, "Invite failed", exception.Errors.First().ErrorMessage);
            }
            catch (InvalidOperationException exception)
            {
                FeedbackDialog.Error(FindForm()!, "Invite failed", exception.Message);
            }
            catch (Exception)
            {
                FeedbackDialog.Error(FindForm()!, "Invite failed", "Unable to send the invitation. Please try again.");
            }
            finally
            {
                SetBusy(false);
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            FindForm()?.Close();
        }

        private void SetBusy(bool busy)
        {
            loading = busy;
            UseWaitCursor = busy;
            emailInput.Enabled = !busy;
            roleSelect.Enabled = !busy;
            addButton.Enabled = !busy;
            cancelButton.Enabled = !busy;
        }
    }
}
