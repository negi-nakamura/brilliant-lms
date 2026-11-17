using brilliant_lms.Models.Entities;
using brilliant_lms.Models.Responses;
using brilliant_lms.Services;
using brilliant_lms.Utilities;
using brilliant_lms.Theme;

namespace brilliant_lms.Views.Classrooms.Teachings.Resources
{
    public partial class ResourcesDirectoryControl : UserControl
    {
        private User user;
        public event EventHandler? ResourceChanged;
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
                        card.UpdateRequested += Card_UpdateRequested;
                        card.DeleteRequested += Card_DeleteRequested;
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

        private void Card_UpdateRequested(object? sender, ResourceDirectoryItem resource)
        {
            if (loading) return;

            using UpdateResourceControl updateResource = new UpdateResourceControl(user, classroom, resource);
            Form owner = FindForm()!;
            if (owner is AntdUI.Window window) window.AutoDpi(updateResource);

            AntdUI.Modal.open(new AntdUI.Modal.Config(owner, "Update Resource", updateResource, AntdUI.TType.None)
            {
                BtnHeight = 0,
                MaskClosable = false,
                Keyboard = false,
                CloseIcon = true
            });

            if (updateResource.UpdatedResource != null) ResourceChanged?.Invoke(this, EventArgs.Empty);
        }

        private async void Card_DeleteRequested(object? sender, ResourceDirectoryItem resource)
        {
            if (loading) return;

            DialogResult result = AntdUI.Modal.open(new AntdUI.Modal.Config(FindForm()!, "Delete resource", "Delete this resource? This action cannot be undone.\n\n")
            {
                Icon = AntdUI.TType.Warn,
                OkText = "Delete",
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
                await resourceService.DeleteAsync(user.Id, classroom.Id, resource.Id);
                FeedbackDialog.Success(FindForm()!, "Resource deleted", "The resource has been deleted successfully.");
            }
            catch (InvalidOperationException exception)
            {
                FeedbackDialog.Error(FindForm()!, "Delete failed", exception.Message);
                return;
            }
            catch (Exception)
            {
                FeedbackDialog.Error(FindForm()!, "Delete failed", "Unable to delete the resource. Please try again.");
                return;
            }
            finally
            {
                SetBusy(false);
            }

            ResourceChanged?.Invoke(this, EventArgs.Empty);
        }

        private void SetBusy(bool busy)
        {
            loading = busy;
            UseWaitCursor = busy;
            resourcesContent.Enabled = !busy;
        }

    }
}
