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
    public class EfMessage2Repository : GenericRepository<Message2>, IMessage2Dal
    {
        public List<Message2> GetSendboxWithMessageByWriter(int id)
        {
            using (var c =new  MyContext())
            {
                return c.Message2s.Include(x=>x.ReceiverUser).Where(y=>y.SenderID == id).ToList();
            }
        }

        public List<Message2> GetInboxtWithMessageByWriter(int id)
        {
            using (var c = new MyContext())
            {
                return c.Message2s.Include(x => x.SenderUser).Where(x => x.ReceiverID == id).ToList();
            }
        }
    }
}
