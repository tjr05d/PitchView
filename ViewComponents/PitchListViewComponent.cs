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
            Inning query_inning = new Inning(inning_num, top);
            query_inning.GetData();
            var match_up = from ab in query_inning.AtBats select ab;
            var pitches = match_up.FirstOrDefault().Pitches; 
            return View(pitches);
        }
    }
}