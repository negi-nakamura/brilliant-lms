namespace brilliant_lms.Views.Invites
{
    partial class InvitesControl
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
            panel1 = new AntdUI.Panel();
            panel2 = new AntdUI.Panel();
            description = new AntdUI.Label();
            heading = new AntdUI.Label();
            invitesTabs = new AntdUI.Tabs();
            inboxTab = new AntdUI.TabPage();
            pendingTab = new AntdUI.TabPage();
            declinedTab = new AntdUI.TabPage();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            invitesTabs.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.AutoContainerBgTransparent = true;
            panel1.Back = Color.Transparent;
            panel1.Controls.Add(panel2);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(24, 16);
            panel1.Name = "panel1";
            panel1.Size = new Size(952, 80);
            panel1.TabIndex = 0;
            panel1.Text = "panel1";
            // 
            // panel2
            // 
            panel2.AutoContainerBgTransparent = true;
            panel2.Back = Color.Transparent;
            panel2.Controls.Add(description);
            panel2.Controls.Add(heading);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(952, 80);
            panel2.TabIndex = 4;
            panel2.Text = "panel2";
            // 
            // description
            // 
            description.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            description.AutoEllipsis = true;
            description.TextMultiLine = false;
            description.Font = new Font("Microsoft YaHei UI", 10F);
            description.Location = new Point(0, 36);
            description.Name = "description";
            description.Size = new Size(952, 19);
            description.TabIndex = 9;
            description.Text = "Accept or decline invitations to join a class.";
            // 
            // heading
            // 
            heading.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            heading.AutoEllipsis = true;
            heading.TextMultiLine = false;
            heading.Font = new Font("Microsoft YaHei UI", 18F, FontStyle.Bold);
            heading.Location = new Point(0, 0);
            heading.Name = "heading";
            heading.Size = new Size(952, 34);
            heading.TabIndex = 3;
            heading.Text = "Pending Invitations";
            // 
            // invitesTabs
            // 
            invitesTabs.Controls.Add(inboxTab);
            invitesTabs.Controls.Add(pendingTab);
            invitesTabs.Controls.Add(declinedTab);
            invitesTabs.Dock = DockStyle.Fill;
            invitesTabs.Gap = 24;
            invitesTabs.Location = new Point(24, 96);
            invitesTabs.Margin = new Padding(0);
            invitesTabs.Name = "invitesTabs";
            invitesTabs.Pages.Add(inboxTab);
            invitesTabs.Pages.Add(pendingTab);
            invitesTabs.Pages.Add(declinedTab);
            invitesTabs.Size = new Size(952, 488);
            invitesTabs.Style = styleLine1;
            invitesTabs.TabIndex = 1;
            invitesTabs.Text = "invitesTabs";
            invitesTabs.SelectedIndexChanged += invitesTabs_SelectedIndexChanged;
            // 
            // pendingTab
            // 
            inboxTab.Name = "inboxTab";
            inboxTab.Text = "Inbox";
            inboxTab.Size = new Size(952, 447);
            inboxTab.TabIndex = 0;
            pendingTab.Location = new Point(0, 41);
            pendingTab.Name = "pendingTab";
            pendingTab.Size = new Size(952, 447);
            pendingTab.TabIndex = 0;
            pendingTab.Text = "Pending";
            // 
            // declinedTab
            // 
            declinedTab.Location = new Point(0, 0);
            declinedTab.Name = "declinedTab";
            declinedTab.Size = new Size(0, 0);
            declinedTab.TabIndex = 1;
            declinedTab.Text = "Declined";
            //
            //
            // 
            // InvitesControl
            // 
            AutoScaleDimensions = new SizeF(8F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(invitesTabs);
            Controls.Add(panel1);
            Font = new Font("Microsoft YaHei UI", 10F);
            Margin = new Padding(0);
            Name = "InvitesControl";
            Padding = new Padding(24, 16, 24, 16);
            Size = new Size(1000, 600);
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            invitesTabs.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private AntdUI.Panel panel1;
        private AntdUI.Panel panel2;
        private AntdUI.Label heading;
        private AntdUI.Label description;
        private AntdUI.Tabs invitesTabs;
        private AntdUI.TabPage inboxTab;
        private AntdUI.TabPage pendingTab;
        private AntdUI.TabPage declinedTab;
    }
}
