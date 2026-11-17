namespace brilliant_lms.Views.Classrooms.Classes
{
    partial class ClassesControl
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
            classesTabControl = new AntdUI.Tabs();
            announcementsTab = new AntdUI.TabPage();
            assignmentsTab = new AntdUI.TabPage();
            resourcesTab = new AntdUI.TabPage();
            membersTab = new AntdUI.TabPage();
            detailsTab = new AntdUI.TabPage();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            classesTabControl.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.AutoContainerBgTransparent = true;
            panel1.Back = Color.Transparent;
            panel1.Controls.Add(panel2);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(24, 16);
            panel1.Name = "panel1";
            panel1.Size = new Size(952, 80);
            panel1.TabIndex = 0;
            panel1.Text = "panel1";
            // 
            // panel2
            // 
            panel2.AutoContainerBgTransparent = true;
            panel2.Back = Color.Transparent;
            panel2.Controls.Add(description);
            panel2.Controls.Add(heading);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(952, 80);
            panel2.TabIndex = 4;
            panel2.Text = "panel2";
            // 
            // description
            // 
            description.Font = new Font("Microsoft YaHei UI", 10F);
            description.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            description.AutoEllipsis = true;
            description.TextMultiLine = false;
            description.Location = new Point(0, 36);
            description.Name = "description";
            description.Size = new Size(952, 19);
            description.TabIndex = 9;
            description.Text = "Stay up to date with class announcements.";
            // 
            // heading
            // 
            heading.Font = new Font("Microsoft YaHei UI", 18F, FontStyle.Bold);
            heading.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            heading.AutoEllipsis = true;
            heading.TextMultiLine = false;
            heading.Location = new Point(0, 0);
            heading.Name = "heading";
            heading.Size = new Size(952, 34);
            heading.TabIndex = 3;
            heading.Text = "Class name";
            // 
            // classesTabControl
            // 
            classesTabControl.Controls.Add(announcementsTab);
            classesTabControl.Controls.Add(assignmentsTab);
            classesTabControl.Controls.Add(resourcesTab);
            classesTabControl.Controls.Add(membersTab);
            classesTabControl.Controls.Add(detailsTab);
            classesTabControl.Dock = DockStyle.Fill;
            classesTabControl.Gap = 24;
            classesTabControl.Location = new Point(24, 96);
            classesTabControl.Margin = new Padding(0);
            classesTabControl.Name = "classesTabControl";
            classesTabControl.Pages.Add(announcementsTab);
            classesTabControl.Pages.Add(assignmentsTab);
            classesTabControl.Pages.Add(resourcesTab);
            classesTabControl.Pages.Add(membersTab);
            classesTabControl.Pages.Add(detailsTab);
            classesTabControl.Size = new Size(952, 488);
            classesTabControl.Style = styleLine1;
            classesTabControl.TabIndex = 1;
            classesTabControl.Text = "classesTabControl";
            classesTabControl.SelectedIndexChanged += classesTabControl_SelectedIndexChanged;
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
            assignmentsTab.Location = new Point(0, 41);
            assignmentsTab.Name = "assignmentsTab";
            assignmentsTab.Size = new Size(952, 447);
            assignmentsTab.TabIndex = 1;
            assignmentsTab.Text = "Assignments";
            //
            // resourcesTab
            //
            resourcesTab.Location = new Point(0, 41);
            resourcesTab.Name = "resourcesTab";
            resourcesTab.Size = new Size(952, 447);
            resourcesTab.TabIndex = 2;
            resourcesTab.Text = "Resources";
            //
            // membersTab
            //
            membersTab.Location = new Point(0, 41);
            membersTab.Name = "membersTab";
            membersTab.Size = new Size(952, 447);
            membersTab.TabIndex = 3;
            membersTab.Text = "Members";
            //
            // detailsTab
            //
            detailsTab.Location = new Point(0, 41);
            detailsTab.Name = "detailsTab";
            detailsTab.Size = new Size(952, 447);
            detailsTab.TabIndex = 4;
            detailsTab.Text = "Details";
            //
            // ClassesControl
            // 
            AutoScaleDimensions = new SizeF(8F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(classesTabControl);
            Controls.Add(panel1);
            Font = new Font("Microsoft YaHei UI", 10F);
            Margin = new Padding(0);
            Name = "ClassesControl";
            Padding = new Padding(24, 16, 24, 16);
            Size = new Size(1000, 600);
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            classesTabControl.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private AntdUI.Panel panel1;
        private AntdUI.Panel panel2;
        private AntdUI.Label heading;
        private AntdUI.Label description;
        private AntdUI.Tabs classesTabControl;
        private AntdUI.TabPage announcementsTab;
        private AntdUI.TabPage assignmentsTab;
        private AntdUI.TabPage resourcesTab;
        private AntdUI.TabPage membersTab;
        private AntdUI.TabPage detailsTab;
    }
}
