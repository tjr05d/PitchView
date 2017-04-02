using System; 
using System.Collections.Generic; 
using System.Linq; 
using Newtonsoft.Json; 

namespace pitch_app.Models 
{
    public class Pitcher : Player
    {
        public int PitcherId { get; set;}

        public Pitcher(string name, int pitcher_id)
        {
            Name = name;
            PitcherId = pitcher_id; 
        }
        public float AveragePitchSpeed(int inning = 9, string type= "FB", bool cumulative = true )
        {
            //EXTRACT THIS TO ITS OWN METHOD
            //select only pitches from this pither 
            List<Pitch>  PlayerPitches = this.AllGamePitches().ToList(); 
            List<Pitch> TypePitches = new List<Pitch>(); 
            if(cumulative)
            {
                TypePitches = (from pitch in PlayerPitches where ((pitch.pitch_type_name == "Four-Seam FB") || (pitch.pitch_type_name == "Two-Seam FB")) && pitch.inning <= inning select pitch).ToList(); 
            }
            else
            {
                TypePitches = (from pitch in PlayerPitches where ((pitch.pitch_type_name == "Four-Seam FB") || (pitch.pitch_type_name == "Two-Seam FB")) && pitch.inning == inning select pitch).ToList();
            }
            
            return TypePitches.ToList().Count() == 0 ? 0 : TypePitches.Select(pitch => pitch.release_speed).Average();    
        }

        private IEnumerable<Pitch> AllGamePitches()
        {
            //Get all the pitch Data
            string json = System.IO.File.ReadAllText(@"App_Data/interviewgame.json");
            // Takes the JSON String a converts into a List of Dictionaries
            var GameData =  JsonConvert.DeserializeObject<List<Pitch>>(json); 
            var allPitches = (from pitch in GameData where (pitch.pitcher_id == this.PitcherId) select pitch); 
            return allPitches; 
        }

    }
}