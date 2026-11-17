namespace brilliant_lms.Views.Classrooms.Teachings.Announcements
{
    partial class CreateAnnouncementControl
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
            contentInput = new AntdUI.Input();
            createButton = new AntdUI.Button();
            cancelButton = new AntdUI.Button();
            SuspendLayout();
            // 
            // contentInput
            // 
            contentInput.AccessibleName = "Announcement content";
            contentInput.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            contentInput.Font = new Font("Microsoft YaHei UI", 10F);
            contentInput.Location = new Point(0, 11);
            contentInput.Multiline = true;
            contentInput.Name = "contentInput";
            contentInput.PlaceholderText = "Write your announcement...";
            contentInput.Radius = 0;
            contentInput.Size = new Size(520, 246);
            contentInput.TabIndex = 0;
            // 
            // createButton
            // 
            createButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            createButton.Font = new Font("Microsoft YaHei UI", 10F);
            createButton.Location = new Point(340, 262);
            createButton.Name = "createButton";
            createButton.Radius = 0;
            createButton.Size = new Size(180, 44);
            createButton.TabIndex = 1;
            createButton.Text = "Create Announcement";
            createButton.Type = AntdUI.TTypeMini.Primary;
            createButton.Click += createButton_Click;
            // 
            // cancelButton
            // 
            cancelButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            cancelButton.Font = new Font("Microsoft YaHei UI", 10F);
            cancelButton.Location = new Point(212, 262);
            cancelButton.Name = "cancelButton";
            cancelButton.Radius = 0;
            cancelButton.Size = new Size(120, 44);
            cancelButton.TabIndex = 2;
            cancelButton.Text = "Cancel";
            cancelButton.Click += cancelButton_Click;
            // 
            // CreateAnnouncementControl
            // 
            AutoScaleDimensions = new SizeF(8F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(contentInput);
            Controls.Add(createButton);
            Controls.Add(cancelButton);
            Font = new Font("Microsoft YaHei UI", 10F);
            Margin = new Padding(0);
            Name = "CreateAnnouncementControl";
            Size = new Size(520, 313);
            ResumeLayout(false);
        }

        #endregion
        private AntdUI.Input contentInput;
        private AntdUI.Button createButton;
        private AntdUI.Button cancelButton;
    }
}
