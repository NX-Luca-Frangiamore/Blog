using Blog.Models;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Controllers
{
    public class BlogController : Controller
    {
        ModelDb db;

        public ViewResult Index(string username,string password)
        {
            if (username == "luca" && password == "1234")//creare sevizio per verificare credenziali
                return View();
            return View("/Views/Home/Index.cshtml");
        }
        public BlogController([FromServices] ModelDb db) { this.db = db; }
        
        
        public void setUp (){
             db.setUp();
        }
        
        public List<Dati> showPage() {

            return db.get();
        }
       
    }
}
