namespace brilliant_lms.Views.Archived.Classes.Details
{
    partial class DetailsControl
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
            detailsContent = new AntdUI.StackPanel();
            SuspendLayout();
            detailsContent.AutoContainerBgTransparent = true;
            detailsContent.AutoScroll = true;
            detailsContent.Back = Color.Transparent;
            detailsContent.BackColor = Color.Transparent;
            detailsContent.Dock = DockStyle.Fill;
            detailsContent.Name = "detailsContent";
            detailsContent.Padding = new Padding(0, 16, 0, 0);
            detailsContent.Vertical = true;
            BackColor = Color.Transparent;
            Controls.Add(detailsContent);
            Load += DetailsControl_Load;
            AutoScaleDimensions = new SizeF(8F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            Font = new Font("Microsoft YaHei UI", 10F);
            Name = "DetailsControl";
            Size = new Size(952, 510);
            ResumeLayout(false);
        }

        #endregion

        private AntdUI.StackPanel detailsContent;
    }
}
