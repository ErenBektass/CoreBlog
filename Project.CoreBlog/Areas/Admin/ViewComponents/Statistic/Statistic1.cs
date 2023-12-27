using DocumentFormat.OpenXml.Bibliography;
using Microsoft.AspNetCore.Mvc;
using Project.BLL.Concrate;
using Project.DAL.Concrate;
using Project.DAL.EntityFramework;
using System.Xml.Linq;

namespace Project.CoreBlog.Areas.Admin.ViewComponents.Statistic
{
    public class Statistic1:ViewComponent
    {
        BlogManager bm = new BlogManager(new EfBlogRepository());
        MyContext mc=new MyContext();
        public IViewComponentResult Invoke()
        {
            ViewBag.v1 = bm.GetList().Count();
            ViewBag.v2=mc.Contacts.Count();
            ViewBag.v3=mc.Comments.Count();
            string city = "istanbul";
            string api = "68c0c813563e0d0dbeed7d3c22fc7572";
            string connection = "https://api.openweathermap.org/data/2.5/weather?q=" + city +  "&mode=xml&appid=" + api + "&units=metric";
            XDocument document =XDocument.Load(connection);
            ViewBag.v4 = document.Descendants("temperature").ElementAt(0).Attribute("value").Value;
           return View();
        }
    }
}
