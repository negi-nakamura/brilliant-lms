using brilliant_lms.Models.Entities;
using brilliant_lms.Utilities;
using brilliant_lms.Models.Requests;
using brilliant_lms.Services;
using FluentValidation;

namespace brilliant_lms.Views.Classrooms
{
    public partial class JoinClassroomControl : UserControl
    {
        private User user;
        public Classroom? JoinedClassroom { get; private set; }
        private ClassroomService classroomService = new ClassroomService();
        private bool loading;

        public JoinClassroomControl(User user)
        {
            this.user = user;
            InitializeComponent();
            InitializeControl();
        }

        private void InitializeControl()
        {
            classCodeInput.Text = "";
            joinButton.Enabled = !loading;
        }

        private async void joinButton_Click(object sender, EventArgs e)
        {
            if (loading) return;

            JoinClassroomRequest request = new JoinClassroomRequest
            {
                JoinCode = classCodeInput.Text.Trim()
            };

            SetBusy(true);

            try
            {
                JoinedClassroom = await classroomService.JoinAsync(user.Id, request);
                classCodeInput.Text = "";
                FeedbackDialog.Success(FindForm()!, "Classroom joined", $"You have joined {JoinedClassroom.Name}.");
                FindForm()?.Close();
            }
            catch (ValidationException exception)
            {
                FeedbackDialog.Error(FindForm()!, "Join failed", exception.Errors.First().ErrorMessage);
            }
            catch (InvalidOperationException exception)
            {
                FeedbackDialog.Error(FindForm()!, "Join failed", exception.Message);
            }
            catch (Exception)
            {
                FeedbackDialog.Error(FindForm()!, "Join failed", "Unable to join the classroom. Please try again.");
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

            classCodeInput.Enabled = !busy;
            
            joinButton.Loading = busy;
            joinButton.Enabled = !busy;
            cancelButton.Enabled = !busy;
        }
    }
}
