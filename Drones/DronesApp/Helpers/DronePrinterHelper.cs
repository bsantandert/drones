using Drones.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DronesApp.Helpers
{
    /// <summary>
    /// Drone Printer Helper
    /// </summary>
    public static class DronePrinterHelper
    {
        /// <summary>
        /// Shows results in console
        /// </summary>
        /// <param name="drones">Drones to print trips</param>
        /// <param name="droneTrips">Drone trip source</param>
        public static void PrintDeliveryResults(List<Drone> drones, List<DroneTrip> droneTrips)
        {
            foreach (var currentDrone in drones)
            {
                var currentDroneTrips =  droneTrips.Where(d => d.GetDrone().Id == currentDrone.Id).ToList();
                if (currentDroneTrips.Count > 0)
                {
                    Console.WriteLine(currentDrone.ToString());

                    for (int i = 0; i < currentDroneTrips.Count; i++)
                    {
                        Console.WriteLine($"Trip #{i+1}");
                        var currentDroneTripLocations = currentDroneTrips[i].GetLocations().Select(l => l.ToString()).ToArray();
                        string joinedLocationString = string.Join(",", currentDroneTripLocations);
                        Console.WriteLine(joinedLocationString);
                    }
                    Console.WriteLine();
                }
            }
        }
    }
}
