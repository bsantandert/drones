using System.Collections.Generic;

namespace Drones.Models
{
    /// <summary>
    /// Input Data Class
    /// </summary>
    public class InputData
    {
        public List<Drone> Drones { get; set; }
        public List<Location> Locations { get; set; }

        public InputData()
        {
            Drones = new List<Drone>();
            Locations = new List<Location>();
        }
    }
}
