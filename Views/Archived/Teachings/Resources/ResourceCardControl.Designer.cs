namespace brilliant_lms.Views.Archived.Teachings.Resources
{
    partial class ResourceCardControl
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
            attachmentButton = new AntdUI.Button();
            footerDivider = new AntdUI.Divider();
            contentLabel = new AntdUI.Label();
            titleLabel = new AntdUI.Label();
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
            panel1.Controls.Add(titleLabel);
            panel1.Controls.Add(headerPanel);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Padding = new Padding(16);
            panel1.Radius = 0;
            panel1.Size = new Size(1100, 226);
            panel1.TabIndex = 0;
            // 
            // footerPanel
            // 
            footerPanel.Controls.Add(attachmentButton);
            footerPanel.Dock = DockStyle.Top;
            footerPanel.Location = new Point(17, 152);
            footerPanel.Margin = new Padding(0);
            footerPanel.Name = "footerPanel";
            footerPanel.Radius = 0;
            footerPanel.Size = new Size(1066, 42);
            footerPanel.TabIndex = 7;
            footerPanel.LocationChanged += contentLabel_SizeChanged;
            // 
            // attachmentButton
            // 
            attachmentButton.Ghost = true;
            attachmentButton.IconSvg = "LinkOutlined";
            attachmentButton.Location = new Point(0, 3);
            attachmentButton.Name = "attachmentButton";
            attachmentButton.Radius = 0;
            attachmentButton.Size = new Size(170, 36);
            attachmentButton.TabIndex = 8;
            attachmentButton.Text = "Attachment links";
            attachmentButton.Click += attachmentButton_Click;
            // 
            // footerDivider
            // 
            footerDivider.Dock = DockStyle.Top;
            footerDivider.Location = new Point(17, 144);
            footerDivider.Margin = new Padding(0);
            footerDivider.Name = "footerDivider";
            footerDivider.Size = new Size(1066, 8);
            footerDivider.TabIndex = 5;
            // 
            // contentLabel
            // 
            contentLabel.AutoSizeMode = AntdUI.TAutoSize.Height;
            contentLabel.Dock = DockStyle.Top;
            contentLabel.Location = new Point(17, 115);
            contentLabel.Margin = new Padding(0);
            contentLabel.Name = "contentLabel";
            contentLabel.Padding = new Padding(0, 6, 0, 6);
            contentLabel.Size = new Size(1066, 29);
            contentLabel.TabIndex = 3;
            contentLabel.Text = "Resource content";
            contentLabel.TextAlign = ContentAlignment.TopLeft;
            contentLabel.SizeChanged += contentLabel_SizeChanged;
            // 
            // titleLabel
            // 
            titleLabel.AutoSizeMode = AntdUI.TAutoSize.Height;
            titleLabel.Dock = DockStyle.Top;
            titleLabel.Font = new Font("Microsoft YaHei UI", 14F, FontStyle.Bold);
            titleLabel.Location = new Point(17, 83);
            titleLabel.Name = "titleLabel";
            titleLabel.Padding = new Padding(0, 0, 0, 8);
            titleLabel.Size = new Size(1066, 32);
            titleLabel.TabIndex = 9;
            titleLabel.Text = "Resource title";
            titleLabel.SizeChanged += contentLabel_SizeChanged;
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
            // ResourceCardControl
            // 
            AutoScaleDimensions = new SizeF(8F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panel1);
            Font = new Font("Microsoft YaHei UI", 10F);
            Margin = new Padding(8);
            MinimumSize = new Size(1100, 0);
            Name = "ResourceCardControl";
            Size = new Size(1100, 226);
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
        private AntdUI.Label titleLabel;
        private AntdUI.Button attachmentButton;
        private AntdUI.Divider footerDivider;
    }
}
