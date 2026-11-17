namespace brilliant_lms.Views.Classrooms.Teachings.Details
{
    partial class DetailsCardControl
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
            divider = new AntdUI.Divider();
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
            codeLabel = new AntdUI.Label();
            codeValue = new AntdUI.Label();
            createdAtLabel = new AntdUI.Label();
            createdAtValue = new AntdUI.Label();
            SuspendLayout();
            panel1.SuspendLayout();
            panel1.AutoContainerBgTransparent = true;
            panel1.BorderWidth = 1;
            panel1.Dock = DockStyle.Fill;
            panel1.Name = "panel1";
            panel1.Radius = 0;
            avatar.Location = new Point(24, 20);
            avatar.Name = "avatar";
            avatar.Size = new Size(48, 48);
            avatar.Round = true;
            avatar.BackColor = Color.FromArgb(22, 119, 255);
            avatar.ForeColor = Color.White;
            avatar.Font = new Font("Microsoft YaHei UI", 14F, FontStyle.Bold);
            nameLabel.Location = new Point(88, 20);
            nameLabel.Name = "nameLabel";
            nameLabel.Size = new Size(988, 48);
            nameLabel.AutoEllipsis = true;
            nameLabel.TextMultiLine = false;
            nameLabel.BackColor = Color.Transparent;
            nameLabel.Font = new Font("Microsoft YaHei UI", 16F, FontStyle.Bold);
            divider.Location = new Point(24, 84);
            divider.Name = "divider";
            divider.Size = new Size(1052, 8);
            divider.BackColor = Color.Transparent;
            panel1.Controls.Add(avatar);
            panel1.Controls.Add(nameLabel);
            panel1.Controls.Add(divider);
            //
            // sectionLabel
            //
            sectionLabel.Location = new Point(24, 108);
            sectionLabel.Name = "sectionLabel";
            sectionLabel.Size = new Size(120, 32);
            sectionLabel.Text = "Section:";
            sectionLabel.Font = new Font("Microsoft YaHei UI", 10F, FontStyle.Bold);
            sectionLabel.BackColor = Color.Transparent;
            //
            // sectionValue
            //
            sectionValue.Location = new Point(160, 108);
            sectionValue.Name = "sectionValue";
            sectionValue.Size = new Size(916, 32);
            sectionValue.AutoEllipsis = true;
            sectionValue.TextMultiLine = false;
            sectionValue.BackColor = Color.Transparent;
            panel1.Controls.Add(sectionLabel);
            panel1.Controls.Add(sectionValue);
            //
            // subjectLabel
            //
            subjectLabel.Location = new Point(24, 150);
            subjectLabel.Name = "subjectLabel";
            subjectLabel.Size = new Size(120, 32);
            subjectLabel.Text = "Subject:";
            subjectLabel.Font = new Font("Microsoft YaHei UI", 10F, FontStyle.Bold);
            subjectLabel.BackColor = Color.Transparent;
            //
            // subjectValue
            //
            subjectValue.Location = new Point(160, 150);
            subjectValue.Name = "subjectValue";
            subjectValue.Size = new Size(916, 32);
            subjectValue.AutoEllipsis = true;
            subjectValue.TextMultiLine = false;
            subjectValue.BackColor = Color.Transparent;
            panel1.Controls.Add(subjectLabel);
            panel1.Controls.Add(subjectValue);
            //
            // roomLabel
            //
            roomLabel.Location = new Point(24, 192);
            roomLabel.Name = "roomLabel";
            roomLabel.Size = new Size(120, 32);
            roomLabel.Text = "Room:";
            roomLabel.Font = new Font("Microsoft YaHei UI", 10F, FontStyle.Bold);
            roomLabel.BackColor = Color.Transparent;
            //
            // roomValue
            //
            roomValue.Location = new Point(160, 192);
            roomValue.Name = "roomValue";
            roomValue.Size = new Size(916, 32);
            roomValue.AutoEllipsis = true;
            roomValue.TextMultiLine = false;
            roomValue.BackColor = Color.Transparent;
            panel1.Controls.Add(roomLabel);
            panel1.Controls.Add(roomValue);
            //
            // scheduleLabel
            //
            scheduleLabel.Location = new Point(24, 234);
            scheduleLabel.Name = "scheduleLabel";
            scheduleLabel.Size = new Size(120, 32);
            scheduleLabel.Text = "Schedule:";
            scheduleLabel.Font = new Font("Microsoft YaHei UI", 10F, FontStyle.Bold);
            scheduleLabel.BackColor = Color.Transparent;
            //
            // scheduleValue
            //
            scheduleValue.Location = new Point(160, 234);
            scheduleValue.Name = "scheduleValue";
            scheduleValue.Size = new Size(916, 32);
            scheduleValue.AutoEllipsis = true;
            scheduleValue.TextMultiLine = false;
            scheduleValue.BackColor = Color.Transparent;
            panel1.Controls.Add(scheduleLabel);
            panel1.Controls.Add(scheduleValue);
            //
            // levelLabel
            //
            levelLabel.Location = new Point(24, 276);
            levelLabel.Name = "levelLabel";
            levelLabel.Size = new Size(120, 32);
            levelLabel.Text = "Level:";
            levelLabel.Font = new Font("Microsoft YaHei UI", 10F, FontStyle.Bold);
            levelLabel.BackColor = Color.Transparent;
            //
            // levelValue
            //
            levelValue.Location = new Point(160, 276);
            levelValue.Name = "levelValue";
            levelValue.Size = new Size(916, 32);
            levelValue.AutoEllipsis = true;
            levelValue.TextMultiLine = false;
            levelValue.BackColor = Color.Transparent;
            panel1.Controls.Add(levelLabel);
            panel1.Controls.Add(levelValue);
            //
            // teacherLabel
            //
            teacherLabel.Location = new Point(24, 318);
            teacherLabel.Name = "teacherLabel";
            teacherLabel.Size = new Size(120, 32);
            teacherLabel.Text = "Teacher:";
            teacherLabel.Font = new Font("Microsoft YaHei UI", 10F, FontStyle.Bold);
            teacherLabel.BackColor = Color.Transparent;
            //
            // teacherValue
            //
            teacherValue.Location = new Point(160, 318);
            teacherValue.Name = "teacherValue";
            teacherValue.Size = new Size(916, 32);
            teacherValue.AutoEllipsis = true;
            teacherValue.TextMultiLine = false;
            teacherValue.BackColor = Color.Transparent;
            panel1.Controls.Add(teacherLabel);
            panel1.Controls.Add(teacherValue);
            //
            // codeLabel
            //
            codeLabel.Location = new Point(24, 360);
            codeLabel.Name = "codeLabel";
            codeLabel.Size = new Size(120, 32);
            codeLabel.Text = "Class Code:";
            codeLabel.Font = new Font("Microsoft YaHei UI", 10F, FontStyle.Bold);
            codeLabel.BackColor = Color.Transparent;
            //
            // codeValue
            //
            codeValue.Location = new Point(160, 360);
            codeValue.Name = "codeValue";
            codeValue.Size = new Size(916, 32);
            codeValue.AutoEllipsis = true;
            codeValue.TextMultiLine = false;
            codeValue.BackColor = Color.Transparent;
            panel1.Controls.Add(codeLabel);
            panel1.Controls.Add(codeValue);
            //
            // createdAtLabel
            //
            createdAtLabel.Location = new Point(24, 402);
            createdAtLabel.Name = "createdAtLabel";
            createdAtLabel.Size = new Size(120, 32);
            createdAtLabel.Text = "Created At:";
            createdAtLabel.Font = new Font("Microsoft YaHei UI", 10F, FontStyle.Bold);
            createdAtLabel.BackColor = Color.Transparent;
            //
            // createdAtValue
            //
            createdAtValue.Location = new Point(160, 402);
            createdAtValue.Name = "createdAtValue";
            createdAtValue.Size = new Size(916, 32);
            createdAtValue.AutoEllipsis = true;
            createdAtValue.TextMultiLine = false;
            createdAtValue.BackColor = Color.Transparent;
            panel1.Controls.Add(createdAtLabel);
            panel1.Controls.Add(createdAtValue);
            Controls.Add(panel1);
            Margin = new Padding(8);
            panel1.ResumeLayout(false);
            AutoScaleDimensions = new SizeF(8F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            Font = new Font("Microsoft YaHei UI", 10F);
            MinimumSize = new Size(1100, 0);
            Name = "DetailsCardControl";
            Size = new Size(1100, 460);
            ResumeLayout(false);
        }

        #endregion

        private AntdUI.Panel panel1;
        private AntdUI.Avatar avatar;
        private AntdUI.Label nameLabel;
        private AntdUI.Divider divider;
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
        private AntdUI.Label codeLabel;
        private AntdUI.Label codeValue;
        private AntdUI.Label createdAtLabel;
        private AntdUI.Label createdAtValue;
    }
}
