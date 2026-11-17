namespace brilliant_lms.Views.Archived.Classes.Members
{
    partial class MembersDirectoryControl
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
            membersTable = new AntdUI.Table();
            searchPanel = new AntdUI.Panel();
            searchInput = new AntdUI.Input();
            searchButton = new AntdUI.Button();
            SuspendLayout();
            //
            // membersTable
            //
            membersTable.EmptyText = "No members found.";
            membersTable.AutoSizeColumnsMode = AntdUI.ColumnsMode.Fill;
            membersTable.Dock = DockStyle.Fill;
            membersTable.Location = new Point(0, 76);
            membersTable.Name = "membersTable";
            membersTable.Size = new Size(952, 371);
            membersTable.TabIndex = 2;
            //
            // searchPanel
            //
            searchPanel.AutoContainerBgTransparent = true;
            searchPanel.Back = Color.Transparent;
            searchPanel.BackColor = Color.Transparent;
            searchPanel.Dock = DockStyle.Top;
            searchPanel.Name = "searchPanel";
            searchPanel.Size = new Size(952, 60);
            searchPanel.Controls.Add(searchInput);
            searchPanel.Controls.Add(searchButton);
            //
            // searchInput
            //
            searchInput.Location = new Point(0, 0);
            searchInput.Name = "searchInput";
            searchInput.PlaceholderText = "Search by name, email, or role";
            searchInput.Radius = 0;
            searchInput.Size = new Size(340, 44);
            searchInput.TabIndex = 0;
            searchInput.KeyDown += searchInput_KeyDown;
            //
            // searchButton
            //
            searchButton.IconSvg = "SearchOutlined";
            searchButton.Location = new Point(348, 0);
            searchButton.Name = "searchButton";
            searchButton.Radius = 0;
            searchButton.Size = new Size(48, 44);
            searchButton.TabIndex = 1;
            searchButton.Type = AntdUI.TTypeMini.Primary;
            searchButton.Click += searchButton_Click;
            //
            // MembersDirectoryControl
            //
            AutoScaleDimensions = new SizeF(8F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Transparent;
            Controls.Add(membersTable);
            Controls.Add(searchPanel);
            Font = new Font("Microsoft YaHei UI", 10F);
            Name = "MembersDirectoryControl";
            Padding = new Padding(0, 16, 0, 0);
            Size = new Size(952, 447);
            Load += MembersDirectoryControl_Load;
            ResumeLayout(false);
        }

        #endregion

        private AntdUI.Table membersTable;
        private AntdUI.Panel searchPanel;
        private AntdUI.Input searchInput;
        private AntdUI.Button searchButton;
    }
}
