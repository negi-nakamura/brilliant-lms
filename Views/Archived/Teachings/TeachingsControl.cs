using brilliant_lms.Models.Entities;
using brilliant_lms.Views.Archived.Teachings.Announcements;
using brilliant_lms.Views.Archived.Teachings.Assignments;
using brilliant_lms.Views.Archived.Teachings.Resources;
using brilliant_lms.Views.Archived.Teachings.Members;
using brilliant_lms.Views.Archived.Teachings.Details;
using brilliant_lms.Views.Archived.Teachings.Reports;

namespace brilliant_lms.Views.Archived.Teachings
{
    public partial class TeachingsControl : UserControl
    {
        private User user;
        private Classroom classroom;

        public TeachingsControl(User user, Classroom classroom)
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

        private void teachingsTabControl_SelectedIndexChanged(object sender, AntdUI.IntEventArgs e)
        {
            ShowSelectedControl();
        }

        private void ShowSelectedControl()
        {
            DisposeControlsTab();
            AntdUI.TabPage? selected = teachingsTabControl.SelectedTab;
            actionButton.Visible = selected == reportsTab;
            if (selected == announcementsTab)
            {
                description.Text = "View archived class announcements.";
                AnnouncementsDirectoryControl view = new AnnouncementsDirectoryControl(user, classroom)
                {
                    Dock = DockStyle.Fill,
                    TabIndex = 0
                };
                selected.Controls.Add(view);
            }
            else if (selected == assignmentsTab)
            {
                description.Text = "View archived assignments and student submissions.";
                AssignmentsDirectoryControl view = new AssignmentsDirectoryControl(user, classroom)
                {
                    Dock = DockStyle.Fill,
                    TabIndex = 0
                };
                selected.Controls.Add(view);
            }
            else if (selected == resourcesTab)
            {
                description.Text = "View archived learning materials.";
                ResourcesDirectoryControl view = new ResourcesDirectoryControl(user, classroom)
                {
                    Dock = DockStyle.Fill,
                    TabIndex = 0
                };
                selected.Controls.Add(view);
            }
            else if (selected == membersTab)
            {
                description.Text = "View members of this archived class.";
                MembersDirectoryControl view = new MembersDirectoryControl(user, classroom)
                {
                    Dock = DockStyle.Fill,
                    TabIndex = 0
                };
                selected.Controls.Add(view);
            }
            else if (selected == detailsTab)
            {
                description.Text = "View archived classroom information and schedule.";
                DetailsControl view = new DetailsControl(user, classroom)
                {
                    Dock = DockStyle.Fill,
                    TabIndex = 0
                };
                selected.Controls.Add(view);
            }
            else if (selected == reportsTab)
            {
                description.Text = "View reports for this archived class.";
                ReportsControl view = new ReportsControl(user, classroom)
                {
                    Dock = DockStyle.Fill,
                    TabIndex = 0
                };
                selected.Controls.Add(view);
            }
            actionButton.Text = "Export CSV";
            actionButton.IconSvg = "DownloadOutlined";
        }

        private void actionButton_Click(object sender, EventArgs e)
        {
            if (teachingsTabControl.SelectedTab != reportsTab) return;
            foreach (Control control in reportsTab.Controls)
            {
                if (control is ReportsControl reports) reports.ExportCsv();
            }
        }

        private void DisposeControlsTab()
        {
            foreach (AntdUI.TabPage page in teachingsTabControl.Pages)
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
