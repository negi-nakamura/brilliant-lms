namespace brilliant_lms.Views.Classrooms
{
    partial class JoinClassroomControl
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
            classCodeInput = new AntdUI.Input();
            joinButton = new AntdUI.Button();
            description = new AntdUI.Label();
            cancelButton = new AntdUI.Button();
            SuspendLayout();
            // 
            // classCodeInput
            // 
            classCodeInput.AccessibleName = "Class code";
            classCodeInput.Font = new Font("Microsoft YaHei UI", 10F);
            classCodeInput.Location = new Point(3, 51);
            classCodeInput.Margin = new Padding(3, 4, 3, 4);
            classCodeInput.Name = "classCodeInput";
            classCodeInput.PlaceholderText = "Enter class code";
            classCodeInput.Radius = 0;
            classCodeInput.Size = new Size(394, 42);
            classCodeInput.TabIndex = 0;

            // 
            // joinButton
            // 
            joinButton.Font = new Font("Microsoft YaHei UI", 10F);
            joinButton.Location = new Point(283, 100);
            joinButton.Margin = new Padding(3, 4, 3, 4);
            joinButton.Name = "joinButton";
            joinButton.Radius = 0;
            joinButton.Size = new Size(112, 44);
            joinButton.TabIndex = 1;
            joinButton.Text = "Join";
            joinButton.Type = AntdUI.TTypeMini.Primary;
            joinButton.Click += joinButton_Click;
            // 
            // description
            // 
            description.Font = new Font("Microsoft YaHei UI", 10F);
            description.Location = new Point(8, 18);
            description.Name = "description";
            description.Size = new Size(384, 24);
            description.TabIndex = 15;
            description.Text = "Enter the class code provided by your teacher.";
            // 
            // cancelButton
            // 
            cancelButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            cancelButton.Location = new Point(159, 100);
            cancelButton.Name = "cancelButton";
            cancelButton.Radius = 0;
            cancelButton.Size = new Size(120, 42);
            cancelButton.TabIndex = 2;
            cancelButton.Text = "Cancel";
            cancelButton.Click += cancelButton_Click;
            // 
            // JoinClassroomControl
            // 
            AutoScaleDimensions = new SizeF(8F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(cancelButton);
            Controls.Add(description);
            Controls.Add(classCodeInput);
            Controls.Add(joinButton);
            Font = new Font("Microsoft YaHei UI", 10F);
            Margin = new Padding(0);
            Name = "JoinClassroomControl";
            Size = new Size(400, 150);
            ResumeLayout(false);
        }

        #endregion

        private AntdUI.Input classCodeInput;
        private AntdUI.Button joinButton;
        private AntdUI.Label description;
        private AntdUI.Button cancelButton;
    }
}
