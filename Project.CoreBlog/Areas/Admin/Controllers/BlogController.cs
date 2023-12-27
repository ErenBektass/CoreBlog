using ClosedXML.Excel;
using DocumentFormat.OpenXml.InkML;
using DocumentFormat.OpenXml.Office2010.Excel;
using Microsoft.AspNetCore.Mvc;
using Project.CoreBlog.Areas.Admin.Models;
using Project.DAL.Concrate;

namespace Project.CoreBlog.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BlogController : Controller
    {
  
        public IActionResult ExportStaticBlogList()
        {
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Blog Listesi");
                worksheet.Cell(1, 1).Value = "Blog ID";
                worksheet.Cell(1, 2).Value = "Blog Adı";

                int BlogRowCount = 2;
                foreach (var item in GetBlogList())
                {
                    worksheet.Cell(BlogRowCount, 1).Value = item.ID;
                    worksheet.Cell(BlogRowCount, 2).Value = item.BlogName;
                    BlogRowCount++;
                }
                using (var stream=new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    var content=stream.ToArray();
                    return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet","Calisma1.xlsx");
                }
            }
        }
        public List<BlogModel> GetBlogList()
        {
            List<BlogModel> bm = new List<BlogModel>
            {
                new BlogModel
                {
                    ID=1,
                    BlogName="C# Programlamaya Giriş"

                },
                new BlogModel
                {
                    ID=2,
                    BlogName="Tesla Firmasının Araçları"

                },
                new BlogModel
                {
                    ID=3,
                    BlogName="2023 Olimpiyatları"

                },
            };
            return bm;
        }
        public IActionResult BlogListExcel()
        {   
            return View();
        }

        public IActionResult ExportDynamicExcelBlogList()
        {
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Blog Listesi"); 
                worksheet.Cell(1, 1).Value = "Blod ID";

                worksheet.Cell(1, 2).Value = "Blod Adı";

                int BlogRowCount = 2; 
                foreach (var item in BlogTitleList()) 
                {
                    worksheet.Cell(BlogRowCount, 1).Value = item.ID;
                    

                    worksheet.Cell(BlogRowCount, 2).Value = item.BlogName;
                    BlogRowCount++;

                }
                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    var content = stream.ToArray();
                    return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet","Calisma.xlsx");
                    
                }
            }
        }
        public List<BlogModel2> BlogTitleList()
        {
            List<BlogModel2> bm2 = new List<BlogModel2>();
            using (var mc=new MyContext())
            {
                bm2 = mc.Blogs.Select(x => new BlogModel2
                {
                    ID = x.BlogID,
                    BlogName = x.Title

                }).ToList();
            }
            return bm2;
        }
        public IActionResult BlogTitleListExcel()
        {
            return View();
        }
    }
    
}
