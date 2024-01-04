using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project.BlogAPI.DAL;

namespace Project.BlogAPI.Controllers
{
    /// <summary>
    /// Bu controller kullanıcılarla olan işlemleri yapılmasını sağlar
    /// </summary>
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class DefaultController : ControllerBase
    {
        /// <summary>
        /// Bu metot ile kullanıcıların listesini çekebilmektedir
        /// </summary>
        /// <returns> Kullanıcı listesi</returns>
        [HttpGet]
        public IActionResult EmployeeList()
        {
            using var c = new Context();
            var values = c.Employees.ToList();
            return Ok(values);
        }
		/// <summary>
		/// Bu metot  kullanıcıları ekler
		/// </summary>
		/// <param name="employee"> employee objesi gönderilir kulla </param>
		/// <returns>Kullanıcı ekleme</returns>
		[HttpPost]
        public IActionResult EmployeeAdd(Employee employee)
        {
            using var c = new Context();
            c.Add(employee);
            c.SaveChanges();
            return Ok();
        }
		/// <summary>
		///  Bu metot  kullanıcıyı Getirir
		/// </summary>
		/// <param name="id"> Kullanıcının ID bilgisi Getirir </param>
		/// <returns>Kullanıcı Getir</returns>
		[HttpGet("{id}")]
        public IActionResult EmployeeGet(int id)
        {
            using var c = new Context();
            var employee = c.Employees.Find(id);
            if (employee==null)
            {
                return NotFound();
            }
            else
            {
                return Ok(employee);
            }
        }
		/// <summary>
		/// Bu metot kullanıcıları siler
		/// </summary>
		/// <param name="id"> Kullanıcının ID'sine göre işlem yapar </param>
		/// <returns>Kullanıcı Sil</returns>
		[HttpDelete("{id}")]
        public IActionResult EmployeeDelete(int id)
        {
            using var c = new Context();
            var employee = c.Employees.Find(id);
            if (employee == null)
            {
                return NotFound();
            }
            else
            {
                c.Remove(employee);
                c.SaveChanges();
                return Ok();
            }
        }
		/// <summary>
		/// Bu metot kullanıcıları Günceller
		/// </summary>
		/// <param name="id">Kullanıcıyı Güncelle </param>
		/// <returns> Kullanıcı Güncelle</returns>
		[HttpPut]
        public IActionResult EmployeeUpdate(Employee employee)
        {
            using var c = new Context();
            var emp = c.Find<Employee>(employee.ID);
            if (emp == null)
            {
                return NotFound();
            }
            else
            {
                emp.Name= employee.Name;
                c.Update(emp);
                c.SaveChanges();
                return Ok();
            }
        }
}   } 
