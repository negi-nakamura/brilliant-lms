namespace brilliant_lms.Views.Classrooms.Teachings.Announcements
{
    partial class AnnouncementCardControl
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            if (disposing) brilliant_lms.Theme.ThemeManager.ThemeChanged -= ThemeManager_ThemeChanged;
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        private void InitializeComponent()
        {
            panel1 = new AntdUI.Panel();
            footerPanel = new AntdUI.Panel();
            likeIcon = new AntdUI.Avatar();
            likesLabel = new AntdUI.Label();
            optionsButton = new AntdUI.Button();
            footerDivider = new AntdUI.Divider();
            contentLabel = new AntdUI.Label();
            headerPanel = new AntdUI.Panel();
            avatar = new AntdUI.Avatar();
            creatorLabel = new AntdUI.Label();
            dateLabel = new AntdUI.Label();
            panel1.SuspendLayout();
            footerPanel.SuspendLayout();
            headerPanel.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BorderWidth = 1F;
            panel1.Controls.Add(footerPanel);
            panel1.Controls.Add(footerDivider);
            panel1.Controls.Add(contentLabel);
            panel1.Controls.Add(headerPanel);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Padding = new Padding(16);
            panel1.Radius = 0;
            panel1.Size = new Size(1100, 368);
            panel1.TabIndex = 0;
            // 
            // footerPanel
            // 
            footerPanel.Controls.Add(likeIcon);
            footerPanel.Controls.Add(likesLabel);
            footerPanel.Controls.Add(optionsButton);
            footerPanel.Dock = DockStyle.Top;
            footerPanel.Location = new Point(17, 120);
            footerPanel.Margin = new Padding(0);
            footerPanel.Name = "footerPanel";
            footerPanel.Radius = 0;
            footerPanel.Size = new Size(1066, 42);
            footerPanel.TabIndex = 7;
            footerPanel.LocationChanged += contentLabel_SizeChanged;
            // 
            // likeIcon
            // 
            likeIcon.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            likeIcon.ImageSvg = "LikeOutlined";
            likeIcon.Location = new Point(5, 11);
            likeIcon.Name = "likeIcon";
            likeIcon.Size = new Size(18, 18);
            likeIcon.TabIndex = 6;
            likeIcon.TabStop = false;
            // 
            // likesLabel
            // 
            likesLabel.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            likesLabel.Location = new Point(31, 8);
            likesLabel.Name = "likesLabel";
            likesLabel.Size = new Size(180, 24);
            likesLabel.TabIndex = 7;
            likesLabel.Text = "0 likes";
            likesLabel.TextMultiLine = false;
            // 
            // optionsButton
            // 
            optionsButton.AccessibleName = "Announcement options";
            optionsButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            optionsButton.Ghost = true;
            optionsButton.IconSvg = "MoreOutlined";
            optionsButton.Location = new Point(1026, 3);
            optionsButton.Name = "optionsButton";
            optionsButton.Radius = 0;
            optionsButton.Size = new Size(40, 36);
            optionsButton.TabIndex = 8;
            optionsButton.Click += optionsButton_Click;
            // 
            // footerDivider
            // 
            footerDivider.Dock = DockStyle.Top;
            footerDivider.Location = new Point(17, 112);
            footerDivider.Margin = new Padding(0);
            footerDivider.Name = "footerDivider";
            footerDivider.Size = new Size(1066, 8);
            footerDivider.TabIndex = 5;
            // 
            // contentLabel
            // 
            contentLabel.AutoSizeMode = AntdUI.TAutoSize.Height;
            contentLabel.Dock = DockStyle.Top;
            contentLabel.Location = new Point(17, 83);
            contentLabel.Margin = new Padding(0);
            contentLabel.Name = "contentLabel";
            contentLabel.Padding = new Padding(0, 6, 0, 6);
            contentLabel.Size = new Size(1066, 29);
            contentLabel.TabIndex = 3;
            contentLabel.Text = "Announcement content";
            contentLabel.TextAlign = ContentAlignment.TopLeft;
            contentLabel.SizeChanged += contentLabel_SizeChanged;
            // 
            // headerPanel
            // 
            headerPanel.Controls.Add(avatar);
            headerPanel.Controls.Add(creatorLabel);
            headerPanel.Controls.Add(dateLabel);
            headerPanel.Dock = DockStyle.Top;
            headerPanel.Location = new Point(17, 17);
            headerPanel.Margin = new Padding(0);
            headerPanel.Name = "headerPanel";
            headerPanel.Size = new Size(1066, 66);
            headerPanel.TabIndex = 6;
            // 
            // avatar
            // 
            avatar.BackColor = Color.FromArgb(22, 119, 255);
            avatar.Font = new Font("Microsoft YaHei UI Light", 14F, FontStyle.Bold);
            avatar.ForeColor = Color.White;
            avatar.Location = new Point(0, 0);
            avatar.Name = "avatar";
            avatar.Round = true;
            avatar.Size = new Size(44, 44);
            avatar.TabIndex = 0;
            avatar.Text = "A";
            // 
            // creatorLabel
            // 
            creatorLabel.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            creatorLabel.AutoEllipsis = true;
            creatorLabel.Font = new Font("Microsoft YaHei UI", 12F, FontStyle.Bold);
            creatorLabel.Location = new Point(56, 0);
            creatorLabel.Name = "creatorLabel";
            creatorLabel.Size = new Size(1010, 28);
            creatorLabel.TabIndex = 1;
            creatorLabel.Text = "Name of creator";
            creatorLabel.TextMultiLine = false;
            // 
            // dateLabel
            // 
            dateLabel.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            dateLabel.AutoEllipsis = true;
            dateLabel.Location = new Point(56, 28);
            dateLabel.Name = "dateLabel";
            dateLabel.Size = new Size(1010, 24);
            dateLabel.TabIndex = 2;
            dateLabel.Text = "Date created";
            dateLabel.TextMultiLine = false;
            // 
            // AnnouncementCardControl
            // 
            AutoScaleDimensions = new SizeF(8F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panel1);
            Font = new Font("Microsoft YaHei UI", 10F);
            Margin = new Padding(8);
            MinimumSize = new Size(1100, 0);
            Name = "AnnouncementCardControl";
            Size = new Size(1100, 368);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            footerPanel.ResumeLayout(false);
            headerPanel.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private AntdUI.Panel panel1;
        private AntdUI.Panel headerPanel;
        private AntdUI.Panel footerPanel;
        private AntdUI.Avatar avatar;
        private AntdUI.Label creatorLabel;
        private AntdUI.Label dateLabel;
        private AntdUI.Label contentLabel;
        private AntdUI.Divider footerDivider;
        private AntdUI.Avatar likeIcon;
        private AntdUI.Label likesLabel;
        private AntdUI.Button optionsButton;
    }
}
