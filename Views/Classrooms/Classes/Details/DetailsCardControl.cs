using brilliant_lms.Models.Responses;
using brilliant_lms.Theme;
using brilliant_lms.Utilities;

namespace brilliant_lms.Views.Classrooms.Classes.Details
{
    public partial class DetailsCardControl : UserControl
    {
        private ClassroomDirectoryItem classroom;

        public DetailsCardControl(ClassroomDirectoryItem classroom)
        {
            this.classroom = classroom;
            InitializeComponent();
            InitializeControl();
            SetBackground();
            ThemeManager.ThemeChanged += ThemeManager_ThemeChanged;
        }

        private void InitializeControl()
        {
            avatar.Text = TextFormatter.GetInitials(classroom.Name);
            nameLabel.Text = classroom.Name;
            sectionValue.Text = string.IsNullOrWhiteSpace(classroom.Section) ? "---" : classroom.Section;
            subjectValue.Text = string.IsNullOrWhiteSpace(classroom.Subject) ? "---" : classroom.Subject;
            roomValue.Text = string.IsNullOrWhiteSpace(classroom.Room) ? "---" : classroom.Room;
            scheduleValue.Text = string.IsNullOrWhiteSpace(classroom.Schedule) ? "---" : classroom.Schedule;
            levelValue.Text = string.IsNullOrWhiteSpace(classroom.Level) ? "---" : classroom.Level;
            teacherValue.Text = TextFormatter.GetFullName(classroom.TeacherFirstName, classroom.TeacherMiddleName, classroom.TeacherLastName);
            joinedAtValue.Text = classroom.JoinedAt.ToString("MMM dd, yyyy h:mm tt");
            createdAtValue.Text = classroom.CreatedAt.ToString("MMM dd, yyyy h:mm tt");
        }

        private void ThemeManager_ThemeChanged(object? sender, EventArgs e)
        {
            SetBackground();
        }

        private void SetBackground()
        {
            BackColor = AntdUI.Style.Db.BgElevated;
            panel1.Back = AntdUI.Style.Db.BgElevated;
            panel1.BackColor = AntdUI.Style.Db.BgElevated;
        }
    }
}
