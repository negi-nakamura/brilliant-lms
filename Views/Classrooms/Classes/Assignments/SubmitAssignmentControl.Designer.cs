namespace brilliant_lms.Views.Classrooms.Classes.Assignments
{
    partial class SubmitAssignmentControl
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            titleLabel = new AntdUI.Label();
            statusLabel = new AntdUI.Label();
            gradeLabel = new AntdUI.Label();
            answerLabel = new AntdUI.Label();
            attachmentLabel = new AntdUI.Label();
            feedbackLabel = new AntdUI.Label();
            answerInput = new AntdUI.Input();
            attachmentInput = new AntdUI.Input();
            feedbackInput = new AntdUI.Input();
            submitButton = new AntdUI.Button();
            cancelButton = new AntdUI.Button();
            SuspendLayout();
            //
            // titleLabel
            //
            titleLabel.Name = "titleLabel";
            titleLabel.Text = "Assignment";
            titleLabel.Location = new Point(12, 8);
            titleLabel.Size = new Size(656, 32);
            titleLabel.BackColor = Color.Transparent;
            //
            // statusLabel
            //
            statusLabel.Name = "statusLabel";
            statusLabel.Text = "";
            statusLabel.Location = new Point(12, 44);
            statusLabel.Size = new Size(656, 28);
            statusLabel.BackColor = Color.Transparent;
            //
            // gradeLabel
            //
            gradeLabel.Name = "gradeLabel";
            gradeLabel.Text = "Grade: —";
            gradeLabel.Location = new Point(12, 76);
            gradeLabel.Size = new Size(656, 28);
            gradeLabel.BackColor = Color.Transparent;
            //
            // answerLabel
            //
            answerLabel.Name = "answerLabel";
            answerLabel.Text = "Your answer";
            answerLabel.Location = new Point(12, 116);
            answerLabel.Size = new Size(656, 24);
            answerLabel.BackColor = Color.Transparent;
            //
            // attachmentLabel
            //
            attachmentLabel.Name = "attachmentLabel";
            attachmentLabel.Text = "Attachment links (one per line)";
            attachmentLabel.Location = new Point(12, 296);
            attachmentLabel.Size = new Size(656, 24);
            attachmentLabel.BackColor = Color.Transparent;
            //
            // feedbackLabel
            //
            feedbackLabel.Name = "feedbackLabel";
            feedbackLabel.Text = "Teacher feedback";
            feedbackLabel.Visible = false;
            feedbackLabel.Location = new Point(12, 444);
            feedbackLabel.Size = new Size(656, 24);
            feedbackLabel.BackColor = Color.Transparent;
            titleLabel.Font = new Font("Microsoft YaHei UI", 14F, FontStyle.Bold);
            titleLabel.AutoEllipsis = true;
            //
            // answerInput
            //
            answerInput.Name = "answerInput";
            answerInput.Location = new Point(12, 144);
            answerInput.Size = new Size(656, 140);
            answerInput.Multiline = true;
            answerInput.Radius = 0;
            //
            // attachmentInput
            //
            attachmentInput.Name = "attachmentInput";
            attachmentInput.Location = new Point(12, 324);
            attachmentInput.Size = new Size(656, 108);
            attachmentInput.Multiline = true;
            attachmentInput.Radius = 0;
            //
            // feedbackInput
            //
            feedbackInput.Name = "feedbackInput";
            feedbackInput.Location = new Point(12, 472);
            feedbackInput.Size = new Size(656, 84);
            feedbackInput.Multiline = true;
            feedbackInput.Radius = 0;
            feedbackInput.ReadOnly = true;
            feedbackInput.Visible = false;
            //
            // cancelButton
            //
            cancelButton.Name = "cancelButton";
            cancelButton.Text = "Close";
            cancelButton.Location = new Point(404, 576);
            cancelButton.Size = new Size(128, 44);
            cancelButton.Radius = 0;
            cancelButton.Click += cancelButton_Click;
            //
            // submitButton
            //
            submitButton.Name = "submitButton";
            submitButton.Text = "Turn in";
            submitButton.Location = new Point(540, 576);
            submitButton.Size = new Size(128, 44);
            submitButton.Radius = 0;
            submitButton.Click += submitButton_Click;
            submitButton.Type = AntdUI.TTypeMini.Primary;
            Controls.Add(titleLabel);
            Controls.Add(statusLabel);
            Controls.Add(gradeLabel);
            Controls.Add(answerLabel);
            Controls.Add(attachmentLabel);
            Controls.Add(feedbackLabel);
            Controls.Add(answerInput);
            Controls.Add(attachmentInput);
            Controls.Add(feedbackInput);
            Controls.Add(submitButton);
            Controls.Add(cancelButton);
            AutoScaleDimensions = new SizeF(8F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            Font = new Font("Microsoft YaHei UI", 10F);
            Name = "SubmitAssignmentControl";
            Size = new Size(680, 636);
            Load += SubmitAssignmentControl_Load;
            ResumeLayout(false);
        }
        private AntdUI.Label titleLabel;
        private AntdUI.Label statusLabel;
        private AntdUI.Label gradeLabel;
        private AntdUI.Label answerLabel;
        private AntdUI.Label attachmentLabel;
        private AntdUI.Label feedbackLabel;
        private AntdUI.Input answerInput;
        private AntdUI.Input attachmentInput;
        private AntdUI.Input feedbackInput;
        private AntdUI.Button submitButton;
        private AntdUI.Button cancelButton;
    }
}
