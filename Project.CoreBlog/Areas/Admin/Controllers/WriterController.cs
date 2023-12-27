using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Bson;
using Project.CoreBlog.Areas.Admin.Models;

namespace Project.CoreBlog.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class WriterController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult WriterList()
        {
            var jsonWriters = JsonConvert.SerializeObject(writers);
            return Json(jsonWriters);
        }
        public IActionResult GetWriterByID(int writerid)
        {
            var findWriter=writers.FirstOrDefault(x=>x.ID== writerid);
            var jsonWriters = JsonConvert.SerializeObject(findWriter);
            return Json(jsonWriters);

        }
        [HttpPost]
        public IActionResult AddWriter(WriterClass writer)
        {
            writers.Add(writer);
            var jsonWriters = JsonConvert.SerializeObject(writer);
            return Json(jsonWriters);
        }
        public IActionResult DeleteWriter(int id)
        {
            var writer = writers.FirstOrDefault(x => x.ID == id);
            writers.Remove(writer);
            return Json(writer);
        }
        public IActionResult UpdateWriter(WriterClass wc)
        {
            var writer = writers.FirstOrDefault(x => x.ID == wc.ID);
            writer.Name = writer.Name;
            var jsonWriter = JsonConvert.SerializeObject(wc);
            return Json(jsonWriter);
        }

        public static List<WriterClass> writers = new List<WriterClass>()
        {
            new WriterClass
            {
                 ID = 1,
                 Name="Eren"
            },
            new WriterClass
            {
                 ID = 2,
                 Name="Selin"
            },
            new WriterClass
            {
                 ID = 3,
                 Name="Cem"
            }
        };
    }
}
