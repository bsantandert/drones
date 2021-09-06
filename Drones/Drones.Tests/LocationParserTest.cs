using Drones.Models;
using Drones.Parsers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Drones.Tests
{
    /// <summary>
    /// Test on Location Parser
    /// </summary>
    [TestClass]
    public class LocationParserTest
    {
        private LocationParser locationParser;

        public LocationParserTest()
        {
        }

        /// <summary>
        /// Initialize location parser
        /// </summary>
        [TestInitialize]
        public void Setup()
        {
            locationParser = new LocationParser();
        }

        /// <summary>
        /// Proper data validations
        /// </summary>
        [TestMethod]
        public void Parse()
        {
            string[] data = new string[2] { "Location 1", "560" };
            Location location = locationParser.Parse(data);
            Assert.AreEqual(data[0], location.Name);
            Assert.AreEqual(Convert.ToDouble(data[1]), location.Weight);

            string[] data2 = new string[2] { "Location 2", "60000" };
            Location location2 = locationParser.Parse(data2);
            Assert.AreEqual(data2[0], location2.Name);
            Assert.AreEqual(Convert.ToDouble(data2[1]), location2.Weight);
        }

        /// <summary>
        /// Null values returned because of wrong data
        /// </summary>
        [TestMethod]
        public void ParseWrongData()
        {
            string[] data = new string[1] { "Location 1" };
            Location location = locationParser.Parse(data);
            Assert.AreEqual(null, location);

            string[] data2 = new string[3] { "Location 2", "60000", "Location 3" };
            Location location2 = locationParser.Parse(data2);
            Assert.AreEqual(null, location2);
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException), "Location weight is not a number")]
        public void ParseWrongFormatData()
        {
            string[] data = new string[2] { "Location 1", "not a number" };
            locationParser.Parse(data);
        }
    }
}
