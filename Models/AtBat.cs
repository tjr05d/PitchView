using System; 
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic; 

namespace pitch_app.Models 
{
    public class AtBat
    {
        public Pitcher Pitcher { get; }
        public Batter Batter { get; }
        public List<Pitch> Pitches { get; set; }

        public AtBat(Pitcher pitcher, Batter batter, List<Pitch> pitches)
        {
            Pitcher = pitcher;
            Batter = batter;
            Pitches = pitches; 
        }

    }
}