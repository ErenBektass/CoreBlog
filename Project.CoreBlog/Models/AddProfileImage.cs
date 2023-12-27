namespace Project.CoreBlog.Models
{
    public class AddProfileImage
    {
        public int WriterID { get; set; }
        public string WriterName { get; set; }
        public string About { get; set; }
        public IFormFile? Image { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public bool Status { get; set; }
    }
}
