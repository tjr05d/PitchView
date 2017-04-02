using System;
using System.Collections.Generic; 
using System.Linq; 
using Newtonsoft.Json; 

namespace pitch_app.Models
{
    public class Inning
    {
        public int Number { get; set; }
        public bool Top  { get; set; }
        public List<AtBat> AtBats { get; set; }

        public Inning(int number, bool top) 
        {
            Number = number; 
            Top = top;
            AtBats = new List<AtBat>(); 
        }

        public void GetData()
        {
            string json = System.IO.File.ReadAllText(@"App_Data/interviewgame.json");
            // Takes the JSON String a converts into a List of Dictionaries
            var GameData =  JsonConvert.DeserializeObject<List<Pitch>>(json); 
            //query pitches for this inning
            var InningPitches = from pitch in GameData where (pitch.inning == this.Number) && (pitch.top_of_inning == this.Top) select pitch; 
            //Create at bats for the Inning
            int currentBatter = 0; 
            foreach(Pitch pitch in InningPitches)
            {
                if(currentBatter != pitch.batter_id)
                {
                    //set teh currnet batter to new batter
                    currentBatter = pitch.batter_id;
                    //query for all of the picthes in the at bat
                    List<Pitch> PitchesInAtBat = (from inningPitch in InningPitches where inningPitch.batter_id == currentBatter select inningPitch).ToList();  
                    //instantiates new at bat
                    Pitcher c_pitcher = new Pitcher(pitch.pitcher, pitch.pitcher_id);
                    Batter c_batter = new Batter(pitch.batter, pitch.batter_id); 
                    AtBat newAB = new AtBat(c_pitcher, c_batter, PitchesInAtBat);
                    //Add the at bat to the inning
                    this.AtBats.Add(newAB);  
                }
            }
            
        }
    }
}