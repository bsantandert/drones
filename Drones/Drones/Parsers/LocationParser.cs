using Drones.Models;
using System;

namespace Drones.Parsers
{
    /// <summary>
    /// Parser Class to Build Location object from strings
    /// </summary>
    public class LocationParser
    {
        /// <summary>
        /// Build and return location object from string array
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public Location Parse(string[] data)
        {
            if (data.Length == 2)
            {
                return new Location(data[0], Convert.ToDouble(data[1]));
            }

            return null;
        }
    }
}
