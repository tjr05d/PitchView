using System.Collections.Generic; 

namespace pitch_app.Models.Services
{
    public class InningDropdown
    {
        public List<Inning> GetInnings(bool bot_nine = false)
        {
            List<Inning> list = new List<Inning>(); 
            for(int i = 1; i <= 9; i++)
            {
                list.Add(new Inning (i, true)); 
                if(bot_nine || i < 9) list.Add(new Inning (i, false)); 
            }
            return list; 
        } 
    }
 }
