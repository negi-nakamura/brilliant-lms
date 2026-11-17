using brilliant_lms.Models.Entities;
using brilliant_lms.Models.Requests;
using brilliant_lms.Services;
using brilliant_lms.Utilities;
using FluentValidation;

namespace brilliant_lms.Views.Classrooms.Teachings.Announcements
{
    public partial class UpdateAnnouncementControl : UserControl
    {
        private User user;
        private Classroom classroom;
        private Announcement announcement;
        public Announcement? UpdatedAnnouncement { get; private set; }
        private AnnouncementService announcementService = new AnnouncementService();
        private bool loading;

        public UpdateAnnouncementControl(User user, Classroom classroom, Announcement announcement)
        {
            this.user = user;
            this.classroom = classroom;
            this.announcement = announcement;
            InitializeComponent();
            InitializeControl();
        }

        private void InitializeControl()
        {
            contentInput.Text = announcement.Content;
        }

        private async void updateButton_Click(object sender, EventArgs e)
        {
            if (loading) return;

            UpdateAnnouncementRequest request = new UpdateAnnouncementRequest
            {
                Content = contentInput.Text.Trim()
            };
            SetBusy(true);

            try
            {
                UpdatedAnnouncement = await announcementService.UpdateAsync(user.Id, classroom.Id, announcement.Id, request);
                FeedbackDialog.Success(FindForm()!, "Announcement updated", "Your announcement has been updated successfully.");
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
                FeedbackDialog.Error(FindForm()!, "Update failed", "Unable to update the announcement. Please try again.");
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
            updateButton.Enabled = !busy;
            cancelButton.Enabled = !busy;
        }
    }
}
