using System.IO;

namespace Full_GRASP_And_SOLID.Library
{
    /// <summary>
    /// Independizamos el poder imprimir en archivos, creando la clase FilePrinter, que hereda de la interfaz
    /// IPrinter (Patrón utilizado: Polimorfismo).
    /// </summary>
    public class FilePrinter : IPrinter
    {
        public void PrintBuilding(Building building)
        {
            File.WriteAllText("Building.txt", building.GetTextToPrint());
        }
    }
}