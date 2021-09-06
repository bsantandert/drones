using System;
using System.Collections.Generic;

namespace Drones.Models
{
    /// <summary>
    /// Reseller class
    /// </summary>
    public class Reseller
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<Squad> Squads { get; set; }

        public Reseller(string name)
        {
            Id = Guid.NewGuid();
            Name = name;
        }
    }
}
