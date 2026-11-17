using brilliant_lms.Models.Entities;
using brilliant_lms.Models.Responses;
using brilliant_lms.Services;
using brilliant_lms.Utilities;
using brilliant_lms.Theme;

namespace brilliant_lms.Views.Archived.Teachings
{
    public partial class TeachingsDirectoryControl : UserControl
    {
        private User user;
        private ClassroomService classroomService = new ClassroomService();
        public event EventHandler<Classroom>? ClassroomChanged;
        public event EventHandler<Classroom>? ClassroomRequested;
        private bool loading;

        public TeachingsDirectoryControl(User user)
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

        private async void TeachingsDirectoryControl_Load(object? sender, EventArgs e)
        {
            await LoadClassroomsAsync();
        }

        private async Task LoadClassroomsAsync()
        {
            if (loading) return;

            SetBusy(true);
            
            try
            {
                List<ClassroomDirectoryItem> classrooms = await classroomService.GetArchivedTeacherClassroomsAsync(user.Id);

                teachingsContent.SuspendLayout();

                try
                {
                    foreach (ClassroomDirectoryItem classroom in classrooms)
                    {
                        TeachingsCardControl card = new TeachingsCardControl(user, classroom);
                        card.ClassroomRequested += Card_ClassroomRequested;
                        card.ClassroomChanged += Card_ClassroomChanged;
                        card.TabIndex = teachingsContent.Controls.Count;
                        teachingsContent.Controls.Add(card);
                    }

                    emptyPanel.Visible = classrooms.Count == 0;
                    teachingsContent.Visible = classrooms.Count > 0;
                }
                finally
                {
                    teachingsContent.ResumeLayout(true);
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
                    FeedbackDialog.Error(FindForm()!, "Load failed", "Unable to load your classrooms. Please try again.");
            }
            finally
            {
                SetBusy(false);
            }
        }

        private void Card_ClassroomRequested(object? sender, Classroom classroom)
        {
            ClassroomRequested?.Invoke(this, classroom);
        }

        private void Card_ClassroomChanged(object? sender, Classroom classroom)
        {
            ClassroomChanged?.Invoke(this, classroom);
        }

        private void SetBusy(bool busy)
        {
            loading = busy;
            UseWaitCursor = busy;
            teachingsContent.Enabled = !busy;
        }

    }
}
