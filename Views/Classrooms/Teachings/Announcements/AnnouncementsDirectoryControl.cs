using brilliant_lms.Models.Entities;
using brilliant_lms.Models.Responses;
using brilliant_lms.Services;
using brilliant_lms.Utilities;
using brilliant_lms.Theme;

namespace brilliant_lms.Views.Classrooms.Teachings.Announcements
{
    public partial class AnnouncementsDirectoryControl : UserControl
    {
        private User user;
        public event EventHandler? AnnouncementChanged;
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
                        card.UpdateRequested += Card_UpdateRequested;
                        card.DeleteRequested += Card_DeleteRequested;
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

        private void Card_UpdateRequested(object? sender, AnnouncementDirectoryItem announcement)
        {
            if (loading) return;

            using UpdateAnnouncementControl updateAnnouncement = new UpdateAnnouncementControl(user, classroom, announcement);
            Form owner = FindForm()!;
            if (owner is AntdUI.Window window) window.AutoDpi(updateAnnouncement);

            AntdUI.Modal.open(new AntdUI.Modal.Config(owner, "Update Announcement", updateAnnouncement, AntdUI.TType.None)
            {
                BtnHeight = 0,
                MaskClosable = false,
                Keyboard = false,
                CloseIcon = true
            });

            if (updateAnnouncement.UpdatedAnnouncement != null)
                AnnouncementChanged?.Invoke(this, EventArgs.Empty);
        }

        private async void Card_DeleteRequested(object? sender, AnnouncementDirectoryItem announcement)
        {
            if (loading) return;

            DialogResult result = AntdUI.Modal.open(new AntdUI.Modal.Config(
                FindForm()!, "Delete announcement", "Delete this announcement? This action cannot be undone.\n\n")
            {
                Icon = AntdUI.TType.Warn,
                OkText = "Delete",
                CancelText = "Cancel",
                MaskClosable = false,
                OnButtonStyle = SetConfirmationButtonStyle
            });
            if (result != DialogResult.OK) return;

            SetBusy(true);
            try
            {
                await announcementService.DeleteAsync(user.Id, classroom.Id, announcement.Id);
                FeedbackDialog.Success(FindForm()!, "Announcement deleted", "The announcement has been deleted successfully.");
            }
            catch (InvalidOperationException exception)
            {
                FeedbackDialog.Error(FindForm()!, "Delete failed", exception.Message);
                return;
            }
            catch (Exception)
            {
                FeedbackDialog.Error(FindForm()!, "Delete failed", "Unable to delete the announcement. Please try again.");
                return;
            }
            finally
            {
                if (!IsDisposed) SetBusy(false);
            }

            AnnouncementChanged?.Invoke(this, EventArgs.Empty);
        }

        private void SetConfirmationButtonStyle(string name, AntdUI.Button button)
        {
            button.Radius = 0;
        }

        private void SetBusy(bool busy)
        {
            loading = busy;
            UseWaitCursor = busy;
            announcementsContent.Enabled = !busy;
        }

    }
}
