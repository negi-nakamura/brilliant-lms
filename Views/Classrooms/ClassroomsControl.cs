using AntdUI;
using brilliant_lms.Views.Classrooms.Classes;
using brilliant_lms.Views.Classrooms.Teachings;
using brilliant_lms.Models.Entities;

namespace brilliant_lms.Views.Classrooms
{
    public partial class ClassroomsControl : UserControl
    {
        private User user;
        public event EventHandler<Classroom>? ClassroomRequested;
        public event EventHandler<Classroom>? TeachingRequested;

        public ClassroomsControl(User user)
        {
            this.user = user;
            InitializeComponent();
            InitializeControl();
        }

        private void InitializeControl()
        {
            ShowSelectedControl();
        }

        private void classroomsTab_SelectedIndexChanged(object sender, AntdUI.IntEventArgs e)
        {
            ShowSelectedControl();
        }

        public void RefreshControl()
        {
            ShowSelectedControl();
        }

        private void ShowSelectedControl()
        {
            DisposeControlsTab();

            AntdUI.TabPage? selected = classroomsTab.SelectedTab;
            Control view;

            if (selected == classesTab)
            {
                heading.Text = "Classes";
                description.Text = "Access your classes, view assignments, and stay connected with your teachers and classmates.";

                ClassesDirectoryControl directory = new ClassesDirectoryControl(user);
                directory.ClassroomRequested += ClassesDirectory_ClassroomRequested;
                directory.ClassroomLeft += ClassesDirectory_ClassroomLeft;
                view = directory;
            }
            else if (selected == teachingsTab)
            {
                heading.Text = "Teachings";
                description.Text = "Manage the classes you teach, share materials, and track student progress.";

                TeachingsDirectoryControl directory = new TeachingsDirectoryControl(user);
                directory.ClassroomRequested += TeachingsDirectory_ClassroomRequested;
                directory.ClassroomArchived += TeachingsDirectory_ClassroomArchived;
                view = directory;
            }
            else
                return;

            view.Dock = DockStyle.Fill;
            view.TabIndex = 0;
            selected.Controls.Add(view);
        }

        private void ClassesDirectory_ClassroomRequested(object? sender, Classroom classroom)
        {
            ClassroomRequested?.Invoke(this, classroom);
        }

        private void ClassesDirectory_ClassroomLeft(object? sender, EventArgs e)
        {
            ShowSelectedControl();
        }

        private void TeachingsDirectory_ClassroomRequested(object? sender, Classroom classroom)
        {
            TeachingRequested?.Invoke(this, classroom);
        }

        private void TeachingsDirectory_ClassroomArchived(object? sender, EventArgs e)
        {
            ShowSelectedControl();
        }

        private void DisposeControlsTab()
        {
            foreach (AntdUI.TabPage page in classroomsTab.Pages)
            {
                while (page.Controls.Count > 0)
                {
                    Control previous = page.Controls[0];
                    page.Controls.Remove(previous);
                    previous.Dispose();
                }
            }
        }

        private void addClassButton_Click(object sender, EventArgs e)
        {
            ContextMenuStripItem joinItem = new ContextMenuStripItem("Join Class") { IconSvg = "LoginOutlined" };
            ContextMenuStripItem createItem = new ContextMenuStripItem("Create Class") { IconSvg = "PlusOutlined" };

            AntdUI.ContextMenuStrip.open(new(addClassButton, HandleAddClassSelection, new IContextMenuStripItem[] { joinItem, createItem })
            {
                Align = TAlign.Bottom,
                Radius = 0
            });

            void HandleAddClassSelection(IContextMenuStrip item)
            {
                if (item == joinItem)
                {
                    ShowJoinClassroom();
                    //JoinClassRequested?.Invoke(this, EventArgs.Empty);
                }
                else if (item == createItem)
                {
                    ShowCreateClassroom();
                    //CreateClassRequested?.Invoke(this, EventArgs.Empty);
                }
            }
        }

        private void ShowJoinClassroom()
        {
            using JoinClassroomControl joinClassroom = new JoinClassroomControl(user);
            Form owner = FindForm()!;
            if (owner is AntdUI.Window window) window.AutoDpi(joinClassroom);

            Modal.open(new Modal.Config(owner, "Join Classroom", joinClassroom, TType.None)
            {
                BtnHeight = 0,
                MaskClosable = false,
                Keyboard = false,
                CloseIcon = true
            });

            if (joinClassroom.JoinedClassroom != null) ShowSelectedControl();
        }

        private void ShowCreateClassroom()
        {
            using CreateClassroomControl createClassroom = new CreateClassroomControl(user);
            Form owner = FindForm()!;
            if (owner is AntdUI.Window window) window.AutoDpi(createClassroom);

            Modal.open(new Modal.Config(owner, "Create Classroom", createClassroom, TType.None)
            {
                BtnHeight = 0,
                MaskClosable = false,
                Keyboard = false,
                CloseIcon = true
            });

            if (createClassroom.CreatedClassroom != null) ShowSelectedControl();
        }

    }
}
