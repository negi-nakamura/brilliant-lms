using brilliant_lms.Models.Entities;
using brilliant_lms.Utilities;
using brilliant_lms.Models.Requests;
using brilliant_lms.Services;
using FluentValidation;

namespace brilliant_lms.Views.Classrooms
{
    public partial class CreateClassroomControl : UserControl
    {
        private User user;
        public Classroom? CreatedClassroom { get; private set; }
        private ClassroomService classroomService = new ClassroomService();
        private bool loading;

        public CreateClassroomControl(User user)
        {
            this.user = user;
            InitializeComponent();
            InitializeControl();
        }

        private void InitializeControl()
        {
            classNameInput.Text = "";
            createButton.Enabled = !loading;
        }

        private async void createButton_Click(object sender, EventArgs e)
        {
            if (loading) return;

            CreateClassroomRequest request = new CreateClassroomRequest
            {
                Name = classNameInput.Text.Trim()
            };

            SetBusy(true);

            try
            {
                CreatedClassroom = await classroomService.CreateAsync(user.Id, request);
                classNameInput.Text = "";
                FeedbackDialog.Success(FindForm()!, "Classroom created", $"{CreatedClassroom.Name} has been created.");
                FindForm()?.Close();
            }
            catch (ValidationException exception)
            {
                FeedbackDialog.Error(FindForm()!, "Create failed", exception.Errors.First().ErrorMessage);
            }
            catch (InvalidOperationException exception)
            {
                FeedbackDialog.Error(FindForm()!, "Create failed", exception.Message);
            }
            catch (Exception)
            {
                FeedbackDialog.Error(FindForm()!, "Create failed", "Unable to create the classroom. Please try again.");
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

            classNameInput.Enabled = !busy;
            
            createButton.Loading = busy;
            createButton.Enabled = !busy;
            cancelButton.Enabled = !busy;
        }
    }
}
