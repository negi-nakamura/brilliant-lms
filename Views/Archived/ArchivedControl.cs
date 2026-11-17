using brilliant_lms.Models.Entities;
using brilliant_lms.Views.Archived.Classes;
using brilliant_lms.Views.Archived.Teachings;

namespace brilliant_lms.Views.Archived
{
    public partial class ArchivedControl : UserControl
    {
        private User user;
        public event EventHandler<Classroom>? ClassroomRequested;
        public event EventHandler<Classroom>? TeachingRequested;
        public event EventHandler<Classroom>? ClassroomChanged;

        public ArchivedControl(User user)
        {
            this.user = user;
            InitializeComponent();
            InitializeControl();
        }

        private void InitializeControl()
        {
            ShowSelectedControl();
        }

        private void archivedTabs_SelectedIndexChanged(object sender, AntdUI.IntEventArgs e)
        {
            ShowSelectedControl();
        }

        private void ShowSelectedControl()
        {
            DisposeControlsTab();
            AntdUI.TabPage? selected = archivedTabs.SelectedTab;
            if (selected == classesTab)
            {
                heading.Text = "Archived Classes";
                description.Text = "View your archived classes and saved learning materials.";
                ClassesDirectoryControl directory = new ClassesDirectoryControl(user)
                {
                    Dock = DockStyle.Fill
                };
                directory.ClassroomRequested += ClassesDirectory_ClassroomRequested;
                selected.Controls.Add(directory);
            }
            else if (selected == teachingsTab)
            {
                heading.Text = "Archived Teachings";
                description.Text = "View archived teachings. Classroom owners can unarchive or permanently delete them.";
                TeachingsDirectoryControl directory = new TeachingsDirectoryControl(user)
                {
                    Dock = DockStyle.Fill
                };
                directory.ClassroomRequested += TeachingsDirectory_ClassroomRequested;
                directory.ClassroomChanged += TeachingsDirectory_ClassroomChanged;
                selected.Controls.Add(directory);
            }
        }

        private void ClassesDirectory_ClassroomRequested(object? sender, Classroom classroom)
        {
            ClassroomRequested?.Invoke(this, classroom);
        }

        private void TeachingsDirectory_ClassroomRequested(object? sender, Classroom classroom)
        {
            TeachingRequested?.Invoke(this, classroom);
        }

        private void TeachingsDirectory_ClassroomChanged(object? sender, Classroom classroom)
        {
            ShowSelectedControl();
            ClassroomChanged?.Invoke(this, classroom);
        }

        private void DisposeControlsTab()
        {
            foreach (AntdUI.TabPage page in archivedTabs.Pages)
            {
                while (page.Controls.Count > 0)
                {
                    Control previous = page.Controls[0];
                    page.Controls.Remove(previous);
                    previous.Dispose();
                }
            }
        }
    }
}
