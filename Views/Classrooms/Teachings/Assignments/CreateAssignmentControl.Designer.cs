namespace brilliant_lms.Views.Classrooms.Teachings.Assignments
{
    partial class CreateAssignmentControl
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        private void InitializeComponent()
        {
            titleLabel = new AntdUI.Label();
            titleInput = new AntdUI.Input();
            instructionsLabel = new AntdUI.Label();
            instructionsInput = new AntdUI.Input();
            dueDateLabel = new AntdUI.Label();
            dueDatePicker = new AntdUI.DatePicker();
            maxPointsLabel = new AntdUI.Label();
            maxPointsInput = new AntdUI.InputNumber();
            attachmentLabel = new AntdUI.Label();
            attachmentInput = new AntdUI.Input();
            createButton = new AntdUI.Button();
            cancelButton = new AntdUI.Button();
            SuspendLayout();
            //
            // titleLabel
            //
            titleLabel.Name = "titleLabel";
            titleLabel.Font = new Font("Microsoft YaHei UI", 10F);
            titleLabel.Location = new Point(12, 12);
            titleLabel.Size = new Size(536, 24);
            titleLabel.Text = "Title:";
            //
            // titleInput
            //
            titleInput.Name = "titleInput";
            titleInput.Font = new Font("Microsoft YaHei UI", 10F);
            titleInput.Location = new Point(12, 40);
            titleInput.Size = new Size(536, 42);
            titleInput.Radius = 0;
            titleInput.PlaceholderText = "Enter assignment title";
            //
            // instructionsLabel
            //
            instructionsLabel.Name = "instructionsLabel";
            instructionsLabel.Font = new Font("Microsoft YaHei UI", 10F);
            instructionsLabel.Location = new Point(12, 96);
            instructionsLabel.Size = new Size(536, 24);
            instructionsLabel.Text = "Instructions:";
            //
            // instructionsInput
            //
            instructionsInput.Name = "instructionsInput";
            instructionsInput.Font = new Font("Microsoft YaHei UI", 10F);
            instructionsInput.Location = new Point(12, 124);
            instructionsInput.Size = new Size(536, 140);
            instructionsInput.Radius = 0;
            instructionsInput.Multiline = true;
            instructionsInput.PlaceholderText = "Write assignment instructions...";
            //
            // dueDateLabel
            //
            dueDateLabel.Name = "dueDateLabel";
            dueDateLabel.Font = new Font("Microsoft YaHei UI", 10F);
            dueDateLabel.Location = new Point(12, 276);
            dueDateLabel.Size = new Size(260, 24);
            dueDateLabel.Text = "Due date:";
            //
            // dueDatePicker
            //
            dueDatePicker.Name = "dueDatePicker";
            dueDatePicker.Font = new Font("Microsoft YaHei UI", 10F);
            dueDatePicker.Location = new Point(12, 304);
            dueDatePicker.Size = new Size(260, 42);
            dueDatePicker.Radius = 0;
            dueDatePicker.Format = "MMM dd, yyyy HH:mm";
            //
            // maxPointsLabel
            //
            maxPointsLabel.Name = "maxPointsLabel";
            maxPointsLabel.Font = new Font("Microsoft YaHei UI", 10F);
            maxPointsLabel.Location = new Point(288, 276);
            maxPointsLabel.Size = new Size(260, 24);
            maxPointsLabel.Text = "Maximum points:";
            //
            // maxPointsInput
            //
            maxPointsInput.Name = "maxPointsInput";
            maxPointsInput.Font = new Font("Microsoft YaHei UI", 10F);
            maxPointsInput.Location = new Point(288, 304);
            maxPointsInput.Size = new Size(260, 42);
            maxPointsInput.Radius = 0;
            maxPointsInput.Minimum = 0.01M;
            maxPointsInput.Maximum = 99999999.99M;
            maxPointsInput.DecimalPlaces = 2;
            maxPointsInput.Value = 100;
            //
            // attachmentLabel
            //
            attachmentLabel.Name = "attachmentLabel";
            attachmentLabel.Font = new Font("Microsoft YaHei UI", 10F);
            attachmentLabel.Location = new Point(12, 360);
            attachmentLabel.Size = new Size(536, 24);
            attachmentLabel.Text = "Attachment links (one per line, optional):";
            //
            // attachmentInput
            //
            attachmentInput.Name = "attachmentInput";
            attachmentInput.Font = new Font("Microsoft YaHei UI", 10F);
            attachmentInput.Location = new Point(12, 388);
            attachmentInput.Size = new Size(536, 100);
            attachmentInput.Multiline = true;
            attachmentInput.Radius = 0;
            attachmentInput.PlaceholderText = "Enter one https:// link per line";
            //
            // createButton
            //
            createButton.Name = "createButton";
            createButton.Font = new Font("Microsoft YaHei UI", 10F);
            createButton.Location = new Point(368, 504);
            createButton.Size = new Size(180, 44);
            createButton.Text = "Post Assignment";
            createButton.Radius = 0;
            createButton.Type = AntdUI.TTypeMini.Primary;
            createButton.Click += createButton_Click;
            //
            // cancelButton
            //
            cancelButton.Name = "cancelButton";
            cancelButton.Font = new Font("Microsoft YaHei UI", 10F);
            cancelButton.Location = new Point(240, 504);
            cancelButton.Size = new Size(120, 44);
            cancelButton.Text = "Cancel";
            cancelButton.Radius = 0;
            cancelButton.Click += cancelButton_Click;
            titleInput.TabIndex = 0;
            instructionsInput.TabIndex = 1;
            dueDatePicker.TabIndex = 2;
            maxPointsInput.TabIndex = 3;
            attachmentInput.TabIndex = 4;
            createButton.TabIndex = 5;
            cancelButton.TabIndex = 6;
            AutoScaleDimensions = new SizeF(8F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(titleLabel);
            Controls.Add(titleInput);
            Controls.Add(instructionsLabel);
            Controls.Add(instructionsInput);
            Controls.Add(dueDateLabel);
            Controls.Add(dueDatePicker);
            Controls.Add(maxPointsLabel);
            Controls.Add(maxPointsInput);
            Controls.Add(attachmentLabel);
            Controls.Add(attachmentInput);
            Controls.Add(createButton);
            Controls.Add(cancelButton);
            Font = new Font("Microsoft YaHei UI", 10F);
            Margin = new Padding(0);
            Padding = new Padding(12);
            Name = "CreateAssignmentControl";
            Size = new Size(560, 564);
            ResumeLayout(false);
        }

        #endregion

        private AntdUI.Label titleLabel;
        private AntdUI.Input titleInput;
        private AntdUI.Label instructionsLabel;
        private AntdUI.Input instructionsInput;
        private AntdUI.Label dueDateLabel;
        private AntdUI.DatePicker dueDatePicker;
        private AntdUI.Label maxPointsLabel;
        private AntdUI.InputNumber maxPointsInput;
        private AntdUI.Label attachmentLabel;
        private AntdUI.Input attachmentInput;
        private AntdUI.Button createButton;
        private AntdUI.Button cancelButton;
    }
}
