using Drones.Contracts;
using Drones.Models;
using Drones.Parsers;
using System;
using System.IO;

namespace Drones.Sources
{
    /// <summary>
    /// File Source builds InputData object from file data
    /// </summary>
    public class FileSource : IDataSource
    {
        public string FilePath { get; set; }
        private DroneParser _droneParser;
        private LocationParser _locationParser;

        public FileSource(string filePath)
        {
            FilePath = filePath;
            _droneParser = new DroneParser();
            _locationParser = new LocationParser();
        }

        /// <summary>
        /// Reads data from filePath and retrieves InputData object
        /// </summary>
        /// <returns></returns>
        public InputData ReadData()
        {
            InputData input = new InputData();
            try
            {
                string[] lines = File.ReadAllLines(this.FilePath);
                for (int i = 0; i < lines.Length; i++)
                {
                    string currentLine = lines[i];
                    string[] values = currentLine.Split(',');

                    // first line has Drone data
                    if (i == 0)
                    {
                        input.Drones = _droneParser.Parse(values);
                    }
                    else
                    {
                        Location locationData = _locationParser.Parse(values);
                        if (locationData != null)
                        {
                            input.Locations.Add(locationData);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // log something here
                throw ex;
            }

            return input;
        }
    }
}
