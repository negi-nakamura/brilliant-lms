using AntdUI;
using brilliant_lms.Models.Responses;

namespace brilliant_lms.Views.Archived.Teachings.Reports
{
    public partial class AssignmentsReportControl : UserControl
    {
        private List<AssignmentReportItem> assignments;

        public AssignmentsReportControl(List<AssignmentReportItem> assignments)
        {
            this.assignments = assignments;
            InitializeComponent();
            InitializeControl();
        }

        private void InitializeControl()
        {
            reportTable.Columns = new ColumnCollection
            {
                new Column("Title", "Title"),
                new Column("DueAt", "Due Date") { Render = RenderDueDate },
                new Column("SubmittedCount", "Submitted") { Render = RenderSubmitted },
                new Column("MissingCount", "Missing"),
                new Column("GradedCount", "Graded"),
                new Column("AverageScore", "Average Score") { Render = RenderAverage }
            };
            reportTable.DataSource = assignments;
        }

        private object RenderDueDate(object? value, object record, int index)
        {
            AssignmentReportItem assignment = (AssignmentReportItem)record;
            return assignment.DueAt?.ToString("MMM dd, yyyy h:mm tt") ?? "—";
        }

        private object RenderSubmitted(object? value, object record, int index)
        {
            AssignmentReportItem assignment = (AssignmentReportItem)record;
            return $"{assignment.SubmittedCount} / {assignment.StudentCount}";
        }

        private object RenderAverage(object? value, object record, int index)
        {
            AssignmentReportItem assignment = (AssignmentReportItem)record;
            return $"{assignment.AverageScore?.ToString("0.##") ?? "—"} / {assignment.MaxPoints:0.##}";
        }
    }
}
