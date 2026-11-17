using brilliant_lms.Models.Entities;
using brilliant_lms.Models.Requests;
using brilliant_lms.Services;
using brilliant_lms.Theme;
using brilliant_lms.Utilities;
using FluentValidation;

namespace brilliant_lms.Views.Auth
{
    public partial class AuthForm : AntdUI.Window
    {
        private AuthService authService = new AuthService();
        public User? AuthenticatedUser { get; private set; }
        private bool loading = false;

        public AuthForm()
        {
            InitializeComponent();
            registerControl.Hide();
            loginControl.Show();
            loginControl.FocusFirstInput();
            illustrationImage.Image = ResourceImage.Load("Illustrations.Auth.login.gif");
            loginControl.LoginRequested += LoginControl_LoginRequested;
            loginControl.SwitchToRegisterRequested += LoginControl_SwitchToRegisterRequested;
            registerControl.RegisterRequested += RegisterControl_RegisterRequested;
            registerControl.SwitchToLoginRequested += RegisterControl_SwitchToLoginRequested;
        }

        public void LoginControl_SwitchToRegisterRequested(object? sender, EventArgs e)
        {
            loginControl.ClearFields();
            loginControl.Hide();
            registerControl.Show();
            registerControl.FocusFirstInput();
            illustrationImage.Image = ResourceImage.Load("Illustrations.Auth.register.gif");
            illustrationHeading.Text = "A place for every learner.";
            illustrationDescription.Text = "Join your classmates and stay on top of your learning.";
        }

        public void RegisterControl_SwitchToLoginRequested(object? sender, EventArgs e)
        {
            registerControl.clearFields();
            registerControl.Hide();
            loginControl.Show();
            loginControl.FocusFirstInput();
            illustrationImage.Image = ResourceImage.Load("Illustrations.Auth.login.gif");
            illustrationHeading.Text = "Your next chapter starts here.";
            illustrationDescription.Text = "Stay connected to your classes, teachers, and learning.";
        }

        public async void LoginControl_LoginRequested(object? sender, LoginRequest loginRequest)
        {
            if (loading) return;

            loading = true;
            loginControl.Enabled = false;
            UseWaitCursor = true;

            try
            {
                AuthenticatedUser = await authService.LoginAsync(loginRequest);
                DialogResult = DialogResult.OK;
            }
            catch (ValidationException exception)
            {
                FeedbackDialog.Error(FindForm()!, "Login failed", exception.Errors.First().ErrorMessage);
            }
            catch (InvalidOperationException exception)
            {
                FeedbackDialog.Error(FindForm()!, "Login failed", exception.Message);
            }
            catch (Exception exception)
            {
                FeedbackDialog.Error(FindForm()!, "Registration failed", exception.Message);
            }
            finally
            {
                loading = false;
                loginControl.Enabled = true;
                UseWaitCursor = false;
            }
        }

        public async void RegisterControl_RegisterRequested(object? sender, RegisterRequest registerRequest)
        {
            if (loading) return;

            loading = true;
            registerControl.Enabled = false;
            UseWaitCursor = true;

            try
            {
                AuthenticatedUser = await authService.RegisterAsync(registerRequest);
                DialogResult = DialogResult.OK;
            }
            catch (ValidationException exception)
            {
                FeedbackDialog.Error(FindForm()!, "Registration failed", exception.Errors.First().ErrorMessage);
            }
            catch (InvalidOperationException exception)
            {
                FeedbackDialog.Error(FindForm()!, "Registration failed", exception.Message);
            }
            catch (Exception exception)
            {
                FeedbackDialog.Error(FindForm()!, "Registration failed", exception.Message);
            }
            finally
            {
                loading = false;
                registerControl.Enabled = true;
                UseWaitCursor = false;
            }
        }

        private void themeButton_Click(object sender, EventArgs e)
        {
            ThemeManager.Toggle();
        }
    }
}
