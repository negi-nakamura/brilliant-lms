using AntdUI;
using brilliant_lms.Models.Responses;
using brilliant_lms.Utilities;

namespace brilliant_lms.Views.Archived.Teachings.Reports
{
    public partial class StudentsReportControl : UserControl
    {
        private List<StudentReportItem> students;
        public event EventHandler<StudentReportItem>? DetailsRequested;

        public StudentsReportControl(List<StudentReportItem> students)
        {
            this.students = students;
            InitializeComponent();
            InitializeControl();
        }

        private void InitializeControl()
        {
            reportTable.Columns = new ColumnCollection
            {
                new Column("FirstName", "Name") { Render = RenderName },
                new Column("SubmittedCount", "Submitted") { Render = RenderSubmitted },
                new Column("MissingCount", "Missing"),
                new Column("LateCount", "Late"),
                new Column("AverageGrade", "Average Grade") { Render = RenderAverage },
                new Column("UserId", "Options") { Render = RenderDetails }
            };
            reportTable.DataSource = students;
        }

        private object RenderName(object? value, object record, int index)
        {
            StudentReportItem student = (StudentReportItem)record;
            return TextFormatter.GetFullName(student.FirstName, student.MiddleName, student.LastName);
        }

        private object RenderSubmitted(object? value, object record, int index)
        {
            StudentReportItem student = (StudentReportItem)record;
            return $"{student.SubmittedCount} / {student.AssignmentCount}";
        }

        private object RenderAverage(object? value, object record, int index)
        {
            StudentReportItem student = (StudentReportItem)record;
            return student.AverageGrade == null ? "—" : $"{student.AverageGrade:0.##}%";
        }

        private object RenderDetails(object? value, object record, int index)
        {
            return new CellButton("details", "View Details")
            {
                Ghost = true,
                Radius = 0
            };
        }

        private void reportTable_CellButtonClick(object sender, TableButtonEventArgs e)
        {
            if (e.Btn.Id == "details" && e.Record is StudentReportItem student)
                DetailsRequested?.Invoke(this, student);
        }
    }
}
