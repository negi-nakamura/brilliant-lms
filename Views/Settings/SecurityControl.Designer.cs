namespace brilliant_lms.Views.Settings
{
    partial class SecurityControl
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
            heading = new AntdUI.Label();
            description = new AntdUI.Label();
            currentPasswordInput = new AntdUI.Input();
            newPasswordInput = new AntdUI.Input();
            confirmPasswordInput = new AntdUI.Input();
            changePasswordButton = new AntdUI.Button();
            currentPasswordLabel = new AntdUI.Label();
            newPasswordLabel = new AntdUI.Label();
            confirmPasswordLabel = new AntdUI.Label();
            SuspendLayout();
            // 
            // heading
            // 
            heading.Font = new Font("Microsoft YaHei UI", 19F, FontStyle.Bold);
            heading.Location = new Point(12, 12);
            heading.Name = "heading";
            heading.Size = new Size(350, 38);
            heading.TabIndex = 20;
            heading.Text = "Security";
            // 
            // description
            // 
            description.Font = new Font("Microsoft YaHei UI", 10F);
            description.Location = new Point(12, 51);
            description.Name = "description";
            description.Size = new Size(350, 24);
            description.TabIndex = 21;
            description.Text = "Change your account password.";
            // 
            // currentPasswordInput
            // 
            currentPasswordInput.AccessibleName = "Current password";
            currentPasswordInput.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            currentPasswordInput.Font = new Font("Microsoft YaHei UI", 10F);
            currentPasswordInput.Location = new Point(12, 119);
            currentPasswordInput.Name = "currentPasswordInput";
            currentPasswordInput.PlaceholderText = "Current password";
            currentPasswordInput.Radius = 0;
            currentPasswordInput.Size = new Size(576, 42);
            currentPasswordInput.TabIndex = 0;
            currentPasswordInput.UseSystemPasswordChar = true;
            // 
            // newPasswordInput
            // 
            newPasswordInput.AccessibleName = "New password";
            newPasswordInput.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            newPasswordInput.Font = new Font("Microsoft YaHei UI", 10F);
            newPasswordInput.Location = new Point(12, 185);
            newPasswordInput.Name = "newPasswordInput";
            newPasswordInput.PlaceholderText = "New password";
            newPasswordInput.Radius = 0;
            newPasswordInput.Size = new Size(576, 42);
            newPasswordInput.TabIndex = 1;
            newPasswordInput.UseSystemPasswordChar = true;
            // 
            // confirmPasswordInput
            // 
            confirmPasswordInput.AccessibleName = "Confirm password";
            confirmPasswordInput.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            confirmPasswordInput.Font = new Font("Microsoft YaHei UI", 10F);
            confirmPasswordInput.Location = new Point(12, 254);
            confirmPasswordInput.Name = "confirmPasswordInput";
            confirmPasswordInput.PlaceholderText = "Confirm password";
            confirmPasswordInput.Radius = 0;
            confirmPasswordInput.Size = new Size(576, 42);
            confirmPasswordInput.TabIndex = 2;
            confirmPasswordInput.UseSystemPasswordChar = true;
            // 
            // changePasswordButton
            // 
            changePasswordButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            changePasswordButton.Font = new Font("Microsoft YaHei UI", 10F);
            changePasswordButton.Location = new Point(408, 312);
            changePasswordButton.Name = "changePasswordButton";
            changePasswordButton.Radius = 0;
            changePasswordButton.Size = new Size(180, 44);
            changePasswordButton.TabIndex = 3;
            changePasswordButton.Text = "Change Password";
            changePasswordButton.Type = AntdUI.TTypeMini.Primary;
            changePasswordButton.Click += changePasswordButton_Click;
            // 
            // currentPasswordLabel
            // 
            currentPasswordLabel.Font = new Font("Microsoft YaHei UI", 10F);
            currentPasswordLabel.Location = new Point(15, 98);
            currentPasswordLabel.Name = "currentPasswordLabel";
            currentPasswordLabel.Size = new Size(350, 24);
            currentPasswordLabel.TabIndex = 27;
            currentPasswordLabel.Text = "Current Password:";
            // 
            // newPasswordLabel
            // 
            newPasswordLabel.Font = new Font("Microsoft YaHei UI", 10F);
            newPasswordLabel.Location = new Point(15, 165);
            newPasswordLabel.Name = "newPasswordLabel";
            newPasswordLabel.Size = new Size(350, 24);
            newPasswordLabel.TabIndex = 28;
            newPasswordLabel.Text = "New Password:";
            // 
            // confirmPasswordLabel
            // 
            confirmPasswordLabel.Font = new Font("Microsoft YaHei UI", 10F);
            confirmPasswordLabel.Location = new Point(15, 234);
            confirmPasswordLabel.Name = "confirmPasswordLabel";
            confirmPasswordLabel.Size = new Size(350, 24);
            confirmPasswordLabel.TabIndex = 29;
            confirmPasswordLabel.Text = "Confirm Password:";
            // 
            // SecurityControl
            // 
            AutoScaleDimensions = new SizeF(8F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(confirmPasswordLabel);
            Controls.Add(newPasswordLabel);
            Controls.Add(currentPasswordLabel);
            Controls.Add(heading);
            Controls.Add(description);
            Controls.Add(currentPasswordInput);
            Controls.Add(newPasswordInput);
            Controls.Add(confirmPasswordInput);
            Controls.Add(changePasswordButton);
            Font = new Font("Microsoft YaHei UI", 10F);
            Margin = new Padding(0);
            Name = "SecurityControl";
            Padding = new Padding(12);
            Size = new Size(600, 553);
            ResumeLayout(false);
        }

        #endregion

        private AntdUI.Label heading;
        private AntdUI.Label description;
        private AntdUI.Input currentPasswordInput;
        private AntdUI.Input newPasswordInput;
        private AntdUI.Input confirmPasswordInput;
        private AntdUI.Button changePasswordButton;
        private AntdUI.Label currentPasswordLabel;
        private AntdUI.Label newPasswordLabel;
        private AntdUI.Label confirmPasswordLabel;
    }
}
