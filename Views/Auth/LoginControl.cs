using brilliant_lms.Models.Requests;

namespace brilliant_lms.Views.Auth
{
    public partial class LoginControl : UserControl
    {
        public event EventHandler<LoginRequest>? LoginRequested;
        public event EventHandler? SwitchToRegisterRequested;

        public LoginControl()
        {
            InitializeComponent();
        }

        public void ClearFields()
        {
            emailInput.Clear();
            passwordInput.Clear();
            showPassword.Checked = false;
        }

        public void FocusFirstInput()
        {
            emailInput.Focus();
        }

        private void showPassword_CheckedChanged(object sender, AntdUI.BoolEventArgs e)
        {
            passwordInput.UseSystemPasswordChar = !showPassword.Checked;
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            LoginRequest request = new()
            {
                Email = emailInput.Text.Trim(),
                Password = passwordInput.Text
            };

            LoginRequested?.Invoke(this, request);
        }

        private void switchLink_LinkClicked(object sender, AntdUI.HyperlinkLabel.LinkClickedEventArgs e)
        {
            SwitchToRegisterRequested?.Invoke(this, EventArgs.Empty);
        }
    }
}
