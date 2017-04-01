using System; 
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic; 

namespace pitch_app.Models 
{
    public class AtBat
    {
        public string Pitcher { get; set; }
        public string Batter { get; set; }
        
        public List<Pitch> Pitches { get; set; }

        public AtBat(string pitcher = null, string batter= null)
        {
            Pitcher = pitcher;
            Batter = batter; 
        }

    }
}