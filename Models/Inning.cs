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

        public void Populate()
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
                    //create a new at bat
                    AtBat newAB = new AtBat(pitch.batter, pitch.pitcher);
                    //Add the at bat to the inning
                    this.AtBats.Add(newAB);  
                    currentBatter = pitch.batter_id; 
                }
            }
            
        }
    }
}

// To populate the Inning
// loop through every dict that has that has the corret number and top boolean
//When a new batter appears create a new AtBat
// for each AtBat create the Pitches that go along with that atBAt