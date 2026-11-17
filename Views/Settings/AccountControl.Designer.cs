namespace brilliant_lms.Views.Settings
{
    partial class AccountControl
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
            avatar = new AntdUI.Avatar();
            fullnameLabel = new AntdUI.Label();
            emailLabel = new AntdUI.Label();
            SuspendLayout();
            // 
            // avatar
            // 
            avatar.BackColor = Color.FromArgb(22, 119, 255);
            avatar.Font = new Font("Microsoft YaHei UI Light", 26F, FontStyle.Bold);
            avatar.ForeColor = Color.White;
            avatar.Location = new Point(152, 43);
            avatar.Margin = new Padding(3, 4, 3, 4);
            avatar.Name = "avatar";
            avatar.Round = true;
            avatar.Size = new Size(90, 90);
            avatar.TabIndex = 0;
            avatar.Text = "1";
            // 
            // fullnameLabel
            // 
            fullnameLabel.Font = new Font("Microsoft YaHei UI", 17F, FontStyle.Bold);
            fullnameLabel.Location = new Point(20, 137);
            fullnameLabel.Name = "fullnameLabel";
            fullnameLabel.Size = new Size(360, 60);
            fullnameLabel.TabIndex = 2;
            fullnameLabel.Text = "Christian Postrado Regalado";
            fullnameLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // emailLabel
            // 
            emailLabel.Location = new Point(20, 195);
            emailLabel.Name = "emailLabel";
            emailLabel.Size = new Size(360, 22);
            emailLabel.TabIndex = 3;
            emailLabel.Text = "regaladochristian999.pro@gmail.com";
            emailLabel.TextAlign = ContentAlignment.TopCenter;
            // 
            // AccountControl
            // 
            AutoScaleDimensions = new SizeF(8F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(emailLabel);
            Controls.Add(fullnameLabel);
            Controls.Add(avatar);
            Font = new Font("Microsoft YaHei UI", 10F);
            Margin = new Padding(3, 4, 3, 4);
            Name = "AccountControl";
            Size = new Size(400, 250);
            ResumeLayout(false);
        }

        #endregion

        private AntdUI.Avatar avatar;
        private AntdUI.Label fullnameLabel;
        private AntdUI.Label emailLabel;
    }
}
