using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json; 
using pitch_app.Models;

namespace pitch_app.ViewComponents
{
    public class PitchListViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(int inning_num, bool top, int pitcher_id, int batter_id)
        {
            
            var pitches = GetPitchData(inning_num, top, pitcher_id, batter_id); 
            return View(pitches);
        }

        private List<Pitch> GetPitchData(int inning_num, bool top, int pitcher_id, int batter_id){
            string json = System.IO.File.ReadAllText(@"App_Data/interviewgame.json");
            // Takes the JSON String a converts into a List of Dictionaries
            var GameData =  JsonConvert.DeserializeObject<List<Pitch>>(json); 
            //query pitches for this inning
            var InningPitches = from pitch in GameData where (pitch.inning == inning_num) && (pitch.top_of_inning == top) select pitch;
            var AbPitches = from pitch in InningPitches where (pitch.batter_id == batter_id) && (pitch.pitcher_id == pitcher_id) select pitch;
            int ab_counter = 1; 
            foreach (Pitch ab_pitch in AbPitches)
                    {
                        ab_pitch.at_bat_pitch = ab_counter;
                        ab_counter ++; 
                    }
            return AbPitches.ToList();  
        }
    }
}