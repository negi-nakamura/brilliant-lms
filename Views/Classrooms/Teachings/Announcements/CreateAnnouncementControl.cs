using brilliant_lms.Models.Entities;
using brilliant_lms.Models.Requests;
using brilliant_lms.Services;
using brilliant_lms.Utilities;
using FluentValidation;

namespace brilliant_lms.Views.Classrooms.Teachings.Announcements
{
    public partial class CreateAnnouncementControl : UserControl
    {
        private User user;
        private Classroom classroom;
        public Announcement? CreatedAnnouncement { get; private set; }
        private AnnouncementService announcementService = new AnnouncementService();
        private bool loading;

        public CreateAnnouncementControl(User user, Classroom classroom)
        {
            this.user = user;
            this.classroom = classroom;
            InitializeComponent();
            InitializeControl();
        }

        private void InitializeControl()
        {
            contentInput.Text = "";
        }

        private async void createButton_Click(object sender, EventArgs e)
        {
            if (loading) return;

            CreateAnnouncementRequest request = new CreateAnnouncementRequest
            {
                Content = contentInput.Text.Trim()
            };
            SetBusy(true);

            try
            {
                CreatedAnnouncement = await announcementService.CreateAsync(user.Id, classroom.Id, request);
                FeedbackDialog.Success(FindForm()!, "Announcement created", "Your announcement has been posted successfully.");
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
                FeedbackDialog.Error(FindForm()!, "Create failed", "Unable to create the announcement. Please try again.");
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
            contentInput.Enabled = !busy;
            createButton.Enabled = !busy;
            cancelButton.Enabled = !busy;
        }
    }
}
