namespace brilliant_lms.Views.Archived.Teachings.Announcements
{
    partial class AnnouncementsDirectoryControl
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
            if (disposing)
            {
                brilliant_lms.Theme.ThemeManager.ThemeChanged -= ThemeManager_ThemeChanged;
                illustrationImage.Image?.Dispose();
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
            announcementsContent = new AntdUI.StackPanel();
            emptyPanel = new AntdUI.Panel();
            illustrationContent = new AntdUI.Panel();
            illustrationImage = new AntdUI.Avatar();
            illustrationHeading = new AntdUI.Label();
            illustrationDescription = new AntdUI.Label();
            SuspendLayout();
            // 
            // announcementsContent
            // 
            announcementsContent.AutoScroll = true;
            announcementsContent.Back = Color.Transparent;
            announcementsContent.BackColor = Color.Transparent;
            announcementsContent.Dock = DockStyle.Fill;
            announcementsContent.Location = new Point(0, 0);
            announcementsContent.Margin = new Padding(0);
            announcementsContent.Name = "announcementsContent";
            announcementsContent.Padding = new Padding(0, 16, 0, 0);
            announcementsContent.Size = new Size(952, 447);
            announcementsContent.TabIndex = 0;
            announcementsContent.Text = "announcementsContent";
            announcementsContent.Vertical = true;
            announcementsContent.AutoContainerBgTransparent = true;
            //
            // emptyPanel
            //
            emptyPanel.AutoContainerBgTransparent = true;
            emptyPanel.Back = Color.Transparent;
            emptyPanel.BackColor = Color.Transparent;
            emptyPanel.Dock = DockStyle.Fill;
            emptyPanel.Name = "emptyPanel";
            emptyPanel.Size = new Size(952, 447);
            emptyPanel.Visible = false;
            emptyPanel.Controls.Add(illustrationContent);
            //
            // illustrationContent
            //
            illustrationContent.Anchor = AnchorStyles.None;
            illustrationContent.AutoContainerBgTransparent = true;
            illustrationContent.Back = Color.Transparent;
            illustrationContent.BackColor = Color.Transparent;
            illustrationContent.Location = new Point(236, 53);
            illustrationContent.Margin = new Padding(0);
            illustrationContent.Name = "illustrationContent";
            illustrationContent.Size = new Size(480, 340);
            illustrationContent.Controls.Add(illustrationImage);
            illustrationContent.Controls.Add(illustrationHeading);
            illustrationContent.Controls.Add(illustrationDescription);
            //
            // illustrationImage
            //
            illustrationImage.Location = new Point(80, 0);
            illustrationImage.Name = "illustrationImage";
            illustrationImage.Size = new Size(320, 240);
            illustrationImage.Text = "";
            //
            // illustrationHeading
            //
            illustrationHeading.Font = new Font("Microsoft YaHei UI", 14F, FontStyle.Bold);
            illustrationHeading.Location = new Point(0, 252);
            illustrationHeading.Name = "illustrationHeading";
            illustrationHeading.Size = new Size(480, 32);
            illustrationHeading.Text = "No announcements yet.";
            illustrationHeading.TextAlign = ContentAlignment.MiddleCenter;
            //
            // illustrationDescription
            //
            illustrationDescription.Location = new Point(0, 292);
            illustrationDescription.Name = "illustrationDescription";
            illustrationDescription.Size = new Size(480, 40);
            illustrationDescription.Text = "No announcements were posted in this archived class.";
            illustrationDescription.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // AnnouncementsDirectoryControl
            // 
            AutoScaleDimensions = new SizeF(8F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Transparent;
            Controls.Add(announcementsContent);
            Controls.Add(emptyPanel);
            Font = new Font("Microsoft YaHei UI", 10F);
            Margin = new Padding(3, 4, 3, 4);
            Name = "AnnouncementsDirectoryControl";
            Size = new Size(952, 447);
            Load += AnnouncementsDirectoryControl_Load;
            ResumeLayout(false);
        }

        #endregion

        private AntdUI.StackPanel announcementsContent;
        private AntdUI.Panel emptyPanel;
        private AntdUI.Panel illustrationContent;
        private AntdUI.Avatar illustrationImage;
        private AntdUI.Label illustrationHeading;
        private AntdUI.Label illustrationDescription;
    }
}
