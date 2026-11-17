namespace brilliant_lms.Views.Classrooms
{
    partial class ClassroomsControl
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
            addClassButton = new AntdUI.Button();
            classroomsTab = new AntdUI.Tabs();
            classesTab = new AntdUI.TabPage();
            teachingsTab = new AntdUI.TabPage();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            classroomsTab.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.AutoContainerBgTransparent = true;
            panel1.Back = Color.Transparent;
            panel1.Controls.Add(panel2);
            panel1.Controls.Add(addClassButton);
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
            panel2.Dock = DockStyle.Left;
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(650, 80);
            panel2.TabIndex = 4;
            panel2.Text = "panel2";
            // 
            // description
            // 
            description.Font = new Font("Microsoft YaHei UI", 10F);
            description.Location = new Point(0, 36);
            description.Name = "description";
            description.Size = new Size(623, 19);
            description.TabIndex = 9;
            description.Text = "Access your classes, view assignments, and stay connected with your teachers and classmates.";
            // 
            // heading
            // 
            heading.Font = new Font("Microsoft YaHei UI", 18F, FontStyle.Bold);
            heading.Location = new Point(0, 0);
            heading.Name = "heading";
            heading.Size = new Size(623, 34);
            heading.TabIndex = 3;
            heading.Text = "Classrooms";
            // 
            // addClassButton
            // 
            addClassButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            addClassButton.IconSvg = "PlusOutlined";
            addClassButton.Location = new Point(812, 5);
            addClassButton.Margin = new Padding(0);
            addClassButton.Name = "addClassButton";
            addClassButton.Radius = 0;
            addClassButton.Size = new Size(140, 50);
            addClassButton.TabIndex = 2;
            addClassButton.Text = "Add Class";
            addClassButton.Type = AntdUI.TTypeMini.Primary;
            addClassButton.Click += addClassButton_Click;
            // 
            // classroomsTab
            // 
            classroomsTab.Controls.Add(classesTab);
            classroomsTab.Controls.Add(teachingsTab);
            classroomsTab.Dock = DockStyle.Fill;
            classroomsTab.Gap = 24;
            classroomsTab.Location = new Point(24, 96);
            classroomsTab.Margin = new Padding(0);
            classroomsTab.Name = "classroomsTab";
            classroomsTab.Pages.Add(classesTab);
            classroomsTab.Pages.Add(teachingsTab);
            classroomsTab.Size = new Size(952, 488);
            classroomsTab.Style = styleLine1;
            classroomsTab.TabIndex = 1;
            classroomsTab.Text = "classroomsTab";
            classroomsTab.SelectedIndexChanged += classroomsTab_SelectedIndexChanged;
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
            // ClassroomsControl
            // 
            AutoScaleDimensions = new SizeF(8F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(classroomsTab);
            Controls.Add(panel1);
            Font = new Font("Microsoft YaHei UI", 10F);
            Margin = new Padding(0);
            Name = "ClassroomsControl";
            Padding = new Padding(24, 16, 24, 16);
            Size = new Size(1000, 600);
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            classroomsTab.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private AntdUI.Panel panel1;
        private AntdUI.Button addClassButton;
        private AntdUI.Panel panel2;
        private AntdUI.Label heading;
        private AntdUI.Label description;
        private AntdUI.Tabs classroomsTab;
        private AntdUI.TabPage classesTab;
        private AntdUI.TabPage teachingsTab;
    }
}
