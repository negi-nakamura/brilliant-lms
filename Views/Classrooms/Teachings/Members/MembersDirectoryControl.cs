using AntdUI;
using brilliant_lms.Models.Entities;
using brilliant_lms.Models.Responses;
using brilliant_lms.Services;
using brilliant_lms.Utilities;

namespace brilliant_lms.Views.Classrooms.Teachings.Members
{
    public partial class MembersDirectoryControl : UserControl
    {
        private User user;
        private Classroom classroom;
        private MemberService memberService = new MemberService();
        private bool loading;
        private List<MemberDirectoryItem> members = new List<MemberDirectoryItem>();
        private MemberDirectoryItem? selectedMember;
        public event EventHandler? MemberRemoved;

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
                new Column("Role", "Role"),
                new Column("Id", "Options") { Render = RenderOptions }
            };
        }

        private object RenderName(object? value, object record, int index)
        {
            MemberDirectoryItem member = (MemberDirectoryItem)record;
            return TextFormatter.GetFullName(member.FirstName, member.MiddleName, member.LastName);
        }

        private object RenderOptions(object? value, object record, int index)
        {
            MemberDirectoryItem member = (MemberDirectoryItem)record;
            if (member.UserId == classroom.OwnerId || classroom.IsArchived) return "";
            return new CellButton("options", "")
            {
                IconSvg = "MoreOutlined",
                Ghost = true,
                Radius = 0
            };
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

        private void membersTable_CellButtonClick(object sender, TableButtonEventArgs e)
        {
            if (loading || e.Btn.Id != "options" || e.Record is not MemberDirectoryItem member) return;
            selectedMember = member;
            ContextMenuStripItem removeItem = new ContextMenuStripItem("Remove member") { IconSvg = "UserDeleteOutlined" };
            AntdUI.ContextMenuStrip.open(new(membersTable, HandleMemberSelection, new IContextMenuStripItem[] { removeItem })
            {
                Location = membersTable.PointToScreen(new Point(e.Rect.Left, e.Rect.Bottom)),
                Radius = 0
            });
        }

        private async void HandleMemberSelection(IContextMenuStrip item)
        {
            if (loading || selectedMember == null) return;
            
            MemberDirectoryItem member = selectedMember;
            
            string name = TextFormatter.GetFullName(member.FirstName, member.MiddleName, member.LastName);
            
            DialogResult result = AntdUI.Modal.open(new AntdUI.Modal.Config(FindForm()!, "Remove member", $"Remove {name} from this class?\n\n")
            {
                Icon = TType.Warn,
                OkText = "Remove",
                CancelText = "Cancel",
                MaskClosable = false,
                OnButtonStyle = (name, button) =>
                {
                    button.Radius = 0;
                }
            });

            if (result != DialogResult.OK) return;

            SetBusy(true);
            
            try
            {
                await memberService.RemoveAsync(user.Id, classroom.Id, member.Id);
                FeedbackDialog.Success(FindForm()!, "Member removed", "The member has been removed from your class.");
            }
            catch (InvalidOperationException exception)
            {
                FeedbackDialog.Error(FindForm()!, "Remove failed", exception.Message);
                return;
            }
            catch (Exception)
            {
                FeedbackDialog.Error(FindForm()!, "Remove failed", "Unable to remove the member. Please try again.");
                return;
            }
            finally
            {
                if (!IsDisposed) SetBusy(false);
            }
            
            MemberRemoved?.Invoke(this, EventArgs.Empty);
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
