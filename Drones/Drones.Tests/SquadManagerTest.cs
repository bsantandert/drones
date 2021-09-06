using Drones.Managers;
using Drones.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Drones.Tests
{
    [TestClass]
    public class SquadManagerTest
    {
        private SquadManager squadManager;

        public SquadManagerTest()
        {
        }

        /// <summary>
        /// Initialize location parser
        /// </summary>
        [TestInitialize]
        public void Setup()
        {
            squadManager = new SquadManager();
        }

        /// <summary>
        /// Validate list of drone trips create
        /// </summary>
        [TestMethod]
        public void GenerateMaxSquadTrips()
        {
            List<Drone> drones = new List<Drone>();
            drones.Add(new Drone("Drone 1", 150));
            drones.Add(new Drone("Drone 2", 220));
            drones.Add(new Drone("Drone 3", 100));
            drones.Add(new Drone("Drone 4", 50));

            squadManager.GenerateMaxSquadTrips(drones, 10);
            Assert.AreEqual(10, squadManager.SquadTrips.Count);
            // Drone trips are assigned and order by weight
            Assert.AreEqual("Drone 2", squadManager.SquadTrips[0][0].GetDrone().Name);
            Assert.AreEqual("Drone 1", squadManager.SquadTrips[9][1].GetDrone().Name);

            squadManager.GenerateMaxSquadTrips(drones, 5);
            Assert.AreEqual(5, squadManager.SquadTrips.Count);

            Assert.AreEqual("Drone 3", squadManager.SquadTrips[0][2].GetDrone().Name);
            Assert.AreEqual("Drone 4", squadManager.SquadTrips[1][3].GetDrone().Name);
        }

        /// <summary>
        /// Locations should be assigned to available spaces
        /// </summary>
        [TestMethod]
        public void AssignLocationToNextAvailableDroneTrip()
        {
            List<Drone> drones = new List<Drone>();
            drones.Add(new Drone("Drone 1", 150));
            drones.Add(new Drone("Drone 2", 200));
            drones.Add(new Drone("Drone 3", 80));

            squadManager.GenerateMaxSquadTrips(drones, 4);
            squadManager.AssignLocationToNextAvailableDroneTrip(new Location("Location 1", 190));

            // 190 location is assigned to Drone 2 since it is the only drone with enough capacity
            Assert.AreEqual("Drone 2", squadManager.SquadTrips[0][0].GetDrone().Name);
            // remaining space must be 10 only on this trip
            Assert.AreEqual(10, squadManager.SquadTrips[0][0].GetRemainingSpace());
            // remaining space in other trip must be 200 still since it is empty
            Assert.AreEqual(200, squadManager.SquadTrips[1][0].GetRemainingSpace());

            // 20 does not fit in Drone 2 since available space is only 10
            // It is assigned to Drone 1 in array position 1
            squadManager.AssignLocationToNextAvailableDroneTrip(new Location("Location 2", 20));
            Assert.AreEqual("Drone 1", squadManager.SquadTrips[0][1].GetDrone().Name);
            // remaining space must be 130 since it went to the Drone 1 150 - 20
            Assert.AreEqual(130, squadManager.SquadTrips[0][1].GetRemainingSpace());

            // 10 is good enough for Drone 2 to be complete so we will find it in position 0
            squadManager.AssignLocationToNextAvailableDroneTrip(new Location("Location 3", 10));
            Assert.AreEqual("Drone 2", squadManager.SquadTrips[0][0].GetDrone().Name);
            // remaining space is 0 since 10 fits in Drone 2 and uses all the space
            Assert.AreEqual(0, squadManager.SquadTrips[0][0].GetRemainingSpace());

            // 195 only can fit in Drone 2, but since it is full it will take another trip 
            // trip position will be now 1
            squadManager.AssignLocationToNextAvailableDroneTrip(new Location("Location 4", 195));
            Assert.AreEqual("Drone 2", squadManager.SquadTrips[1][0].GetDrone().Name);
            // remaining space in Drone 2 for second trip is 5
            Assert.AreEqual(5, squadManager.SquadTrips[1][0].GetRemainingSpace());

            // 80 still fits in Drone 1 of first trip since there is enough space
            squadManager.AssignLocationToNextAvailableDroneTrip(new Location("Location 5", 80));
            Assert.AreEqual("Drone 1", squadManager.SquadTrips[0][1].GetDrone().Name);
            // remaining space in Drone 2 for first trip is 50 since first location has 20 and last one is 80
            Assert.AreEqual(50, squadManager.SquadTrips[0][1].GetRemainingSpace());
        }
    }
}
