using brilliant_lms.Models.Entities;
using brilliant_lms.Models.Responses;
using brilliant_lms.Services;
using brilliant_lms.Utilities;
using brilliant_lms.Theme;

namespace brilliant_lms.Views.Archived.Classes.Resources
{
    public partial class ResourcesDirectoryControl : UserControl
    {
        private User user;
        private ResourceService resourceService = new ResourceService();
        private Classroom classroom;
        private bool loading;

        public ResourcesDirectoryControl(User user, Classroom classroom)
        {
            this.user = user;
            this.classroom = classroom;
            InitializeComponent();
            InitializeControl();
            ThemeManager.ThemeChanged += ThemeManager_ThemeChanged;
        }

        private void InitializeControl()
        {
            SetIllustration();
        }

        private void ThemeManager_ThemeChanged(object? sender, EventArgs e)
        {
            SetIllustration();
        }

        private void SetIllustration()
        {
            Image? previous = illustrationImage.Image;
            illustrationImage.Image = ResourceImage.Load(AntdUI.Config.IsLight
                ? "Illustrations.Empty.empty_light.png"
                : "Illustrations.Empty.empty_dark.png");
            previous?.Dispose();
        }

        private async void ResourcesDirectoryControl_Load(object? sender, EventArgs e)
        {
            await LoadResourcesAsync();
        }

        private async Task LoadResourcesAsync()
        {
            if (loading) return;

            SetBusy(true);
            
            try
            {
                List<ResourceDirectoryItem> resources = await resourceService.GetClassroomResourcesAsync(user.Id, classroom.Id);

                resourcesContent.SuspendLayout();

                try
                {
                    foreach (ResourceDirectoryItem resource in resources)
                    {
                        ResourceCardControl card = new ResourceCardControl(user, resource);
                        card.TabIndex = resourcesContent.Controls.Count;
                        AntdUI.GridPanel cardRow = new AntdUI.GridPanel
                        {
                            Span = "50%_N 1116 50%_N",
                            Size = new Size(952, card.Height + card.Margin.Vertical),
                            BackColor = Color.Transparent,
                            Back = Color.Transparent,
                            Margin = new Padding(0)
                        };
                        cardRow.Controls.Add(card);
                        resourcesContent.Controls.Add(cardRow);
                    }

                    emptyPanel.Visible = resources.Count == 0;
                    resourcesContent.Visible = resources.Count > 0;
                }
                finally
                {
                    resourcesContent.ResumeLayout(true);
                }
            }
            catch (InvalidOperationException exception)
            {
                if (!IsDisposed)
                    FeedbackDialog.Error(FindForm()!, "Load failed", exception.Message);
            }
            catch (Exception)
            {
                if (!IsDisposed)
                    FeedbackDialog.Error(FindForm()!, "Load failed", "Unable to load resources. Please try again.");
            }
            finally
            {
                SetBusy(false);
            }
        }

        private void SetBusy(bool busy)
        {
            loading = busy;
            UseWaitCursor = busy;
            resourcesContent.Enabled = !busy;
        }

    }
}
