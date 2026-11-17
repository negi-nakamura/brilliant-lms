using brilliant_lms.Models.Responses;
using brilliant_lms.Models.Entities;
using brilliant_lms.Services;
using brilliant_lms.Utilities;

namespace brilliant_lms.Views.Archived.Teachings
{
    public partial class TeachingsCardControl : UserControl
    {
        private User user;
        private ClassroomDirectoryItem classroom;
        private ClassroomService classroomService = new ClassroomService();
        private bool loading;
        public event EventHandler<Classroom>? ClassroomChanged;
        public event EventHandler<Classroom>? ClassroomRequested;

        public TeachingsCardControl(User user, ClassroomDirectoryItem classroom)
        {
            this.user = user;
            this.classroom = classroom;
            InitializeComponent();
            InitializeControl();
        }

        private void InitializeControl()
        {
            avatar.Text = TextFormatter.GetInitials(classroom.Name);
            nameLabel.Text = classroom.Name;
            sectionLabel.Text = string.IsNullOrWhiteSpace(classroom.Section) ? "---" : classroom.Section;
            timeLabel.Text = string.IsNullOrWhiteSpace(classroom.Schedule) ? "---" : classroom.Schedule;
            unarchiveButton.Enabled = user.Id == classroom.OwnerId;
            deleteButton.Enabled = user.Id == classroom.OwnerId;
        }

        private void TeachingsCardControl_Click(object sender, EventArgs e)
        {
            if (loading) return;
            ClassroomRequested?.Invoke(this, classroom);
        }

        private async void unarchiveButton_Click(object sender, EventArgs e)
        {
            if (loading) return;
            DialogResult result = AntdUI.Modal.open(new AntdUI.Modal.Config(FindForm()!, "Unarchive classroom", $"Unarchive {classroom.Name}? It will return to the active classroom lists.\n\n")
            {
                Icon = AntdUI.TType.Warn,
                OkText = "Unarchive",
                CancelText = "Cancel",
                MaskClosable = false,
                OnButtonStyle = (name, button) =>
                {
                    button.Radius = 0;
                }
            });
            if (result != DialogResult.OK) return;
            SetBusy(true);
            try
            {
                await classroomService.UnarchiveAsync(user.Id, classroom.Id);
                classroom.IsArchived = false;
                FeedbackDialog.Success(FindForm()!, "Classroom unarchived", "The classroom is active again.");
            }
            catch (InvalidOperationException exception)
            {
                FeedbackDialog.Error(FindForm()!, "Unarchive failed", exception.Message);
                return;
            }
            catch (Exception)
            {
                FeedbackDialog.Error(FindForm()!, "Unarchive failed", "Unable to unarchive the classroom. Please try again.");
                return;
            }
            finally
            {
                SetBusy(false);
            }
            ClassroomChanged?.Invoke(this, classroom);
        }

        private async void deleteButton_Click(object sender, EventArgs e)
        {
            if (loading) return;
            DialogResult result = AntdUI.Modal.open(new AntdUI.Modal.Config(FindForm()!, "Delete archived classroom", $"Permanently delete {classroom.Name} and all its announcements, assignments, submissions, resources, and memberships? This cannot be undone.\n\n")
            {
                Icon = AntdUI.TType.Warn,
                OkText = "Delete permanently",
                CancelText = "Cancel",
                MaskClosable = false,
                OnButtonStyle = (name, button) =>
                {
                    button.Radius = 0;
                }
            });
            if (result != DialogResult.OK) return;
            SetBusy(true);
            try
            {
                await classroomService.DeleteArchivedAsync(user.Id, classroom.Id);
                FeedbackDialog.Success(FindForm()!, "Classroom deleted", "The archived classroom has been permanently deleted.");
            }
            catch (InvalidOperationException exception)
            {
                FeedbackDialog.Error(FindForm()!, "Delete failed", exception.Message);
                return;
            }
            catch (Exception)
            {
                FeedbackDialog.Error(FindForm()!, "Delete failed", "Unable to delete the archived classroom. Please try again.");
                return;
            }
            finally
            {
                SetBusy(false);
            }
            ClassroomChanged?.Invoke(this, classroom);
        }

        private void SetBusy(bool busy)
        {
            loading = busy;
            UseWaitCursor = busy;
            unarchiveButton.Enabled = !busy && user.Id == classroom.OwnerId;
            deleteButton.Enabled = !busy && user.Id == classroom.OwnerId;
        }
    }
}
