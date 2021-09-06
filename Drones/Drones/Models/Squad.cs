using System;
using System.Collections.Generic;

namespace Drones.Models
{
    /// <summary>
    /// Squad Class
    /// </summary>
    public class Squad
    {
        public Guid Id { get; set; }
        public int MaxSize { get; set; }
        private List<Drone> Drones;

        public Squad()
        {
            Id = Guid.Empty;
            Drones = new List<Drone>();
        }

        /// <summary>
        /// Add drone to list if not in the limit
        /// </summary>
        /// <param name="drone">Drone to add</param>
        /// <returns>true if added, false if not</returns>
        public bool AddDrone(Drone drone)
        {
            if (this.Drones.Count < this.MaxSize)
            {
                this.Drones.Add(drone);
                return true;
            }
            return false;
        }

        /// <summary>
        /// Add List of drones validating the limit
        /// </summary>
        /// <param name="drone"></param>
        /// <returns></returns>
        public bool AddDrones(List<Drone> drones)
        {
            if ((this.Drones.Count + drones.Count) < this.MaxSize)
            {
                this.Drones.AddRange(drones);
                return true;
            }
            return false;
        }

        /// <summary>
        /// Get list of drones
        /// </summary>
        /// <returns></returns>
        public List<Drone> GetDrones()
        {
            return this.Drones;
        }
    }
}
