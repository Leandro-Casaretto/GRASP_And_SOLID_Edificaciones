using System;

namespace Full_GRASP_And_SOLID.Library
{
    public class Printer
    {

        public void PrintBuilding(Building building)
        {
            Console.WriteLine($"El costo es: ${building.GetProductionCost()}");
        }
    }
}