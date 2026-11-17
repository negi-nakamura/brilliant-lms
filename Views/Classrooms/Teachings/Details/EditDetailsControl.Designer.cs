namespace brilliant_lms.Views.Classrooms.Teachings.Details
{
    partial class EditDetailsControl
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null) components.Dispose();
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        private void InitializeComponent()
        {
            nameLabel = new AntdUI.Label();
            nameInput = new AntdUI.Input();
            sectionLabel = new AntdUI.Label();
            sectionInput = new AntdUI.Input();
            roomLabel = new AntdUI.Label();
            roomInput = new AntdUI.Input();
            subjectLabel = new AntdUI.Label();
            subjectInput = new AntdUI.Input();
            levelLabel = new AntdUI.Label();
            levelInput = new AntdUI.Input();
            scheduleLabel = new AntdUI.Label();
            scheduleInput = new AntdUI.Input();
            saveButton = new AntdUI.Button();
            cancelButton = new AntdUI.Button();
            SuspendLayout();
            //
            // nameLabel
            //
            nameLabel.Location = new Point(12, 12);
            nameLabel.Name = "nameLabel";
            nameLabel.Size = new Size(616, 24);
            nameLabel.Text = "Name:";
            //
            // nameInput
            //
            nameInput.Location = new Point(12, 40);
            nameInput.Name = "nameInput";
            nameInput.Radius = 0;
            nameInput.Size = new Size(616, 44);
            nameInput.TabIndex = 0;
            //
            // sectionLabel
            //
            sectionLabel.Location = new Point(12, 96);
            sectionLabel.Name = "sectionLabel";
            sectionLabel.Size = new Size(300, 24);
            sectionLabel.Text = "Section:";
            //
            // sectionInput
            //
            sectionInput.Location = new Point(12, 124);
            sectionInput.Name = "sectionInput";
            sectionInput.Radius = 0;
            sectionInput.Size = new Size(300, 44);
            sectionInput.TabIndex = 1;
            //
            // roomLabel
            //
            roomLabel.Location = new Point(328, 96);
            roomLabel.Name = "roomLabel";
            roomLabel.Size = new Size(300, 24);
            roomLabel.Text = "Room:";
            //
            // roomInput
            //
            roomInput.Location = new Point(328, 124);
            roomInput.Name = "roomInput";
            roomInput.Radius = 0;
            roomInput.Size = new Size(300, 44);
            roomInput.TabIndex = 2;
            //
            // subjectLabel
            //
            subjectLabel.Location = new Point(12, 180);
            subjectLabel.Name = "subjectLabel";
            subjectLabel.Size = new Size(300, 24);
            subjectLabel.Text = "Subject:";
            //
            // subjectInput
            //
            subjectInput.Location = new Point(12, 208);
            subjectInput.Name = "subjectInput";
            subjectInput.Radius = 0;
            subjectInput.Size = new Size(300, 44);
            subjectInput.TabIndex = 3;
            //
            // levelLabel
            //
            levelLabel.Location = new Point(328, 180);
            levelLabel.Name = "levelLabel";
            levelLabel.Size = new Size(300, 24);
            levelLabel.Text = "Level:";
            //
            // levelInput
            //
            levelInput.Location = new Point(328, 208);
            levelInput.Name = "levelInput";
            levelInput.Radius = 0;
            levelInput.Size = new Size(300, 44);
            levelInput.TabIndex = 4;
            //
            // scheduleLabel
            //
            scheduleLabel.Location = new Point(12, 264);
            scheduleLabel.Name = "scheduleLabel";
            scheduleLabel.Size = new Size(616, 24);
            scheduleLabel.Text = "Schedule:";
            //
            // scheduleInput
            //
            scheduleInput.Location = new Point(12, 292);
            scheduleInput.Name = "scheduleInput";
            scheduleInput.Radius = 0;
            scheduleInput.Size = new Size(616, 44);
            scheduleInput.TabIndex = 5;
            //
            // saveButton
            //
            saveButton.Location = new Point(448, 364);
            saveButton.Name = "saveButton";
            saveButton.Radius = 0;
            saveButton.Size = new Size(180, 44);
            saveButton.Text = "Save Changes";
            saveButton.Click += saveButton_Click;
            //
            // cancelButton
            //
            cancelButton.Location = new Point(320, 364);
            cancelButton.Name = "cancelButton";
            cancelButton.Radius = 0;
            cancelButton.Size = new Size(120, 44);
            cancelButton.Text = "Cancel";
            cancelButton.Click += cancelButton_Click;
            saveButton.Type = AntdUI.TTypeMini.Primary;
            Controls.Add(nameLabel);
            Controls.Add(nameInput);
            Controls.Add(sectionLabel);
            Controls.Add(sectionInput);
            Controls.Add(roomLabel);
            Controls.Add(roomInput);
            Controls.Add(subjectLabel);
            Controls.Add(subjectInput);
            Controls.Add(levelLabel);
            Controls.Add(levelInput);
            Controls.Add(scheduleLabel);
            Controls.Add(scheduleInput);
            Controls.Add(saveButton);
            Controls.Add(cancelButton);
            AutoScaleDimensions = new SizeF(8F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            Font = new Font("Microsoft YaHei UI", 10F);
            Name = "EditDetailsControl";
            Size = new Size(640, 424);
            ResumeLayout(false);
        }

        #endregion

        private AntdUI.Label nameLabel;
        private AntdUI.Input nameInput;
        private AntdUI.Label sectionLabel;
        private AntdUI.Input sectionInput;
        private AntdUI.Label roomLabel;
        private AntdUI.Input roomInput;
        private AntdUI.Label subjectLabel;
        private AntdUI.Input subjectInput;
        private AntdUI.Label levelLabel;
        private AntdUI.Input levelInput;
        private AntdUI.Label scheduleLabel;
        private AntdUI.Input scheduleInput;
        private AntdUI.Button saveButton;
        private AntdUI.Button cancelButton;
    }
}
