using brilliant_lms.Models.Entities;
using brilliant_lms.Models.Requests;
using brilliant_lms.Services;
using brilliant_lms.Utilities;
using FluentValidation;

namespace brilliant_lms.Views.Classrooms.Teachings.Details
{
    public partial class EditDetailsControl : UserControl
    {
        private User user;
        private Classroom classroom;
        private ClassroomService classroomService = new ClassroomService();
        private bool loading;
        public Classroom? UpdatedClassroom { get; private set; }

        public EditDetailsControl(User user, Classroom classroom)
        {
            this.user = user;
            this.classroom = classroom;
            InitializeComponent();
            InitializeControl();
        }

        private void InitializeControl()
        {
            nameInput.Text = classroom.Name;
            sectionInput.Text = classroom.Section ?? "";
            subjectInput.Text = classroom.Subject ?? "";
            roomInput.Text = classroom.Room ?? "";
            scheduleInput.Text = classroom.Schedule ?? "";
            levelInput.Text = classroom.Level ?? "";
        }

        private async void saveButton_Click(object sender, EventArgs e)
        {
            if (loading) return;
            UpdateClassroomRequest request = new UpdateClassroomRequest
            {
                Name = nameInput.Text.Trim(),
                Section = sectionInput.Text.Trim(),
                Subject = subjectInput.Text.Trim(),
                Room = roomInput.Text.Trim(),
                Schedule = scheduleInput.Text.Trim(),
                Level = levelInput.Text.Trim()
            };
            SetBusy(true);
            try
            {
                UpdatedClassroom = await classroomService.UpdateAsync(user.Id, classroom.Id, request);
                FeedbackDialog.Success(FindForm()!, "Details updated", "Your classroom details have been updated successfully.");
                FindForm()?.Close();
            }
            catch (ValidationException exception)
            {
                FeedbackDialog.Error(FindForm()!, "Update failed", exception.Errors.First().ErrorMessage);
            }
            catch (InvalidOperationException exception)
            {
                FeedbackDialog.Error(FindForm()!, "Update failed", exception.Message);
            }
            catch (Exception)
            {
                FeedbackDialog.Error(FindForm()!, "Update failed", "Unable to update classroom details. Please try again.");
            }
            finally
            {
                SetBusy(false);
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            FindForm()?.Close();
        }

        private void SetBusy(bool busy)
        {
            loading = busy;
            UseWaitCursor = busy;
            nameInput.Enabled = !busy;
            sectionInput.Enabled = !busy;
            subjectInput.Enabled = !busy;
            roomInput.Enabled = !busy;
            scheduleInput.Enabled = !busy;
            levelInput.Enabled = !busy;
            saveButton.Enabled = !busy;
            cancelButton.Enabled = !busy;
        }
    }
}
