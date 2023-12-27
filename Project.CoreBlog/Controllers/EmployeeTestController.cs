using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace Project.CoreBlog.Controllers
{
    public class EmployeeTestController : Controller
    {
        public  async Task<IActionResult> Index()
        {
            var httpClient=new HttpClient();
            var responseMessage = await httpClient.GetAsync("https://localhost:7159/api/Default/EmployeeList");
            var jsonString=await responseMessage.Content.ReadAsStringAsync();
            var values=JsonConvert.DeserializeObject<List<Class1>>(jsonString);
            return View(values);
        }

        [HttpGet]
        public IActionResult AddEmployee()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddEmployee(Class1 clas)
        {
            var httpClient = new HttpClient();
            var jsonEmployee = JsonConvert.SerializeObject(clas);
            StringContent content = new StringContent(jsonEmployee, Encoding.UTF8, "application/json");
            var rensonseMessage = await httpClient.PostAsync("https://localhost:7159/api/Default/EmployeeList\r\n", content);
            if (rensonseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View(clas);
        }
        [HttpGet]
        public async Task<IActionResult> EditEmployee(int id)
        {
            var httpClient = new HttpClient();
            var rensonseMessage = await httpClient.GetAsync("\"https://localhost:7159/api/Default/EmployeeList\r\n" + id);
            if (rensonseMessage.IsSuccessStatusCode)
            {
                var jsonEmployee = await rensonseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<Class1>(jsonEmployee);
                return View(values);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> EditEmployee(Class1 p)
        {
            var httpClient = new HttpClient();
            var jsonEmployee = JsonConvert.SerializeObject(p);
            var content=new StringContent(jsonEmployee, Encoding.UTF8, "application/json");
            var rensonseMessage = await httpClient.PutAsync("\"https://localhost:7159/api/Default/EmployeeList\r\n", content);
            if (rensonseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View(p);
        }
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            var httpClient = new HttpClient();
            var rensonseMessage = await httpClient.DeleteAsync("\"https://localhost:7159/api/Default/EmployeeList\r\n" + id);
            if (rensonseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
    }
    public class Class1
    {
        public int ID { get; set; }
        public string? Name { get; set; }
    }
}
