using Microsoft.EntityFrameworkCore;
using Project.DAL.Abstact;
using Project.DAL.Concrate;
using Project.DAL.Repositories;
using Project.ENTITIES.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DAL.EntityFramework
{
    public class EfBlogRepository : GenericRepository<Blog>, IBlogDal
    {
        public List<Blog> GetListWithCategory()
        {
            using(var c=new MyContext())
            {
                return c.Blogs.Include(x => x.Category).ToList(); // Kategori tablosuna ait tüm değerleri getir
            }
            
        }

        public List<Blog> GetListWithCategoryByWriter(int id)
        {
            using (var c = new MyContext())
            {
                return c.Blogs.Include(x => x.Category).Where(x=>x.WriterID==id).ToList(); 
            }
        }
    }
}
