using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.ENTITIES.Concrete
{
    public class Writer
    {
        [Key]
        public int WriterID { get; set; }
        public string? WriterName { get; set; }
        public string? About { get; set; }
        public string? Image { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public bool Status { get; set; }

		//Relational Properties
		public List<Blog> Blogs { get; set; }
        public virtual ICollection<Message2> WriterSender { get; set; }
        public virtual ICollection<Message2> WriterReceiver { get; set; }
	}
}
