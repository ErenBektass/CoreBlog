using Project.BLL.Abstract;
using Project.DAL.Abstact;
using Project.ENTITIES.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Project.BLL.Concrate
{
	public class NewsLetterManager : INewsLetterService
	{
		INewsLetterDal _newsletterdal;

		public NewsLetterManager(INewsLetterDal newsletterdal)
		{
			_newsletterdal = newsletterdal;
		}

		public void AddNewsLetter(NewsLetter newsLetter)
		{
			_newsletterdal.Insert(newsLetter);
		}
	}
}
