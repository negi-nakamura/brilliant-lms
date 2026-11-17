namespace brilliant_lms.Views.Classrooms.Teachings.Reports
{
    partial class ReportsControl
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
            AntdUI.Tabs.StyleLine styleLine1 = new AntdUI.Tabs.StyleLine();
            summaryGrid = new AntdUI.GridPanel();
            missingCard = new AntdUI.Panel();
            missingLabel = new AntdUI.Label();
            missingValue = new AntdUI.Label();
            gradedCard = new AntdUI.Panel();
            gradedLabel = new AntdUI.Label();
            gradedValue = new AntdUI.Label();
            submittedCard = new AntdUI.Panel();
            submittedLabel = new AntdUI.Label();
            submittedValue = new AntdUI.Label();
            assignmentsCard = new AntdUI.Panel();
            assignmentsLabel = new AntdUI.Label();
            assignmentsValue = new AntdUI.Label();
            studentsCard = new AntdUI.Panel();
            studentsLabel = new AntdUI.Label();
            studentsValue = new AntdUI.Label();
            filtersGrid = new AntdUI.GridPanel();
            toDatePanel = new AntdUI.Panel();
            toDatePicker = new AntdUI.DatePicker();
            toDateLabel = new AntdUI.Label();
            fromDatePanel = new AntdUI.Panel();
            fromDatePicker = new AntdUI.DatePicker();
            fromDateLabel = new AntdUI.Label();
            studentPanel = new AntdUI.Panel();
            studentSelect = new AntdUI.Select();
            studentLabel = new AntdUI.Label();
            assignmentPanel = new AntdUI.Panel();
            assignmentSelect = new AntdUI.Select();
            assignmentLabel = new AntdUI.Label();
            filterActions = new AntdUI.Panel();
            filterHint = new AntdUI.Label();
            resetButton = new AntdUI.Button();
            applyButton = new AntdUI.Button();
            reportTabs = new AntdUI.Tabs();
            assignmentsTab = new AntdUI.TabPage();
            studentsTab = new AntdUI.TabPage();
            reportContent = new AntdUI.Panel();
            summaryGrid.SuspendLayout();
            missingCard.SuspendLayout();
            gradedCard.SuspendLayout();
            submittedCard.SuspendLayout();
            assignmentsCard.SuspendLayout();
            studentsCard.SuspendLayout();
            filtersGrid.SuspendLayout();
            toDatePanel.SuspendLayout();
            fromDatePanel.SuspendLayout();
            studentPanel.SuspendLayout();
            assignmentPanel.SuspendLayout();
            filterActions.SuspendLayout();
            reportTabs.SuspendLayout();
            SuspendLayout();
            // 
            // summaryGrid
            // 
            summaryGrid.Back = Color.Transparent;
            summaryGrid.BackColor = Color.Transparent;
            summaryGrid.Controls.Add(missingCard);
            summaryGrid.Controls.Add(gradedCard);
            summaryGrid.Controls.Add(submittedCard);
            summaryGrid.Controls.Add(assignmentsCard);
            summaryGrid.Controls.Add(studentsCard);
            summaryGrid.Dock = DockStyle.Top;
            summaryGrid.Location = new Point(0, 16);
            summaryGrid.Name = "summaryGrid";
            summaryGrid.Size = new Size(952, 104);
            summaryGrid.Span = "20% 20% 20% 20% 20%";
            summaryGrid.TabIndex = 4;
            // 
            // missingCard
            // 
            missingCard.AutoContainerBgTransparent = true;
            missingCard.Back = Color.Transparent;
            missingCard.BackColor = Color.Transparent;
            missingCard.BorderWidth = 1F;
            missingCard.Controls.Add(missingLabel);
            missingCard.Controls.Add(missingValue);
            missingCard.Location = new Point(762, 0);
            missingCard.Margin = new Padding(0, 0, 12, 12);
            missingCard.Name = "missingCard";
            missingCard.Radius = 0;
            missingCard.Size = new Size(178, 92);
            missingCard.TabIndex = 0;
            // 
            // missingLabel
            // 
            missingLabel.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            missingLabel.AutoEllipsis = true;
            missingLabel.Location = new Point(16, 12);
            missingLabel.Name = "missingLabel";
            missingLabel.Size = new Size(146, 24);
            missingLabel.TabIndex = 0;
            missingLabel.Text = "Missing";
            // 
            // missingValue
            // 
            missingValue.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            missingValue.Font = new Font("Microsoft YaHei UI", 20F, FontStyle.Bold);
            missingValue.Location = new Point(16, 40);
            missingValue.Name = "missingValue";
            missingValue.Size = new Size(146, 36);
            missingValue.TabIndex = 1;
            missingValue.Text = "0";
            // 
            // gradedCard
            // 
            gradedCard.AutoContainerBgTransparent = true;
            gradedCard.Back = Color.Transparent;
            gradedCard.BackColor = Color.Transparent;
            gradedCard.BorderWidth = 1F;
            gradedCard.Controls.Add(gradedLabel);
            gradedCard.Controls.Add(gradedValue);
            gradedCard.Location = new Point(571, 0);
            gradedCard.Margin = new Padding(0, 0, 12, 12);
            gradedCard.Name = "gradedCard";
            gradedCard.Radius = 0;
            gradedCard.Size = new Size(178, 92);
            gradedCard.TabIndex = 1;
            // 
            // gradedLabel
            // 
            gradedLabel.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            gradedLabel.AutoEllipsis = true;
            gradedLabel.Location = new Point(16, 12);
            gradedLabel.Name = "gradedLabel";
            gradedLabel.Size = new Size(146, 24);
            gradedLabel.TabIndex = 0;
            gradedLabel.Text = "Graded";
            // 
            // gradedValue
            // 
            gradedValue.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            gradedValue.Font = new Font("Microsoft YaHei UI", 20F, FontStyle.Bold);
            gradedValue.Location = new Point(16, 40);
            gradedValue.Name = "gradedValue";
            gradedValue.Size = new Size(146, 36);
            gradedValue.TabIndex = 1;
            gradedValue.Text = "0";
            // 
            // submittedCard
            // 
            submittedCard.AutoContainerBgTransparent = true;
            submittedCard.Back = Color.Transparent;
            submittedCard.BackColor = Color.Transparent;
            submittedCard.BorderWidth = 1F;
            submittedCard.Controls.Add(submittedLabel);
            submittedCard.Controls.Add(submittedValue);
            submittedCard.Location = new Point(381, 0);
            submittedCard.Margin = new Padding(0, 0, 12, 12);
            submittedCard.Name = "submittedCard";
            submittedCard.Radius = 0;
            submittedCard.Size = new Size(178, 92);
            submittedCard.TabIndex = 2;
            // 
            // submittedLabel
            // 
            submittedLabel.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            submittedLabel.AutoEllipsis = true;
            submittedLabel.Location = new Point(16, 12);
            submittedLabel.Name = "submittedLabel";
            submittedLabel.Size = new Size(146, 24);
            submittedLabel.TabIndex = 0;
            submittedLabel.Text = "Turned In";
            // 
            // submittedValue
            // 
            submittedValue.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            submittedValue.Font = new Font("Microsoft YaHei UI", 20F, FontStyle.Bold);
            submittedValue.Location = new Point(16, 40);
            submittedValue.Name = "submittedValue";
            submittedValue.Size = new Size(146, 36);
            submittedValue.TabIndex = 1;
            submittedValue.Text = "0";
            // 
            // assignmentsCard
            // 
            assignmentsCard.AutoContainerBgTransparent = true;
            assignmentsCard.Back = Color.Transparent;
            assignmentsCard.BackColor = Color.Transparent;
            assignmentsCard.BorderWidth = 1F;
            assignmentsCard.Controls.Add(assignmentsLabel);
            assignmentsCard.Controls.Add(assignmentsValue);
            assignmentsCard.Location = new Point(190, 0);
            assignmentsCard.Margin = new Padding(0, 0, 12, 12);
            assignmentsCard.Name = "assignmentsCard";
            assignmentsCard.Radius = 0;
            assignmentsCard.Size = new Size(178, 92);
            assignmentsCard.TabIndex = 3;
            // 
            // assignmentsLabel
            // 
            assignmentsLabel.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            assignmentsLabel.AutoEllipsis = true;
            assignmentsLabel.Location = new Point(16, 12);
            assignmentsLabel.Name = "assignmentsLabel";
            assignmentsLabel.Size = new Size(146, 24);
            assignmentsLabel.TabIndex = 0;
            assignmentsLabel.Text = "Assignments";
            // 
            // assignmentsValue
            // 
            assignmentsValue.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            assignmentsValue.Font = new Font("Microsoft YaHei UI", 20F, FontStyle.Bold);
            assignmentsValue.Location = new Point(16, 40);
            assignmentsValue.Name = "assignmentsValue";
            assignmentsValue.Size = new Size(146, 36);
            assignmentsValue.TabIndex = 1;
            assignmentsValue.Text = "0";
            // 
            // studentsCard
            // 
            studentsCard.AutoContainerBgTransparent = true;
            studentsCard.Back = Color.Transparent;
            studentsCard.BackColor = Color.Transparent;
            studentsCard.BorderWidth = 1F;
            studentsCard.Controls.Add(studentsLabel);
            studentsCard.Controls.Add(studentsValue);
            studentsCard.Location = new Point(0, 0);
            studentsCard.Margin = new Padding(0, 0, 12, 12);
            studentsCard.Name = "studentsCard";
            studentsCard.Radius = 0;
            studentsCard.Size = new Size(178, 92);
            studentsCard.TabIndex = 4;
            // 
            // studentsLabel
            // 
            studentsLabel.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            studentsLabel.AutoEllipsis = true;
            studentsLabel.Location = new Point(16, 12);
            studentsLabel.Name = "studentsLabel";
            studentsLabel.Size = new Size(146, 24);
            studentsLabel.TabIndex = 0;
            studentsLabel.Text = "Students";
            // 
            // studentsValue
            // 
            studentsValue.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            studentsValue.Font = new Font("Microsoft YaHei UI", 20F, FontStyle.Bold);
            studentsValue.Location = new Point(16, 40);
            studentsValue.Name = "studentsValue";
            studentsValue.Size = new Size(146, 36);
            studentsValue.TabIndex = 1;
            studentsValue.Text = "0";
            // 
            // filtersGrid
            // 
            filtersGrid.Back = Color.Transparent;
            filtersGrid.BackColor = Color.Transparent;
            filtersGrid.Controls.Add(toDatePanel);
            filtersGrid.Controls.Add(fromDatePanel);
            filtersGrid.Controls.Add(studentPanel);
            filtersGrid.Controls.Add(assignmentPanel);
            filtersGrid.Dock = DockStyle.Top;
            filtersGrid.Location = new Point(0, 120);
            filtersGrid.Name = "filtersGrid";
            filtersGrid.Size = new Size(952, 84);
            filtersGrid.Span = "30% 30% 20% 20%";
            filtersGrid.TabIndex = 3;
            // 
            // toDatePanel
            // 
            toDatePanel.AutoContainerBgTransparent = true;
            toDatePanel.Back = Color.Transparent;
            toDatePanel.BackColor = Color.Transparent;
            toDatePanel.Controls.Add(toDatePicker);
            toDatePanel.Controls.Add(toDateLabel);
            toDatePanel.Location = new Point(762, 0);
            toDatePanel.Margin = new Padding(0, 0, 12, 8);
            toDatePanel.Name = "toDatePanel";
            toDatePanel.Size = new Size(178, 76);
            toDatePanel.TabIndex = 0;
            // 
            // toDatePicker
            // 
            toDatePicker.Dock = DockStyle.Bottom;
            toDatePicker.Format = "MMM dd, yyyy";
            toDatePicker.Location = new Point(0, 32);
            toDatePicker.Name = "toDatePicker";
            toDatePicker.Radius = 0;
            toDatePicker.Size = new Size(178, 44);
            toDatePicker.TabIndex = 0;
            // 
            // toDateLabel
            // 
            toDateLabel.Dock = DockStyle.Top;
            toDateLabel.Location = new Point(0, 0);
            toDateLabel.Name = "toDateLabel";
            toDateLabel.Size = new Size(178, 24);
            toDateLabel.TabIndex = 1;
            toDateLabel.Text = "To:";
            // 
            // fromDatePanel
            // 
            fromDatePanel.AutoContainerBgTransparent = true;
            fromDatePanel.Back = Color.Transparent;
            fromDatePanel.BackColor = Color.Transparent;
            fromDatePanel.Controls.Add(fromDatePicker);
            fromDatePanel.Controls.Add(fromDateLabel);
            fromDatePanel.Location = new Point(571, 0);
            fromDatePanel.Margin = new Padding(0, 0, 12, 8);
            fromDatePanel.Name = "fromDatePanel";
            fromDatePanel.Size = new Size(178, 76);
            fromDatePanel.TabIndex = 1;
            // 
            // fromDatePicker
            // 
            fromDatePicker.Dock = DockStyle.Bottom;
            fromDatePicker.Format = "MMM dd, yyyy";
            fromDatePicker.Location = new Point(0, 32);
            fromDatePicker.Name = "fromDatePicker";
            fromDatePicker.Radius = 0;
            fromDatePicker.Size = new Size(178, 44);
            fromDatePicker.TabIndex = 0;
            // 
            // fromDateLabel
            // 
            fromDateLabel.Dock = DockStyle.Top;
            fromDateLabel.Location = new Point(0, 0);
            fromDateLabel.Name = "fromDateLabel";
            fromDateLabel.Size = new Size(178, 24);
            fromDateLabel.TabIndex = 1;
            fromDateLabel.Text = "From:";
            // 
            // studentPanel
            // 
            studentPanel.AutoContainerBgTransparent = true;
            studentPanel.Back = Color.Transparent;
            studentPanel.BackColor = Color.Transparent;
            studentPanel.Controls.Add(studentSelect);
            studentPanel.Controls.Add(studentLabel);
            studentPanel.Location = new Point(286, 0);
            studentPanel.Margin = new Padding(0, 0, 12, 8);
            studentPanel.Name = "studentPanel";
            studentPanel.Size = new Size(274, 76);
            studentPanel.TabIndex = 2;
            // 
            // studentSelect
            // 
            studentSelect.Dock = DockStyle.Bottom;
            studentSelect.List = true;
            studentSelect.Location = new Point(0, 32);
            studentSelect.Name = "studentSelect";
            studentSelect.Radius = 0;
            studentSelect.Size = new Size(274, 44);
            studentSelect.TabIndex = 0;
            // 
            // studentLabel
            // 
            studentLabel.Dock = DockStyle.Top;
            studentLabel.Location = new Point(0, 0);
            studentLabel.Name = "studentLabel";
            studentLabel.Size = new Size(274, 24);
            studentLabel.TabIndex = 1;
            studentLabel.Text = "Student:";
            // 
            // assignmentPanel
            // 
            assignmentPanel.AutoContainerBgTransparent = true;
            assignmentPanel.Back = Color.Transparent;
            assignmentPanel.BackColor = Color.Transparent;
            assignmentPanel.Controls.Add(assignmentSelect);
            assignmentPanel.Controls.Add(assignmentLabel);
            assignmentPanel.Location = new Point(0, 0);
            assignmentPanel.Margin = new Padding(0, 0, 12, 8);
            assignmentPanel.Name = "assignmentPanel";
            assignmentPanel.Size = new Size(274, 76);
            assignmentPanel.TabIndex = 3;
            // 
            // assignmentSelect
            // 
            assignmentSelect.Dock = DockStyle.Bottom;
            assignmentSelect.List = true;
            assignmentSelect.Location = new Point(0, 32);
            assignmentSelect.Name = "assignmentSelect";
            assignmentSelect.Radius = 0;
            assignmentSelect.Size = new Size(274, 44);
            assignmentSelect.TabIndex = 0;
            // 
            // assignmentLabel
            // 
            assignmentLabel.Dock = DockStyle.Top;
            assignmentLabel.Location = new Point(0, 0);
            assignmentLabel.Name = "assignmentLabel";
            assignmentLabel.Size = new Size(274, 24);
            assignmentLabel.TabIndex = 1;
            assignmentLabel.Text = "Assignment:";
            // 
            // filterActions
            // 
            filterActions.AutoContainerBgTransparent = true;
            filterActions.Back = Color.Transparent;
            filterActions.BackColor = Color.Transparent;
            filterActions.Controls.Add(filterHint);
            filterActions.Controls.Add(resetButton);
            filterActions.Controls.Add(applyButton);
            filterActions.Dock = DockStyle.Top;
            filterActions.Location = new Point(0, 204);
            filterActions.Name = "filterActions";
            filterActions.Size = new Size(952, 52);
            filterActions.TabIndex = 2;
            // 
            // filterHint
            // 
            filterHint.AutoEllipsis = true;
            filterHint.Dock = DockStyle.Fill;
            filterHint.Location = new Point(0, 0);
            filterHint.Name = "filterHint";
            filterHint.Size = new Size(728, 52);
            filterHint.TabIndex = 0;
            filterHint.Text = "Date range filters assignment creation dates.";
            // 
            // resetButton
            // 
            resetButton.Dock = DockStyle.Right;
            resetButton.Location = new Point(728, 0);
            resetButton.Name = "resetButton";
            resetButton.Radius = 0;
            resetButton.Size = new Size(112, 52);
            resetButton.TabIndex = 1;
            resetButton.Text = "Reset";
            resetButton.Click += resetButton_Click;
            // 
            // applyButton
            // 
            applyButton.Dock = DockStyle.Right;
            applyButton.Location = new Point(840, 0);
            applyButton.Name = "applyButton";
            applyButton.Radius = 0;
            applyButton.Size = new Size(112, 52);
            applyButton.TabIndex = 2;
            applyButton.Text = "Apply";
            applyButton.Type = AntdUI.TTypeMini.Primary;
            applyButton.Click += applyButton_Click;
            // 
            // reportTabs
            // 
            reportTabs.Controls.Add(assignmentsTab);
            reportTabs.Controls.Add(studentsTab);
            reportTabs.Dock = DockStyle.Top;
            reportTabs.Gap = 16;
            reportTabs.Location = new Point(0, 256);
            reportTabs.Name = "reportTabs";
            reportTabs.Pages.Add(assignmentsTab);
            reportTabs.Pages.Add(studentsTab);
            reportTabs.Size = new Size(952, 44);
            reportTabs.Style = styleLine1;
            reportTabs.TabIndex = 1;
            reportTabs.SelectedIndexChanged += reportTabs_SelectedIndexChanged;
            // 
            // assignmentsTab
            // 
            assignmentsTab.Location = new Point(0, 39);
            assignmentsTab.Name = "assignmentsTab";
            assignmentsTab.Size = new Size(952, 5);
            assignmentsTab.TabIndex = 0;
            assignmentsTab.Text = "Assignments";
            // 
            // studentsTab
            // 
            studentsTab.Location = new Point(0, 0);
            studentsTab.Name = "studentsTab";
            studentsTab.Size = new Size(0, 0);
            studentsTab.TabIndex = 1;
            studentsTab.Text = "Students";
            // 
            // reportContent
            // 
            reportContent.AutoContainerBgTransparent = true;
            reportContent.Back = Color.Transparent;
            reportContent.BackColor = Color.Transparent;
            reportContent.Dock = DockStyle.Fill;
            reportContent.Location = new Point(0, 300);
            reportContent.Name = "reportContent";
            reportContent.Size = new Size(952, 340);
            reportContent.TabIndex = 0;
            // 
            // ReportsControl
            // 
            AutoScaleDimensions = new SizeF(8F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Transparent;
            Controls.Add(reportContent);
            Controls.Add(reportTabs);
            Controls.Add(filterActions);
            Controls.Add(filtersGrid);
            Controls.Add(summaryGrid);
            Font = new Font("Microsoft YaHei UI", 10F);
            Name = "ReportsControl";
            Padding = new Padding(0, 16, 0, 0);
            Size = new Size(952, 640);
            Load += ReportsControl_Load;
            summaryGrid.ResumeLayout(false);
            missingCard.ResumeLayout(false);
            gradedCard.ResumeLayout(false);
            submittedCard.ResumeLayout(false);
            assignmentsCard.ResumeLayout(false);
            studentsCard.ResumeLayout(false);
            filtersGrid.ResumeLayout(false);
            toDatePanel.ResumeLayout(false);
            fromDatePanel.ResumeLayout(false);
            studentPanel.ResumeLayout(false);
            assignmentPanel.ResumeLayout(false);
            filterActions.ResumeLayout(false);
            reportTabs.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private AntdUI.GridPanel summaryGrid;
        private AntdUI.GridPanel filtersGrid;
        private AntdUI.Panel filterActions;
        private AntdUI.Label filterHint;
        private AntdUI.Button applyButton;
        private AntdUI.Button resetButton;
        private AntdUI.Tabs reportTabs;
        private AntdUI.TabPage assignmentsTab;
        private AntdUI.TabPage studentsTab;
        private AntdUI.Panel reportContent;
        private AntdUI.Panel studentsCard;
        private AntdUI.Label studentsLabel;
        private AntdUI.Label studentsValue;
        private AntdUI.Panel assignmentsCard;
        private AntdUI.Label assignmentsLabel;
        private AntdUI.Label assignmentsValue;
        private AntdUI.Panel submittedCard;
        private AntdUI.Label submittedLabel;
        private AntdUI.Label submittedValue;
        private AntdUI.Panel gradedCard;
        private AntdUI.Label gradedLabel;
        private AntdUI.Label gradedValue;
        private AntdUI.Panel missingCard;
        private AntdUI.Label missingLabel;
        private AntdUI.Label missingValue;
        private AntdUI.Panel assignmentPanel;
        private AntdUI.Label assignmentLabel;
        private AntdUI.Select assignmentSelect;
        private AntdUI.Panel studentPanel;
        private AntdUI.Label studentLabel;
        private AntdUI.Select studentSelect;
        private AntdUI.Panel fromDatePanel;
        private AntdUI.Label fromDateLabel;
        private AntdUI.DatePicker fromDatePicker;
        private AntdUI.Panel toDatePanel;
        private AntdUI.Label toDateLabel;
        private AntdUI.DatePicker toDatePicker;
    }
}
