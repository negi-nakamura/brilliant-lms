using brilliant_lms.Models.Entities;
using brilliant_lms.Models.Requests;
using brilliant_lms.Models.Responses;
using brilliant_lms.Services;
using brilliant_lms.Utilities;
using FluentValidation;

namespace brilliant_lms.Views.Classrooms.Teachings.Resources
{
    public partial class UpdateResourceControl : UserControl
    {
        private User user;
        private Classroom classroom;
        private ResourceDirectoryItem resource;
        public Resource? UpdatedResource { get; private set; }
        private ResourceService resourceService = new ResourceService();
        private bool loading;

        public UpdateResourceControl(User user, Classroom classroom, ResourceDirectoryItem resource)
        {
            this.user = user;
            this.classroom = classroom;
            this.resource = resource;
            InitializeComponent();
            InitializeControl();
        }

        private void InitializeControl()
        {
            titleInput.Text = resource.Title;
            descriptionInput.Text = resource.Description ?? "";
            attachmentInput.Text = string.Join(Environment.NewLine, resource.Attachments.Select(attachment => attachment.LinkUrl));
        }

        private async void updateButton_Click(object sender, EventArgs e)
        {
            if (loading) return;

            UpdateResourceRequest request = new UpdateResourceRequest
            {
                Title = titleInput.Text.Trim(),
                Description = descriptionInput.Text.Trim(),
                AttachmentLinks = attachmentInput.Text.Split(new[] { "\r\n", "\n", "\r" },
                    StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries).ToList()
            };

            SetBusy(true);

            try
            {
                UpdatedResource = await resourceService.UpdateAsync(user.Id, classroom.Id, resource.Id, request);
                FeedbackDialog.Success(FindForm()!, "Resource updated", "Your resource has been updated successfully.");
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
                FeedbackDialog.Error(FindForm()!, "Update failed", "Unable to update the resource. Please try again.");
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
            descriptionInput.Enabled = !busy;
            attachmentInput.Enabled = !busy;
            updateButton.Enabled = !busy;
            cancelButton.Enabled = !busy;
        }
    }
}
