using brilliant_lms.Models.Entities;
using brilliant_lms.Models.Responses;
using brilliant_lms.Services;
using brilliant_lms.Utilities;
using brilliant_lms.Theme;

namespace brilliant_lms.Views.Archived.Teachings.Announcements
{
    public partial class AnnouncementsDirectoryControl : UserControl
    {
        private User user;
        private AnnouncementService announcementService = new AnnouncementService();
        private Classroom classroom;
        private bool loading;

        public AnnouncementsDirectoryControl(User user, Classroom classroom)
        {
            this.user = user;
            this.classroom = classroom;
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

        private async void AnnouncementsDirectoryControl_Load(object? sender, EventArgs e)
        {
            await LoadAnnouncementsAsync();
        }

        private async Task LoadAnnouncementsAsync()
        {
            if (loading) return;

            SetBusy(true);
            
            try
            {
                List<AnnouncementDirectoryItem> announcements = await announcementService.GetClassroomAnnouncementsAsync(user.Id, classroom.Id);

                announcementsContent.SuspendLayout();

                try
                {
                    foreach (AnnouncementDirectoryItem announcement in announcements)
                    {
                        AnnouncementCardControl card = new AnnouncementCardControl(user, announcement);
                        card.TabIndex = announcementsContent.Controls.Count;
                        AntdUI.GridPanel cardRow = new AntdUI.GridPanel
                        {
                            Span = "50%_N 1116 50%_N",
                            Size = new Size(952, card.Height + card.Margin.Vertical),
                            BackColor = Color.Transparent,
                            Back = Color.Transparent,
                            Margin = new Padding(0)
                        };
                        cardRow.Controls.Add(card);
                        announcementsContent.Controls.Add(cardRow);
                    }

                    emptyPanel.Visible = announcements.Count == 0;
                    announcementsContent.Visible = announcements.Count > 0;
                }
                finally
                {
                    announcementsContent.ResumeLayout(true);
                }
            }
            catch (InvalidOperationException exception)
            {
                if (!IsDisposed)
                    FeedbackDialog.Error(FindForm()!, "Load failed", exception.Message);
            }
            catch (Exception)
            {
                if (!IsDisposed)
                    FeedbackDialog.Error(FindForm()!, "Load failed", "Unable to load announcements. Please try again.");
            }
            finally
            {
                SetBusy(false);
            }
        }

        private void SetBusy(bool busy)
        {
            loading = busy;
            UseWaitCursor = busy;
            announcementsContent.Enabled = !busy;
        }

    }
}
