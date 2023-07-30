using Blog.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Blog.Controllers
{
    public class HomeController : Controller
    {
        public ViewResult Index(string username,string password)
        {
           
               return View("Index");
           
        }
    }
}