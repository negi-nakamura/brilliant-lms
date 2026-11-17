namespace brilliant_lms.Views.Archived.Classes
{
    partial class ClassroomInformationControl
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
            nameLabel = new AntdUI.Label();
            nameValue = new AntdUI.Label();
            sectionLabel = new AntdUI.Label();
            sectionValue = new AntdUI.Label();
            subjectLabel = new AntdUI.Label();
            subjectValue = new AntdUI.Label();
            roomLabel = new AntdUI.Label();
            roomValue = new AntdUI.Label();
            scheduleLabel = new AntdUI.Label();
            scheduleValue = new AntdUI.Label();
            levelLabel = new AntdUI.Label();
            levelValue = new AntdUI.Label();
            teacherLabel = new AntdUI.Label();
            teacherValue = new AntdUI.Label();
            joinedAtLabel = new AntdUI.Label();
            joinedAtValue = new AntdUI.Label();
            SuspendLayout();
            //
            // nameLabel
            //
            nameLabel.Location = new Point(16, 12);
            nameLabel.Name = "nameLabel";
            nameLabel.Size = new Size(100, 36);
            nameLabel.Text = "Name:";
            nameLabel.Font = new Font("Microsoft YaHei UI", 10F, FontStyle.Bold);
            //
            // nameValue
            //
            nameValue.AutoEllipsis = true;
            nameValue.TextMultiLine = false;
            nameValue.Location = new Point(124, 12);
            nameValue.Name = "nameValue";
            nameValue.Size = new Size(340, 36);
            nameValue.Text = "---";
            //
            // sectionLabel
            //
            sectionLabel.Location = new Point(16, 54);
            sectionLabel.Name = "sectionLabel";
            sectionLabel.Size = new Size(100, 36);
            sectionLabel.Text = "Section:";
            sectionLabel.Font = new Font("Microsoft YaHei UI", 10F, FontStyle.Bold);
            //
            // sectionValue
            //
            sectionValue.AutoEllipsis = true;
            sectionValue.TextMultiLine = false;
            sectionValue.Location = new Point(124, 54);
            sectionValue.Name = "sectionValue";
            sectionValue.Size = new Size(340, 36);
            sectionValue.Text = "---";
            //
            // subjectLabel
            //
            subjectLabel.Location = new Point(16, 96);
            subjectLabel.Name = "subjectLabel";
            subjectLabel.Size = new Size(100, 36);
            subjectLabel.Text = "Subject:";
            subjectLabel.Font = new Font("Microsoft YaHei UI", 10F, FontStyle.Bold);
            //
            // subjectValue
            //
            subjectValue.AutoEllipsis = true;
            subjectValue.TextMultiLine = false;
            subjectValue.Location = new Point(124, 96);
            subjectValue.Name = "subjectValue";
            subjectValue.Size = new Size(340, 36);
            subjectValue.Text = "---";
            //
            // roomLabel
            //
            roomLabel.Location = new Point(16, 138);
            roomLabel.Name = "roomLabel";
            roomLabel.Size = new Size(100, 36);
            roomLabel.Text = "Room:";
            roomLabel.Font = new Font("Microsoft YaHei UI", 10F, FontStyle.Bold);
            //
            // roomValue
            //
            roomValue.AutoEllipsis = true;
            roomValue.TextMultiLine = false;
            roomValue.Location = new Point(124, 138);
            roomValue.Name = "roomValue";
            roomValue.Size = new Size(340, 36);
            roomValue.Text = "---";
            //
            // scheduleLabel
            //
            scheduleLabel.Location = new Point(16, 180);
            scheduleLabel.Name = "scheduleLabel";
            scheduleLabel.Size = new Size(100, 36);
            scheduleLabel.Text = "Schedule:";
            scheduleLabel.Font = new Font("Microsoft YaHei UI", 10F, FontStyle.Bold);
            //
            // scheduleValue
            //
            scheduleValue.AutoEllipsis = true;
            scheduleValue.TextMultiLine = false;
            scheduleValue.Location = new Point(124, 180);
            scheduleValue.Name = "scheduleValue";
            scheduleValue.Size = new Size(340, 36);
            scheduleValue.Text = "---";
            //
            // levelLabel
            //
            levelLabel.Location = new Point(16, 222);
            levelLabel.Name = "levelLabel";
            levelLabel.Size = new Size(100, 36);
            levelLabel.Text = "Level:";
            levelLabel.Font = new Font("Microsoft YaHei UI", 10F, FontStyle.Bold);
            //
            // levelValue
            //
            levelValue.AutoEllipsis = true;
            levelValue.TextMultiLine = false;
            levelValue.Location = new Point(124, 222);
            levelValue.Name = "levelValue";
            levelValue.Size = new Size(340, 36);
            levelValue.Text = "---";
            //
            // teacherLabel
            //
            teacherLabel.Location = new Point(16, 264);
            teacherLabel.Name = "teacherLabel";
            teacherLabel.Size = new Size(100, 36);
            teacherLabel.Text = "Teacher:";
            teacherLabel.Font = new Font("Microsoft YaHei UI", 10F, FontStyle.Bold);
            //
            // teacherValue
            //
            teacherValue.AutoEllipsis = true;
            teacherValue.TextMultiLine = false;
            teacherValue.Location = new Point(124, 264);
            teacherValue.Name = "teacherValue";
            teacherValue.Size = new Size(340, 36);
            teacherValue.Text = "---";
            //
            // joinedAtLabel
            //
            joinedAtLabel.Location = new Point(16, 306);
            joinedAtLabel.Name = "joinedAtLabel";
            joinedAtLabel.Size = new Size(100, 36);
            joinedAtLabel.Text = "Joined At:";
            joinedAtLabel.Font = new Font("Microsoft YaHei UI", 10F, FontStyle.Bold);
            //
            // joinedAtValue
            //
            joinedAtValue.AutoEllipsis = true;
            joinedAtValue.TextMultiLine = false;
            joinedAtValue.Location = new Point(124, 306);
            joinedAtValue.Name = "joinedAtValue";
            joinedAtValue.Size = new Size(340, 36);
            joinedAtValue.Text = "---";
            //
            // ClassroomInformationControl
            //
            AutoScaleDimensions = new SizeF(8F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(nameLabel);
            Controls.Add(nameValue);
            Controls.Add(sectionLabel);
            Controls.Add(sectionValue);
            Controls.Add(subjectLabel);
            Controls.Add(subjectValue);
            Controls.Add(roomLabel);
            Controls.Add(roomValue);
            Controls.Add(scheduleLabel);
            Controls.Add(scheduleValue);
            Controls.Add(levelLabel);
            Controls.Add(levelValue);
            Controls.Add(teacherLabel);
            Controls.Add(teacherValue);
            Controls.Add(joinedAtLabel);
            Controls.Add(joinedAtValue);
            Font = new Font("Microsoft YaHei UI", 10F);
            Margin = new Padding(0);
            Padding = new Padding(12);
            Name = "ClassroomInformationControl";
            Size = new Size(480, 360);
            ResumeLayout(false);
        }

        #endregion

        private AntdUI.Label nameLabel;
        private AntdUI.Label nameValue;
        private AntdUI.Label sectionLabel;
        private AntdUI.Label sectionValue;
        private AntdUI.Label subjectLabel;
        private AntdUI.Label subjectValue;
        private AntdUI.Label roomLabel;
        private AntdUI.Label roomValue;
        private AntdUI.Label scheduleLabel;
        private AntdUI.Label scheduleValue;
        private AntdUI.Label levelLabel;
        private AntdUI.Label levelValue;
        private AntdUI.Label teacherLabel;
        private AntdUI.Label teacherValue;
        private AntdUI.Label joinedAtLabel;
        private AntdUI.Label joinedAtValue;
    }
}
