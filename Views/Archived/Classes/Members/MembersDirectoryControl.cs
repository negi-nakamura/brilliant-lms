using AntdUI;
using brilliant_lms.Models.Entities;
using brilliant_lms.Models.Responses;
using brilliant_lms.Services;
using brilliant_lms.Utilities;

namespace brilliant_lms.Views.Archived.Classes.Members
{
    public partial class MembersDirectoryControl : UserControl
    {
        private User user;
        private Classroom classroom;
        private MemberService memberService = new MemberService();
        private bool loading;
        private List<MemberDirectoryItem> members = new List<MemberDirectoryItem>();

        public MembersDirectoryControl(User user, Classroom classroom)
        {
            this.user = user;
            this.classroom = classroom;
            InitializeComponent();
            InitializeControl();
        }

        private void InitializeControl()
        {
            membersTable.Columns = new ColumnCollection
            {
                new Column("FirstName", "Name") { Render = RenderName },
                new Column("Email", "Email"),
                new Column("Role", "Role")
            };
        }

        private object RenderName(object? value, object record, int index)
        {
            MemberDirectoryItem member = (MemberDirectoryItem)record;
            return TextFormatter.GetFullName(member.FirstName, member.MiddleName, member.LastName);
        }

        private async void MembersDirectoryControl_Load(object? sender, EventArgs e)
        {
            if (loading) return;

            SetBusy(true);
            
            try
            {
                members = await memberService.GetClassroomMembersAsync(user.Id, classroom.Id);
                if (IsDisposed) return;
                ShowMembers();
            }
            catch (InvalidOperationException exception)
            {
                if (!IsDisposed) FeedbackDialog.Error(FindForm()!, "Load failed", exception.Message);
            }
            catch (Exception)
            {
                if (!IsDisposed) FeedbackDialog.Error(FindForm()!, "Load failed", "Unable to load classroom members. Please try again.");
            }
            finally
            {
                if (!IsDisposed) SetBusy(false);
            }
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            if (loading) return;
            ShowMembers();
        }

        private void searchInput_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter || loading) return;
            e.SuppressKeyPress = true;
            ShowMembers();
        }

        private void ShowMembers()
        {
            string search = searchInput.Text.Trim();
            List<MemberDirectoryItem> filtered = members.Where(member =>
                TextFormatter.GetFullName(member.FirstName, member.MiddleName, member.LastName).Contains(search, StringComparison.OrdinalIgnoreCase) ||
                member.Email.Contains(search, StringComparison.OrdinalIgnoreCase) ||
                member.Role.Contains(search, StringComparison.OrdinalIgnoreCase)).ToList();
            membersTable.DataSource = filtered;
        }

        private void SetBusy(bool busy)
        {
            loading = busy;
            UseWaitCursor = busy;
            membersTable.Enabled = !busy;
            searchInput.Enabled = !busy;
            searchButton.Enabled = !busy;
        }
    }
}
