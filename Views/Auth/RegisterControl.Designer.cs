namespace brilliant_lms.Views.Auth
{
    partial class RegisterControl
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
            firstNameInput = new AntdUI.Input();
            middleNameInput = new AntdUI.Input();
            lastNameInput = new AntdUI.Input();
            emailInput = new AntdUI.Input();
            passwordInput = new AntdUI.Input();
            confirmPasswordInput = new AntdUI.Input();
            showPassword = new AntdUI.Checkbox();
            registerButton = new AntdUI.Button();
            switchLink = new AntdUI.HyperlinkLabel();
            SuspendLayout();
            // 
            // heading
            // 
            heading.Font = new Font("Microsoft YaHei UI", 19F, FontStyle.Bold);
            heading.Location = new Point(0, 0);
            heading.Name = "heading";
            heading.Size = new Size(350, 38);
            heading.TabIndex = 10;
            heading.Text = "Create your account";
            // 
            // description
            // 
            description.Font = new Font("Microsoft YaHei UI", 10F);
            description.Location = new Point(0, 39);
            description.Name = "description";
            description.Size = new Size(350, 24);
            description.TabIndex = 11;
            description.Text = "Keep your classes and coursework in one place.";
            // 
            // firstNameInput
            // 
            firstNameInput.AccessibleName = "First name";
            firstNameInput.Font = new Font("Microsoft YaHei UI", 10F);
            firstNameInput.Location = new Point(0, 76);
            firstNameInput.Name = "firstNameInput";
            firstNameInput.PlaceholderText = "First name";
            firstNameInput.Radius = 0;
            firstNameInput.Size = new Size(350, 42);
            firstNameInput.TabIndex = 12;
            // 
            // middleNameInput
            // 
            middleNameInput.AccessibleName = "Middle name (optional)";
            middleNameInput.Font = new Font("Microsoft YaHei UI", 10F);
            middleNameInput.Location = new Point(0, 122);
            middleNameInput.Name = "middleNameInput";
            middleNameInput.PlaceholderText = "Middle name (optional)";
            middleNameInput.Radius = 0;
            middleNameInput.Size = new Size(350, 42);
            middleNameInput.TabIndex = 13;
            // 
            // lastNameInput
            // 
            lastNameInput.AccessibleName = "Last name";
            lastNameInput.Font = new Font("Microsoft YaHei UI", 10F);
            lastNameInput.Location = new Point(0, 168);
            lastNameInput.Name = "lastNameInput";
            lastNameInput.PlaceholderText = "Last name";
            lastNameInput.Radius = 0;
            lastNameInput.Size = new Size(350, 42);
            lastNameInput.TabIndex = 14;
            // 
            // emailInput
            // 
            emailInput.AccessibleName = "Email";
            emailInput.Font = new Font("Microsoft YaHei UI", 10F);
            emailInput.Location = new Point(0, 214);
            emailInput.Name = "emailInput";
            emailInput.PlaceholderText = "Email";
            emailInput.Radius = 0;
            emailInput.Size = new Size(350, 42);
            emailInput.TabIndex = 15;
            // 
            // passwordInput
            // 
            passwordInput.AccessibleName = "Password";
            passwordInput.Font = new Font("Microsoft YaHei UI", 10F);
            passwordInput.Location = new Point(0, 260);
            passwordInput.Name = "passwordInput";
            passwordInput.PlaceholderText = "Password";
            passwordInput.Radius = 0;
            passwordInput.Size = new Size(350, 42);
            passwordInput.TabIndex = 16;
            passwordInput.UseSystemPasswordChar = true;
            // 
            // confirmPasswordInput
            // 
            confirmPasswordInput.AccessibleName = "Confirm password";
            confirmPasswordInput.Font = new Font("Microsoft YaHei UI", 10F);
            confirmPasswordInput.Location = new Point(0, 306);
            confirmPasswordInput.Name = "confirmPasswordInput";
            confirmPasswordInput.PlaceholderText = "Confirm password";
            confirmPasswordInput.Radius = 0;
            confirmPasswordInput.Size = new Size(350, 42);
            confirmPasswordInput.TabIndex = 17;
            confirmPasswordInput.UseSystemPasswordChar = true;
            // 
            // showPassword
            // 
            showPassword.Font = new Font("Microsoft YaHei UI", 10F);
            showPassword.Location = new Point(0, 355);
            showPassword.Name = "showPassword";
            showPassword.Size = new Size(350, 28);
            showPassword.TabIndex = 18;
            showPassword.Text = "Show password";
            showPassword.CheckedChanged += showPassword_CheckedChanged;
            // 
            // registerButton
            // 
            registerButton.Font = new Font("Microsoft YaHei UI", 10F);
            registerButton.Location = new Point(0, 390);
            registerButton.Name = "registerButton";
            registerButton.Radius = 0;
            registerButton.Size = new Size(350, 44);
            registerButton.TabIndex = 19;
            registerButton.Text = "Create account";
            registerButton.Type = AntdUI.TTypeMini.Primary;
            registerButton.Click += registerButton_Click;
            // 
            // switchLink
            // 
            switchLink.Font = new Font("Microsoft YaHei UI", 10F);
            switchLink.HoverStyle = linkAppearance1;
            switchLink.Location = new Point(3, 442);
            switchLink.Name = "switchLink";
            switchLink.NormalStyle = linkAppearance2;
            switchLink.Size = new Size(344, 28);
            switchLink.TabIndex = 20;
            switchLink.Text = "Already have an account? <a href='signup'>Login</a>";
            switchLink.TextAlign = ContentAlignment.MiddleCenter;
            switchLink.LinkClicked += switchLink_LinkClicked;
            // 
            // RegisterControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(switchLink);
            Controls.Add(heading);
            Controls.Add(description);
            Controls.Add(firstNameInput);
            Controls.Add(middleNameInput);
            Controls.Add(lastNameInput);
            Controls.Add(emailInput);
            Controls.Add(passwordInput);
            Controls.Add(confirmPasswordInput);
            Controls.Add(showPassword);
            Controls.Add(registerButton);
            Name = "RegisterControl";
            Size = new Size(350, 470);
            ResumeLayout(false);
        }

        #endregion

        private AntdUI.Label heading;
        private AntdUI.Label description;
        private AntdUI.Input firstNameInput;
        private AntdUI.Input middleNameInput;
        private AntdUI.Input lastNameInput;
        private AntdUI.Input emailInput;
        private AntdUI.Input passwordInput;
        private AntdUI.Input confirmPasswordInput;
        private AntdUI.Checkbox showPassword;
        private AntdUI.Button registerButton;
        private AntdUI.HyperlinkLabel switchLink;
    }
}
