using System; 
using System.Collections.Generic; 

namespace pitch_app.Models 
{
    public class Batter : Player
    {
        public int BatterId { get; set; }

        public Batter(string name, int batter_id)
        {
            Name = name;
            BatterId = batter_id; 
        }

    }
}