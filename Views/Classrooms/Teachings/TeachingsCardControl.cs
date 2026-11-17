using brilliant_lms.Models.Responses;
using brilliant_lms.Models.Entities;
using brilliant_lms.Services;
using brilliant_lms.Utilities;

namespace brilliant_lms.Views.Classrooms.Teachings
{
    public partial class TeachingsCardControl : UserControl
    {
        private User user;
        private ClassroomDirectoryItem classroom;
        private ClassroomService classroomService = new ClassroomService();
        public event EventHandler? Archived;
        public event EventHandler<Classroom>? ClassroomRequested;
        private bool loading;

        public TeachingsCardControl(User user, ClassroomDirectoryItem classroom)
        {
            this.user = user;
            this.classroom = classroom;
            InitializeComponent();
            InitializeControl();
        }

        private void InitializeControl()
        {
            archiveButton.Enabled = user.Id == classroom.OwnerId;
            avatar.Text = TextFormatter.GetInitials(classroom.Name);
            nameLabel.Text = classroom.Name;
            sectionLabel.Text = string.IsNullOrWhiteSpace(classroom.Section) ? "---" : classroom.Section;
            timeLabel.Text = string.IsNullOrWhiteSpace(classroom.Schedule) ? "---" : $"{classroom.Schedule}";
        }
        private void TeachingsCardControl_Click(object sender, EventArgs e)
        {
            if (loading) return;
            ClassroomRequested?.Invoke(this, classroom);
        }

        private void copyButton_Click(object sender, EventArgs e)
        {
            try
            {
                Clipboard.SetText(classroom.JoinCode);
                FeedbackDialog.Success(FindForm()!, "Code copied", "The class code has been copied to your clipboard.");
            }
            catch (Exception)
            {
                FeedbackDialog.Error(FindForm()!, "Copy failed", "Unable to copy the class code. Please try again.");
            }
        }

        private async void archiveButton_Click(object sender, EventArgs e)
        {
            if (loading) return;

            DialogResult result = AntdUI.Modal.open(new AntdUI.Modal.Config(FindForm()!, "Archive classroom", $"Archive {classroom.Name}? It will be removed from active classroom lists.\n\n")
            {
                Icon = AntdUI.TType.Warn,
                OkText = "Archive",
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
                await classroomService.ArchiveAsync(user.Id, classroom.Id);
                classroom.IsArchived = true;
                FeedbackDialog.Success(FindForm()!, "Classroom archived", "The classroom has been archived successfully.");
            }
            catch (InvalidOperationException exception)
            {
                FeedbackDialog.Error(FindForm()!, "Archive failed", exception.Message);
                return;
            }
            catch (Exception)
            {
                FeedbackDialog.Error(FindForm()!, "Archive failed", "Unable to archive the classroom. Please try again.");
                return;
            }
            finally
            {
                SetBusy(false);
            }

            Archived?.Invoke(this, EventArgs.Empty);
        }

        private void SetBusy(bool busy)
        {
            loading = busy;
            UseWaitCursor = busy;

            copyButton.Enabled = !busy;
            archiveButton.Enabled = !busy && user.Id == classroom.OwnerId;
        }
    }
}
