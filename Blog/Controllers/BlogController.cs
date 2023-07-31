using Blog.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Web;
namespace Blog.Controllers
{
    [Route("Blog")]
    public class BlogController : Controller
    {
        ModelDb db;
        public ViewResult Index(string username,string password)
        {
            
            int id=db.getId(username, password);
            if (id != 0)
            {
                HttpContext.Session.SetString("id", id + "");
                HttpContext.Session.SetString("username", username);

                return show();
            }
            return View("Views/Home/Index.cshtml");
        }
        [Route("show")]
        public ViewResult show()
        {

            string id=HttpContext.Session.GetString("id");
            string username=HttpContext.Session.GetString("username");

            ViewBag.username = username;
            ViewBag.Contenuti = db.get(Int32.Parse(id));
            return View("Views/Blog/Index.cshtml");
        }
        public BlogController([FromServices] ModelDb db) { this.db = db; }

        [Route("addContenuti")]
        public IActionResult addContenuti(string titolo,string descrizione)
        {
            string id = HttpContext.Session.GetString("id");
            db.addContenuto(Int32.Parse(id), titolo, descrizione);
            ViewBag.Contenuti = db.get(Int32.Parse(id));
            return RedirectToAction("show","Blog");
         
        }
        
       
       
    }
}
