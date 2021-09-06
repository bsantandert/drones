using Drones.Helpers;
using Drones.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Collections.Generic;

namespace Drones.Tests
{
    /// <summary>
    /// Test on Delivery Solver Helper
    /// </summary>
    [TestClass]
    public class DeliverySolverHelperTest
    {
        /// <summary>
        /// Validate location distribution to drones
        /// </summary>
        [TestMethod]
        public void GetDeliveryDistribution()
        {
            List<Drone> drones = new List<Drone>();
            drones.Add(new Drone("Drone 1", 190));
            drones.Add(new Drone("Drone 2", 120));
            drones.Add(new Drone("Drone 3", 230));

            List<Location> locations = new List<Location>();
            locations.Add(new Location("Location 1", 70));
            locations.Add(new Location("Location 2", 180));
            locations.Add(new Location("Location 3", 40));
            locations.Add(new Location("Location 4", 200));

            var droneTrips = DeliverySolverHelper.GetDeliveryDistribution(drones, locations);
            // drone trips is 3, so each drone will do only 1 trip and all drones will cover all locations
            Assert.AreEqual(3, droneTrips.Count);

            var drone2Trip = droneTrips.Where(dt => dt.GetDrone().MaxWeight == 120).FirstOrDefault();
            // Drone 2 will take location 3 and 1 so count should be 2
            Assert.AreEqual(2, drone2Trip.GetLocationsCount());

            List<Drone> drones2 = new List<Drone>();
            drones2.Add(new Drone("Drone 1", 20));
            drones2.Add(new Drone("Drone 2", 80));
            drones2.Add(new Drone("Drone 3", 250));

            List<Location> locations2 = new List<Location>();
            locations2.Add(new Location("Location 1", 150));
            locations2.Add(new Location("Location 2", 200));
            locations2.Add(new Location("Location 3", 50));

            var droneTrips2 = DeliverySolverHelper.GetDeliveryDistribution(drones2, locations2);
            // only Drone 3 can deliver all locations and it needs 2 trips to complete them
            // first will take location 2, and then will take location 1 and 3
            Assert.AreEqual(2, droneTrips2.Count);
            Assert.AreEqual("Drone 3", droneTrips2[0].GetDrone().Name);
            Assert.AreEqual("Drone 3", droneTrips2[1].GetDrone().Name);
        }
    }
}
