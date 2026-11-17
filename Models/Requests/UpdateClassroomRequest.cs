namespace brilliant_lms.Models.Requests
{
    public class UpdateClassroomRequest
    {
        public string Name { get; set; } = "";
        public string? Section { get; set; }
        public string? Subject { get; set; }
        public string? Room { get; set; }
        public string? Schedule { get; set; }
        public string? Level { get; set; }
    }
}
