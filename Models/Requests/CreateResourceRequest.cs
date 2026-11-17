namespace brilliant_lms.Models.Requests
{
    public class CreateResourceRequest
    {
        public string Title { get; set; } = "";
        public string Description { get; set; } = "";
        public List<string> AttachmentLinks { get; set; } = new List<string>();
    }
}
