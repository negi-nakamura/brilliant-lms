namespace brilliant_lms.Views.Classrooms.Teachings.Resources
{
    partial class UpdateResourceControl
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
            descriptionLabel = new AntdUI.Label();
            descriptionInput = new AntdUI.Input();
            attachmentLabel = new AntdUI.Label();
            attachmentInput = new AntdUI.Input();
            updateButton = new AntdUI.Button();
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
            titleInput.PlaceholderText = "Enter resource title";
            //
            // descriptionLabel
            //
            descriptionLabel.Name = "descriptionLabel";
            descriptionLabel.Font = new Font("Microsoft YaHei UI", 10F);
            descriptionLabel.Location = new Point(12, 96);
            descriptionLabel.Size = new Size(536, 24);
            descriptionLabel.Text = "Description:";
            //
            // descriptionInput
            //
            descriptionInput.Name = "descriptionInput";
            descriptionInput.Font = new Font("Microsoft YaHei UI", 10F);
            descriptionInput.Location = new Point(12, 124);
            descriptionInput.Size = new Size(536, 140);
            descriptionInput.Radius = 0;
            descriptionInput.Multiline = true;
            descriptionInput.PlaceholderText = "Write resource description...";
            //
            // attachmentLabel
            //
            attachmentLabel.Name = "attachmentLabel";
            attachmentLabel.Font = new Font("Microsoft YaHei UI", 10F);
            attachmentLabel.Location = new Point(12, 276);
            attachmentLabel.Size = new Size(536, 24);
            attachmentLabel.Text = "Attachment links (one per line):";
            //
            // attachmentInput
            //
            attachmentInput.Name = "attachmentInput";
            attachmentInput.Font = new Font("Microsoft YaHei UI", 10F);
            attachmentInput.Location = new Point(12, 304);
            attachmentInput.Size = new Size(536, 100);
            attachmentInput.Multiline = true;
            attachmentInput.Radius = 0;
            attachmentInput.PlaceholderText = "Enter one https:// link per line";
            //
            // updateButton
            //
            updateButton.Name = "updateButton";
            updateButton.Font = new Font("Microsoft YaHei UI", 10F);
            updateButton.Location = new Point(368, 420);
            updateButton.Size = new Size(180, 44);
            updateButton.Text = "Update Resource";
            updateButton.Radius = 0;
            updateButton.Type = AntdUI.TTypeMini.Primary;
            updateButton.Click += updateButton_Click;
            //
            // cancelButton
            //
            cancelButton.Name = "cancelButton";
            cancelButton.Font = new Font("Microsoft YaHei UI", 10F);
            cancelButton.Location = new Point(240, 420);
            cancelButton.Size = new Size(120, 44);
            cancelButton.Text = "Cancel";
            cancelButton.Radius = 0;
            cancelButton.Click += cancelButton_Click;
            titleInput.TabIndex = 0;
            descriptionInput.TabIndex = 1;
            attachmentInput.TabIndex = 2;
            updateButton.TabIndex = 3;
            cancelButton.TabIndex = 4;
            AutoScaleDimensions = new SizeF(8F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(titleLabel);
            Controls.Add(titleInput);
            Controls.Add(descriptionLabel);
            Controls.Add(descriptionInput);
            Controls.Add(attachmentLabel);
            Controls.Add(attachmentInput);
            Controls.Add(updateButton);
            Controls.Add(cancelButton);
            Font = new Font("Microsoft YaHei UI", 10F);
            Margin = new Padding(0);
            Padding = new Padding(12);
            Name = "UpdateResourceControl";
            Size = new Size(560, 480);
            ResumeLayout(false);
        }

        #endregion

        private AntdUI.Label titleLabel;
        private AntdUI.Input titleInput;
        private AntdUI.Label descriptionLabel;
        private AntdUI.Input descriptionInput;
        private AntdUI.Label attachmentLabel;
        private AntdUI.Input attachmentInput;
        private AntdUI.Button updateButton;
        private AntdUI.Button cancelButton;
    }
}
