using System.Collections.Generic; 

namespace pitch_app.Models.Services
{
    public class InningDropdown
    {
        public List<Inning> GetInnings()
        {
            List<Inning> list = new List<Inning>(); 
            for(int i = 1; i <= 9; i++)
            {
                list.Add(new Inning (i, true)); 
                list.Add(new Inning (i, false)); 
            }
            return list; 
        } 
    }
 }
