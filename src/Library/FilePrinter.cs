using System.IO;

namespace Full_GRASP_And_SOLID.Library
{
    
    public class FilePrinter : IPrinter
    {
        public void PrintBuilding(IPrintable filePrintable)
        {
            File.WriteAllText("Building.txt", filePrintable.GetTextToPrint());
        }
    }
}