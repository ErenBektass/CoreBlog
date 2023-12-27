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
    public class EfCommentRepository : GenericRepository<Comment>, ICommentDal
    {
        public List<Comment> GetListWithBlog()
        {
            using (var c = new MyContext())
            {
                return c.Comments.Include(x => x.Blog).ToList();
            }
        }
    }
}
