using System.ComponentModel.DataAnnotations;

namespace Project.BlogAPI.DAL
{
    public class Employee
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
    }
}
