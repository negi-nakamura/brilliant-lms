using brilliant_lms.Models.Entities;
using brilliant_lms.Models.Requests;
using brilliant_lms.Services;
using brilliant_lms.Utilities;
using FluentValidation;

namespace brilliant_lms.Views.Classrooms.Teachings.Assignments
{
    public partial class CreateAssignmentControl : UserControl
    {
        private User user;
        private Classroom classroom;
        public Assignment? CreatedAssignment { get; private set; }
        private AssignmentService assignmentService = new AssignmentService();
        private bool loading;

        public CreateAssignmentControl(User user, Classroom classroom)
        {
            this.user = user;
            this.classroom = classroom;
            InitializeComponent();
            InitializeControl();
        }

        private void InitializeControl()
        {
            titleInput.Text = "";
            instructionsInput.Text = "";
            dueDatePicker.Value = DateTime.Now.AddDays(7);
            maxPointsInput.Value = 100;
            attachmentInput.Text = "";
        }

        private async void createButton_Click(object sender, EventArgs e)
        {
            if (loading) return;

            CreateAssignmentRequest request = new CreateAssignmentRequest
            {
                Title = titleInput.Text.Trim(),
                Instructions = instructionsInput.Text.Trim(),
                DueAt = dueDatePicker.Value,
                MaxPoints = maxPointsInput.Value,
                AttachmentLinks = attachmentInput.Text.Split(new[] { "\r\n", "\n", "\r" }, StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries).ToList()
            };

            SetBusy(true);

            try
            {
                CreatedAssignment = await assignmentService.CreateAsync(user.Id, classroom.Id, request);
                FeedbackDialog.Success(FindForm()!, "Assignment created", "Your assignment has been posted successfully.");
                FindForm()?.Close();
            }
            catch (ValidationException exception)
            {
                FeedbackDialog.Error(FindForm()!, "Create failed", exception.Errors.First().ErrorMessage);
            }
            catch (InvalidOperationException exception)
            {
                FeedbackDialog.Error(FindForm()!, "Create failed", exception.Message);
            }
            catch (Exception)
            {
                FeedbackDialog.Error(FindForm()!, "Create failed", "Unable to create the assignment. Please try again.");
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
            titleInput.Enabled = !busy;
            instructionsInput.Enabled = !busy;
            dueDatePicker.Enabled = !busy;
            maxPointsInput.Enabled = !busy;
            attachmentInput.Enabled = !busy;
            createButton.Enabled = !busy;
            cancelButton.Enabled = !busy;
        }
    }
}
