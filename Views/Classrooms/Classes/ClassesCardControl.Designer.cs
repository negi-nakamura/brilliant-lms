namespace brilliant_lms.Views.Classrooms.Classes
{
    partial class ClassesCardControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panel1 = new AntdUI.Panel();
            teacherIcon = new AntdUI.Avatar();
            teacherLabel = new AntdUI.Label();
            timeIcon = new AntdUI.Avatar();
            timeLabel = new AntdUI.Label();
            footerDivider = new AntdUI.Divider();
            informationButton = new AntdUI.Button();
            leaveButton = new AntdUI.Button();
            nameLabel = new AntdUI.Label();
            avatar = new AntdUI.Avatar();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.AutoContainerBgTransparent = true;
            panel1.BorderWidth = 1F;
            panel1.Controls.Add(teacherIcon);
            panel1.Controls.Add(teacherLabel);
            panel1.Controls.Add(timeIcon);
            panel1.Controls.Add(timeLabel);
            panel1.Controls.Add(footerDivider);
            panel1.Controls.Add(informationButton);
            panel1.Controls.Add(leaveButton);
            panel1.Controls.Add(nameLabel);
            panel1.Controls.Add(avatar);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Cursor = Cursors.Hand;
            panel1.Click += ClassesCardControl_Click;
            panel1.Radius = 0;
            panel1.Size = new Size(296, 208);
            panel1.TabIndex = 0;
            panel1.Text = "panel1";
            // 
            // 
            // 
            // teacherIcon
            // 
            teacherIcon.ImageSvg = "UserOutlined";
            teacherIcon.Location = new Point(25, 82);
            teacherIcon.Name = "teacherIcon";
            teacherIcon.Cursor = Cursors.Hand;
            teacherIcon.Click += ClassesCardControl_Click;
            teacherIcon.Size = new Size(15, 15);
            teacherIcon.TabIndex = 0;
            teacherIcon.TabStop = false;
            // 
            // teacherLabel
            // 
            teacherLabel.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            teacherLabel.AutoEllipsis = true;
            teacherLabel.BackColor = Color.Transparent;
            teacherLabel.Location = new Point(50, 77);
            teacherLabel.Name = "teacherLabel";
            teacherLabel.Cursor = Cursors.Hand;
            teacherLabel.Click += ClassesCardControl_Click;
            teacherLabel.Size = new Size(230, 24);
            teacherLabel.TabIndex = 1;
            teacherLabel.Text = "Teacher: Not assigned";
            teacherLabel.TextMultiLine = false;
            // 
            // timeIcon
            // 
            timeIcon.ImageSvg = "ClockCircleOutlined";
            timeIcon.Location = new Point(25, 114);
            timeIcon.Name = "timeIcon";
            timeIcon.Cursor = Cursors.Hand;
            timeIcon.Click += ClassesCardControl_Click;
            timeIcon.Size = new Size(15, 15);
            timeIcon.TabIndex = 2;
            timeIcon.TabStop = false;
            // 
            // timeLabel
            // 
            timeLabel.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            timeLabel.AutoEllipsis = true;
            timeLabel.BackColor = Color.Transparent;
            timeLabel.Location = new Point(50, 109);
            timeLabel.Name = "timeLabel";
            timeLabel.Cursor = Cursors.Hand;
            timeLabel.Click += ClassesCardControl_Click;
            timeLabel.Size = new Size(230, 24);
            timeLabel.TabIndex = 3;
            timeLabel.Text = "Time: Not scheduled";
            timeLabel.TextMultiLine = false;
            // 
            // footerDivider
            // 
            footerDivider.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            footerDivider.BackColor = Color.Transparent;
            footerDivider.Location = new Point(16, 144);
            footerDivider.Name = "footerDivider";
            footerDivider.Cursor = Cursors.Hand;
            footerDivider.Click += ClassesCardControl_Click;
            footerDivider.Size = new Size(264, 8);
            footerDivider.TabIndex = 4;
            // 
            // informationButton
            // 
            informationButton.AccessibleName = "Classroom information";
            informationButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            informationButton.Ghost = true;
            informationButton.IconSvg = "InfoCircleOutlined";
            informationButton.Location = new Point(196, 160);
            informationButton.Name = "informationButton";
            informationButton.Radius = 0;
            informationButton.Size = new Size(40, 36);
            informationButton.TabIndex = 6;
            informationButton.Click += informationButton_Click;
            // 
            // leaveButton
            // 
            leaveButton.AccessibleName = "Leave classroom";
            leaveButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            leaveButton.Ghost = true;
            leaveButton.IconSvg = "LogoutOutlined";
            leaveButton.Location = new Point(240, 160);
            leaveButton.Name = "leaveButton";
            leaveButton.Radius = 0;
            leaveButton.Size = new Size(40, 36);
            leaveButton.TabIndex = 7;
            leaveButton.Click += leaveButton_Click;
            // 
            // nameLabel
            // 
            nameLabel.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            nameLabel.AutoEllipsis = true;
            nameLabel.BackColor = Color.Transparent;
            nameLabel.Font = new Font("Microsoft YaHei UI", 12F, FontStyle.Bold);
            nameLabel.Location = new Point(72, 16);
            nameLabel.Name = "nameLabel";
            nameLabel.Cursor = Cursors.Hand;
            nameLabel.Click += ClassesCardControl_Click;
            nameLabel.Size = new Size(208, 44);
            nameLabel.TabIndex = 2;
            nameLabel.Text = "Subject name";
            // 
            // avatar
            // 
            avatar.BackColor = Color.FromArgb(22, 119, 255);
            avatar.Font = new Font("Microsoft YaHei UI Light", 14F, FontStyle.Bold);
            avatar.ForeColor = Color.White;
            avatar.Location = new Point(16, 16);
            avatar.Margin = new Padding(3, 4, 3, 4);
            avatar.Name = "avatar";
            avatar.Cursor = Cursors.Hand;
            avatar.Click += ClassesCardControl_Click;
            avatar.Round = true;
            avatar.Size = new Size(44, 44);
            avatar.TabIndex = 1;
            avatar.Text = "A";
            // 
            // ClassesCardControl
            // 
            AutoScaleDimensions = new SizeF(8F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panel1);
            Font = new Font("Microsoft YaHei UI", 10F);
            Margin = new Padding(8);
            MinimumSize = new Size(240, 208);
            Name = "ClassesCardControl";
            Click += ClassesCardControl_Click;
            Size = new Size(296, 208);
            panel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private AntdUI.Avatar teacherIcon;
        private AntdUI.Label teacherLabel;
        private AntdUI.Avatar timeIcon;
        private AntdUI.Label timeLabel;
        private AntdUI.Divider footerDivider;
        private AntdUI.Panel panel1;
        private AntdUI.Button informationButton;
        private AntdUI.Button leaveButton;
        private AntdUI.Label nameLabel;
        private AntdUI.Avatar avatar;
    }
}
