namespace brilliant_lms.Utilities
{
    public static class FeedbackDialog
    {
        public static void Error(Form owner, string title, string message)
        {
            AntdUI.Modal.open(new AntdUI.Modal.Config(owner, title, message + "\n\n")
            {
                Icon = AntdUI.TType.Error,
                OkText = "Try again",
                OkType = AntdUI.TTypeMini.Primary,
                CancelText = null,
                CloseIcon = true,
                Mask = true,
                MaskClosable = false,
                OnButtonStyle = (name, button) =>
                {
                    button.Radius = 0;
                }
            });
        }

        public static void Success(Form owner, string title, string message)
        {
            AntdUI.Modal.open(new AntdUI.Modal.Config(owner, title, message + "\n\n")
            {
                Icon = AntdUI.TType.Success,
                OkText = "OK",
                OkType = AntdUI.TTypeMini.Primary,
                CancelText = null,
                CloseIcon = true,
                Mask = true,
                MaskClosable = false,
                OnButtonStyle = (name, button) =>
                {
                    button.Radius = 0;
                }
            });
        }
    }
}