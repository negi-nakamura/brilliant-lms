namespace brilliant_lms.Views.Settings
{
    partial class PersonalInformationControl
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
            firstNameInput = new AntdUI.Input();
            middleNameInput = new AntdUI.Input();
            lastNameInput = new AntdUI.Input();
            emailInput = new AntdUI.Input();
            updateButton = new AntdUI.Button();
            label1 = new AntdUI.Label();
            label2 = new AntdUI.Label();
            label3 = new AntdUI.Label();
            label4 = new AntdUI.Label();
            SuspendLayout();
            // 
            // heading
            // 
            heading.Font = new Font("Microsoft YaHei UI", 19F, FontStyle.Bold);
            heading.Location = new Point(12, 12);
            heading.Name = "heading";
            heading.Size = new Size(350, 38);
            heading.TabIndex = 20;
            heading.Text = "Personal Information";
            // 
            // description
            // 
            description.Font = new Font("Microsoft YaHei UI", 10F);
            description.Location = new Point(12, 51);
            description.Name = "description";
            description.Size = new Size(350, 24);
            description.TabIndex = 21;
            description.Text = "Update your name and email address.";
            // 
            // firstNameInput
            // 
            firstNameInput.AccessibleName = "First name";
            firstNameInput.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            firstNameInput.Font = new Font("Microsoft YaHei UI", 10F);
            firstNameInput.Location = new Point(12, 119);
            firstNameInput.Name = "firstNameInput";
            firstNameInput.PlaceholderText = "First name";
            firstNameInput.Radius = 0;
            firstNameInput.Size = new Size(576, 42);
            firstNameInput.TabIndex = 22;
            // 
            // middleNameInput
            // 
            middleNameInput.AccessibleName = "Middle name (optional)";
            middleNameInput.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            middleNameInput.Font = new Font("Microsoft YaHei UI", 10F);
            middleNameInput.Location = new Point(12, 185);
            middleNameInput.Name = "middleNameInput";
            middleNameInput.PlaceholderText = "Middle name (optional)";
            middleNameInput.Radius = 0;
            middleNameInput.Size = new Size(576, 42);
            middleNameInput.TabIndex = 23;
            // 
            // lastNameInput
            // 
            lastNameInput.AccessibleName = "Last name";
            lastNameInput.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lastNameInput.Font = new Font("Microsoft YaHei UI", 10F);
            lastNameInput.Location = new Point(12, 254);
            lastNameInput.Name = "lastNameInput";
            lastNameInput.PlaceholderText = "Last name";
            lastNameInput.Radius = 0;
            lastNameInput.Size = new Size(576, 42);
            lastNameInput.TabIndex = 24;
            // 
            // emailInput
            // 
            emailInput.AccessibleName = "Email";
            emailInput.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            emailInput.Font = new Font("Microsoft YaHei UI", 10F);
            emailInput.Location = new Point(12, 325);
            emailInput.Name = "emailInput";
            emailInput.PlaceholderText = "Email";
            emailInput.Radius = 0;
            emailInput.Size = new Size(576, 42);
            emailInput.TabIndex = 25;
            // 
            // updateButton
            // 
            updateButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            updateButton.Font = new Font("Microsoft YaHei UI", 10F);
            updateButton.Location = new Point(461, 383);
            updateButton.Name = "updateButton";
            updateButton.Radius = 0;
            updateButton.Size = new Size(127, 44);
            updateButton.TabIndex = 26;
            updateButton.Text = "Update";
            updateButton.Type = AntdUI.TTypeMini.Primary;
            updateButton.Click += updateButton_Click;
            // 
            // label1
            // 
            label1.Font = new Font("Microsoft YaHei UI", 10F);
            label1.Location = new Point(15, 98);
            label1.Name = "label1";
            label1.Size = new Size(350, 24);
            label1.TabIndex = 27;
            label1.Text = "First Name:";
            // 
            // label2
            // 
            label2.Font = new Font("Microsoft YaHei UI", 10F);
            label2.Location = new Point(15, 165);
            label2.Name = "label2";
            label2.Size = new Size(350, 24);
            label2.TabIndex = 28;
            label2.Text = "Middle Name (Optional):";
            // 
            // label3
            // 
            label3.Font = new Font("Microsoft YaHei UI", 10F);
            label3.Location = new Point(15, 234);
            label3.Name = "label3";
            label3.Size = new Size(350, 24);
            label3.TabIndex = 29;
            label3.Text = "Last Name:";
            // 
            // label4
            // 
            label4.Font = new Font("Microsoft YaHei UI", 10F);
            label4.Location = new Point(18, 305);
            label4.Name = "label4";
            label4.Size = new Size(350, 24);
            label4.TabIndex = 30;
            label4.Text = "Email Address:";
            // 
            // personalInformationControl
            // 
            AutoScaleDimensions = new SizeF(8F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(heading);
            Controls.Add(description);
            Controls.Add(firstNameInput);
            Controls.Add(middleNameInput);
            Controls.Add(lastNameInput);
            Controls.Add(emailInput);
            Controls.Add(updateButton);
            Font = new Font("Microsoft YaHei UI", 10F);
            Margin = new Padding(0);
            Name = "personalInformationControl";
            Padding = new Padding(12);
            Size = new Size(600, 553);
            ResumeLayout(false);
        }

        #endregion

        private AntdUI.Label heading;
        private AntdUI.Label description;
        private AntdUI.Input firstNameInput;
        private AntdUI.Input middleNameInput;
        private AntdUI.Input lastNameInput;
        private AntdUI.Input emailInput;
        private AntdUI.Button updateButton;
        private AntdUI.Label label1;
        private AntdUI.Label label2;
        private AntdUI.Label label3;
        private AntdUI.Label label4;
    }
}
