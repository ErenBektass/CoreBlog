using Project.ENTITIES.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DAL.Abstact
{
    public interface IMessage2Dal : IGenericDal<Message2>
    {
        List<Message2> GetInboxtWithMessageByWriter(int id);
        List<Message2> GetSendboxWithMessageByWriter(int id);
    }
}
