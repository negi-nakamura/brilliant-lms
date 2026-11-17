namespace brilliant_lms.Views.Classrooms.Teachings.Reports
{
    partial class StudentReportDetailsControl
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
            headerPanel = new AntdUI.Panel();
            nameLabel = new AntdUI.Label();
            emailLabel = new AntdUI.Label();
            reportTable = new AntdUI.Table();
            footerPanel = new AntdUI.Panel();
            closeButton = new AntdUI.Button();
            SuspendLayout();
            headerPanel.AutoContainerBgTransparent = true;
            headerPanel.Back = Color.Transparent;
            headerPanel.Dock = DockStyle.Top;
            headerPanel.Name = "headerPanel";
            headerPanel.Size = new Size(976, 84);
            headerPanel.Controls.Add(nameLabel);
            headerPanel.Controls.Add(emailLabel);
            nameLabel.Location = new Point(0, 0);
            nameLabel.Name = "nameLabel";
            nameLabel.Size = new Size(976, 32);
            nameLabel.AutoEllipsis = true;
            nameLabel.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            nameLabel.Font = new Font("Microsoft YaHei UI", 14F, FontStyle.Bold);
            emailLabel.Location = new Point(0, 40);
            emailLabel.Name = "emailLabel";
            emailLabel.Size = new Size(976, 24);
            emailLabel.AutoEllipsis = true;
            emailLabel.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            reportTable.EmptyText = "No assignments found for this student.";
            reportTable.AutoSizeColumnsMode = AntdUI.ColumnsMode.Fill;
            reportTable.Dock = DockStyle.Fill;
            reportTable.Name = "reportTable";
            footerPanel.AutoContainerBgTransparent = true;
            footerPanel.Back = Color.Transparent;
            footerPanel.Dock = DockStyle.Bottom;
            footerPanel.Name = "footerPanel";
            footerPanel.Size = new Size(976, 56);
            footerPanel.Controls.Add(closeButton);
            closeButton.Dock = DockStyle.Right;
            closeButton.Name = "closeButton";
            closeButton.Radius = 0;
            closeButton.Size = new Size(120, 56);
            closeButton.Text = "Close";
            closeButton.Click += closeButton_Click;
            Controls.Add(reportTable);
            Controls.Add(footerPanel);
            Controls.Add(headerPanel);
            Padding = new Padding(12);
            AutoScaleDimensions = new SizeF(8F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Transparent;
            Font = new Font("Microsoft YaHei UI", 10F);
            Name = "StudentReportDetailsControl";
            Size = new Size(1000, 560);
            ResumeLayout(false);
        }

        #endregion

        private AntdUI.Panel headerPanel;
        private AntdUI.Label nameLabel;
        private AntdUI.Label emailLabel;
        private AntdUI.Table reportTable;
        private AntdUI.Panel footerPanel;
        private AntdUI.Button closeButton;
    }
}
