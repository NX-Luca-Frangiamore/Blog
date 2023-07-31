using Blog.Models;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Controllers
{
    public class BlogController : Controller
    {
        ModelDb db;
        public static string id;
        public ViewResult Index(string username,string password)
        {
            string id=db.getId(username, password);
            if (id != null)
            {
                BlogController.id = id;
                ViewBag.id = id;
                ViewBag.Contenuti = db.get(id);
                return View();
            }
            return View("/Views/Home/Index.cshtml");
        }
        public BlogController([FromServices] ModelDb db) { this.db = db; }
        
        
       
       
    }
}
