using brilliant_lms.Models.Responses;
using brilliant_lms.Models.Entities;
using brilliant_lms.Utilities;

namespace brilliant_lms.Views.Archived.Classes
{
    public partial class ClassesCardControl : UserControl
    {
        private User user;
        private ClassroomDirectoryItem classroom;
        public event EventHandler<Classroom>? ClassroomRequested;

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

    }
}
