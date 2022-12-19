using System;
using System.Collections;
using System.IO;

namespace Full_GRASP_And_SOLID.Library
{
    
    public class FilePrinter : IPrinter
    {
    /// <summary>
    /// Ahora que aplicamos DIP, en vez de pasarle como parámetro un Building, le pasamos como
    /// parámetro un objeto de tipo IPrintable.
    /// </summary>

        public void PrintBuilding(IPrintable filePrintable)
        {
            File.WriteAllText("Building.txt", filePrintable.GetTextToPrint());
        }
    }
}