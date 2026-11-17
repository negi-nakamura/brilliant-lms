using brilliant_lms.Models.Entities;
using brilliant_lms.Models.Responses;
using brilliant_lms.Services;
using brilliant_lms.Utilities;
using brilliant_lms.Theme;

namespace brilliant_lms.Views.Classrooms.Teachings.Assignments.Submissions
{
    public partial class AssignmentsSubmissionsControl : UserControl
    {
        private User user;
        private Assignment assignment;
        private SubmissionService submissionService = new SubmissionService();
        private List<SubmissionDirectoryItem> submissions = new List<SubmissionDirectoryItem>();
        private bool loading;

        public AssignmentsSubmissionsControl(User user, Assignment assignment)
        {
            this.user = user;
            this.assignment = assignment;
            InitializeComponent();
            InitializeControl();
            ThemeManager.ThemeChanged += ThemeManager_ThemeChanged;
        }

        private void InitializeControl()
        {
            headingLabel.Text = assignment.Title;
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

        private async void AssignmentsSubmissionsControl_Load(object? sender, EventArgs e)
        {
            await LoadSubmissionsAsync();
        }

        private async void refreshButton_Click(object sender, EventArgs e)
        {
            await LoadSubmissionsAsync();
        }

        private async Task LoadSubmissionsAsync()
        {
            if (loading) return;

            SetBusy(true);
            
            try
            {
                submissions = await submissionService.GetAssignmentSubmissionsAsync(user.Id, assignment);

                if (IsDisposed) return;
                
                studentsBadge.Text = $"{submissions.Count} students";
                turnedInBadge.Text = $"{submissions.Count(submission => submission.Status == "Turned in")} turned in";
                gradedBadge.Text = $"{submissions.Count(submission => submission.Status == "Graded")} graded";
                returnedBadge.Text = $"{submissions.Count(submission => submission.Status == "Returned")} returned";
                
                ShowSelectedControl();
            }
            catch (InvalidOperationException exception)
            {
                FeedbackDialog.Error(FindForm()!, "Load failed", exception.Message);
            }
            catch (Exception)
            {
                FeedbackDialog.Error(FindForm()!, "Load failed", "Unable to load student work. Please try again.");
            }
            finally
            {
                SetBusy(false);
            }
        }

        private void statusTabs_SelectedIndexChanged(object sender, EventArgs e)
        {
            ShowSelectedControl();
        }

        private void ShowSelectedControl()
        {
            submissionsContent.SuspendLayout();

            try
            {
                DisposeSubmissionControls();

                string status = statusTabs.SelectedTab?.Text ?? "All";
                
                foreach (SubmissionDirectoryItem submission in submissions)
                {
                    if (status != "All" && submission.Status != status) continue;
                    SubmissionCardControl card = new SubmissionCardControl(assignment, submission);
                    card.ReviewRequested += Card_ReviewRequested;
                    submissionsContent.Controls.Add(card);
                }

                emptyPanel.Visible = submissionsContent.Controls.Count == 0;
                submissionsContent.Visible = submissionsContent.Controls.Count > 0;
            }
            finally
            {
                submissionsContent.ResumeLayout(true);
            }
        }

        private void DisposeSubmissionControls()
        {
            while (submissionsContent.Controls.Count > 0)
            {
                Control previous = submissionsContent.Controls[0];
                submissionsContent.Controls.Remove(previous);
                previous.Dispose();
            }
        }

        private async void Card_ReviewRequested(object? sender, SubmissionDirectoryItem submission)
        {
            using ReviewSubmissionControl review = new ReviewSubmissionControl(user, assignment, submission);
            Form owner = FindForm()!;
            if (owner is AntdUI.Window window) window.AutoDpi(review);

            AntdUI.Modal.open(new AntdUI.Modal.Config(owner, "Submission", review, AntdUI.TType.None)
            {
                BtnHeight = 0,
                CloseIcon = true,
                MaskClosable = false,
                Keyboard = false
            });

            if (review.saved) await LoadSubmissionsAsync();
        }

        private void SetBusy(bool busy)
        {
            loading = busy;
            UseWaitCursor = busy;
            refreshButton.Enabled = !busy;
            submissionsContent.Enabled = !busy;
        }
    }
}
