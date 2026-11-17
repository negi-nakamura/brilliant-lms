using brilliant_lms.Models.Entities;
using brilliant_lms.Views.Archived.Classes.Announcements;
using brilliant_lms.Views.Archived.Classes.Assignments;
using brilliant_lms.Views.Archived.Classes.Resources;
using brilliant_lms.Views.Archived.Classes.Members;
using brilliant_lms.Views.Archived.Classes.Details;

namespace brilliant_lms.Views.Archived.Classes
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
                description.Text = "View archived class announcements.";

                AnnouncementsDirectoryControl directory = new AnnouncementsDirectoryControl(user, classroom)
                {
                    Dock = DockStyle.Fill,
                    TabIndex = 0
                };
                selected.Controls.Add(directory);
            }
            else if (selected == assignmentsTab)
            {
                description.Text = "View archived assignments and your previous submissions.";
                AssignmentsDirectoryControl directory = new AssignmentsDirectoryControl(user, classroom)
                {
                    Dock = DockStyle.Fill,
                    TabIndex = 0
                };
                selected.Controls.Add(directory);
            }
            else if (selected == resourcesTab)
            {
                description.Text = "View learning materials from this archived class.";
                ResourcesDirectoryControl directory = new ResourcesDirectoryControl(user, classroom)
                {
                    Dock = DockStyle.Fill,
                    TabIndex = 0
                };
                selected.Controls.Add(directory);
            }
            else if (selected == membersTab)
            {
                description.Text = "View members of this archived class.";

                MembersDirectoryControl directory = new MembersDirectoryControl(user, classroom)
                {
                    Dock = DockStyle.Fill,
                    TabIndex = 0
                };
                selected.Controls.Add(directory);
            }
            else if (selected == detailsTab)
            {
                description.Text = "View archived classroom information and schedule.";
                DetailsControl details = new DetailsControl(user, classroom)
                {
                    Dock = DockStyle.Fill,
                    TabIndex = 0
                };
                selected.Controls.Add(details);
            }
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
