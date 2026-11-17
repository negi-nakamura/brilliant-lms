namespace brilliant_lms.Views.Classrooms
{
    partial class CreateClassroomControl
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
            classNameInput = new AntdUI.Input();
            createButton = new AntdUI.Button();
            description = new AntdUI.Label();
            cancelButton = new AntdUI.Button();
            SuspendLayout();
            // 
            // classNameInput
            // 
            classNameInput.AccessibleName = "Class name";
            classNameInput.Font = new Font("Microsoft YaHei UI", 10F);
            classNameInput.Location = new Point(3, 51);
            classNameInput.Margin = new Padding(3, 4, 3, 4);
            classNameInput.Name = "classNameInput";
            classNameInput.PlaceholderText = "Enter class name";
            classNameInput.Radius = 0;
            classNameInput.Size = new Size(394, 42);
            classNameInput.TabIndex = 0;
            // 
            // createButton
            // 
            createButton.Font = new Font("Microsoft YaHei UI", 10F);
            createButton.Location = new Point(283, 100);
            createButton.Margin = new Padding(3, 4, 3, 4);
            createButton.Name = "createButton";
            createButton.Radius = 0;
            createButton.Size = new Size(112, 44);
            createButton.TabIndex = 1;
            createButton.Text = "Create";
            createButton.Type = AntdUI.TTypeMini.Primary;
            createButton.Click += createButton_Click;
            // 
            // description
            // 
            description.Font = new Font("Microsoft YaHei UI", 10F);
            description.Location = new Point(8, 18);
            description.Name = "description";
            description.Size = new Size(350, 24);
            description.TabIndex = 15;
            description.Text = "Give your class a name. You can add details later.";
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
            // CreateClassroomControl
            // 
            AutoScaleDimensions = new SizeF(8F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(cancelButton);
            Controls.Add(description);
            Controls.Add(classNameInput);
            Controls.Add(createButton);
            Font = new Font("Microsoft YaHei UI", 10F);
            Margin = new Padding(0);
            Name = "CreateClassroomControl";
            Size = new Size(400, 150);
            ResumeLayout(false);
        }

        #endregion

        private AntdUI.Input classNameInput;
        private AntdUI.Button createButton;
        private AntdUI.Label description;
        private AntdUI.Button cancelButton;
    }
}
