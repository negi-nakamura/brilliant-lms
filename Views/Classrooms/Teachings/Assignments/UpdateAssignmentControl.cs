using brilliant_lms.Models.Entities;
using brilliant_lms.Models.Requests;
using brilliant_lms.Models.Responses;
using brilliant_lms.Services;
using brilliant_lms.Utilities;
using FluentValidation;

namespace brilliant_lms.Views.Classrooms.Teachings.Assignments
{
    public partial class UpdateAssignmentControl : UserControl
    {
        private User user;
        private Classroom classroom;
        private AssignmentDirectoryItem assignment;
        public Assignment? UpdatedAssignment { get; private set; }
        private AssignmentService assignmentService = new AssignmentService();
        private bool loading;

        public UpdateAssignmentControl(User user, Classroom classroom, AssignmentDirectoryItem assignment)
        {
            this.user = user;
            this.classroom = classroom;
            this.assignment = assignment;
            InitializeComponent();
            InitializeControl();
        }

        private void InitializeControl()
        {
            titleInput.Text = assignment.Title;
            instructionsInput.Text = assignment.Instructions ?? "";
            dueDatePicker.Value = assignment.DueAt;
            maxPointsInput.Value = assignment.MaxPoints;
            attachmentInput.Text = string.Join(Environment.NewLine, assignment.Attachments.Select(attachment => attachment.LinkUrl));
        }

        private async void updateButton_Click(object sender, EventArgs e)
        {
            if (loading) return;

            UpdateAssignmentRequest request = new UpdateAssignmentRequest
            {
                Title = titleInput.Text.Trim(),
                Instructions = instructionsInput.Text.Trim(),
                DueAt = dueDatePicker.Value,
                MaxPoints = maxPointsInput.Value,
                AttachmentLinks = attachmentInput.Text.Split(new[] { "\r\n", "\n", "\r" },
                    StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries).ToList()
            };

            SetBusy(true);

            try
            {
                UpdatedAssignment = await assignmentService.UpdateAsync(user.Id, classroom.Id, assignment.Id, request);
                FeedbackDialog.Success(FindForm()!, "Assignment updated", "Your assignment has been updated successfully.");
                FindForm()?.Close();
            }
            catch (ValidationException exception)
            {
                FeedbackDialog.Error(FindForm()!, "Update failed", exception.Errors.First().ErrorMessage);
            }
            catch (InvalidOperationException exception)
            {
                FeedbackDialog.Error(FindForm()!, "Update failed", exception.Message);
            }
            catch (Exception)
            {
                FeedbackDialog.Error(FindForm()!, "Update failed", "Unable to update the assignment. Please try again.");
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
            updateButton.Enabled = !busy;
            cancelButton.Enabled = !busy;
        }
    }
}
