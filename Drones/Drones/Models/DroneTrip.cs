using System.Collections.Generic;

namespace Drones.Models
{
    /// <summary>
    /// Drone Trip Class, it helps to keep track of trips by drone
    /// </summary>
    public class DroneTrip
    {
        private Drone _drone;
        private List<Location> _locations;

        public DroneTrip()
        {
            _locations = new List<Location>();
        }

        public DroneTrip (Drone drone)
        {
            _drone = drone;
            _locations = new List<Location>();
        }

        /// <summary>
        /// Returns current drone;
        /// </summary>
        /// <returns></returns>
        public Drone GetDrone()
        {
            return _drone;
        }

        /// <summary>
        /// Adds a location to the list of locations, validates if there is available space
        /// </summary>
        /// <param name="location"></param>
        /// <returns></returns>
        public bool AddLocation(Location location)
        {
            if (location.Weight <= this.GetRemainingSpace())
            {
                _locations.Add(location);
                return true;
            }
            return false;
        }

        /// <summary>
        /// Returns locations count value
        /// </summary>
        /// <returns></returns>
        public int GetLocationsCount()
        {
            return _locations.Count;
        }

        /// <summary>
        /// Returns all locations
        /// </summary>
        /// <returns></returns>
        public List<Location> GetLocations()
        {
            return _locations;
        }

        /// <summary>
        /// Return total weight of locations
        /// </summary>
        /// <returns></returns>
        public double GetTotalTripWeight()
        {
            double totalWeight = 0;
            foreach (Location currentLocation in _locations)
            {
                totalWeight += currentLocation.Weight;
            }

            return totalWeight;
        }

        /// <summary>
        /// Returns remaining drone available space based on the locations weights
        /// </summary>
        /// <returns></returns>
        public double GetRemainingSpace()
        {
            return _drone.MaxWeight - this.GetTotalTripWeight();
        }
    }
}
