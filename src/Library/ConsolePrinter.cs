using System;

namespace Full_GRASP_And_SOLID.Library
{
    /// <summary>
    /// Independizamos el poder imprimir en consola, creando la clase ConsolePrinter, 
    /// que hereda de la interfaz IPrinter. 
    /// (Patrón utilizado: Polimorfismo)
    /// </summary>
    public class ConsolePrinter : IPrinter
    {
        public void PrintBuilding(Building building)
        {
            Console.WriteLine(building.GetTextToPrint());
        }
    }
}