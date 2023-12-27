namespace Project.CoreBlog.Areas.Admin.Models
{
    public class RoleAssignViewModel
    {
        public int RoleID { get; set; }
        public string Name { get; set; }
        public bool Exists { get; set; }// Exists= Bu rol bu kullanıcıda var mi
    }
}
