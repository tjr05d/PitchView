using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using pitch_app.Models;

namespace pitch_app.ViewComponents
{
    public class AtBatListViewComponent : ViewComponent
    {


        public async Task<IViewComponentResult> InvokeAsync(int inning_num, bool top)
        {
            var atBats = GetAtBatsAsync(inning_num, top);
            return View(atBats);
        }
        private List<AtBat> GetAtBatsAsync(int inning_num, bool top)
        {
            GameDataApi api_call = new GameDataApi(); 
            return api_call.GetPopulatedInning(inning_num, top).AtBats; 

        }
    }
}