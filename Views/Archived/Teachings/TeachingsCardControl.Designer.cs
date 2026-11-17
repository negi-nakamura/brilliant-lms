namespace brilliant_lms.Views.Archived.Teachings
{
    partial class TeachingsCardControl
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
            sectionIcon = new AntdUI.Avatar();
            sectionLabel = new AntdUI.Label();
            timeIcon = new AntdUI.Avatar();
            timeLabel = new AntdUI.Label();
            footerDivider = new AntdUI.Divider();
            unarchiveButton = new AntdUI.Button();
            deleteButton = new AntdUI.Button();
            nameLabel = new AntdUI.Label();
            avatar = new AntdUI.Avatar();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.AutoContainerBgTransparent = true;
            panel1.BorderWidth = 1F;
            panel1.Controls.Add(sectionIcon);
            panel1.Controls.Add(sectionLabel);
            panel1.Controls.Add(timeIcon);
            panel1.Controls.Add(timeLabel);
            panel1.Controls.Add(footerDivider);
            panel1.Controls.Add(unarchiveButton);
            panel1.Controls.Add(deleteButton);
            panel1.Controls.Add(nameLabel);
            panel1.Controls.Add(avatar);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Cursor = Cursors.Hand;
            panel1.Click += TeachingsCardControl_Click;
            panel1.Radius = 0;
            panel1.Size = new Size(296, 208);
            panel1.TabIndex = 0;
            panel1.Text = "panel1";
            // 
            // sectionIcon
            // 
            sectionIcon.ImageSvg = "TeamOutlined";
            sectionIcon.Location = new Point(25, 82);
            sectionIcon.Name = "sectionIcon";
            sectionIcon.Cursor = Cursors.Hand;
            sectionIcon.Click += TeachingsCardControl_Click;
            sectionIcon.Size = new Size(15, 15);
            sectionIcon.TabIndex = 0;
            sectionIcon.TabStop = false;
            // 
            // sectionLabel
            // 
            sectionLabel.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            sectionLabel.AutoEllipsis = true;
            sectionLabel.BackColor = Color.Transparent;
            sectionLabel.Location = new Point(50, 77);
            sectionLabel.Name = "sectionLabel";
            sectionLabel.Cursor = Cursors.Hand;
            sectionLabel.Click += TeachingsCardControl_Click;
            sectionLabel.Size = new Size(230, 24);
            sectionLabel.TabIndex = 1;
            sectionLabel.Text = "Section";
            sectionLabel.TextMultiLine = false;
            // 
            // timeIcon
            // 
            timeIcon.ImageSvg = "ClockCircleOutlined";
            timeIcon.Location = new Point(25, 114);
            timeIcon.Name = "timeIcon";
            timeIcon.Cursor = Cursors.Hand;
            timeIcon.Click += TeachingsCardControl_Click;
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
            timeLabel.Click += TeachingsCardControl_Click;
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
            footerDivider.Click += TeachingsCardControl_Click;
            footerDivider.Size = new Size(264, 8);
            footerDivider.TabIndex = 4;
            // 
            // 
            // 
            // unarchiveButton
            //
            unarchiveButton.AccessibleName = "Unarchive classroom";
            unarchiveButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            unarchiveButton.Ghost = true;
            unarchiveButton.IconSvg = "RollbackOutlined";
            unarchiveButton.Location = new Point(196, 160);
            unarchiveButton.Name = "unarchiveButton";
            unarchiveButton.Radius = 0;
            unarchiveButton.Size = new Size(40, 36);
            unarchiveButton.TabIndex = 4;
            unarchiveButton.Click += unarchiveButton_Click;
            //
            // deleteButton
            //
            deleteButton.AccessibleName = "Delete archived classroom";
            deleteButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            deleteButton.Ghost = true;
            deleteButton.IconSvg = "DeleteOutlined";
            deleteButton.Location = new Point(240, 160);
            deleteButton.Name = "deleteButton";
            deleteButton.Radius = 0;
            deleteButton.Size = new Size(40, 36);
            deleteButton.TabIndex = 5;
            deleteButton.Click += deleteButton_Click;
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
            nameLabel.Click += TeachingsCardControl_Click;
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
            avatar.Click += TeachingsCardControl_Click;
            avatar.Round = true;
            avatar.Size = new Size(44, 44);
            avatar.TabIndex = 1;
            avatar.Text = "A";
            // 
            // TeachingsCardControl
            // 
            AutoScaleDimensions = new SizeF(8F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panel1);
            Font = new Font("Microsoft YaHei UI", 10F);
            Margin = new Padding(8);
            MinimumSize = new Size(240, 208);
            Name = "TeachingsCardControl";
            Click += TeachingsCardControl_Click;
            Size = new Size(296, 208);
            panel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private AntdUI.Avatar sectionIcon;
        private AntdUI.Label sectionLabel;
        private AntdUI.Avatar timeIcon;
        private AntdUI.Label timeLabel;
        private AntdUI.Divider footerDivider;
        private AntdUI.Panel panel1;
        private AntdUI.Button unarchiveButton;
        private AntdUI.Button deleteButton;
        private AntdUI.Label nameLabel;
        private AntdUI.Avatar avatar;
    }
}
