namespace brilliant_lms.Views.Archived.Teachings.Assignments.Submissions
{
    partial class SubmissionCardControl
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            panel1 = new AntdUI.Panel();
            panel1.Name = "panel1";
            panel1.Cursor = Cursors.Hand;
            panel1.Click += SubmissionCardControl_Click;
            avatar = new AntdUI.Avatar();
            avatar.Name = "avatar";
            avatar.Cursor = Cursors.Hand;
            avatar.Click += SubmissionCardControl_Click;
            nameLabel = new AntdUI.Label();
            nameLabel.Name = "nameLabel";
            nameLabel.Cursor = Cursors.Hand;
            nameLabel.Click += SubmissionCardControl_Click;
            dateLabel = new AntdUI.Label();
            dateLabel.Name = "dateLabel";
            dateLabel.Cursor = Cursors.Hand;
            dateLabel.Click += SubmissionCardControl_Click;
            statusLabel = new AntdUI.Label();
            statusLabel.Name = "statusLabel";
            statusLabel.Cursor = Cursors.Hand;
            statusLabel.Click += SubmissionCardControl_Click;
            scoreLabel = new AntdUI.Label();
            scoreLabel.Name = "scoreLabel";
            scoreLabel.Cursor = Cursors.Hand;
            scoreLabel.Click += SubmissionCardControl_Click;
            reviewButton = new AntdUI.Button();
            reviewButton.Name = "reviewButton";
            SuspendLayout();
            panel1.AutoContainerBgTransparent = true;
            panel1.Dock = DockStyle.Fill;
            panel1.BorderWidth = 1;
            panel1.Radius = 0;
            avatar.Location = new Point(16, 20);
            avatar.Size = new Size(44, 44);
            avatar.Round = true;
            avatar.BackColor = Color.FromArgb(22, 119, 255);
            avatar.ForeColor = Color.White;
            nameLabel.Location = new Point(72, 16);
            nameLabel.Size = new Size(370, 24);
            nameLabel.Font = new Font("Microsoft YaHei UI", 11F, FontStyle.Bold);
            nameLabel.AutoEllipsis = true;
            nameLabel.TextMultiLine = false;
            dateLabel.Location = new Point(72, 40);
            dateLabel.Size = new Size(370, 24);
            dateLabel.AutoEllipsis = true;
            dateLabel.TextMultiLine = false;
            statusLabel.Location = new Point(460, 26);
            statusLabel.Size = new Size(180, 28);
            scoreLabel.Location = new Point(652, 26);
            scoreLabel.Size = new Size(150, 28);
            reviewButton.Location = new Point(816, 20);
            reviewButton.Size = new Size(120, 40);
            reviewButton.Text = "Review";
            reviewButton.Radius = 0;
            reviewButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            reviewButton.Click += SubmissionCardControl_Click;
            panel1.Controls.Add(avatar);
            panel1.Controls.Add(nameLabel);
            panel1.Controls.Add(dateLabel);
            panel1.Controls.Add(statusLabel);
            panel1.Controls.Add(scoreLabel);
            panel1.Controls.Add(reviewButton);
            Controls.Add(panel1);
            Margin = new Padding(0, 0, 0, 8);
            AutoScaleDimensions = new SizeF(8F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            Font = new Font("Microsoft YaHei UI", 10F);
            Name = "SubmissionCardControl";
            Cursor = Cursors.Hand;
            Click += SubmissionCardControl_Click;
            Size = new Size(952, 84);
            ResumeLayout(false);
        }
        private AntdUI.Panel panel1;
        private AntdUI.Avatar avatar;
        private AntdUI.Label nameLabel;
        private AntdUI.Label dateLabel;
        private AntdUI.Label statusLabel;
        private AntdUI.Label scoreLabel;
        private AntdUI.Button reviewButton;
    }
}
