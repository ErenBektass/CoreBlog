using Project.DAL.Abstact;
using Project.DAL.Concrate;
using Project.ENTITIES.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Project.DAL.Repositories
{
    public class GenericRepository<T> : IGenericDal<T> where T : class
    {
        MyContext mc = new MyContext();
        public void Delete(T t)
        {
           mc.Remove(t);
           mc.SaveChanges();
        }

        public T GetById(int id)
        {
            return mc.Set<T>().Find(id);
        }

        public List<T> GetListAll()
        {
            return mc.Set<T>().ToList();
        }

        public void Insert(T t)
        {
            mc.Add(t);
            mc.SaveChanges();
        }

		public List<T> GetListAll(Expression<Func<T, bool>> filter)
		{
			return mc.Set<T>().Where(filter).ToList(); // filterdan gelen değere göre listemele işlemini yapicak
		}

		public void Update(T t)
        {
            mc.Update(t);
            mc.SaveChanges();
        }
    }
}
