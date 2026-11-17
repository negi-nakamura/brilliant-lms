using brilliant_lms.Models.Entities;
using brilliant_lms.Utilities;

namespace brilliant_lms.Views.Settings
{
    public partial class AccountControl : UserControl
    {
        private User user;

        public AccountControl(User user)
        {
            this.user = user;
            InitializeComponent();
            InitializeControl();
        }

        private void InitializeControl()
        {
            avatar.Text = TextFormatter.GetInitials(user);
            fullnameLabel.Text = TextFormatter.GetFullName(user);
            emailLabel.Text = user.Email;
        }
    }
}
