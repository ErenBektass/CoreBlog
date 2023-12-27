using Project.BLL.Abstract;
using Project.DAL.Abstact;
using Project.ENTITIES.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BLL.Concrate
{
    public class NotificationManager : INotificationService
    {
        INotificationDal _noNotificationDal;

        public NotificationManager(INotificationDal noNotificationDal)
        {
            _noNotificationDal = noNotificationDal;
        }

        public List<Notification> GetList()
        {
            return _noNotificationDal.GetListAll();
        }

        public void TAdd(Notification t)
        {
            throw new NotImplementedException();
        }

        public void TDelete(Notification t)
        {
            throw new NotImplementedException();
        }

        public Notification TGetById(int id)
        {
            throw new NotImplementedException();
        }

        public void TUpdate(Notification t)
        {
            throw new NotImplementedException();
        }
    }
}
