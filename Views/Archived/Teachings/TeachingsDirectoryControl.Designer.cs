namespace brilliant_lms.Views.Archived.Teachings
{
    partial class TeachingsDirectoryControl
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
            if (disposing)
            {
                brilliant_lms.Theme.ThemeManager.ThemeChanged -= ThemeManager_ThemeChanged;
                illustrationImage.Image?.Dispose();
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
            teachingsContent = new AntdUI.FlowPanel();
            emptyPanel = new AntdUI.Panel();
            illustrationContent = new AntdUI.Panel();
            illustrationImage = new AntdUI.Avatar();
            illustrationHeading = new AntdUI.Label();
            illustrationDescription = new AntdUI.Label();
            SuspendLayout();
            // 
            // teachingsContent
            // 
            teachingsContent.Align = AntdUI.TAlignFlow.Left;
            teachingsContent.AutoContainerBgTransparent = true;
            teachingsContent.AutoScroll = true;
            teachingsContent.Back = Color.Transparent;
            teachingsContent.Dock = DockStyle.Fill;
            teachingsContent.Location = new Point(0, 0);
            teachingsContent.Name = "teachingsContent";
            teachingsContent.Padding = new Padding(0, 16, 0, 0);
            teachingsContent.Size = new Size(952, 447);
            teachingsContent.TabIndex = 0;
            teachingsContent.Text = "flowPanel1";
            //
            // emptyPanel
            //
            emptyPanel.AutoContainerBgTransparent = true;
            emptyPanel.Back = Color.Transparent;
            emptyPanel.BackColor = Color.Transparent;
            emptyPanel.Dock = DockStyle.Fill;
            emptyPanel.Name = "emptyPanel";
            emptyPanel.Size = new Size(952, 447);
            emptyPanel.Visible = false;
            emptyPanel.Controls.Add(illustrationContent);
            //
            // illustrationContent
            //
            illustrationContent.Anchor = AnchorStyles.None;
            illustrationContent.AutoContainerBgTransparent = true;
            illustrationContent.Back = Color.Transparent;
            illustrationContent.BackColor = Color.Transparent;
            illustrationContent.Location = new Point(236, 53);
            illustrationContent.Margin = new Padding(0);
            illustrationContent.Name = "illustrationContent";
            illustrationContent.Size = new Size(480, 340);
            illustrationContent.Controls.Add(illustrationImage);
            illustrationContent.Controls.Add(illustrationHeading);
            illustrationContent.Controls.Add(illustrationDescription);
            //
            // illustrationImage
            //
            illustrationImage.Location = new Point(80, 0);
            illustrationImage.Name = "illustrationImage";
            illustrationImage.Size = new Size(320, 240);
            illustrationImage.Text = "";
            //
            // illustrationHeading
            //
            illustrationHeading.Font = new Font("Microsoft YaHei UI", 14F, FontStyle.Bold);
            illustrationHeading.Location = new Point(0, 252);
            illustrationHeading.Name = "illustrationHeading";
            illustrationHeading.Size = new Size(480, 32);
            illustrationHeading.Text = "No archived teachings.";
            illustrationHeading.TextAlign = ContentAlignment.MiddleCenter;
            //
            // illustrationDescription
            //
            illustrationDescription.Location = new Point(0, 292);
            illustrationDescription.Name = "illustrationDescription";
            illustrationDescription.Size = new Size(480, 40);
            illustrationDescription.Text = "Your archived teachings will appear here.";
            illustrationDescription.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // TeachingsDirectoryControl
            // 
            AutoScaleDimensions = new SizeF(8F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(teachingsContent);
            Controls.Add(emptyPanel);
            Font = new Font("Microsoft YaHei UI", 10F);
            Margin = new Padding(3, 4, 3, 4);
            Name = "TeachingsDirectoryControl";
            Size = new Size(952, 447);
            Load += TeachingsDirectoryControl_Load;
            ResumeLayout(false);
        }

        #endregion

        private AntdUI.FlowPanel teachingsContent;
        private AntdUI.Panel emptyPanel;
        private AntdUI.Panel illustrationContent;
        private AntdUI.Avatar illustrationImage;
        private AntdUI.Label illustrationHeading;
        private AntdUI.Label illustrationDescription;
    }
}
