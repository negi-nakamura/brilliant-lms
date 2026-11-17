using brilliant_lms.Models.Entities;
using brilliant_lms.Views.Classrooms.Classes.Announcements;
using brilliant_lms.Views.Classrooms.Classes.Assignments;
using brilliant_lms.Views.Classrooms.Classes.Resources;
using brilliant_lms.Views.Classrooms.Classes.Members;
using brilliant_lms.Views.Classrooms.Classes.Details;

namespace brilliant_lms.Views.Classrooms.Classes
{
    public partial class ClassesControl : UserControl
    {
        private User user;
        private Classroom classroom;

        public ClassesControl(User user, Classroom classroom)
        {
            this.user = user;
            this.classroom = classroom;
            InitializeComponent();
            InitializeControl();
        }

        private void InitializeControl()
        {
            heading.Text = classroom.Name;
            ShowSelectedControl();
        }

        private void classesTabControl_SelectedIndexChanged(object sender, AntdUI.IntEventArgs e)
        {
            ShowSelectedControl();
        }

        private void ShowSelectedControl()
        {
            DisposeControlsTab();

            AntdUI.TabPage? selected = classesTabControl.SelectedTab;

            if (selected == announcementsTab)
            {
                description.Text = "Stay up to date with class announcements.";

                AnnouncementsDirectoryControl directory = new AnnouncementsDirectoryControl(user, classroom)
                {
                    Dock = DockStyle.Fill,
                    TabIndex = 0
                };
                selected.Controls.Add(directory);
            }
            else if (selected == assignmentsTab)
            {
                description.Text = "View class assignments and submit your work.";
                AssignmentsDirectoryControl directory = new AssignmentsDirectoryControl(user, classroom)
                {
                    Dock = DockStyle.Fill,
                    TabIndex = 0
                };
                selected.Controls.Add(directory);
            }
            else if (selected == resourcesTab)
            {
                description.Text = "Access learning materials shared with your class.";
                ResourcesDirectoryControl directory = new ResourcesDirectoryControl(user, classroom)
                {
                    Dock = DockStyle.Fill,
                    TabIndex = 0
                };
                selected.Controls.Add(directory);
            }
            else if (selected == membersTab)
            {
                description.Text = "View the teachers and students in your class.";

                MembersDirectoryControl directory = new MembersDirectoryControl(user, classroom)
                {
                    Dock = DockStyle.Fill,
                    TabIndex = 0
                };
                selected.Controls.Add(directory);
            }
            else if (selected == detailsTab)
            {
                description.Text = "View your classroom information and schedule.";
                DetailsControl details = new DetailsControl(user, classroom)
                {
                    Dock = DockStyle.Fill,
                    TabIndex = 0
                };
                selected.Controls.Add(details);
            }
        }

        public void ShowAssignments()
        {
            classesTabControl.SelectedTab = assignmentsTab;
        }

        public void ShowAnnouncements()
        {
            classesTabControl.SelectedTab = announcementsTab;
        }

        private void DisposeControlsTab()
        {
            foreach (AntdUI.TabPage page in classesTabControl.Pages)
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
