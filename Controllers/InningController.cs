using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;

namespace pitch_app.Controllers
{
    public class InningController : Controller
    {
        public IActionResult Index(int Id = 1)
        {
            ViewData["Inning"] = Id.ToString() + "Inning";
            ViewData["Pitcher"] = "Fiers, M"; 

            return View(); 
        }

        public IActionResult Welcome(string name, int ID = 1)
        {
            ViewData["Message"] = "Hello " + name;
            ViewData["NumTimes"] = ID;

            return View();
        }
    }
}