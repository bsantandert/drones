using Drones.Models;
using System.Collections.Generic;
using System.Linq;

namespace Drones.Managers
{
    /// <summary>
    /// Manages the squad trip availability
    /// </summary>
    public class SquadManager
    {
        public List<List<DroneTrip>> SquadTrips { get; set; }

        public SquadManager()
        {
            this.SquadTrips = new List<List<DroneTrip>>();
        }

        /// <summary>
        /// Generates a list of list of drone trips with only drones info
        /// </summary>
        /// <param name="drones">drones available</param>
        /// <param name="maxTrips">max possible trips</param>
        public void GenerateMaxSquadTrips(List<Drone> drones, int maxTrips)
        {
            for (int i = 0; i < maxTrips; i++)
            {
                var droneTrips = drones
                    .OrderByDescending(d => d.MaxWeight)
                    .Select(d => new DroneTrip(d))
                    .ToList();
                this.SquadTrips.Add(droneTrips);
            }
        }

        /// <summary>
        /// Assign location to next available drone trip
        /// </summary>
        /// <param name="location"></param>
        public void AssignLocationToNextAvailableDroneTrip(Location location)
        {
            bool assigned = false;

            foreach (var droneTrips in this.SquadTrips)
            {
                foreach (var currentDroneTrip in droneTrips)
                {
                    if (currentDroneTrip.GetRemainingSpace() >= location.Weight)
                    {
                        currentDroneTrip.AddLocation(location);
                        assigned = true;
                        break;
                    }
                }
                if (assigned)
                {
                    break;
                }
            }
        }

        /// <summary>
        /// Get drone trips with actual locations, empty trips are ignored
        /// </summary>
        /// <returns>drone trips with locations</returns>
        public List<DroneTrip> GetDroneTrips()
        {
            List<DroneTrip> trips = new List<DroneTrip>();
            foreach (List<DroneTrip> droneTrips in this.SquadTrips)
            {
                trips.AddRange(droneTrips.Where(dt => dt.GetLocationsCount() > 0));
            }
            return trips;
        }

    }
}
