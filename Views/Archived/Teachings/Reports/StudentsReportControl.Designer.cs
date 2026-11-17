namespace brilliant_lms.Views.Archived.Teachings.Reports
{
    partial class StudentsReportControl
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
            reportTable.EmptyText = "No students match the selected filters.";
            reportTable.AutoSizeColumnsMode = AntdUI.ColumnsMode.Fill;
            reportTable.Dock = DockStyle.Fill;
            reportTable.Name = "reportTable";
            reportTable.Size = new Size(952, 380);
            reportTable.TabIndex = 0;
            Controls.Add(reportTable);
            reportTable.CellButtonClick += reportTable_CellButtonClick;
            AutoScaleDimensions = new SizeF(8F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Transparent;
            Font = new Font("Microsoft YaHei UI", 10F);
            Name = "StudentsReportControl";
            Size = new Size(952, 380);
            ResumeLayout(false);
        }

        #endregion

        private AntdUI.Table reportTable;
    }
}
