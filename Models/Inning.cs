using System.Collections.Generic; 

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

        public string FormatName()
        {
            return this.Top ? $"Top {this.Number}" : $"Bottom {this.Number}";
        }

        public string FormatValue()
        {
            return $"{this.Number}, {this.Top}";        
        }
    }
}