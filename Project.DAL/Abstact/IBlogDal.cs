using Project.ENTITIES.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DAL.Abstact
{
    public interface IBlogDal:IGenericDal<Blog>
    {
        List<Blog> GetListWithCategory(); //Kategori ile beraber listeyi getir
        List<Blog> GetListWithCategoryByWriter(int id);
    }
}
