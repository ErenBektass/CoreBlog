using Microsoft.EntityFrameworkCore;

namespace Project.BlogAPI.DAL
{
    public class Context:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            //optionsBuilder.UseSqlServer("server=DESKTOP-QMN15OM\\SQLEXPRESS;database=CoreBlogDB; integrated security=true;");
            optionsBuilder.UseSqlServer("server=DESKTOP-QMN15OM\\SQLEXPRESS; database = CoreBlogApiDB; integrated security=true; TrustServerCertificate=True");
            base.OnConfiguring(optionsBuilder);
        }


        public DbSet<Employee>  Employees { get; set; }
    }
}
