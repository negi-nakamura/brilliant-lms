using brilliant_lms.Models.Entities;
using brilliant_lms.Models.Responses;
using brilliant_lms.Services;
using brilliant_lms.Utilities;
using brilliant_lms.Theme;

namespace brilliant_lms.Views.Invites.Inbox
{
    public partial class InvitesDirectoryControl : UserControl
    {
        private User user;
        private InvitationService invitationService = new InvitationService();
        private bool loading;
        public event EventHandler? InvitationChanged;

        public InvitesDirectoryControl(User user)
        {
            this.user = user;
            InitializeComponent();
            InitializeControl();
            ThemeManager.ThemeChanged += ThemeManager_ThemeChanged;
        }

        private void InitializeControl()
        {
            SetIllustration();
        }

        private void ThemeManager_ThemeChanged(object? sender, EventArgs e)
        {
            SetIllustration();
        }

        private void SetIllustration()
        {
            Image? previous = illustrationImage.Image;
            illustrationImage.Image = ResourceImage.Load(AntdUI.Config.IsLight
                ? "Illustrations.Empty.empty_light.png"
                : "Illustrations.Empty.empty_dark.png");
            previous?.Dispose();
        }

        private async void InvitesDirectoryControl_Load(object? sender, EventArgs e)
        {
            if (loading) return;
            SetBusy(true);
            try
            {
                List<InvitationDirectoryItem> invitations = await invitationService.GetPendingInvitationsAsync(user.Id);
                if (IsDisposed) return;
                invitesContent.SuspendLayout();
                try
                {
                    foreach (InvitationDirectoryItem invitation in invitations.AsEnumerable().Reverse())
                    {
                        InviteCardControl card = new InviteCardControl(user, invitation);
                        card.InvitationResponded += Card_InvitationResponded;
                        card.TabIndex = invitesContent.Controls.Count;
                        AntdUI.GridPanel cardRow = new AntdUI.GridPanel
                        {
                            Span = "50%_N 1116 50%_N",
                            Size = new Size(952, card.Height + card.Margin.Vertical),
                            BackColor = Color.Transparent,
                            Back = Color.Transparent,
                            Margin = new Padding(0)
                        };
                        cardRow.Controls.Add(card);
                        invitesContent.Controls.Add(cardRow);
                        card.PerformLayout();
                    }
                    emptyPanel.Visible = invitations.Count == 0;
                    invitesContent.Visible = invitations.Count > 0;
                }
                finally
                {
                    invitesContent.ResumeLayout(true);
                }
            }
            catch (InvalidOperationException exception)
            {
                if (!IsDisposed) FeedbackDialog.Error(FindForm()!, "Load failed", exception.Message);
            }
            catch (Exception)
            {
                if (!IsDisposed) FeedbackDialog.Error(FindForm()!, "Load failed", "Unable to load your invitations. Please try again.");
            }
            finally
            {
                if (!IsDisposed) SetBusy(false);
            }
        }

        private void Card_InvitationResponded(object? sender, EventArgs e)
        {
            InvitationChanged?.Invoke(this, EventArgs.Empty);
        }

        private void SetBusy(bool busy)
        {
            loading = busy;
            UseWaitCursor = busy;
            invitesContent.Enabled = !busy;
        }
    }
}
