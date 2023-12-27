using Project.DAL.Abstact;
using Project.DAL.Repositories;
using Project.ENTITIES.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DAL.EntityFramework
{
    public class EfAboutRepository:GenericRepository <About>,IAboutDal
    {
    }
}
