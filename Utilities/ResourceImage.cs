namespace brilliant_lms.Utilities
{
    public static class ResourceImage
    {
        public static Stream? GetStream(string name)
        {
            return typeof(ResourceImage).Assembly.GetManifestResourceStream($"brilliant_lms.Assets.{name}");
        }

        public static Image? Load(string name)
        {
            Stream? stream = GetStream(name);
            if (stream == null) return null;
            return Image.FromStream(stream);
        }
    }
}
