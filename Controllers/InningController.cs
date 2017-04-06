using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;
using pitch_app.Models;  

namespace pitch_app.Controllers
{
    public class InningController : Controller
    {
        public IActionResult Index(int number = 1, bool top = true)
        {
            GameDataApi api_call = new GameDataApi(); 
            Inning inning = api_call.GetPopulatedInning(number, top); 
            return View(inning); 
        }

        public IActionResult GetAtBats(string inning_num, string top)
        {
            int cvt_inning_num = int.Parse(inning_num); 
            bool cvt_top = bool.Parse(top); 

            return ViewComponent("AtBatList", new { inning_num = cvt_inning_num, top = cvt_top}); 
        }

        public IActionResult GetPitches(string inning_num, string top, string pitcher_id, string batter_id )
        {
            int cvt_inning_num = int.Parse(inning_num);
            bool cvt_top = bool.Parse(top);  
            int cvt_pitcher_id = int.Parse(pitcher_id);
            int cvt_batter_id = int.Parse(batter_id); 
    
            return ViewComponent("PitchList", new {inning_num = cvt_inning_num, top = cvt_top, pitcher_id= cvt_pitcher_id, batter_id= cvt_batter_id,}); 
        }

        public IActionResult PitcherStats(string game_pitch_number, string pitcher_id, string pitcher_name)
        {   
            int cvt_pitcher_id = int.Parse(pitcher_id);
            int cvt_game_pitch_number = int.Parse(game_pitch_number);
            Pitcher pitcher = new Pitcher(pitcher_name, cvt_pitcher_id); 

            return Json(pitcher.CurrentAvgFastballSpeed(cvt_game_pitch_number)); 
        }
    }
}