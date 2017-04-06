using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
            Inning inning = new Inning(inning_num, top); 
            var InningPitches = new GameDataApi().InningPitches(inning);
    
            //query pitches for this inning
            var AbPitches = from pitch in InningPitches where (pitch.batter_id == batter_id) && (pitch.pitcher_id == pitcher_id) select pitch;
            int ab_counter = 1; 
            // adds pitch in atbat number
            foreach (Pitch ab_pitch in AbPitches)
                {
                    ab_pitch.at_bat_pitch = ab_counter;
                    ab_counter ++; 
                }
            return AbPitches.ToList();  
        }

    }

}
