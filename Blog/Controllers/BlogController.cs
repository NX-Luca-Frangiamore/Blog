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
        public BlogController(ModelDb db) { this.db = db; }

        public async Task<ViewResult> Index(string username,string password)
        {
            
            int id=await db.getId(username, password);
            if (id != 0)
            {
                HttpContext.Session.SetString("id", id + "");
                HttpContext.Session.SetString("username", username);

                return show().Result;
            }
            return View("Views/Home/Index.cshtml");
        }
        [Route("show")]
        public async Task<ViewResult> show()
        {

            string id=HttpContext.Session.GetString("id");
            string username=HttpContext.Session.GetString("username");

            ViewBag.username = username;
            ViewBag.Contenuti = db.get(Int32.Parse(id)).Result;
            return View("Views/Blog/Index.cshtml");
        }

        [Route("addContenuto")]
        public IActionResult addContenuti(string titolo,string descrizione)
        {
            string id = HttpContext.Session.GetString("id");
            db.addContenuto(Int32.Parse(id), titolo, descrizione);
            ViewBag.Contenuti = db.get(Int32.Parse(id)).Result;
            return RedirectToAction("show","Blog");
         
        }
        [Route("addUtente")]
        public IActionResult addUtente(string username, string password)
        {
            db.addUtente(username,password);
            return RedirectToAction("", "Blog");
        }
        [Route("showRegister")]
        public ViewResult showRegister() { return View(); }



    }
}
