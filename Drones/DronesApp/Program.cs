using Drones.Contracts;
using Drones.Helpers;
using Drones.Models;
using Drones.Sources;
using DronesApp.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DronesApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Constants.APP_TITLE);
            Console.WriteLine(Constants.INSERT_FILE_PATH_MESSAGE);

            string filePath = Console.ReadLine();

            try
            {
                if (File.Exists(filePath))
                {
                    IDataSource fileSource = new FileSource(filePath);
                    InputData data = fileSource.ReadData();

                    if (data.Drones.Count > 0 && data.Locations.Count > 0)
                    {
                        // some model usage for drones, squads and reseller
                        Reseller onlineReseller = new Reseller("Online Reseller");
                        var resellerSquad = new Squad() { MaxSize = 100 };
                        resellerSquad.AddDrones(data.Drones);

                        var droneTrips = DeliverySolverHelper.GetDeliveryDistribution(data.Drones, data.Locations);
                        DronePrinterHelper.PrintDeliveryResults(data.Drones, droneTrips);
                    }
                    else
                    {
                        Console.WriteLine(Constants.DATA_NOT_FOUND_MESSAGE);
                    }
                }
                else
                {
                    Console.WriteLine(Constants.FILE_NOT_FOUND_MESSAGE);
                }
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
        }
    }
}
