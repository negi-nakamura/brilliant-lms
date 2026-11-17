using brilliant_lms.Models.Requests;

namespace brilliant_lms.Views.Auth
{
    public partial class RegisterControl : UserControl
    {
        public event EventHandler<RegisterRequest>? RegisterRequested;
        public event EventHandler? SwitchToLoginRequested;

        public RegisterControl()
        {
            InitializeComponent();
        }

        public void clearFields()
        {
            firstNameInput.Clear();
            middleNameInput.Clear();
            lastNameInput.Clear();
            emailInput.Clear();
            passwordInput.Clear();
            confirmPasswordInput.Clear();
            showPassword.Checked = false;
        }

        public void FocusFirstInput()
        {
            firstNameInput.Focus();
        }

        private void showPassword_CheckedChanged(object sender, AntdUI.BoolEventArgs e)
        {
            passwordInput.UseSystemPasswordChar = !showPassword.Checked;
            confirmPasswordInput.UseSystemPasswordChar = !showPassword.Checked;
        }

        private void registerButton_Click(object sender, EventArgs e)
        {
            RegisterRequest request = new RegisterRequest
            {
                FirstName = firstNameInput.Text,
                MiddleName = middleNameInput.Text,
                LastName = lastNameInput.Text,
                Email = emailInput.Text,
                Password = passwordInput.Text,
                ConfirmPassword = confirmPasswordInput.Text
            };

            RegisterRequested?.Invoke(this, request);
        }

        private void switchLink_LinkClicked(object sender, AntdUI.HyperlinkLabel.LinkClickedEventArgs e)
        {
            SwitchToLoginRequested?.Invoke(this, EventArgs.Empty);
        }

    }
}
