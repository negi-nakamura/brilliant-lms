namespace brilliant_lms.Views.Shell
{
    partial class Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            AntdUI.MenuItem menuItem1 = new AntdUI.MenuItem();
            AntdUI.MenuItem menuItem2 = new AntdUI.MenuItem();
            AntdUI.MenuItem menuItem3 = new AntdUI.MenuItem();
            AntdUI.Tabs.StyleCard styleCard1 = new AntdUI.Tabs.StyleCard();
            titleBar = new AntdUI.PageHeader();
            themeButton = new AntdUI.Button();
            userButton = new AntdUI.Button();
            sidebarPanel = new AntdUI.Panel();
            navigationMenu = new AntdUI.Menu();
            collapseButton = new AntdUI.Button();
            panel1 = new AntdUI.Panel();
            contentTabs = new AntdUI.Tabs();
            classroomsTab = new AntdUI.TabPage();
            titleBar.SuspendLayout();
            sidebarPanel.SuspendLayout();
            contentTabs.SuspendLayout();
            classroomsTab.SuspendLayout();
            SuspendLayout();
            // 
            // titleBar
            // 
            titleBar.Controls.Add(themeButton);
            titleBar.Controls.Add(userButton);
            titleBar.DividerShow = true;
            titleBar.Dock = DockStyle.Top;
            titleBar.Location = new Point(0, 0);
            titleBar.Margin = new Padding(3, 4, 3, 4);
            titleBar.Name = "titleBar";
            titleBar.ShowButton = true;
            titleBar.ShowIcon = true;
            titleBar.Size = new Size(1280, 36);
            titleBar.SubText = "Learning Management System";
            titleBar.TabIndex = 1;
            titleBar.Text = "Brilliant";
            // 
            // themeButton
            // 
            themeButton.AccessibleName = "Switch light or dark mode";
            themeButton.Dock = DockStyle.Right;
            themeButton.Ghost = true;
            themeButton.IconSvg = "SunOutlined";
            themeButton.Location = new Point(1022, 0);
            themeButton.Margin = new Padding(3, 4, 3, 4);
            themeButton.Name = "themeButton";
            themeButton.Radius = 0;
            themeButton.Size = new Size(57, 36);
            themeButton.TabIndex = 0;
            themeButton.ToggleIconSvg = "MoonOutlined";
            themeButton.WaveSize = 0;
            themeButton.Click += themeButton_Click;
            // 
            // userButton
            // 
            userButton.AccessibleName = "User settings";
            userButton.Dock = DockStyle.Right;
            userButton.Ghost = true;
            userButton.IconSvg = "UserOutlined";
            userButton.Location = new Point(1079, 0);
            userButton.Margin = new Padding(3, 4, 3, 4);
            userButton.Name = "userButton";
            userButton.Radius = 0;
            userButton.Size = new Size(57, 36);
            userButton.TabIndex = 1;
            userButton.WaveSize = 0;
            userButton.Click += userButton_Click;
            // 
            // sidebarPanel
            // 
            sidebarPanel.Back = Color.Transparent;
            sidebarPanel.Controls.Add(navigationMenu);
            sidebarPanel.Controls.Add(collapseButton);
            sidebarPanel.Dock = DockStyle.Left;
            sidebarPanel.Location = new Point(0, 36);
            sidebarPanel.Margin = new Padding(3, 4, 3, 4);
            sidebarPanel.Name = "sidebarPanel";
            sidebarPanel.Radius = 0;
            sidebarPanel.Size = new Size(60, 684);
            sidebarPanel.TabIndex = 1;
            sidebarPanel.Text = "panel1";
            // 
            // navigationMenu
            // 
            navigationMenu.Collapsed = true;
            navigationMenu.Dock = DockStyle.Fill;
            navigationMenu.IconRatio = 1F;
            navigationMenu.Indent = true;
            menuItem1.IconSvg = "MailOutlined";
            menuItem1.ID = "invites";
            menuItem1.Tag = "invites";
            menuItem1.Text = "Invites";
            menuItem2.Expand = false;
            menuItem2.IconSvg = "ReadOutlined";
            menuItem2.ID = "classrooms";
            menuItem2.Tag = "classroom";
            menuItem2.Text = "Classrooms";
            menuItem3.Expand = false;
            menuItem3.IconSvg = "InboxOutlined";
            menuItem3.ID = "archived";
            menuItem3.Tag = "archived";
            menuItem3.Text = "Archived";
            navigationMenu.Items.Add(menuItem2);
            navigationMenu.Items.Add(menuItem3);
            navigationMenu.Items.Add(menuItem1);
            navigationMenu.Location = new Point(0, 0);
            navigationMenu.Name = "navigationMenu";
            navigationMenu.Padding = new Padding(4);
            navigationMenu.Radius = 0;
            navigationMenu.Size = new Size(60, 634);
            navigationMenu.TabIndex = 3;
            navigationMenu.Unique = true;
            navigationMenu.SelectChanged += navigationMenu_SelectChanged;
            // 
            // collapseButton
            // 
            collapseButton.Dock = DockStyle.Bottom;
            collapseButton.Ghost = true;
            collapseButton.IconRatio = 1F;
            collapseButton.IconSvg = "MenuUnfoldOutlined";
            collapseButton.Location = new Point(0, 634);
            collapseButton.Margin = new Padding(3, 4, 3, 4);
            collapseButton.Name = "collapseButton";
            collapseButton.Radius = 0;
            collapseButton.Size = new Size(60, 50);
            collapseButton.TabIndex = 2;
            collapseButton.ToggleIconSvg = "MenuFoldOutlined";
            collapseButton.WaveSize = 0;
            collapseButton.Click += collapseButton_Click;
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.Control;
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(60, 36);
            panel1.Name = "panel1";
            panel1.Size = new Size(1, 684);
            panel1.TabIndex = 2;
            panel1.Text = "panel1";
            // 
            // contentTabs
            // 
            contentTabs.Controls.Add(classroomsTab);
            contentTabs.Dock = DockStyle.Fill;
            contentTabs.Gap = 16;
            contentTabs.Location = new Point(61, 36);
            contentTabs.Name = "contentTabs";
            contentTabs.Pages.Add(classroomsTab);
            contentTabs.Size = new Size(1219, 684);
            styleCard1.Closable = true;
            contentTabs.Style = styleCard1;
            contentTabs.TabIndex = 3;
            contentTabs.Text = "tabs1";
            contentTabs.Type = AntdUI.TabType.Card;
            // 
            // classroomsTab
            // 
            classroomsTab.Cursor = Cursors.Hand;
            classroomsTab.IconSvg = "ReadOutlined";
            classroomsTab.Location = new Point(0, 36);
            classroomsTab.Name = "classrooms";
            classroomsTab.ReadOnly = true;
            classroomsTab.Size = new Size(1219, 648);
            classroomsTab.TabIndex = 0;
            classroomsTab.Text = "Classrooms";
            // 
            // Main
            // 
            AutoScaleDimensions = new SizeF(8F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1280, 720);
            Controls.Add(contentTabs);
            Controls.Add(panel1);
            Controls.Add(sidebarPanel);
            Controls.Add(titleBar);
            Font = new Font("Microsoft YaHei UI", 10F);
            Margin = new Padding(3, 4, 3, 4);
            Name = "Main";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Main";
            WindowState = FormWindowState.Maximized;
            titleBar.ResumeLayout(false);
            sidebarPanel.ResumeLayout(false);
            contentTabs.ResumeLayout(false);
            classroomsTab.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private AntdUI.PageHeader titleBar;
        private AntdUI.Button themeButton;
        private AntdUI.Button userButton;
        private AntdUI.Panel sidebarPanel;
        private AntdUI.Button collapseButton;
        private AntdUI.Menu navigationMenu;
        private AntdUI.Panel panel1;
        private AntdUI.Tabs contentTabs;
        private AntdUI.TabPage classroomsTab;
    }
}