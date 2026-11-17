using AntdUI;
using brilliant_lms.Models.Entities;
using brilliant_lms.Theme;
using brilliant_lms.Views.Classrooms;
using brilliant_lms.Views.Classrooms.Classes;
using brilliant_lms.Views.Classrooms.Teachings;
using brilliant_lms.Views.Settings;

namespace brilliant_lms.Views.Shell
{
    public partial class Main : AntdUI.Window
    {
        private User user;
        public event EventHandler? SignOutRequested;

        public Main(User user)
        {
            this.user = user;
            InitializeComponent();
            InitializeControl();
        }

        private void InitializeControl()
        {
            ClassroomsControl view = new ClassroomsControl(user)
            {
                Dock = DockStyle.Fill
            };
            view.ClassroomRequested += ClassroomsControl_ClassroomRequested;
            view.TeachingRequested += ClassroomsControl_TeachingRequested;
            classroomsTab.Controls.Add(view);
        }

        private void InvitesControl_InvitationChanged(object? sender, EventArgs e)
        {
            foreach (AntdUI.TabPage page in contentTabs.Pages)
            {
                if (page.Name != "classrooms") continue;
                foreach (Control control in page.Controls)
                {
                    if (control is ClassroomsControl classrooms) classrooms.RefreshControl();
                }
            }
        }

        private void themeButton_Click(object sender, EventArgs e)
        {
            ThemeManager.Toggle();
        }
        private void userButton_Click(object sender, EventArgs e)
        {
            ContextMenuStripItem accountItem = new ContextMenuStripItem("Account") { IconSvg = "UserOutlined" };
            ContextMenuStripItem settingsItem = new ContextMenuStripItem("Settings") { IconSvg = "SettingOutlined" };
            ContextMenuStripItem signOutItem = new ContextMenuStripItem("Sign Out") { IconSvg = "LogoutOutlined" };

            AntdUI.ContextMenuStrip.open(new(userButton, HandleUserMenuSelection, new IContextMenuStripItem[]
            {
                accountItem,
                settingsItem,
                new ContextMenuStripItemDivider(),
                signOutItem
            })
            {
                Align = TAlign.Bottom,
            });

            void HandleUserMenuSelection(IContextMenuStrip item)
            {
                if (item == accountItem)
                    ShowAccountControl();
                else if (item == settingsItem)
                    ShowSettings();
                else if (item == signOutItem)
                    SignOutRequested?.Invoke(this, EventArgs.Empty);
            }
        }

        private void ShowAccountControl()
        {
            using AccountControl accountControl = new AccountControl(user);
            AutoDpi(accountControl);
            AntdUI.Modal.open(new AntdUI.Modal.Config(this, "Account", accountControl, TType.None)
            {
                MaskClosable = false,
                CloseIcon = true,
                BtnHeight = 0
            });
        }

        private void ShowSettings()
        {
            using SettingControl settingsControl = new SettingControl(user);
            AutoDpi(settingsControl);
            AntdUI.Modal.open(new AntdUI.Modal.Config(this, "Settings", settingsControl, TType.None)
            {
                MaskClosable = false,
                CloseIcon = true,
                BtnHeight = 0
            });
        }

        private void collapseButton_Click(object sender, EventArgs e)
        {
            navigationMenu.Collapsed = !navigationMenu.Collapsed;
            sidebarPanel.Width = navigationMenu.Collapsed ? 60 : 250;
            collapseButton.Toggle = !navigationMenu.Collapsed;
        }

        private void navigationMenu_SelectChanged(object sender, AntdUI.MenuSelectEventArgs e)
        {
            switch (e.Value.ID)
            {
                case "invites":
                    OpenInvitesTab();
                    break;

                case "classrooms":
                    OpenClassroomsTab();
                    break;

                case "archived":
                    OpenArchivedTab();
                    break;

                case "settings":

                    break;
            }
        }

        private void OpenInvitesTab()
        {
            foreach (AntdUI.TabPage page in contentTabs.Pages)
            {
                if (page.Name == "invites")
                {
                    contentTabs.SelectedTab = page;
                    foreach (Control control in page.Controls)
                    {
                        if (control is brilliant_lms.Views.Invites.InvitesControl invites) invites.RefreshControl();
                    }
                    return;
                }
            }
            brilliant_lms.Views.Invites.InvitesControl view = new brilliant_lms.Views.Invites.InvitesControl(user)
            {
                Dock = DockStyle.Fill
            };
            view.InvitationChanged += InvitesControl_InvitationChanged;
            AntdUI.TabPage tab = new AntdUI.TabPage
            {
                Name = "invites",
                Text = "Invites",
                IconSvg = "MailOutlined"
            };
            tab.Controls.Add(view);
            contentTabs.Pages.Add(tab);
            contentTabs.SelectedTab = tab;
        }

        private void OpenArchivedTab()
        {
            foreach (AntdUI.TabPage page in contentTabs.Pages)
            {
                if (page.Name == "archived")
                {
                    contentTabs.SelectedTab = page;
                    return;
                }
            }

            brilliant_lms.Views.Archived.ArchivedControl view = new brilliant_lms.Views.Archived.ArchivedControl(user)
            {
                Dock = DockStyle.Fill
            };
            view.ClassroomRequested += ArchivedControl_ClassroomRequested;
            view.TeachingRequested += ArchivedControl_TeachingRequested;
            view.ClassroomChanged += ArchivedControl_ClassroomChanged;

            AntdUI.TabPage tab = new AntdUI.TabPage
            {
                Name = "archived",
                Text = "Archived",
                IconSvg = "InboxOutlined"
            };
            tab.Controls.Add(view);
            contentTabs.Pages.Add(tab);
            contentTabs.SelectedTab = tab;
        }

