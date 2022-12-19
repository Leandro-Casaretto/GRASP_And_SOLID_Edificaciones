using System;
using System.Collections;

namespace Full_GRASP_And_SOLID.Library
{
    /// <summary>
    /// La siguiente clase es la encargada de imprimir en consola. Al crear esta clase, le quitamos la
    /// responsabilidad a Building de hacerlo, lo cual evita tener que cambiar esa clase cada vez
    /// que querramos hacer un cambio en la manera de imprimir. (Principio utilizado: SRP)
    /// </summary>
    public class Printer
    {
        public void PrintBuilding(Building building)
        {
            Console.WriteLine(building.GetTextToPrint());
        }
    }
}