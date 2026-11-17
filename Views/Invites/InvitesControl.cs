using brilliant_lms.Models.Entities;

namespace brilliant_lms.Views.Invites
{
    public partial class InvitesControl : UserControl
    {
        private User user;
        public event EventHandler? InvitationChanged;

        public InvitesControl(User user)
        {
            this.user = user;
            InitializeComponent();
            InitializeControl();
        }

        private void InitializeControl()
        {
            ShowSelectedControl();
        }

        public void RefreshControl()
        {
            ShowSelectedControl();
        }

        private void invitesTabs_SelectedIndexChanged(object sender, AntdUI.IntEventArgs e)
        {
            ShowSelectedControl();
        }

        private void ShowSelectedControl()
        {
            DisposeControlsTab();
            AntdUI.TabPage? selected = invitesTabs.SelectedTab;
            if (selected == inboxTab)
            {
                heading.Text = "Invitation Inbox";
                description.Text = "Accept or decline invitations to join a class as a student or teacher.";
                Inbox.InvitesDirectoryControl directory = new Inbox.InvitesDirectoryControl(user)
                {
                    Dock = DockStyle.Fill
                };
                directory.InvitationChanged += Directory_InvitationChanged;
                selected.Controls.Add(directory);
            }
            else if (selected == pendingTab)
            {
                heading.Text = "Pending Invitations";
                description.Text = "View and cancel pending invitations you have sent.";
                Pending.InvitesDirectoryControl directory = new Pending.InvitesDirectoryControl(user)
                {
                    Dock = DockStyle.Fill
                };
                directory.InvitationChanged += Directory_InvitationChanged;
                selected.Controls.Add(directory);
            }
            else if (selected == declinedTab)
            {
                heading.Text = "Declined Invitations";
                description.Text = "View and resend invitations that were declined.";
                Declined.InvitesDirectoryControl directory = new Declined.InvitesDirectoryControl(user)
                {
                    Dock = DockStyle.Fill
                };
                directory.InvitationChanged += Directory_InvitationChanged;
                selected.Controls.Add(directory);
            }
        }

        private void Directory_InvitationChanged(object? sender, EventArgs e)
        {
            ShowSelectedControl();
            InvitationChanged?.Invoke(this, EventArgs.Empty);
        }

        private void DisposeControlsTab()
        {
            foreach (AntdUI.TabPage page in invitesTabs.Pages)
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
