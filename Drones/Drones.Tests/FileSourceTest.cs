using Drones.Models;
using Drones.Sources;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Drones.Tests
{
    /// <summary>
    /// Test on File Source
    /// </summary>
    [TestClass]
    public class FileSourceTest
    {
        private FileSource source1;
        private FileSource source2;
        private FileSource source3;
        private string inputFilePath1;
        private string inputFilePath2;
        private string inputFilePath3;

        public FileSourceTest()
        {
        }

        /// <summary>
        /// Initialize files configuration
        /// </summary>
        [TestInitialize]
        public void Setup()
        {
            inputFilePath1 = @"TestFiles/file1.txt";
            source1 = new FileSource(inputFilePath1);
            inputFilePath2 = @"TestFiles/file2.txt";
            source2 = new FileSource(inputFilePath2);
            inputFilePath3 = @"TestFiles/file3.txt";
            source3 = new FileSource(inputFilePath3);
        }

        [TestMethod]
        public void ReadProperData()
        {
            InputData data = source1.ReadData();
            Assert.AreEqual(4, data.Drones.Count);
            Assert.AreEqual(5, data.Locations.Count);

            InputData data2 = source2.ReadData();
            Assert.AreEqual(5, data2.Drones.Count);
            Assert.AreEqual(7, data2.Locations.Count);
        }

        [TestMethod]
        public void ReadWrongData()
        {
            InputData data = source3.ReadData();
            // Data missing returns empty
            Assert.AreEqual(0, data.Drones.Count);
            // Only 4 from 7 have proper data
            Assert.AreEqual(4, data.Locations.Count);
        }
    }
}
