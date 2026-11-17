using brilliant_lms.Models.Entities;

namespace brilliant_lms.Views.Settings
{
    public partial class SettingControl : UserControl
    {
        private readonly User user;

        public SettingControl(User user)
        {
            this.user = user;
            InitializeComponent();
            InitializeControl();
        }

        private void InitializeControl()
        {
            ShowSelectedControl();
        }

        private void settingsTab_SelectedIndexChanged(object sender, AntdUI.IntEventArgs e)
        {
            ShowSelectedControl();
        }

        private void ShowSelectedControl()
        {
            DisposeControlsTab();

            AntdUI.TabPage? selected = settingsTab.SelectedTab;
            Control view;

            if (selected == informationTab)
                view = new PersonalInformationControl(user);
            else if (selected == securityTab)
                view = new SecurityControl(user);
            else
                return; 

            view.Dock = DockStyle.Fill;
            view.TabIndex = 0;
            selected.Controls.Add(view);
        }

        private void DisposeControlsTab()
        {
            foreach (AntdUI.TabPage page in settingsTab.Pages)
            {
                while (page.Controls.Count > 0)
                {
                    Control previous = page.Controls[0];
                    page.Controls.Remove(previous);
                    previous.Dispose();
                }
            }
        }

    }
}
