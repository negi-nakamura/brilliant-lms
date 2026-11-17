using brilliant_lms.Models.Entities;
using brilliant_lms.Views.Classrooms.Teachings.Announcements;
using brilliant_lms.Views.Classrooms.Teachings.Assignments;
using brilliant_lms.Views.Classrooms.Teachings.Resources;
using brilliant_lms.Views.Classrooms.Teachings.Members;
using brilliant_lms.Views.Classrooms.Teachings.Details;
using brilliant_lms.Views.Classrooms.Teachings.Reports;

namespace brilliant_lms.Views.Classrooms.Teachings
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

            if (selected == announcementsTab)
            {
                actionButton.Text = "Create Announcement";
                actionButton.IconSvg = "PlusOutlined";
                description.Text = "Post announcements and keep your students informed.";

                AnnouncementsDirectoryControl directory = new AnnouncementsDirectoryControl(user, classroom)
                {
                    Dock = DockStyle.Fill,
                    TabIndex = 0
                };
                directory.AnnouncementChanged += AnnouncementsDirectory_AnnouncementChanged;
                selected.Controls.Add(directory);
            }
            else if (selected == assignmentsTab)
            {
                actionButton.Text = "Post Assignment";
                actionButton.IconSvg = "PlusOutlined";
                description.Text = "Create assignments, review submissions, and manage grades.";

                AssignmentsDirectoryControl directory = new AssignmentsDirectoryControl(user, classroom)
                {
                    Dock = DockStyle.Fill,
                    TabIndex = 0
                };
                directory.AssignmentChanged += AssignmentsDirectory_AssignmentChanged;
                selected.Controls.Add(directory);
            }
            else if (selected == resourcesTab)
            {
                actionButton.Text = "Add Resource";
                actionButton.IconSvg = "PlusOutlined";
                description.Text = "Share and manage learning materials for your students.";

                ResourcesDirectoryControl directory = new ResourcesDirectoryControl(user, classroom)
                {
                    Dock = DockStyle.Fill,
                    TabIndex = 0
                };
                directory.ResourceChanged += ResourcesDirectory_ResourceChanged;
                selected.Controls.Add(directory);
            }
            else if (selected == membersTab)
            {
                actionButton.Text = "Invite Member";
                actionButton.IconSvg = "UserAddOutlined";
                description.Text = "View and manage the students in your class.";

                MembersDirectoryControl directory = new MembersDirectoryControl(user, classroom)
                {
                    Dock = DockStyle.Fill,
                    TabIndex = 0
                };
                directory.MemberRemoved += MembersDirectory_MemberRemoved;
                selected.Controls.Add(directory);
            }
            else if (selected == detailsTab)
            {
                actionButton.Text = "Edit Details";
                actionButton.IconSvg = "EditOutlined";
                description.Text = "Update your classroom information and schedule.";

                DetailsControl details = new DetailsControl(user, classroom)
                {
                    Dock = DockStyle.Fill,
                    TabIndex = 0
                };
                selected.Controls.Add(details);
            }
            else if (selected == reportsTab)
            {
                actionButton.Text = "Export CSV";
                actionButton.IconSvg = "DownloadOutlined";
                description.Text = "View class progress and student performance.";
                ReportsControl reports = new ReportsControl(user, classroom)
                {
                    Dock = DockStyle.Fill,
                    TabIndex = 0
                };
                selected.Controls.Add(reports);
            }
        }

        private void actionButton_Click(object sender, EventArgs e)
        {
            AntdUI.TabPage? selected = teachingsTabControl.SelectedTab;

            if (selected == announcementsTab)
                ShowCreateAnnouncement();
            else if (selected == assignmentsTab)
                ShowCreateAssignment();
            else if (selected == resourcesTab)
                ShowCreateResource();
            else if (selected == membersTab)
                ShowAddMember();
            else if (selected == detailsTab)
                ShowEditDetails();
            else if (selected == reportsTab)
            {
                foreach (Control control in reportsTab.Controls)
                {
                    if (control is ReportsControl reports) reports.ExportCsv();
                }
            }
        }

        private void ShowCreateAnnouncement()
        {
            using CreateAnnouncementControl createAnnouncement = new CreateAnnouncementControl(user, classroom);
            Form owner = FindForm()!;
            if (owner is AntdUI.Window window) window.AutoDpi(createAnnouncement);

            AntdUI.Modal.open(new AntdUI.Modal.Config(owner, "Create Announcement", createAnnouncement, AntdUI.TType.None)
            {
                BtnHeight = 0,
                MaskClosable = false,
                Keyboard = false,
                CloseIcon = true
            });

            if (createAnnouncement.CreatedAnnouncement != null)
                ShowSelectedControl();
        }

        private void AnnouncementsDirectory_AnnouncementChanged(object? sender, EventArgs e)
        {
            ShowSelectedControl();
        }

        private void ShowCreateAssignment()
        {
            using CreateAssignmentControl createAssignment = new CreateAssignmentControl(user, classroom);
            Form owner = FindForm()!;
            if (owner is AntdUI.Window window) window.AutoDpi(createAssignment);

            AntdUI.Modal.open(new AntdUI.Modal.Config(owner, "Create Assignment", createAssignment, AntdUI.TType.None)
            {
                BtnHeight = 0,
                MaskClosable = false,
                Keyboard = false,
                CloseIcon = true
            });

            if (createAssignment.CreatedAssignment != null)
                ShowSelectedControl();
        }

        private void AssignmentsDirectory_AssignmentChanged(object? sender, EventArgs e)
        {
            ShowSelectedControl();
        }

        private void ShowCreateResource()
        {
            using CreateResourceControl createResource = new CreateResourceControl(user, classroom);
            Form owner = FindForm()!;
            if (owner is AntdUI.Window window) window.AutoDpi(createResource);

            AntdUI.Modal.open(new AntdUI.Modal.Config(owner, "Create Resource", createResource, AntdUI.TType.None)
            {
                BtnHeight = 0,
                MaskClosable = false,
                Keyboard = false,
                CloseIcon = true
            });

            if (createResource.CreatedResource != null)
                ShowSelectedControl();
        }

        private void ResourcesDirectory_ResourceChanged(object? sender, EventArgs e)
        {
            ShowSelectedControl();
        }

        private void ShowAddMember()
        {
            using AddMemberControl addMember = new AddMemberControl(user, classroom);
            Form owner = FindForm()!;
            if (owner is AntdUI.Window window) window.AutoDpi(addMember);
            AntdUI.Modal.open(new AntdUI.Modal.Config(owner, "Invite Member", addMember, AntdUI.TType.None)
            {
                BtnHeight = 0,
                MaskClosable = false,
                Keyboard = false,
                CloseIcon = true
            });
            if (addMember.InvitationSent) ShowSelectedControl();
        }

        private void MembersDirectory_MemberRemoved(object? sender, EventArgs e)
        {
            ShowSelectedControl();
        }

        private void ShowEditDetails()
        {
            using EditDetailsControl editDetails = new EditDetailsControl(user, classroom);
            Form owner = FindForm()!;
            if (owner is AntdUI.Window window) window.AutoDpi(editDetails);
            AntdUI.Modal.open(new AntdUI.Modal.Config(owner, "Edit Details", editDetails, AntdUI.TType.None)
            {
                BtnHeight = 0,
                MaskClosable = false,
                Keyboard = false,
                CloseIcon = true
            });
            if (editDetails.UpdatedClassroom == null) return;
            classroom.Name = editDetails.UpdatedClassroom.Name;
            classroom.Section = editDetails.UpdatedClassroom.Section;
            classroom.Subject = editDetails.UpdatedClassroom.Subject;
            classroom.Room = editDetails.UpdatedClassroom.Room;
            classroom.Schedule = editDetails.UpdatedClassroom.Schedule;
            classroom.Level = editDetails.UpdatedClassroom.Level;
            heading.Text = classroom.Name;
            if (Parent is AntdUI.TabPage page) page.Text = classroom.Name;
            ShowSelectedControl();
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
