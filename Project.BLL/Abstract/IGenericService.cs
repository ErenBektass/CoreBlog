using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BLL.Abstract
{
	public interface IGenericService<T>
	{
		void TAdd(T t);  // bu metot veri ekler
        void TDelete(T t); // bu metot veriyi siler
        void TUpdate(T t); // bu metot veriyi Günceller
        List<T> GetList();  // bu metot veriyi listeler
        T TGetById(int id); // bu metot veriyi id'ye göre getirir
    }
}
