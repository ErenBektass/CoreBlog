using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.ENTITIES.Concrete
{
    public class Blog
    {
        [Key]
        public int BlogID {  get; set; }
        public string? Title {  get; set; }
        public string? Content { get; set; }
        public string? ThumbnailImage { get; set; }
        public string? Image  {  get; set; }
        public DateTime CreateDate { get; set; }
        public bool Status { get; set; }

        //Relational Properties
        public int CategoryID { get; set; }
        public Category Category { get; set; }
		public int? WriterID { get; set; }
		public Writer writer { get; set; }
		public List<Comment> Comments { get; set; }
    }
}
