using System;

namespace Drones.Models
{
    /// <summary>
    /// Location Class
    /// </summary>
    public class Location
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public double Weight { get; set; }

        public Location() { }

        public Location(string name, double weight)
        {
            Id = Guid.NewGuid();
            Name = name;
            Weight = weight;
        }

        public override string ToString()
        {
            return $"{Name}";
        }
    }
}
