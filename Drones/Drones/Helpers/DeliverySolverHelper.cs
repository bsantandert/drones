using Drones.Managers;
using Drones.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Drones.Helpers
{
    /// <summary>
    /// Helper that uses other components to return Delivery Distribution
    /// </summary>
    public static class DeliverySolverHelper
    {
        /// <summary>
        /// Order locations by descending weight to improve algorithm
        /// </summary>
        /// <param name="drones">drones available</param>
        /// <param name="locations">locations to deliver</param>
        /// <returns></returns>
        public static List<DroneTrip> GetDeliveryDistribution(List<Drone> drones, List<Location> locations)
        {
            // Order items by weight (location weights)
            List<Location> orderedWeightLocations = locations.OrderByDescending(l => l.Weight).ToList();

            double maxLocationWeight = locations.Max(l => l.Weight);
            double maxDroneWeight = drones.Max(d => d.MaxWeight);

            if (maxDroneWeight >= maxLocationWeight)
            {
                SquadManager squadManager = new SquadManager();
                squadManager.GenerateMaxSquadTrips(drones, locations.Count);

                // Assign all locations to drone trips
                while (orderedWeightLocations.Count > 0)
                {
                    squadManager.AssignLocationToNextAvailableDroneTrip(orderedWeightLocations[0]);
                    orderedWeightLocations.RemoveAt(0);
                }

                return squadManager.GetDroneTrips();
            }
            else
            {
                // Location exceeds drones capacity
                throw new Exception("Location weight exceeds all drones capacity");
            }
        }
    }
}
