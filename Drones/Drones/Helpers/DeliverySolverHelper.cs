using Drones.Managers;
using Drones.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Drones.Helpers
{
    public static class DeliverySolverHelper
    {
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
