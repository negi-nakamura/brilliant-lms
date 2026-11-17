namespace brilliant_lms.Views.Auth
{
    partial class LoginControl
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
            AntdUI.HyperlinkLabel.LinkAppearance linkAppearance1 = new AntdUI.HyperlinkLabel.LinkAppearance();
            AntdUI.HyperlinkLabel.LinkAppearance linkAppearance2 = new AntdUI.HyperlinkLabel.LinkAppearance();
            heading = new AntdUI.Label();
            description = new AntdUI.Label();
            emailInput = new AntdUI.Input();
            passwordInput = new AntdUI.Input();
            showPassword = new AntdUI.Checkbox();
            loginButton = new AntdUI.Button();
            switchLink = new AntdUI.HyperlinkLabel();
            SuspendLayout();
            // 
            // heading
            // 
            heading.Font = new Font("Microsoft YaHei UI", 19F, FontStyle.Bold);
            heading.Location = new Point(0, 2);
            heading.Name = "heading";
            heading.Size = new Size(350, 38);
            heading.TabIndex = 7;
            heading.Text = "Log in to your classes";
            // 
            // description
            // 
            description.Font = new Font("Microsoft YaHei UI", 10F);
            description.Location = new Point(0, 41);
            description.Name = "description";
            description.Size = new Size(350, 24);
            description.TabIndex = 8;
            description.Text = "See your assignments, updates, and grades.";
            // 
            // emailInput
            // 
            emailInput.AccessibleName = "Email";
            emailInput.Font = new Font("Microsoft YaHei UI", 10F);
            emailInput.Location = new Point(0, 78);
            emailInput.Name = "emailInput";
            emailInput.PlaceholderText = "Email";
            emailInput.Radius = 0;
            emailInput.Size = new Size(350, 42);
            emailInput.TabIndex = 9;
            // 
            // passwordInput
            // 
            passwordInput.AccessibleName = "Password";
            passwordInput.Font = new Font("Microsoft YaHei UI", 10F);
            passwordInput.Location = new Point(0, 124);
            passwordInput.Name = "passwordInput";
            passwordInput.PlaceholderText = "Password";
            passwordInput.Radius = 0;
            passwordInput.Size = new Size(350, 42);
            passwordInput.TabIndex = 10;
            passwordInput.UseSystemPasswordChar = true;
            // 
            // showPassword
            // 
            showPassword.Font = new Font("Microsoft YaHei UI", 10F);
            showPassword.Location = new Point(0, 173);
            showPassword.Name = "showPassword";
            showPassword.Size = new Size(350, 28);
            showPassword.TabIndex = 11;
            showPassword.Text = "Show password";
            showPassword.CheckedChanged += showPassword_CheckedChanged;
            // 
            // loginButton
            // 
            loginButton.Font = new Font("Microsoft YaHei UI", 10F);
            loginButton.Location = new Point(0, 208);
            loginButton.Name = "loginButton";
            loginButton.Radius = 0;
            loginButton.Size = new Size(350, 44);
            loginButton.TabIndex = 12;
            loginButton.Text = "Log in";
            loginButton.Type = AntdUI.TTypeMini.Primary;
            loginButton.Click += loginButton_Click;
            // 
            // switchLink
            // 
            switchLink.Font = new Font("Microsoft YaHei UI", 10F);
            switchLink.HoverStyle = linkAppearance1;
            switchLink.Location = new Point(3, 258);
            switchLink.Name = "switchLink";
            switchLink.NormalStyle = linkAppearance2;
            switchLink.Size = new Size(344, 28);
            switchLink.TabIndex = 13;
            switchLink.Text = "Don't have an account? <a href='signup'>Register</a>";
            switchLink.TextAlign = ContentAlignment.MiddleCenter;
            switchLink.LinkClicked += switchLink_LinkClicked;
            // 
            // LoginControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(switchLink);
            Controls.Add(heading);
            Controls.Add(description);
            Controls.Add(emailInput);
            Controls.Add(passwordInput);
            Controls.Add(showPassword);
            Controls.Add(loginButton);
            Name = "LoginControl";
            Size = new Size(350, 286);
            ResumeLayout(false);
        }

        #endregion

        private AntdUI.Label heading;
        private AntdUI.Label description;
        private AntdUI.Input emailInput;
        private AntdUI.Input passwordInput;
        private AntdUI.Checkbox showPassword;
        private AntdUI.Button loginButton;
        private AntdUI.HyperlinkLabel switchLink;
    }
}
