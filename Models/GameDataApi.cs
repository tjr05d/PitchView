using System.Collections.Generic; 
using System.Linq; 
using Newtonsoft.Json; 

namespace pitch_app.Models 
{
    public class GameDataApi
    {
        public string Data {get; set;}
        public GameDataApi(){
            Data = System.IO.File.ReadAllText(@"App_Data/interviewgame.json");
        }

        public List<Pitch> AllPitches(){
            return JsonConvert.DeserializeObject<List<Pitch>>(this.Data);
        }

        public IEnumerable<Pitch> InningPitches(Inning inning)
        {
            var PitchesWithCount = SetPitcherPitchCount();
            return from pitch in PitchesWithCount where (pitch.inning == inning.Number) && (pitch.top_of_inning == inning.Top) select pitch;
        }

        public Inning GetPopulatedInning(int number, bool top)
        {
            Inning inning = new Inning(number, top);
            int currentBatter = 0; 
            foreach(Pitch pitch in InningPitches(inning))
            {
                if(currentBatter != pitch.batter_id)
                {
                    //set the current batter to new batter
                    currentBatter = pitch.batter_id;
                    //query for all of the picthes in the at bat
                    var PitchesInAtBat = (from inningPitch in InningPitches(inning) where inningPitch.batter_id == currentBatter select inningPitch);  
                    //adds pitch number for the atBat
                    int ab_counter = 1;
                    foreach (Pitch ab_pitch in PitchesInAtBat)
                    {
                        ab_pitch.at_bat_pitch = ab_counter;
                        ab_counter ++; 
                    }
                    Pitcher c_pitcher = new Pitcher(pitch.pitcher, pitch.pitcher_id);
                    Batter c_batter = new Batter(pitch.batter, pitch.batter_id); 
                    //instantiates new at bat
                    AtBat newAB = new AtBat(c_pitcher, c_batter, PitchesInAtBat.ToList());
                    //Add the at bat to the inning
                    inning.AtBats.Add(newAB);  
                }
            }
            return inning;
        } 


        private List<Pitch> SetPitcherPitchCount()
        {
            var GamePitches = AllPitches(); 
            Dictionary<int,int> game_pitcher = new Dictionary<int, int>(); 
            foreach (Pitch game_pitch in GamePitches){
                if(game_pitcher.ContainsKey(game_pitch.pitcher_id)) 
                {
                    game_pitcher[game_pitch.pitcher_id] ++;
                } 
                else
                {
                     game_pitcher[game_pitch.pitcher_id] = 1; 
                }
                game_pitch.pitcher_pitch_count = game_pitcher[game_pitch.pitcher_id];      
            }
            return GamePitches; 
        }
    }
} 