using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using pitch_app.Models;

namespace pitch_app.ViewComponents
{
    public class AtBatListViewComponent : ViewComponent
    {


        public async Task<IViewComponentResult> InvokeAsync(
        int inning_num, bool top)
        {
            var atBats = GetAtBatsAsync(inning_num, top);
            return View(atBats);
        }
        private List<AtBat> GetAtBatsAsync(int inning_num, bool top)
        {
            Inning query_inning  = new Inning(inning_num, top);
            query_inning.GetData(); 
            
            return query_inning.AtBats;  
        }
    }
}