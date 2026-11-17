namespace brilliant_lms.Views.Settings
{
    partial class SettingControl
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
            AntdUI.Tabs.StyleLine styleLine1 = new AntdUI.Tabs.StyleLine();
            settingsTab = new AntdUI.Tabs();
            informationTab = new AntdUI.TabPage();
            securityTab = new AntdUI.TabPage();
            settingsTab.SuspendLayout();
            SuspendLayout();
            // 
            // settingsTab
            // 
            settingsTab.Controls.Add(informationTab);
            settingsTab.Controls.Add(securityTab);
            settingsTab.Dock = DockStyle.Fill;
            settingsTab.Gap = 24;
            settingsTab.Location = new Point(0, 0);
            settingsTab.Name = "settingsTab";
            settingsTab.Pages.Add(informationTab);
            settingsTab.Pages.Add(securityTab);
            settingsTab.Size = new Size(600, 600);
            settingsTab.Style = styleLine1;
            settingsTab.TabIndex = 0;
            settingsTab.Text = "settingsTab";
            settingsTab.SelectedIndexChanged += settingsTab_SelectedIndexChanged;
            // 
            // informationTab
            // 
            informationTab.IconSvg = "UserOutlined";
            informationTab.Location = new Point(0, 47);
            informationTab.Name = "informationTab";
            informationTab.Size = new Size(600, 553);
            informationTab.TabIndex = 0;
            informationTab.Text = "Information";
            // 
            // securityTab
            // 
            securityTab.IconSvg = "SafetyOutlined";
            securityTab.Location = new Point(-1200, -1106);
            securityTab.Name = "securityTab";
            securityTab.Size = new Size(600, 553);
            securityTab.TabIndex = 1;
            securityTab.Text = "Security";
            // 
            // SettingControl
            // 
            AutoScaleDimensions = new SizeF(8F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(settingsTab);
            Font = new Font("Microsoft YaHei UI", 10F);
            Margin = new Padding(3, 4, 3, 4);
            Name = "SettingControl";
            Size = new Size(600, 600);
            settingsTab.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private AntdUI.Tabs settingsTab;
        private AntdUI.TabPage informationTab;
        private AntdUI.TabPage securityTab;
    }
}
