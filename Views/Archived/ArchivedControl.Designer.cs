namespace brilliant_lms.Views.Archived
{
    partial class ArchivedControl
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
            archivedTabs = new AntdUI.Tabs();
            classesTab = new AntdUI.TabPage();
            teachingsTab = new AntdUI.TabPage();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            archivedTabs.SuspendLayout();
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
            description.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            description.AutoEllipsis = true;
            description.TextMultiLine = false;
            description.Font = new Font("Microsoft YaHei UI", 10F);
            description.Location = new Point(0, 36);
            description.Name = "description";
            description.Size = new Size(952, 19);
            description.TabIndex = 9;
            description.Text = "View your archived classes and saved learning materials.";
            // 
            // heading
            // 
            heading.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            heading.AutoEllipsis = true;
            heading.TextMultiLine = false;
            heading.Font = new Font("Microsoft YaHei UI", 18F, FontStyle.Bold);
            heading.Location = new Point(0, 0);
            heading.Name = "heading";
            heading.Size = new Size(952, 34);
            heading.TabIndex = 3;
            heading.Text = "Archived Classes";
            // 
            // archivedTabs
            // 
            archivedTabs.Controls.Add(classesTab);
            archivedTabs.Controls.Add(teachingsTab);
            archivedTabs.Dock = DockStyle.Fill;
            archivedTabs.Gap = 24;
            archivedTabs.Location = new Point(24, 96);
            archivedTabs.Margin = new Padding(0);
            archivedTabs.Name = "archivedTabs";
            archivedTabs.Pages.Add(classesTab);
            archivedTabs.Pages.Add(teachingsTab);
            archivedTabs.Size = new Size(952, 488);
            archivedTabs.Style = styleLine1;
            archivedTabs.TabIndex = 1;
            archivedTabs.Text = "archivedTabs";
            archivedTabs.SelectedIndexChanged += archivedTabs_SelectedIndexChanged;
            // 
            // classesTab
            // 
            classesTab.Location = new Point(0, 41);
            classesTab.Name = "classesTab";
            classesTab.Size = new Size(952, 447);
            classesTab.TabIndex = 0;
            classesTab.Text = "Classes";
            // 
            // teachingsTab
            // 
            teachingsTab.Location = new Point(0, 0);
            teachingsTab.Name = "teachingsTab";
            teachingsTab.Size = new Size(0, 0);
            teachingsTab.TabIndex = 1;
            teachingsTab.Text = "Teachings";
            //
            //
            // 
            // ArchivedControl
            // 
            AutoScaleDimensions = new SizeF(8F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(archivedTabs);
            Controls.Add(panel1);
            Font = new Font("Microsoft YaHei UI", 10F);
            Margin = new Padding(0);
            Name = "ArchivedControl";
            Padding = new Padding(24, 16, 24, 16);
            Size = new Size(1000, 600);
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            archivedTabs.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private AntdUI.Panel panel1;
        private AntdUI.Panel panel2;
        private AntdUI.Label heading;
        private AntdUI.Label description;
        private AntdUI.Tabs archivedTabs;
        private AntdUI.TabPage classesTab;
        private AntdUI.TabPage teachingsTab;
    }
}
