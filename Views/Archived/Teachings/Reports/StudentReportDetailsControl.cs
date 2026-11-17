using AntdUI;
using brilliant_lms.Models.Responses;
using brilliant_lms.Utilities;

namespace brilliant_lms.Views.Archived.Teachings.Reports
{
    public partial class StudentReportDetailsControl : UserControl
    {
        private StudentReportItem student;
        private List<StudentAssignmentReportItem> assignments;

        public StudentReportDetailsControl(StudentReportItem student, List<StudentAssignmentReportItem> assignments)
        {
            this.student = student;
            this.assignments = assignments;
            InitializeComponent();
            InitializeControl();
        }

        private void InitializeControl()
        {
            nameLabel.Text = TextFormatter.GetFullName(student.FirstName, student.MiddleName, student.LastName);
            emailLabel.Text = student.Email;
            reportTable.Columns = new ColumnCollection
            {
                new Column("Title", "Assignment"),
                new Column("DueAt", "Due Date") { Render = RenderDueDate },
                new Column("Status", "Status") { Render = RenderStatus },
                new Column("SubmittedAt", "Submitted At") { Render = RenderSubmittedAt },
                new Column("Score", "Score") { Render = RenderScore }
            };
            reportTable.DataSource = assignments;
        }

        private object RenderDueDate(object? value, object record, int index)
        {
            StudentAssignmentReportItem assignment = (StudentAssignmentReportItem)record;
            return assignment.DueAt?.ToString("MMM dd, yyyy h:mm tt") ?? "—";
        }

        private object RenderStatus(object? value, object record, int index)
        {
            StudentAssignmentReportItem assignment = (StudentAssignmentReportItem)record;
            return assignment.Status + (assignment.IsLate ? " (Late)" : "");
        }

        private object RenderSubmittedAt(object? value, object record, int index)
        {
            StudentAssignmentReportItem assignment = (StudentAssignmentReportItem)record;
            return assignment.SubmittedAt?.ToString("MMM dd, yyyy h:mm tt") ?? "—";
        }

        private object RenderScore(object? value, object record, int index)
        {
            StudentAssignmentReportItem assignment = (StudentAssignmentReportItem)record;
            return $"{assignment.Score?.ToString("0.##") ?? "—"} / {assignment.MaxPoints:0.##}";
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            FindForm()?.Close();
        }
    }
}
