namespace brilliant_lms.Views.Archived.Teachings.Assignments.Submissions
{
    partial class AssignmentsSubmissionsControl
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null) components.Dispose();
            if (disposing)
            {
                brilliant_lms.Theme.ThemeManager.ThemeChanged -= ThemeManager_ThemeChanged;
                illustrationImage.Image?.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            AntdUI.Tabs.StyleLine styleLine1 = new AntdUI.Tabs.StyleLine();
            headerPanel = new AntdUI.Panel();
            headingLabel = new AntdUI.Label();
            studentsBadge = new AntdUI.Badge();
            turnedInBadge = new AntdUI.Badge();
            gradedBadge = new AntdUI.Badge();
            returnedBadge = new AntdUI.Badge();
            refreshButton = new AntdUI.Button();
            statusTabs = new AntdUI.Tabs();
            allTab = new AntdUI.TabPage();
            assignedTab = new AntdUI.TabPage();
            turnedInTab = new AntdUI.TabPage();
            gradedTab = new AntdUI.TabPage();
            returnedTab = new AntdUI.TabPage();
            missingTab = new AntdUI.TabPage();
            submissionsContent = new AntdUI.StackPanel();
            headerPanel.SuspendLayout();
            statusTabs.SuspendLayout();
            submissionBody = new AntdUI.Panel();
            emptyPanel = new AntdUI.Panel();
            illustrationContent = new AntdUI.Panel();
            illustrationImage = new AntdUI.Avatar();
            illustrationHeading = new AntdUI.Label();
            illustrationDescription = new AntdUI.Label();
            SuspendLayout();
            // 
            // headerPanel
            // 
            headerPanel.AutoContainerBgTransparent = true;
            headerPanel.Back = Color.Transparent;
            headerPanel.BackColor = Color.Transparent;
            headerPanel.Controls.Add(headingLabel);
            headerPanel.Controls.Add(studentsBadge);
            headerPanel.Controls.Add(turnedInBadge);
            headerPanel.Controls.Add(gradedBadge);
            headerPanel.Controls.Add(returnedBadge);
            headerPanel.Controls.Add(refreshButton);
            headerPanel.Dock = DockStyle.Top;
            headerPanel.Location = new Point(24, 16);
            headerPanel.Name = "headerPanel";
            headerPanel.Size = new Size(1052, 88);
            headerPanel.TabIndex = 2;
            // 
            // headingLabel
            // 
            headingLabel.AutoEllipsis = true;
            headingLabel.Font = new Font("Microsoft YaHei UI", 16F, FontStyle.Bold);
            headingLabel.Location = new Point(0, 0);
            headingLabel.Name = "headingLabel";
            headingLabel.Size = new Size(900, 32);
            headingLabel.TabIndex = 0;
            // 
            // studentsBadge
            // 
            studentsBadge.BackColor = Color.FromArgb(100, 110, 125);
            studentsBadge.DotRatio = 0F;
            studentsBadge.Fill = Color.White;
            studentsBadge.ForeColor = Color.White;
            studentsBadge.Location = new Point(0, 44);
            studentsBadge.Name = "studentsBadge";
            studentsBadge.Size = new Size(160, 28);
            studentsBadge.TabIndex = 1;
            studentsBadge.Text = "0 students";
            // 
            // turnedInBadge
            // 
            turnedInBadge.BackColor = Color.FromArgb(22, 119, 255);
            turnedInBadge.DotRatio = 0F;
            turnedInBadge.Fill = Color.White;
            turnedInBadge.ForeColor = Color.White;
            turnedInBadge.Location = new Point(166, 44);
            turnedInBadge.Name = "turnedInBadge";
            turnedInBadge.Size = new Size(160, 28);
            turnedInBadge.TabIndex = 2;
            turnedInBadge.Text = "0 turned in";
            // 
            // gradedBadge
            // 
            gradedBadge.BackColor = Color.FromArgb(250, 173, 20);
            gradedBadge.DotRatio = 0F;
            gradedBadge.Fill = Color.White;
            gradedBadge.ForeColor = Color.White;
            gradedBadge.Location = new Point(332, 44);
            gradedBadge.Name = "gradedBadge";
            gradedBadge.Size = new Size(160, 28);
            gradedBadge.TabIndex = 3;
            gradedBadge.Text = "0 graded";
            // 
            // returnedBadge
            // 
            returnedBadge.BackColor = Color.FromArgb(82, 196, 26);
            returnedBadge.DotRatio = 0F;
            returnedBadge.Fill = Color.White;
            returnedBadge.ForeColor = Color.White;
            returnedBadge.Location = new Point(498, 44);
            returnedBadge.Name = "returnedBadge";
            returnedBadge.Size = new Size(160, 28);
            returnedBadge.TabIndex = 4;
            returnedBadge.Text = "0 returned";
            // 
            // refreshButton
            // 
            refreshButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            refreshButton.Location = new Point(932, 0);
            refreshButton.Name = "refreshButton";
            refreshButton.Radius = 0;
            refreshButton.Size = new Size(120, 40);
            refreshButton.TabIndex = 3;
            refreshButton.Text = "Refresh";
            refreshButton.Type = AntdUI.TTypeMini.Primary;
            refreshButton.Click += refreshButton_Click;
            // 
            // statusTabs
            // 
            statusTabs.Controls.Add(allTab);
            statusTabs.Controls.Add(assignedTab);
            statusTabs.Controls.Add(turnedInTab);
            statusTabs.Controls.Add(gradedTab);
            statusTabs.Controls.Add(returnedTab);
            statusTabs.Controls.Add(missingTab);
            statusTabs.Dock = DockStyle.Top;
            statusTabs.Gap = 16;
            statusTabs.Location = new Point(24, 104);
            statusTabs.Name = "statusTabs";
            statusTabs.Pages.Add(allTab);
            statusTabs.Pages.Add(assignedTab);
            statusTabs.Pages.Add(turnedInTab);
            statusTabs.Pages.Add(gradedTab);
            statusTabs.Pages.Add(returnedTab);
            statusTabs.Pages.Add(missingTab);
            statusTabs.Size = new Size(1052, 44);
            statusTabs.Style = styleLine1;
            statusTabs.TabIndex = 1;
            statusTabs.SelectedIndexChanged += statusTabs_SelectedIndexChanged;
            // 
            // allTab
            // 
            allTab.Location = new Point(0, 39);
            allTab.Name = "allTab";
            allTab.Size = new Size(1052, 5);
            allTab.TabIndex = 0;
            allTab.Text = "All";
            // 
            // assignedTab
            // 
            assignedTab.Location = new Point(0, 0);
            assignedTab.Name = "assignedTab";
            assignedTab.Size = new Size(0, 0);
            assignedTab.TabIndex = 1;
            assignedTab.Text = "Assigned";
            // 
            // turnedInTab
            // 
            turnedInTab.Location = new Point(0, 0);
            turnedInTab.Name = "turnedInTab";
            turnedInTab.Size = new Size(0, 0);
            turnedInTab.TabIndex = 2;
            turnedInTab.Text = "Turned in";
            // 
            // gradedTab
            // 
            gradedTab.Location = new Point(0, 0);
            gradedTab.Name = "gradedTab";
            gradedTab.Size = new Size(0, 0);
            gradedTab.TabIndex = 3;
            gradedTab.Text = "Graded";
            // 
            // returnedTab
            // 
            returnedTab.Location = new Point(0, 0);
            returnedTab.Name = "returnedTab";
            returnedTab.Size = new Size(0, 0);
            returnedTab.TabIndex = 4;
            returnedTab.Text = "Returned";
            // 
            // missingTab
            // 
            missingTab.Location = new Point(0, 0);
            missingTab.Name = "missingTab";
            missingTab.Size = new Size(0, 0);
            missingTab.TabIndex = 5;
            missingTab.Text = "Missing";
            // 
            // submissionsContent
            // 
            submissionsContent.AutoContainerBgTransparent = true;
            submissionsContent.AutoScroll = true;
            submissionsContent.Back = Color.Transparent;
            submissionsContent.BackColor = Color.Transparent;
            submissionsContent.Dock = DockStyle.Fill;
            submissionsContent.Location = new Point(24, 148);
            submissionsContent.Name = "submissionsContent";
            submissionsContent.Padding = new Padding(0, 12, 0, 0);
            submissionsContent.Size = new Size(1052, 516);
            submissionsContent.TabIndex = 0;
            submissionsContent.Vertical = true;
            //
            // emptyPanel
            //
            emptyPanel.AutoContainerBgTransparent = true;
            emptyPanel.Back = Color.Transparent;
            emptyPanel.BackColor = Color.Transparent;
            emptyPanel.Dock = DockStyle.Fill;
            emptyPanel.Name = "emptyPanel";
            emptyPanel.Size = new Size(1052, 516);
            emptyPanel.Visible = false;
            emptyPanel.Controls.Add(illustrationContent);
            //
            // illustrationContent
            //
            illustrationContent.Anchor = AnchorStyles.None;
            illustrationContent.AutoContainerBgTransparent = true;
            illustrationContent.Back = Color.Transparent;
            illustrationContent.BackColor = Color.Transparent;
            illustrationContent.Location = new Point(286, 88);
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
            illustrationHeading.Text = "No submissions to show.";
            illustrationHeading.TextAlign = ContentAlignment.MiddleCenter;
            //
            // illustrationDescription
            //
            illustrationDescription.Location = new Point(0, 292);
            illustrationDescription.Name = "illustrationDescription";
            illustrationDescription.Size = new Size(480, 40);
            illustrationDescription.Text = "No student work matches the selected status.";
            illustrationDescription.TextAlign = ContentAlignment.MiddleCenter;
            //
            // submissionBody
            //
            submissionBody.AutoContainerBgTransparent = true;
            submissionBody.Back = Color.Transparent;
            submissionBody.BackColor = Color.Transparent;
            submissionBody.Dock = DockStyle.Fill;
            submissionBody.Name = "submissionBody";
            submissionBody.Size = new Size(1052, 516);
            submissionBody.Controls.Add(submissionsContent);
            submissionBody.Controls.Add(emptyPanel);
            // 
            // AssignmentsSubmissionsControl
            // 
            AutoScaleDimensions = new SizeF(8F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(submissionBody);
            Controls.Add(statusTabs);
            Controls.Add(headerPanel);
            Font = new Font("Microsoft YaHei UI", 10F);
            Name = "AssignmentsSubmissionsControl";
            Padding = new Padding(24, 16, 24, 16);
            Size = new Size(1100, 680);
            Load += AssignmentsSubmissionsControl_Load;
            headerPanel.ResumeLayout(false);
            statusTabs.ResumeLayout(false);
            ResumeLayout(false);
        }
        private AntdUI.Panel headerPanel;
        private AntdUI.Label headingLabel;
        private AntdUI.Badge studentsBadge;
        private AntdUI.Badge turnedInBadge;
        private AntdUI.Badge gradedBadge;
        private AntdUI.Badge returnedBadge;
        private AntdUI.Button refreshButton;
        private AntdUI.Tabs statusTabs;
        private AntdUI.StackPanel submissionsContent;
        private AntdUI.Panel submissionBody;
        private AntdUI.Panel emptyPanel;
        private AntdUI.Panel illustrationContent;
        private AntdUI.Avatar illustrationImage;
        private AntdUI.Label illustrationHeading;
        private AntdUI.Label illustrationDescription;
        private AntdUI.TabPage allTab;
        private AntdUI.TabPage assignedTab;
        private AntdUI.TabPage turnedInTab;
        private AntdUI.TabPage gradedTab;
        private AntdUI.TabPage returnedTab;
        private AntdUI.TabPage missingTab;
    }
}
