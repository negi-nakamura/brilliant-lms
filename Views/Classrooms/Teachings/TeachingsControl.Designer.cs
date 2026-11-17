namespace brilliant_lms.Views.Classrooms.Teachings
{
    partial class TeachingsControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            AntdUI.Tabs.StyleLine styleLine1 = new AntdUI.Tabs.StyleLine();
            panel1 = new AntdUI.Panel();
            panel2 = new AntdUI.Panel();
            description = new AntdUI.Label();
            heading = new AntdUI.Label();
            actionButton = new AntdUI.Button();
            teachingsTabControl = new AntdUI.Tabs();
            announcementsTab = new AntdUI.TabPage();
            assignmentsTab = new AntdUI.TabPage();
            resourcesTab = new AntdUI.TabPage();
            membersTab = new AntdUI.TabPage();
            detailsTab = new AntdUI.TabPage();
            reportsTab = new AntdUI.TabPage();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            teachingsTabControl.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.AutoContainerBgTransparent = true;
            panel1.Back = Color.Transparent;
            panel1.Controls.Add(panel2);
            panel1.Controls.Add(actionButton);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(24, 16);
            panel1.Name = "panel1";
            panel1.Size = new Size(952, 80);
            panel1.TabIndex = 0;
            panel1.Text = "panel1";
            // 
            // panel2
            // 
            panel2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel2.AutoContainerBgTransparent = true;
            panel2.Back = Color.Transparent;
            panel2.Controls.Add(description);
            panel2.Controls.Add(heading);
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(736, 80);
            panel2.TabIndex = 4;
            panel2.Text = "panel2";
            // 
            // description
            // 
            description.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            description.AutoEllipsis = true;
            description.Font = new Font("Microsoft YaHei UI", 10F);
            description.Location = new Point(0, 36);
            description.Name = "description";
            description.Size = new Size(736, 19);
            description.TabIndex = 9;
            description.Text = "Post announcements and keep your students informed.";
            description.TextMultiLine = false;
            // 
            // heading
            // 
            heading.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            heading.AutoEllipsis = true;
            heading.Font = new Font("Microsoft YaHei UI", 18F, FontStyle.Bold);
            heading.Location = new Point(0, 0);
            heading.Name = "heading";
            heading.Size = new Size(736, 34);
            heading.TabIndex = 3;
            heading.Text = "Class name";
            heading.TextMultiLine = false;
            // 
            // actionButton
            // 
            actionButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            actionButton.IconSvg = "PlusOutlined";
            actionButton.Location = new Point(752, 5);
            actionButton.Margin = new Padding(0);
            actionButton.Name = "actionButton";
            actionButton.Radius = 0;
            actionButton.Size = new Size(200, 50);
            actionButton.TabIndex = 2;
            actionButton.Text = "Create Announcement";
            actionButton.Type = AntdUI.TTypeMini.Primary;
            actionButton.Click += actionButton_Click;
            // 
            // teachingsTabControl
            // 
            teachingsTabControl.Controls.Add(announcementsTab);
            teachingsTabControl.Controls.Add(assignmentsTab);
            teachingsTabControl.Controls.Add(resourcesTab);
            teachingsTabControl.Controls.Add(membersTab);
            teachingsTabControl.Controls.Add(reportsTab);
            teachingsTabControl.Controls.Add(detailsTab);
            teachingsTabControl.Dock = DockStyle.Fill;
            teachingsTabControl.Gap = 24;
            teachingsTabControl.Location = new Point(24, 96);
            teachingsTabControl.Margin = new Padding(0);
            teachingsTabControl.Name = "teachingsTabControl";
            teachingsTabControl.Pages.Add(announcementsTab);
            teachingsTabControl.Pages.Add(assignmentsTab);
            teachingsTabControl.Pages.Add(resourcesTab);
            teachingsTabControl.Pages.Add(membersTab);
            teachingsTabControl.Pages.Add(reportsTab);
            teachingsTabControl.Pages.Add(detailsTab);
            teachingsTabControl.Size = new Size(952, 488);
            teachingsTabControl.Style = styleLine1;
            teachingsTabControl.TabIndex = 1;
            teachingsTabControl.Text = "teachingsTabControl";
            teachingsTabControl.SelectedIndexChanged += teachingsTabControl_SelectedIndexChanged;
            // 
            // announcementsTab
            // 
            announcementsTab.Location = new Point(0, 41);
            announcementsTab.Name = "announcementsTab";
            announcementsTab.Size = new Size(952, 447);
            announcementsTab.TabIndex = 0;
            announcementsTab.Text = "Announcements";
            // 
            // assignmentsTab
            // 
            assignmentsTab.Location = new Point(-1904, -894);
            assignmentsTab.Name = "assignmentsTab";
            assignmentsTab.Size = new Size(952, 447);
            assignmentsTab.TabIndex = 1;
            assignmentsTab.Text = "Assignments";
            // 
            // resourcesTab
            // 
            resourcesTab.Location = new Point(-1904, -894);
            resourcesTab.Name = "resourcesTab";
            resourcesTab.Size = new Size(952, 447);
            resourcesTab.TabIndex = 2;
            resourcesTab.Text = "Resources";
            // 
            // membersTab
            // 
            membersTab.Location = new Point(-1904, -894);
            membersTab.Name = "membersTab";
            membersTab.Size = new Size(952, 447);
            membersTab.TabIndex = 3;
            membersTab.Text = "Members";
            // 
            // detailsTab
            // 
            detailsTab.Location = new Point(-1904, -894);
            detailsTab.Name = "detailsTab";
            detailsTab.Size = new Size(952, 447);
            detailsTab.TabIndex = 4;
            detailsTab.Text = "Details";
            // 
            // reportsTab
            // 
            reportsTab.Location = new Point(-1904, -894);
            reportsTab.Name = "reportsTab";
            reportsTab.Size = new Size(952, 447);
            reportsTab.TabIndex = 5;
            reportsTab.Text = "Reports";
            // 
            // TeachingsControl
            // 
            AutoScaleDimensions = new SizeF(8F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(teachingsTabControl);
            Controls.Add(panel1);
            Font = new Font("Microsoft YaHei UI", 10F);
            Margin = new Padding(0);
            Name = "TeachingsControl";
            Padding = new Padding(24, 16, 24, 16);
            Size = new Size(1000, 600);
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            teachingsTabControl.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private AntdUI.Panel panel1;
        private AntdUI.Button actionButton;
        private AntdUI.Panel panel2;
        private AntdUI.Label heading;
        private AntdUI.Label description;
        private AntdUI.Tabs teachingsTabControl;
        private AntdUI.TabPage announcementsTab;
        private AntdUI.TabPage assignmentsTab;
        private AntdUI.TabPage resourcesTab;
        private AntdUI.TabPage membersTab;
        private AntdUI.TabPage detailsTab;
        private AntdUI.TabPage reportsTab;
    }
}
