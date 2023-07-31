using Blog.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Blog.Controllers
{
    public class HomeController : Controller
    {
        ModelDb ModelDb;
        public HomeController(ModelDb modelDb)
        {
            ModelDb = modelDb;
        }

        public ViewResult Index(string username,string password)
        {
           
               return View("Index");
           
        }
    }
}