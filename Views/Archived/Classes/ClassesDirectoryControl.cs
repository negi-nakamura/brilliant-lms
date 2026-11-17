using brilliant_lms.Models.Entities;
using brilliant_lms.Models.Responses;
using brilliant_lms.Services;
using brilliant_lms.Utilities;
using brilliant_lms.Theme;

namespace brilliant_lms.Views.Archived.Classes
{
    public partial class ClassesDirectoryControl : UserControl
    {
        private User user;
        public event EventHandler<Classroom>? ClassroomRequested;
        private ClassroomService classroomService = new ClassroomService();
        private bool loading;

        public ClassesDirectoryControl(User user)
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

        private async void ClassesDirectoryControl_Load(object? sender, EventArgs e)
        {
            await LoadClassroomsAsync();
        }

        private async Task LoadClassroomsAsync()
        {
            if (loading) return;

            SetBusy(true);
            
            try
            {
                List<ClassroomDirectoryItem> classrooms = await classroomService.GetArchivedStudentClassroomsAsync(user.Id);

                classesContent.SuspendLayout();

                try
                {
                    foreach (ClassroomDirectoryItem classroom in classrooms)
                    {
                        ClassesCardControl card = new ClassesCardControl(user, classroom);
                        card.ClassroomRequested += Card_ClassroomRequested;
                        card.TabIndex = classesContent.Controls.Count;
                        classesContent.Controls.Add(card);
                    }

                    emptyPanel.Visible = classrooms.Count == 0;
                    classesContent.Visible = classrooms.Count > 0;
                }
                finally
                {
                    classesContent.ResumeLayout(true);
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

        private void SetBusy(bool busy)
        {
            loading = busy;
            UseWaitCursor = busy;
            classesContent.Enabled = !busy;
        }

    }
}
