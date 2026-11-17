namespace brilliant_lms.Views.Archived.Teachings.Assignments.Submissions
{
    partial class ReviewSubmissionControl
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            studentLabel = new AntdUI.Label();
            studentLabel.Name = "studentLabel";
            statusLabel = new AntdUI.Label();
            statusLabel.Name = "statusLabel";
            submittedLabel = new AntdUI.Label();
            submittedLabel.Name = "submittedLabel";
            answerLabel = new AntdUI.Label();
            answerLabel.Name = "answerLabel";
            maxPointsLabel = new AntdUI.Label();
            maxPointsLabel.Name = "maxPointsLabel";
            feedbackLabel = new AntdUI.Label();
            feedbackLabel.Name = "feedbackLabel";
            returnedLabel = new AntdUI.Label();
            returnedLabel.Name = "returnedLabel";
            answerInput = new AntdUI.Input();
            answerInput.Name = "answerInput";
            feedbackInput = new AntdUI.Input();
            feedbackInput.Name = "feedbackInput";
            attachmentButton = new AntdUI.Button();
            attachmentButton.Name = "attachmentButton";
            closeButton = new AntdUI.Button();
            closeButton.Name = "closeButton";
            SuspendLayout();
            studentLabel.Text = "Student";
            studentLabel.Location = new Point(12, 8);
            studentLabel.Size = new Size(656, 32);
            statusLabel.Text = "";
            statusLabel.Location = new Point(12, 44);
            statusLabel.Size = new Size(656, 24);
            submittedLabel.Text = "";
            submittedLabel.Location = new Point(12, 72);
            submittedLabel.Size = new Size(656, 24);
            answerLabel.Text = "Student answer";
            answerLabel.Location = new Point(12, 108);
            answerLabel.Size = new Size(656, 24);
            maxPointsLabel.Text = "";
            maxPointsLabel.Location = new Point(12, 336);
            maxPointsLabel.Size = new Size(656, 28);
            feedbackLabel.Text = "Feedback";
            feedbackLabel.Location = new Point(12, 384);
            feedbackLabel.Size = new Size(656, 24);
            returnedLabel.Text = "";
            returnedLabel.Location = new Point(12, 532);
            returnedLabel.Size = new Size(656, 24);
            studentLabel.Font = new Font("Microsoft YaHei UI", 14F, FontStyle.Bold);
            studentLabel.AutoEllipsis = true;
            answerInput.Location = new Point(12, 136);
            answerInput.Size = new Size(656, 140);
            answerInput.Multiline = true;
            answerInput.ReadOnly = true;
            answerInput.Radius = 0;
            feedbackInput.Location = new Point(12, 412);
            feedbackInput.Size = new Size(656, 110);
            feedbackInput.Multiline = true;
            feedbackInput.ReadOnly = true;
            feedbackInput.Radius = 0;
            attachmentButton.Text = "Attachment links";
            attachmentButton.Location = new Point(12, 284);
            attachmentButton.Size = new Size(180, 44);
            attachmentButton.Radius = 0;
            attachmentButton.Click += attachmentButton_Click;
            closeButton.Text = "Close";
            closeButton.Location = new Point(540, 580);
            closeButton.Size = new Size(120, 44);
            closeButton.Radius = 0;
            closeButton.Click += closeButton_Click;
            attachmentButton.Ghost = true;
            attachmentButton.IconSvg = "LinkOutlined";
            Controls.Add(studentLabel);
            Controls.Add(statusLabel);
            Controls.Add(submittedLabel);
            Controls.Add(answerLabel);
            Controls.Add(maxPointsLabel);
            Controls.Add(feedbackLabel);
            Controls.Add(returnedLabel);
            Controls.Add(answerInput);
            Controls.Add(feedbackInput);
            Controls.Add(attachmentButton);
            Controls.Add(closeButton);

            AutoScaleDimensions = new SizeF(8F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            Font = new Font("Microsoft YaHei UI", 10F);
            Name = "ReviewSubmissionControl";
            Size = new Size(680, 640);
            ResumeLayout(false);
        }
        private AntdUI.Label studentLabel;
        private AntdUI.Label statusLabel;
        private AntdUI.Label submittedLabel;
        private AntdUI.Label answerLabel;
        private AntdUI.Label maxPointsLabel;
        private AntdUI.Label feedbackLabel;
        private AntdUI.Label returnedLabel;
        private AntdUI.Input answerInput;
        private AntdUI.Input feedbackInput;
        private AntdUI.Button attachmentButton;
        private AntdUI.Button closeButton;
    }
}
