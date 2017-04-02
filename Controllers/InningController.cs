using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;
using pitch_app.Models; 

namespace pitch_app.Controllers
{
    public class InningController : Controller
    {
        public IActionResult Index(int number = 2, bool top = false)
        {
            Inning inning = new Inning(number, top);
            inning.GetData(); 
            return View(inning); 
        }

        public IActionResult GetAtBats(string inning_num, string top)
        {
            int cvt_inning_num = int.Parse(inning_num); 
            bool cvt_top = bool.Parse(top); 

            return ViewComponent("AtBatList", new { inning_num = cvt_inning_num, top = cvt_top}); 
        }
    }
}