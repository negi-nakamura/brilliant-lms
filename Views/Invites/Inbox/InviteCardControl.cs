using brilliant_lms.Models.Entities;
using brilliant_lms.Models.Responses;
using brilliant_lms.Services;
using brilliant_lms.Theme;
using brilliant_lms.Utilities;

namespace brilliant_lms.Views.Invites.Inbox
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
            roleLabel.Text = $"Invited as: {invitation.Role}";
            inviterLabel.Text = $"Invited by: {TextFormatter.GetFullName(invitation.InviterFirstName, invitation.InviterMiddleName, invitation.InviterLastName)}";
            dateLabel.Text = invitation.CreatedAt.ToString("MMM dd, yyyy h:mm tt");
        }

        private async void acceptButton_Click(object sender, EventArgs e)
        {
            await RespondAsync(true);
        }

        private async void declineButton_Click(object sender, EventArgs e)
        {
            await RespondAsync(false);
        }

        private async Task RespondAsync(bool accept)
        {
            if (loading) return;
            SetBusy(true);
            try
            {
                if (accept)
                {
                    await invitationService.AcceptAsync(user.Id, invitation.Id);
                    FeedbackDialog.Success(FindForm()!, "Invitation accepted", "Open Classrooms to access your class or teaching.");
                }
                else
                {
                    await invitationService.DeclineAsync(user.Id, invitation.Id);
                    FeedbackDialog.Success(FindForm()!, "Invitation declined", "The invitation has been declined.");
                }
            }
            catch (InvalidOperationException exception)
            {
                FeedbackDialog.Error(FindForm()!, "Response failed", exception.Message);
                return;
            }
            catch (Exception)
            {
                FeedbackDialog.Error(FindForm()!, "Response failed", "Unable to respond to the invitation. Please try again.");
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
            acceptButton.Enabled = !busy;
            declineButton.Enabled = !busy;
        }
    }
}
