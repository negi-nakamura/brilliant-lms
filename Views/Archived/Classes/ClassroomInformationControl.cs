using brilliant_lms.Models.Responses;
using brilliant_lms.Utilities;

namespace brilliant_lms.Views.Archived.Classes
{
    public partial class ClassroomInformationControl : UserControl
    {
        private ClassroomDirectoryItem classroom;

        public ClassroomInformationControl(ClassroomDirectoryItem classroom)
        {
            this.classroom = classroom;
            InitializeComponent();
            InitializeControl();
        }

        private void InitializeControl()
        {
            nameValue.Text = string.IsNullOrWhiteSpace(classroom.Name) ? "---" : classroom.Name;
            sectionValue.Text = string.IsNullOrWhiteSpace(classroom.Section) ? "---" : classroom.Section;
            subjectValue.Text = string.IsNullOrWhiteSpace(classroom.Subject) ? "---" : classroom.Subject;
            roomValue.Text = string.IsNullOrWhiteSpace(classroom.Room) ? "---" : classroom.Room;
            scheduleValue.Text = string.IsNullOrWhiteSpace(classroom.Schedule) ? "---" : classroom.Schedule;
            levelValue.Text = string.IsNullOrWhiteSpace(classroom.Level) ? "---" : classroom.Level;
            teacherValue.Text = TextFormatter.GetFullName(classroom.TeacherFirstName, classroom.TeacherMiddleName, classroom.TeacherLastName);
            joinedAtValue.Text = classroom.JoinedAt.ToString("MMM dd, yyyy h:mm tt");
        }
    }
}
