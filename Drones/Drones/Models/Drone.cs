using System;

namespace Drones.Models
{
    /// <summary>
    /// Drone Class
    /// </summary>
    public class Drone
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public double MaxWeight { get; set; }

        /// <summary>
        /// Any constant value for refuel
        /// </summary>
        public const double REFUEL = 500;
        /// <summary>
        /// Any constant value for restock
        /// </summary>
        public const double RESTOCK = 500;

        public Drone() { }

        public Drone(string name, double maxWeight)
        {
            Id = Guid.NewGuid();
            Name = name;
            MaxWeight = maxWeight;
        }

        public override string ToString()
        {
            return $"{Name}";
        }
    }
}
