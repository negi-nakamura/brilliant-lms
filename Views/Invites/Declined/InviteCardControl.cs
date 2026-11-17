using brilliant_lms.Models.Entities;
using brilliant_lms.Models.Responses;
using brilliant_lms.Services;
using brilliant_lms.Theme;
using brilliant_lms.Utilities;

namespace brilliant_lms.Views.Invites.Declined
{
    public partial class InviteCardControl : UserControl
    {
        private User user;
        private InvitationDirectoryItem invitation;
        private InvitationService invitationService = new InvitationService();
        private bool loading;
        public event EventHandler? InvitationResponded;

        public InviteCardControl(User user, InvitationDirectoryItem invitation)
        {
            this.user = user;
            this.invitation = invitation;
            InitializeComponent();
            InitializeControl();
            SetBackground();
            ThemeManager.ThemeChanged += ThemeManager_ThemeChanged;
        }

        private void InitializeControl()
        {
            avatar.Text = TextFormatter.GetInitials(invitation.ClassroomName);
            nameLabel.Text = invitation.ClassroomName;
            roleLabel.Text = $"Role: {invitation.Role}";
            inviterLabel.Text = $"To: {TextFormatter.GetFullName(invitation.InviteeFirstName, invitation.InviteeMiddleName, invitation.InviteeLastName)} | {invitation.InviteeEmail}";
            dateLabel.Text = invitation.CreatedAt.ToString("MMM dd, yyyy h:mm tt");
        }

        private async void actionButton_Click(object sender, EventArgs e)
        {
            if (loading) return;
            SetBusy(true);
            try
            {
                await invitationService.ResendAsync(user.Id, invitation.Id);
                FeedbackDialog.Success(FindForm()!, "Invitation resent", "The invitation has been sent again.");
            }
            catch (InvalidOperationException exception)
            {
                FeedbackDialog.Error(FindForm()!, "Resend failed", exception.Message);
                return;
            }
            catch (Exception)
            {
                FeedbackDialog.Error(FindForm()!, "Resend failed", "Unable to resend the invitation. Please try again.");
                return;
            }
            finally
            {
                if (!IsDisposed) SetBusy(false);
            }
            InvitationResponded?.Invoke(this, EventArgs.Empty);
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

        private void SetBusy(bool busy)
        {
            loading = busy;
            UseWaitCursor = busy;
            actionButton.Enabled = !busy;
        }
    }
}
