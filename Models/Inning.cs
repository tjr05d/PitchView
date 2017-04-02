using System;
using System.Collections.Generic; 
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
            // loop through all the pitches and cretae AtBats for the inning
            // for(int i = 0; i <= GameData.Count; i++)
            // {
            //     int currentInningNumber = Int32.Parse((GameData[i]["inning"])); 
            //     bool currentTop = Convert.ToBoolean(GameData[i]["top_of_inning"]);

            //     if((this.Number.Equals(currentInningNumber)) && (this.Top.Equals(currentTop)))   
            //     {
                    
            //     }

            // }
    

            AtBat second = new AtBat(GameData[20].batter, GameData[20].pitcher);
            // this.AtBats.Add(first);  
            this.AtBats.Add(second);  
        }
    }
}

// To populate the Inning
// loop through every dict that has that has the corret number and top boolean
//When a new batter appears create a new AtBat
// for each AtBat create the Pitches that go along with that atBAt