using brilliant_lms.Models.Entities;
using brilliant_lms.Models.Requests;
using brilliant_lms.Services;
using brilliant_lms.Views.Auth;
using brilliant_lms.Views.Shell;

namespace brilliant_lms
{
    public static class Application
    {
        private static Main? mainForm;
        private static bool signedOut;

        public static void Initialize()
        {
            //User? user = AutoLogin();
            User? user = null;

            signedOut = true;

            while (signedOut)
            {
                signedOut = false;

                if (user == null)
                {
                    using AuthForm auth = new AuthForm();
                    if (auth.ShowDialog() != DialogResult.OK) return;
                    user = auth.AuthenticatedUser;
                    if (user == null) return;
                }

                using Main main = new Main(user);
                mainForm = main;
                main.SignOutRequested += OnSignOutRequested;

                try
                {
                    System.Windows.Forms.Application.Run(main);
                }
                finally
                {
                    main.SignOutRequested -= OnSignOutRequested;
                    mainForm = null;
                    user = null;
                }
            }
        }

        private static void OnSignOutRequested(object? sender, EventArgs e)
        {
            signedOut = true;
            mainForm?.Close();
        }

        private static User? AutoLogin()
        {
            AuthService authService = new AuthService();

            LoginRequest loginRequest = new LoginRequest
            {
                Email = "regalado999@gmail.com",
                Password = "Christ#15"
            };

            try
            {
                return Task.Run(() => authService.LoginAsync(loginRequest)).GetAwaiter().GetResult();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Auto-login failed");
                return null;
            }
        }
    }
}
