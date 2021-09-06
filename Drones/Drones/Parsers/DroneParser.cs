using Drones.Models;
using System;
using System.Collections.Generic;

namespace Drones.Parsers
{
    /// <summary>
    /// Parser Class to Build Drone object from strings
    /// </summary>
    public class DroneParser
    {
        /// <summary>
        /// Build and return list of drones from string array
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public List<Drone> Parse(string[] data)
        {
            List<Drone> drones = new List<Drone>();

            // If data length is not major than 1 or is not in pairs line is not well formed, do not parse data
            // Note: Consider reading it until error
            if (data.Length > 1 && data.Length % 2 == 0)
            {
                for (int i = 0; i < data.Length; i += 2)
                {
                    drones.Add(new Drone(data[i], Convert.ToDouble(data[i + 1])));
                }
            }

            return drones;
        }
    }
}
