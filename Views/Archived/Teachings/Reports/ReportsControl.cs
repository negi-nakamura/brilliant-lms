using AntdUI;
using brilliant_lms.Models.Entities;
using brilliant_lms.Models.Requests;
using brilliant_lms.Models.Responses;
using brilliant_lms.Services;
using brilliant_lms.Utilities;
using FluentValidation;
using System.Globalization;

namespace brilliant_lms.Views.Archived.Teachings.Reports
{
    public partial class ReportsControl : UserControl
    {
        private User user;
        private Classroom classroom;
        private ReportService reportService = new ReportService();
        private ClassroomReport? report;
        private bool loading;

        public ReportsControl(User user, Classroom classroom)
        {
            this.user = user;
            this.classroom = classroom;
            InitializeComponent();
        }

        private async void ReportsControl_Load(object? sender, EventArgs e)
        {
            await LoadReportAsync(true);
        }

        private async void applyButton_Click(object sender, EventArgs e)
        {
            await LoadReportAsync(false);
        }

        private async void resetButton_Click(object sender, EventArgs e)
        {
            if (loading) return;
            assignmentSelect.SelectedIndex = 0;
            studentSelect.SelectedIndex = 0;
            fromDatePicker.Value = null;
            toDatePicker.Value = null;
            await LoadReportAsync(false);
        }

        private async Task LoadReportAsync(bool initializeFilters)
        {
            if (loading) return;
            ReportFilterRequest request = new ReportFilterRequest
            {
                AssignmentId = assignmentSelect.SelectedValue is int assignmentId && assignmentId > 0 ? assignmentId : null,
                StudentId = studentSelect.SelectedValue is int studentId && studentId > 0 ? studentId : null,
                FromDate = fromDatePicker.Value,
                ToDate = toDatePicker.Value
            };
            SetBusy(true);
            try
            {
                ClassroomReport loaded = await reportService.GetClassroomReportAsync(user.Id, classroom.Id, request);
                if (IsDisposed) return;
                report = loaded;
                if (initializeFilters || assignmentSelect.Items.Count == 0) InitializeFilters();
                studentsValue.Text = report.StudentCount.ToString();
                assignmentsValue.Text = report.AssignmentCount.ToString();
                submittedValue.Text = report.SubmittedCount.ToString();
                gradedValue.Text = report.GradedCount.ToString();
                missingValue.Text = report.MissingCount.ToString();
                ShowSelectedControl();
            }
            catch (ValidationException exception)
            {
                if (!IsDisposed) FeedbackDialog.Error(FindForm()!, "Load failed", exception.Errors.First().ErrorMessage);
            }
            catch (InvalidOperationException exception)
            {
                if (!IsDisposed) FeedbackDialog.Error(FindForm()!, "Load failed", exception.Message);
            }
            catch (Exception)
            {
                if (!IsDisposed) FeedbackDialog.Error(FindForm()!, "Load failed", "Unable to load classroom reports. Please try again.");
            }
            finally
            {
                if (!IsDisposed) SetBusy(false);
            }
        }

        private void InitializeFilters()
        {
            assignmentSelect.Items.Clear();
            assignmentSelect.Items.Add(new SelectItem("All assignments", 0));
            foreach (Assignment assignment in report!.AvailableAssignments)
                assignmentSelect.Items.Add(new SelectItem(assignment.Title, assignment.Id));
            assignmentSelect.SelectedIndex = 0;
            studentSelect.Items.Clear();
            studentSelect.Items.Add(new SelectItem("All students", 0));
            foreach (MemberDirectoryItem student in report.AvailableStudents)
            {
                string name = TextFormatter.GetFullName(student.FirstName, student.MiddleName, student.LastName);
                studentSelect.Items.Add(new SelectItem(name, student.UserId));
            }
            studentSelect.SelectedIndex = 0;
        }

        private void reportTabs_SelectedIndexChanged(object sender, IntEventArgs e)
        {
            ShowSelectedControl();
        }

