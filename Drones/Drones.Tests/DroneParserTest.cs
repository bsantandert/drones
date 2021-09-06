using Drones.Models;
using Drones.Parsers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Drones.Tests
{
    /// <summary>
    /// Test on Drone Parser
    /// </summary>
    [TestClass]
    public class DroneParserTest
    {
        private DroneParser droneParser;

        public DroneParserTest()
        {
        }

        /// <summary>
        /// Initialize drone parser
        /// </summary>
        [TestInitialize]
        public void Setup()
        {
            droneParser = new DroneParser();
        }

        /// <summary>
        /// Proper data validations
        /// </summary>
        [TestMethod]
        public void Parse()
        {
            string[] data = new string[6] { "Drone 1", "160", "Drone 2", "300", "Drone 3", "400" };
            List<Drone> drones = droneParser.Parse(data);

            Assert.AreEqual(3, drones.Count);

            string[] data2 = new string[8] { "Drone 1", "100", "Drone 2", "150", "Drone 3", "310", "Drone 4", "900" };
            List<Drone> drones2 = droneParser.Parse(data2);
            Assert.AreEqual(4, drones2.Count);
        }

        /// <summary>
        /// Empty list returned because of wrong data
        /// </summary>
        [TestMethod]
        public void ParseWrongData()
        {
            string[] data = new string[5] { "Drone 1", "160", "Drone 2", "300", "Drone 3" };
            List<Drone> drones = droneParser.Parse(data);
            Assert.AreEqual(0, drones.Count);

            string[] data2 = new string[1] { "Drone 1" };
            List<Drone> drones2 = droneParser.Parse(data2);
            Assert.AreEqual(0, drones2.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException), "Drone weight is not a number")]
        public void ParseWrongFormatData()
        {
            string[] data = new string[4] { "Drone 1", "160", "Drone 2", "not a number" };
            droneParser.Parse(data);
        }
    }
}
