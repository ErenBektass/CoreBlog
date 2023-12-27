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
	public class ContactManager : IContactService
	{

		IContactDal _contactDal;
		public ContactManager(IContactDal contactDal)
		{
			_contactDal = contactDal;
		}
		public void ContactAdd(Contact contact)
		{
			_contactDal.Insert(contact);
		}

	}
}
