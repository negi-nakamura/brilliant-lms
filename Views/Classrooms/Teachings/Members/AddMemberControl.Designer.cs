namespace brilliant_lms.Views.Classrooms.Teachings.Members
{
    partial class AddMemberControl
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
            emailLabel = new AntdUI.Label();
            emailInput = new AntdUI.Input();
            roleLabel = new AntdUI.Label();
            roleSelect = new AntdUI.Select();
            addButton = new AntdUI.Button();
            cancelButton = new AntdUI.Button();
            SuspendLayout();
            //
            // emailLabel
            //
            emailLabel.Location = new Point(12, 12);
            emailLabel.Name = "emailLabel";
            emailLabel.Size = new Size(456, 24);
            emailLabel.Text = "Email:";
            //
            // emailInput
            //
            emailInput.Location = new Point(12, 40);
            emailInput.Name = "emailInput";
            emailInput.PlaceholderText = "Enter an existing account's email";
            emailInput.Radius = 0;
            emailInput.Size = new Size(456, 44);
            emailInput.TabIndex = 0;
            //
            // roleLabel
            //
            roleLabel.Location = new Point(12, 100);
            roleLabel.Name = "roleLabel";
            roleLabel.Size = new Size(456, 24);
            roleLabel.Text = "Role:";
            //
            // roleSelect
            //
            roleSelect.Location = new Point(12, 128);
            roleSelect.Name = "roleSelect";
            roleSelect.List = true;
            roleSelect.Radius = 0;
            roleSelect.Size = new Size(456, 44);
            roleSelect.TabIndex = 1;
            //
            // addButton
            //
            addButton.Location = new Point(288, 196);
            addButton.Name = "addButton";
            addButton.Radius = 0;
            addButton.Size = new Size(180, 44);
            addButton.TabIndex = 2;
            addButton.Text = "Send Invitation";
            addButton.Type = AntdUI.TTypeMini.Primary;
            addButton.Click += addButton_Click;
            //
            // cancelButton
            //
            cancelButton.Location = new Point(160, 196);
            cancelButton.Name = "cancelButton";
            cancelButton.Radius = 0;
            cancelButton.Size = new Size(120, 44);
            cancelButton.TabIndex = 3;
            cancelButton.Text = "Cancel";
            cancelButton.Click += cancelButton_Click;
            //
            // AddMemberControl
            //
            AutoScaleDimensions = new SizeF(8F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(emailLabel);
            Controls.Add(emailInput);
            Controls.Add(roleLabel);
            Controls.Add(roleSelect);
            Controls.Add(addButton);
            Controls.Add(cancelButton);
            Font = new Font("Microsoft YaHei UI", 10F);
            Name = "AddMemberControl";
            Padding = new Padding(12);
            Size = new Size(480, 256);
            ResumeLayout(false);
        }

        #endregion

        private AntdUI.Label emailLabel;
        private AntdUI.Input emailInput;
        private AntdUI.Label roleLabel;
        private AntdUI.Select roleSelect;
        private AntdUI.Button addButton;
        private AntdUI.Button cancelButton;
    }
}
