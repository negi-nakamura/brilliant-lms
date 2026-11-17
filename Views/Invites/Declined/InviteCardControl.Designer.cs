namespace brilliant_lms.Views.Invites.Declined
{
    partial class InviteCardControl
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null) components.Dispose();
            if (disposing) brilliant_lms.Theme.ThemeManager.ThemeChanged -= ThemeManager_ThemeChanged;
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        private void InitializeComponent()
        {
            panel1 = new AntdUI.Panel();
            avatar = new AntdUI.Avatar();
            nameLabel = new AntdUI.Label();
            roleLabel = new AntdUI.Label();
            inviterLabel = new AntdUI.Label();
            dateLabel = new AntdUI.Label();
            divider = new AntdUI.Divider();
            actionButton = new AntdUI.Button();
            SuspendLayout();
            panel1.AutoContainerBgTransparent = true;
            panel1.Dock = DockStyle.Fill;
            panel1.BorderWidth = 1;
            panel1.Name = "panel1";
            panel1.Radius = 0;
            panel1.Size = new Size(1100, 176);
            avatar.Location = new Point(16, 16);
            avatar.Name = "avatar";
            avatar.Size = new Size(44, 44);
            avatar.Round = true;
            avatar.BackColor = Color.FromArgb(22, 119, 255);
            avatar.ForeColor = Color.White;
            avatar.Font = new Font("Microsoft YaHei UI", 14F, FontStyle.Bold);
            nameLabel.Location = new Point(72, 16);
            nameLabel.Name = "nameLabel";
            nameLabel.Size = new Size(1012, 24);
            nameLabel.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            nameLabel.AutoEllipsis = true;
            nameLabel.TextMultiLine = false;
            nameLabel.BackColor = Color.Transparent;
            roleLabel.Location = new Point(72, 40);
            roleLabel.Name = "roleLabel";
            roleLabel.Size = new Size(1012, 24);
            roleLabel.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            roleLabel.AutoEllipsis = true;
            roleLabel.TextMultiLine = false;
            roleLabel.BackColor = Color.Transparent;
            inviterLabel.Location = new Point(16, 80);
            inviterLabel.Name = "inviterLabel";
            inviterLabel.Size = new Size(1068, 24);
            inviterLabel.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            inviterLabel.AutoEllipsis = true;
            inviterLabel.TextMultiLine = false;
            inviterLabel.BackColor = Color.Transparent;
            dateLabel.Location = new Point(16, 128);
            dateLabel.Name = "dateLabel";
            dateLabel.Size = new Size(796, 24);
            dateLabel.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            dateLabel.AutoEllipsis = true;
            dateLabel.TextMultiLine = false;
            dateLabel.BackColor = Color.Transparent;
            nameLabel.Font = new Font("Microsoft YaHei UI", 12F, FontStyle.Bold);
            divider.Location = new Point(16, 110);
            divider.Name = "divider";
            divider.Size = new Size(1068, 8);
            divider.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            divider.BackColor = Color.Transparent;
            actionButton.Location = new Point(956, 122);
            actionButton.Name = "actionButton";
            actionButton.Size = new Size(128, 38);
            actionButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            actionButton.Text = "Resend";
            actionButton.Radius = 0;
            actionButton.Type = AntdUI.TTypeMini.Primary;
            actionButton.Click += actionButton_Click;
            panel1.Controls.Add(avatar);
            panel1.Controls.Add(nameLabel);
            panel1.Controls.Add(roleLabel);
            panel1.Controls.Add(inviterLabel);
            panel1.Controls.Add(dateLabel);
            panel1.Controls.Add(divider);
            panel1.Controls.Add(actionButton);
            Margin = new Padding(8);
            MinimumSize = new Size(1100, 0);
            Controls.Add(panel1);
            AutoScaleDimensions = new SizeF(8F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Transparent;
            Font = new Font("Microsoft YaHei UI", 10F);
            Name = "InviteCardControl";
            Size = new Size(1100, 176);
            ResumeLayout(false);
        }

        #endregion

        private AntdUI.Panel panel1;
        private AntdUI.Avatar avatar;
        private AntdUI.Label nameLabel;
        private AntdUI.Label roleLabel;
        private AntdUI.Label inviterLabel;
        private AntdUI.Label dateLabel;
        private AntdUI.Divider divider;
        private AntdUI.Button actionButton;
    }
}
