using brilliant_lms.Models.Entities;
using brilliant_lms.Models.Responses;
using brilliant_lms.Services;
using brilliant_lms.Utilities;
using brilliant_lms.Theme;
using brilliant_lms.Views.Classrooms.Teachings.Assignments.Submissions;

namespace brilliant_lms.Views.Classrooms.Teachings.Assignments
{
    public partial class AssignmentsDirectoryControl : UserControl
    {
        private User user;
        public event EventHandler? AssignmentChanged;
        private AssignmentService assignmentService = new AssignmentService();
        private Classroom classroom;
        private bool loading;

        public AssignmentsDirectoryControl(User user, Classroom classroom)
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

        private async void AssignmentsDirectoryControl_Load(object? sender, EventArgs e)
        {
            await LoadAssignmentsAsync();
        }

        private async Task LoadAssignmentsAsync()
        {
            if (loading) return;

            SetBusy(true);
            
            try
            {
                List<AssignmentDirectoryItem> assignments = await assignmentService.GetClassroomAssignmentsAsync(user.Id, classroom.Id);

                assignmentsContent.SuspendLayout();

                try
                {
                    foreach (AssignmentDirectoryItem assignment in assignments)
                    {
                        AssignmentCardControl card = new AssignmentCardControl(user, assignment);
                        card.UpdateRequested += Card_UpdateRequested;
                        card.SubmissionsRequested += Card_SubmissionsRequested;
                        card.DeleteRequested += Card_DeleteRequested;
                        card.TabIndex = assignmentsContent.Controls.Count;
                        AntdUI.GridPanel cardRow = new AntdUI.GridPanel
                        {
                            Span = "50%_N 1116 50%_N",
                            Size = new Size(952, card.Height + card.Margin.Vertical),
                            BackColor = Color.Transparent,
                            Back = Color.Transparent,
                            Margin = new Padding(0)
                        };
                        cardRow.Controls.Add(card);
                        assignmentsContent.Controls.Add(cardRow);
                    }

                    emptyPanel.Visible = assignments.Count == 0;
                    assignmentsContent.Visible = assignments.Count > 0;
                }
                finally
                {
                    assignmentsContent.ResumeLayout(true);
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
                    FeedbackDialog.Error(FindForm()!, "Load failed", "Unable to load assignments. Please try again.");
            }
            finally
            {
                SetBusy(false);
            }
        }

        private void Card_SubmissionsRequested(object? sender, AssignmentDirectoryItem assignment)
        {
            if (loading) return;
            using AssignmentsSubmissionsControl submissions = new AssignmentsSubmissionsControl(user, assignment);
            Form owner = FindForm()!;
            if (owner is AntdUI.Window window) window.AutoDpi(submissions);
            AntdUI.Modal.open(new AntdUI.Modal.Config(owner, "Submission", submissions, AntdUI.TType.None)
            {
                BtnHeight = 0,
                CloseIcon = true,
                MaskClosable = false,
                Keyboard = false
            });
        }

        private void Card_UpdateRequested(object? sender, AssignmentDirectoryItem assignment)
        {
            if (loading) return;

            using UpdateAssignmentControl updateAssignment = new UpdateAssignmentControl(user, classroom, assignment);
            Form owner = FindForm()!;
            if (owner is AntdUI.Window window) window.AutoDpi(updateAssignment);

            AntdUI.Modal.open(new AntdUI.Modal.Config(owner, "Update Assignment", updateAssignment, AntdUI.TType.None)
            {
                BtnHeight = 0,
                MaskClosable = false,
                Keyboard = false,
                CloseIcon = true
            });

            if (updateAssignment.UpdatedAssignment != null) AssignmentChanged?.Invoke(this, EventArgs.Empty);
        }

        private async void Card_DeleteRequested(object? sender, AssignmentDirectoryItem assignment)
        {
            if (loading) return;

            DialogResult result = AntdUI.Modal.open(new AntdUI.Modal.Config(FindForm()!, "Delete assignment", "Delete this assignment? This action cannot be undone.\n\n")
            {
                Icon = AntdUI.TType.Warn,
                OkText = "Delete",
                CancelText = "Cancel",
                MaskClosable = false,
                OnButtonStyle = (name, button) =>
                {
                    button.Radius = 0;
                }
            });

            if (result != DialogResult.OK) return;

            SetBusy(true);

            try
            {
                await assignmentService.DeleteAsync(user.Id, classroom.Id, assignment.Id);
                FeedbackDialog.Success(FindForm()!, "Assignment deleted", "The assignment has been deleted successfully.");
            }
            catch (InvalidOperationException exception)
            {
                FeedbackDialog.Error(FindForm()!, "Delete failed", exception.Message);
                return;
            }
            catch (Exception)
            {
                FeedbackDialog.Error(FindForm()!, "Delete failed", "Unable to delete the assignment. Please try again.");
                return;
            }
            finally
            {
                SetBusy(false);
            }

            AssignmentChanged?.Invoke(this, EventArgs.Empty);
        }

        private void SetBusy(bool busy)
        {
            loading = busy;
            UseWaitCursor = busy;
            assignmentsContent.Enabled = !busy;
        }

    }
}
