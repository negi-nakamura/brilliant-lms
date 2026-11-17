using brilliant_lms.Models.Entities;
using brilliant_lms.Models.Responses;
using brilliant_lms.Services;
using brilliant_lms.Utilities;

namespace brilliant_lms.Views.Classrooms.Classes.Details
{
    public partial class DetailsControl : UserControl
    {
        private User user;
        private Classroom classroom;
        private ClassroomService classroomService = new ClassroomService();
        private bool loading;

        public DetailsControl(User user, Classroom classroom)
        {
            this.user = user;
            this.classroom = classroom;
            InitializeComponent();
        }

        private async void DetailsControl_Load(object? sender, EventArgs e)
        {
            if (loading) return;
            SetBusy(true);
            try
            {
                ClassroomDirectoryItem details = await classroomService.GetClassroomDetailsAsync(user.Id, classroom.Id);
                if (IsDisposed) return;
                DetailsCardControl card = new DetailsCardControl(details);
                AntdUI.GridPanel cardRow = new AntdUI.GridPanel
                {
                    Span = "50%_N 1116 50%_N",
                    Size = new Size(952, card.Height + card.Margin.Vertical),
                    BackColor = Color.Transparent,
                    Back = Color.Transparent,
                    Margin = new Padding(0)
                };
                cardRow.Controls.Add(card);
                detailsContent.Controls.Add(cardRow);
                card.PerformLayout();
            }
            catch (InvalidOperationException exception)
            {
                if (!IsDisposed) FeedbackDialog.Error(FindForm()!, "Load failed", exception.Message);
            }
            catch (Exception)
            {
                if (!IsDisposed) FeedbackDialog.Error(FindForm()!, "Load failed", "Unable to load classroom details. Please try again.");
            }
            finally
            {
                if (!IsDisposed) SetBusy(false);
            }
        }

        private void SetBusy(bool busy)
        {
            loading = busy;
            UseWaitCursor = busy;
            detailsContent.Enabled = !busy;
        }
    }
}
