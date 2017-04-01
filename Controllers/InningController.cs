using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;
using pitch_app.Models; 

namespace pitch_app.Controllers
{
    public class InningController : Controller
    {
        public IActionResult Index(int number = 1, bool top = true)
        {
            Inning inning = new Inning(number, top);
            return View(inning); 
        }

        public IActionResult Welcome(string name, int ID = 1)
        {
         return View(); 
        }

        private static string GetName(Inning inning)
        {
            return inning.Name;
        }
    }
}