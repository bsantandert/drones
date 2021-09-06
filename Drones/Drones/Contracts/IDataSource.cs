using Drones.Models;

namespace Drones.Contracts
{
    /// <summary>
    /// Interface for different data sources
    /// </summary>
    public interface IDataSource
    {
        InputData ReadData();
    }
}
