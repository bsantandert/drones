using System.Collections.Generic;

namespace Drones.Models
{
    /// <summary>
    /// Trip Class
    /// </summary>
    public class Trip
    {
        public List<Location> Locations { get; set; }

        public Trip()
        {
            this.Locations = new List<Location>();
        }

        /// <summary>
        /// Get total trip weight (sum of all location weights).
        /// </summary>
        public double GetTotalTripWeight()
        {
            double totalWeight = 0;
            foreach (Location currentLocation in Locations)
            {
                totalWeight += currentLocation.Weight;
            }

            return totalWeight;
        }
    }
}
