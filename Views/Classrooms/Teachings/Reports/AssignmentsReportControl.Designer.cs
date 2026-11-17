namespace brilliant_lms.Views.Classrooms.Teachings.Reports
{
    partial class AssignmentsReportControl
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
            reportTable = new AntdUI.Table();
            SuspendLayout();
            reportTable.EmptyText = "No assignments match the selected filters.";
            reportTable.AutoSizeColumnsMode = AntdUI.ColumnsMode.Fill;
            reportTable.Dock = DockStyle.Fill;
            reportTable.Name = "reportTable";
            reportTable.Size = new Size(952, 380);
            reportTable.TabIndex = 0;
            Controls.Add(reportTable);
            AutoScaleDimensions = new SizeF(8F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Transparent;
            Font = new Font("Microsoft YaHei UI", 10F);
            Name = "AssignmentsReportControl";
            Size = new Size(952, 380);
            ResumeLayout(false);
        }

        #endregion

        private AntdUI.Table reportTable;
    }
}
