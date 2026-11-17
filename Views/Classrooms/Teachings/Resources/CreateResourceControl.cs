using brilliant_lms.Models.Entities;
using brilliant_lms.Models.Requests;
using brilliant_lms.Services;
using brilliant_lms.Utilities;
using FluentValidation;

namespace brilliant_lms.Views.Classrooms.Teachings.Resources
{
    public partial class CreateResourceControl : UserControl
    {
        private User user;
        private Classroom classroom;
        public Resource? CreatedResource { get; private set; }
        private ResourceService resourceService = new ResourceService();
        private bool loading;

        public CreateResourceControl(User user, Classroom classroom)
        {
            this.user = user;
            this.classroom = classroom;
            InitializeComponent();
            InitializeControl();
        }

        private void InitializeControl()
        {
            titleInput.Text = "";
            descriptionInput.Text = "";
            attachmentInput.Text = "";
        }

        private async void createButton_Click(object sender, EventArgs e)
        {
            if (loading) return;

            CreateResourceRequest request = new CreateResourceRequest
            {
                Title = titleInput.Text.Trim(),
                Description = descriptionInput.Text.Trim(),
                AttachmentLinks = attachmentInput.Text.Split(new[] { "\r\n", "\n", "\r" }, StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries).ToList()
            };

            SetBusy(true);

            try
            {
                CreatedResource = await resourceService.CreateAsync(user.Id, classroom.Id, request);
                FeedbackDialog.Success(FindForm()!, "Resource created", "Your resource has been shared successfully.");
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
                FeedbackDialog.Error(FindForm()!, "Create failed", "Unable to create the resource. Please try again.");
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
            createButton.Enabled = !busy;
            cancelButton.Enabled = !busy;
        }
    }
}
