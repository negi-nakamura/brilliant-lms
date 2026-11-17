namespace brilliant_lms.Views.Invites.Pending
{
    partial class InvitesDirectoryControl
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null) components.Dispose();
            if (disposing)
            {
                brilliant_lms.Theme.ThemeManager.ThemeChanged -= ThemeManager_ThemeChanged;
                illustrationImage.Image?.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        private void InitializeComponent()
        {
            invitesContent = new AntdUI.StackPanel();
            emptyPanel = new AntdUI.Panel();
            illustrationContent = new AntdUI.Panel();
            illustrationImage = new AntdUI.Avatar();
            illustrationHeading = new AntdUI.Label();
            illustrationDescription = new AntdUI.Label();
            SuspendLayout();
            invitesContent.AutoContainerBgTransparent = true;
            invitesContent.AutoScroll = true;
            invitesContent.Back = Color.Transparent;
            invitesContent.BackColor = Color.Transparent;
            invitesContent.Dock = DockStyle.Fill;
            invitesContent.Name = "invitesContent";
            invitesContent.Padding = new Padding(0, 16, 0, 0);
            invitesContent.Vertical = true;
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
            illustrationHeading.Text = "No pending invitations.";
            illustrationHeading.TextAlign = ContentAlignment.MiddleCenter;
            //
            // illustrationDescription
            //
            illustrationDescription.Location = new Point(0, 292);
            illustrationDescription.Name = "illustrationDescription";
            illustrationDescription.Size = new Size(480, 40);
            illustrationDescription.Text = "Invitations you send will appear here.";
            illustrationDescription.TextAlign = ContentAlignment.MiddleCenter;
            Controls.Add(invitesContent);
            Controls.Add(emptyPanel);
            Load += InvitesDirectoryControl_Load;
            AutoScaleDimensions = new SizeF(8F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Transparent;
            Font = new Font("Microsoft YaHei UI", 10F);
            Name = "InvitesDirectoryControl";
            Size = new Size(952, 447);
            ResumeLayout(false);
        }

        #endregion

        private AntdUI.StackPanel invitesContent;
        private AntdUI.Panel emptyPanel;
        private AntdUI.Panel illustrationContent;
        private AntdUI.Avatar illustrationImage;
        private AntdUI.Label illustrationHeading;
        private AntdUI.Label illustrationDescription;
    }
}