        private void OpenClassroomsTab()
        {
            foreach (AntdUI.TabPage page in contentTabs.Pages)
            {
                if (page.Name == "classrooms")
                {
                    contentTabs.SelectedTab = page;
                    return;
                }
            }

            ClassroomsControl view = new ClassroomsControl(user)
            {
                Dock = DockStyle.Fill
            };

            view.ClassroomRequested += ClassroomsControl_ClassroomRequested;
            view.TeachingRequested += ClassroomsControl_TeachingRequested;

            AntdUI.TabPage tab = new AntdUI.TabPage
            {
                Name = "classrooms",
                Text = "Classrooms",
                IconSvg = "BookOutlined"
            };

            tab.Controls.Add(view);
            contentTabs.Pages.Add(tab);
            contentTabs.SelectedTab = tab;
        }

        private void ClassroomsControl_ClassroomRequested(object? sender, Classroom classroom)
        {
            OpenClassTab(classroom);
        }

        private void OpenClassTab(Classroom classroom)
        {
            string tabName = $"class_{classroom.Id}";

            foreach (AntdUI.TabPage page in contentTabs.Pages)
            {
                if (page.Name == tabName)
                {
                    contentTabs.SelectedTab = page;
                    return;
                }
            }

            ClassesControl view = new ClassesControl(user, classroom)
            {
                Dock = DockStyle.Fill
            };

            AntdUI.TabPage tab = new AntdUI.TabPage
            {
                Name = tabName,
                Text = classroom.Name,
                IconSvg = "BookOutlined"
            };

            tab.Controls.Add(view);
            contentTabs.Pages.Add(tab);
            contentTabs.SelectedTab = tab;
        }

        private void ClassroomsControl_TeachingRequested(object? sender, Classroom classroom)
        {
            OpenTeachingTab(classroom);
        }

        private void OpenTeachingTab(Classroom classroom)
        {
            string tabName = $"teaching_{classroom.Id}";

            foreach (AntdUI.TabPage page in contentTabs.Pages)
            {
                if (page.Name == tabName)
                {
                    contentTabs.SelectedTab = page;
                    return;
                }
            }

            TeachingsControl view = new TeachingsControl(user, classroom)
            {
                Dock = DockStyle.Fill
            };

            AntdUI.TabPage tab = new AntdUI.TabPage
            {
                Name = tabName,
                Text = classroom.Name,
                IconSvg = "BookOutlined"
            };

            tab.Controls.Add(view);
            contentTabs.Pages.Add(tab);
            contentTabs.SelectedTab = tab;
        }

        private void ArchivedControl_ClassroomRequested(object? sender, Classroom classroom)
        {
            OpenArchivedClassTab(classroom);
        }

        private void ArchivedControl_TeachingRequested(object? sender, Classroom classroom)
        {
            OpenArchivedTeachingTab(classroom);
        }

        private void ArchivedControl_ClassroomChanged(object? sender, Classroom classroom)
        {
            List<AntdUI.TabPage> pages = new List<AntdUI.TabPage>();
            foreach (AntdUI.TabPage page in contentTabs.Pages)
            {
                if (page.Name == $"class_{classroom.Id}" || page.Name == $"teaching_{classroom.Id}" ||
                    page.Name == $"archived_class_{classroom.Id}" || page.Name == $"archived_teaching_{classroom.Id}")
                    pages.Add(page);
            }
            foreach (AntdUI.TabPage page in pages)
            {
                contentTabs.Pages.Remove(page);
                page.Dispose();
            }
        }

        private void OpenArchivedClassTab(Classroom classroom)
        {
            string tabName = $"archived_class_{classroom.Id}";

            foreach (AntdUI.TabPage page in contentTabs.Pages)
            {
                if (page.Name == tabName)
                {
                    contentTabs.SelectedTab = page;
                    return;
                }
            }

            brilliant_lms.Views.Archived.Classes.ClassesControl view = new brilliant_lms.Views.Archived.Classes.ClassesControl(user, classroom)
            {
                Dock = DockStyle.Fill
            };

            AntdUI.TabPage tab = new AntdUI.TabPage
            {
                Name = tabName,
                Text = classroom.Name,
                IconSvg = "InboxOutlined"
            };

            tab.Controls.Add(view);
            contentTabs.Pages.Add(tab);
            contentTabs.SelectedTab = tab;
        }

        private void OpenArchivedTeachingTab(Classroom classroom)
        {
            string tabName = $"archived_teaching_{classroom.Id}";

            foreach (AntdUI.TabPage page in contentTabs.Pages)
            {
                if (page.Name == tabName)
                {
                    contentTabs.SelectedTab = page;
                    return;
                }
            }

            brilliant_lms.Views.Archived.Teachings.TeachingsControl view = new brilliant_lms.Views.Archived.Teachings.TeachingsControl(user, classroom)
            {
                Dock = DockStyle.Fill
            };

            AntdUI.TabPage tab = new AntdUI.TabPage
            {
                Name = tabName,
                Text = classroom.Name,
                IconSvg = "InboxOutlined"
            };

            tab.Controls.Add(view);
            contentTabs.Pages.Add(tab);
            contentTabs.SelectedTab = tab;
        }

    }
}
