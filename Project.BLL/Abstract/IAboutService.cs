using Project.ENTITIES.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BLL.Abstract
{
	public interface IAboutService : IGenericService<About>
	{
		List<About> GetAll();  // bu metot ilgili About neyse o yapıdaki tüm verileri getirecek
    }
}
