using Microsoft.AspNetCore.Mvc.Rendering;

namespace Project.CoreBlog.Models
{
    public class Cities
    {
        public string Sehir { get; set; }
        public IList<SelectListItem> Sehirler { get; set; }
    }
}
