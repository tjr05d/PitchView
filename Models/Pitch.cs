using System; 
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic; 

namespace pitch_app.Models 
{
    public class Pitch
    {
        public int game_pitch_number {get; set;}
		public int batter_id {get; set;}
		public string batter {get; set;}
		public int pitcher_id {get; set;}
		public string pitcher {get; set;}
		public int inning {get; set;}
		public bool top_of_inning {get; set;}
		public string pitch_result {get; set;}
		public string event_result {get; set;}
		public string play_by_play {get; set;}
		public int balls_before {get; set;}
		public int strikes_before {get; set;}
		public int outs_before {get; set;}
		public string pitch_type_name {get; set;}
		public float release_speed {get; set;}
		public string video_url {get; set;}
        public int at_bat_pitch {get; set; }
		public int pitcher_pitch_count {get; set; }

    }
}