        private void ShowSelectedControl()
        {
            DisposeReportControls();
            if (report == null) return;
            if (reportTabs.SelectedTab == assignmentsTab)
            {
                AssignmentsReportControl view = new AssignmentsReportControl(report.Assignments)
                {
                    Dock = DockStyle.Fill
                };
                reportContent.Controls.Add(view);
            }
            else if (reportTabs.SelectedTab == studentsTab)
            {
                StudentsReportControl view = new StudentsReportControl(report.Students)
                {
                    Dock = DockStyle.Fill
                };
                view.DetailsRequested += StudentsReport_DetailsRequested;
                reportContent.Controls.Add(view);
            }
        }

        private void DisposeReportControls()
        {
            while (reportContent.Controls.Count > 0)
            {
                Control previous = reportContent.Controls[0];
                reportContent.Controls.Remove(previous);
                previous.Dispose();
            }
        }

        private void StudentsReport_DetailsRequested(object? sender, StudentReportItem student)
        {
            if (loading || report == null) return;
            List<StudentAssignmentReportItem> assignments = report.StudentAssignments.Where(item => item.StudentId == student.UserId).ToList();
            using StudentReportDetailsControl details = new StudentReportDetailsControl(student, assignments);
            Form owner = FindForm()!;
            if (owner is AntdUI.Window window) window.AutoDpi(details);
            AntdUI.Modal.open(new AntdUI.Modal.Config(owner, "Student Performance", details, TType.None)
            {
                BtnHeight = 0,
                MaskClosable = false,
                Keyboard = false,
                CloseIcon = true
            });
        }

        public void ExportCsv()
        {
            if (loading) return;
            if (report == null)
            {
                FeedbackDialog.Error(FindForm()!, "Export failed", "Load a report before exporting.");
                return;
            }
            bool assignmentReport = reportTabs.SelectedTab == assignmentsTab;
            List<string[]> rows = new List<string[]>();
            string[] headers;
            if (assignmentReport)
            {
                headers = new[] { "Title", "Due Date", "Submitted", "Students", "Missing", "Graded", "Average Score", "Max Points" };
                foreach (AssignmentReportItem assignment in report.Assignments)
                {
                    rows.Add(new[]
                    {
                        assignment.Title,
                        assignment.DueAt?.ToString("yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture) ?? "",
                        assignment.SubmittedCount.ToString(), assignment.StudentCount.ToString(),
                        assignment.MissingCount.ToString(), assignment.GradedCount.ToString(),
                        assignment.AverageScore?.ToString("0.##", CultureInfo.InvariantCulture) ?? "",
                        assignment.MaxPoints.ToString("0.##", CultureInfo.InvariantCulture)
                    });
                }
            }
            else
            {
                headers = new[] { "Name", "Email", "Submitted", "Assignments", "Missing", "Late", "Graded", "Average Grade (%)" };
                foreach (StudentReportItem student in report.Students)
                {
                    rows.Add(new[]
                    {
                        TextFormatter.GetFullName(student.FirstName, student.MiddleName, student.LastName), student.Email,
                        student.SubmittedCount.ToString(), student.AssignmentCount.ToString(), student.MissingCount.ToString(),
                        student.LateCount.ToString(), student.GradedCount.ToString(),
                        student.AverageGrade?.ToString("0.##", CultureInfo.InvariantCulture) ?? ""
                    });
                }
            }
            using SaveFileDialog dialog = new SaveFileDialog
            {
                Filter = "CSV files (*.csv)|*.csv",
                FileName = $"{(assignmentReport ? "Assignments" : "Students")}_{classroom.Id}_{DateTime.Now:yyyyMMdd}.csv",
                DefaultExt = "csv",
                AddExtension = true,
                OverwritePrompt = true
            };
            if (dialog.ShowDialog(FindForm()) != DialogResult.OK) return;
            try
            {
                CsvExporter.Write(dialog.FileName, headers, rows);
                FeedbackDialog.Success(FindForm()!, "Report exported", "The selected report has been exported successfully.");
            }
            catch (Exception)
            {
                FeedbackDialog.Error(FindForm()!, "Export failed", "Unable to save the CSV file. Please check the file location and try again.");
            }
        }

        private void SetBusy(bool busy)
        {
            loading = busy;
            UseWaitCursor = busy;
            assignmentSelect.Enabled = !busy;
            studentSelect.Enabled = !busy;
            fromDatePicker.Enabled = !busy;
            toDatePicker.Enabled = !busy;
            applyButton.Enabled = !busy;
            resetButton.Enabled = !busy;
            reportContent.Enabled = !busy;
        }
    }
}
