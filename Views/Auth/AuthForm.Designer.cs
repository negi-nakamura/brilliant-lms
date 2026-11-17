namespace brilliant_lms.Views.Auth
{
    partial class AuthForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            themeButton = new AntdUI.Button();
            titleBar = new AntdUI.PageHeader();
            authPanel = new AntdUI.Panel();
            loginControl = new LoginControl();
            registerControl = new RegisterControl();
            illustrationPanel = new AntdUI.Panel();
            illustrationContent = new AntdUI.Panel();
            illustrationDescription = new AntdUI.Label();
            illustrationHeading = new AntdUI.Label();
            illustrationImage = new AntdUI.Avatar();
            layout = new AntdUI.GridPanel();
            titleBar.SuspendLayout();
            authPanel.SuspendLayout();
            illustrationPanel.SuspendLayout();
            illustrationContent.SuspendLayout();
            layout.SuspendLayout();
            SuspendLayout();
            // 
            // themeButton
            // 
            themeButton.AccessibleName = "Switch light or dark mode";
            themeButton.Dock = DockStyle.Right;
            themeButton.Ghost = true;
            themeButton.IconSvg = "SunOutlined";
            themeButton.Location = new Point(1086, 0);
            themeButton.Name = "themeButton";
            themeButton.Radius = 0;
            themeButton.Size = new Size(50, 36);
            themeButton.TabIndex = 0;
            themeButton.ToggleIconSvg = "MoonOutlined";
            themeButton.WaveSize = 0;
            themeButton.Click += themeButton_Click;
            // 
            // titleBar
            // 
            titleBar.Controls.Add(themeButton);
            titleBar.DividerShow = true;
            titleBar.Dock = DockStyle.Top;
            titleBar.Location = new Point(0, 0);
            titleBar.Name = "titleBar";
            titleBar.ShowButton = true;
            titleBar.ShowIcon = true;
            titleBar.Size = new Size(1280, 36);
            titleBar.SubText = "Learning Management System";
            titleBar.TabIndex = 2;
            titleBar.Text = "Brilliant";
            // 
            // authPanel
            // 
            authPanel.Back = Color.Transparent;
            authPanel.BackColor = Color.Transparent;
            authPanel.Controls.Add(registerControl);
            authPanel.Controls.Add(loginControl);
            authPanel.Location = new Point(231, 0);
            authPanel.Margin = new Padding(0);
            authPanel.Name = "authPanel";
            authPanel.Size = new Size(350, 684);
            authPanel.TabIndex = 0;
            authPanel.Text = "panel1";
            // 
            // loginControl
            // 
            loginControl.Anchor = AnchorStyles.None;
            loginControl.Location = new Point(0, 181);
            loginControl.Name = "loginControl";
            loginControl.Size = new Size(350, 286);
            loginControl.TabIndex = 0;
            // 
            // registerControl
            // 
            registerControl.Anchor = AnchorStyles.None;
            registerControl.Location = new Point(0, 107);
            registerControl.Name = "registerControl";
            registerControl.Size = new Size(350, 470);
            registerControl.TabIndex = 1;
            // 
            // illustrationPanel
            // 
            illustrationPanel.Back = Color.Transparent;
            illustrationPanel.BackColor = Color.Transparent;
            illustrationPanel.Controls.Add(illustrationContent);
            illustrationPanel.Location = new Point(619, 0);
            illustrationPanel.Margin = new Padding(38, 0, 0, 0);
            illustrationPanel.Name = "illustrationPanel";
            illustrationPanel.Size = new Size(430, 684);
            illustrationPanel.TabIndex = 1;
            illustrationPanel.Text = "panel1";
            // 
            // illustrationContent
            // 
            illustrationContent.Anchor = AnchorStyles.None;
            illustrationContent.Back = Color.Transparent;
            illustrationContent.BackColor = Color.Transparent;
            illustrationContent.Controls.Add(illustrationImage);
            illustrationContent.Controls.Add(illustrationHeading);
            illustrationContent.Controls.Add(illustrationDescription);
            illustrationContent.Location = new Point(0, 120);
            illustrationContent.Margin = new Padding(0);
            illustrationContent.Name = "illustrationContent";
            illustrationContent.Size = new Size(430, 408);
            illustrationContent.TabIndex = 0;
            // 
            // illustrationDescription
            // 
            illustrationDescription.Font = new Font("Microsoft YaHei UI", 10F);
            illustrationDescription.Location = new Point(0, 381);
            illustrationDescription.Name = "illustrationDescription";
            illustrationDescription.Size = new Size(430, 25);
            illustrationDescription.TabIndex = 4;
            illustrationDescription.Text = "Stay connected to your classes, teachers, and learning.";
            illustrationDescription.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // illustrationHeading
            // 
            illustrationHeading.Font = new Font("Microsoft YaHei UI", 14F, FontStyle.Bold);
            illustrationHeading.Location = new Point(0, 348);
            illustrationHeading.Name = "illustrationHeading";
            illustrationHeading.Size = new Size(430, 32);
            illustrationHeading.TabIndex = 3;
            illustrationHeading.Text = "Your next chapter starts here.";
            illustrationHeading.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // illustrationImage
            // 
            illustrationImage.Location = new Point(0, 0);
            illustrationImage.Name = "illustrationImage";
            illustrationImage.Size = new Size(430, 336);
            illustrationImage.TabIndex = 6;
            illustrationImage.Text = "";
            // 
            // layout
            // 
            layout.Controls.Add(illustrationPanel);
            layout.Controls.Add(authPanel);
            layout.Dock = DockStyle.Fill;
            layout.Location = new Point(0, 36);
            layout.Margin = new Padding(0);
            layout.Name = "layout";
            layout.Size = new Size(1280, 684);
            layout.Span = "50%_N 350 468 50%_N";
            layout.TabIndex = 3;
            layout.Text = "gridPanel1";
            // 
            // AuthForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1280, 720);
            Controls.Add(layout);
            Controls.Add(titleBar);
            MinimumSize = new Size(960, 620);
            WindowState = FormWindowState.Maximized;
            Name = "AuthForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            titleBar.ResumeLayout(false);
            authPanel.ResumeLayout(false);
            illustrationPanel.ResumeLayout(false);
            illustrationContent.ResumeLayout(false);
            layout.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private AntdUI.Button themeButton;
        private AntdUI.PageHeader titleBar;
        private AntdUI.Panel authPanel;
        private RegisterControl registerControl;
        private LoginControl loginControl;
        private AntdUI.Panel illustrationPanel;
        private AntdUI.Panel illustrationContent;
        private AntdUI.Avatar illustrationImage;
        private AntdUI.Label illustrationHeading;
        private AntdUI.Label illustrationDescription;
        private AntdUI.GridPanel layout;
    }
}
