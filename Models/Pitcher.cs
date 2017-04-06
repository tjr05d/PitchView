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

        public float AveragePitchSpeed(int game_pitch, int inning = 9, string type= "FB", bool cumulative = true )
        {
            var  PlayerPitches = GamePitchesUpToCurrent(game_pitch); 
            var  TypePitches = new List<Pitch>(); 
            if(cumulative)
            {
                TypePitches = (from pitch in PlayerPitches where ((pitch.pitch_type_name == "Four-Seam FB") || (pitch.pitch_type_name == "Two-Seam FB")) && pitch.inning <= inning select pitch).ToList(); 
            }
            else
            {
                TypePitches = (from pitch in PlayerPitches where ((pitch.pitch_type_name == "Four-Seam FB") || (pitch.pitch_type_name == "Two-Seam FB")) && pitch.inning == inning select pitch).ToList();
            }
            
            return TypePitches.Count() == 0 ? 0 : TypePitches.Select(pitch => pitch.release_speed).Average();    
        }
        
        public Dictionary<int,float> CurrentAvgFastballSpeed(int game_pitch)
        {
            IEnumerable<Pitch> PlayerPitches = this.GamePitchesUpToCurrent(game_pitch);
            List<int>  InningsPitched = (from pitch in PlayerPitches where pitch.game_pitch_number <= game_pitch select pitch.inning).Distinct().ToList();
            var averageSpeedPerInning= new Dictionary<int, float>();

            foreach(int inning in InningsPitched){
                averageSpeedPerInning[inning] = this.AveragePitchSpeed(game_pitch, inning);  
            }

            return  averageSpeedPerInning; 
        } 

        private IEnumerable<Pitch> AllGamePitches()
        {
            var GameData =  new GameDataApi().AllPitches(); 
            return  from pitch in GameData where (pitch.pitcher_id == this.PitcherId) select pitch; 
        }

        private IEnumerable<Pitch> GamePitchesUpToCurrent(int game_pitch)
        {
            var UpToCurrentPitches = from pitch in AllGamePitches() where pitch.game_pitch_number <= game_pitch select pitch;
            return UpToCurrentPitches;  
        }

    }
}