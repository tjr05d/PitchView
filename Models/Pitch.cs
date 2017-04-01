using System; 
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic; 

namespace pitch_app.Models 
{
    public class Pitch
    {
        public string Type { get; }
        public float Speed { get; }
        public Pitch(string data = null)
        {
            Type = GetType(data);
            Speed = GetSpeed(data); 
        }

        private string GetType(string data)
        {
            return "Four Seam FB"; 
        }

        private float GetSpeed(string data)
        {
            return 87.94F; 
        }

    }
}