using brilliant_lms.Models.Responses;
using brilliant_lms.Models.Entities;
using brilliant_lms.Services;
using brilliant_lms.Utilities;

namespace brilliant_lms.Views.Classrooms.Classes
{
    public partial class ClassesCardControl : UserControl
    {
        private User user;
        private ClassroomDirectoryItem classroom;
        private ClassroomService classroomService = new ClassroomService();
        public event EventHandler? ClassroomLeft;
        public event EventHandler<Classroom>? ClassroomRequested;
        private bool loading;

        public ClassesCardControl(User user, ClassroomDirectoryItem classroom)
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
            string teacherName = TextFormatter.GetFullName(classroom.TeacherFirstName, classroom.TeacherMiddleName, classroom.TeacherLastName);
            teacherLabel.Text = $"{teacherName}";
            timeLabel.Text = string.IsNullOrWhiteSpace(classroom.Schedule) ? "---" : $"{classroom.Schedule}";
        }
        private void ClassesCardControl_Click(object sender, EventArgs e)
        {
            if (loading) return;
            ClassroomRequested?.Invoke(this, classroom);
        }

        private void informationButton_Click(object sender, EventArgs e)
        {
            using ClassroomInformationControl informationControl = new ClassroomInformationControl(classroom);
            Form owner = FindForm()!;
            if (owner is AntdUI.Window window) window.AutoDpi(informationControl);

            AntdUI.Modal.open(new AntdUI.Modal.Config(owner, "Classroom information", informationControl, AntdUI.TType.None)
            {
                MaskClosable = false,
                CloseIcon = true,
                BtnHeight = 0
            });
        }

        private async void leaveButton_Click(object sender, EventArgs e)
        {
            if (loading) return;

            DialogResult result = AntdUI.Modal.open(new AntdUI.Modal.Config(FindForm()!, "Leave classroom", $"Leave {classroom.Name}? You will need the class code to join again.\n\n")
            {
                Icon = AntdUI.TType.Warn,
                OkText = "Leave",
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
                await classroomService.LeaveAsync(user.Id, classroom.Id);
                FeedbackDialog.Success(FindForm()!, "Classroom left", "You have left the classroom successfully.");
            }
            catch (InvalidOperationException exception)
            {
                FeedbackDialog.Error(FindForm()!, "Leave failed", exception.Message);
                return;
            }
            catch (Exception)
            {
                FeedbackDialog.Error(FindForm()!, "Leave failed", "Unable to leave the classroom. Please try again.");
                return;
            }
            finally
            {
                SetBusy(false);
            }

            ClassroomLeft?.Invoke(this, EventArgs.Empty);
        }

        private void SetBusy(bool busy)
        {
            loading = busy;
            UseWaitCursor = busy;

            informationButton.Enabled = !busy;
            leaveButton.Enabled = !busy;
        }
    }
}
