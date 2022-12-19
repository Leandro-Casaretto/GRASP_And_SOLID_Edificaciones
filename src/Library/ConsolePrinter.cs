using System.Collections;
using System;

namespace Full_GRASP_And_SOLID.Library
{
    
    public class ConsolePrinter : IPrinter
    {
        /// <summary>
        /// Ahora que aplicamos DIP, en vez de pasarle como parámetro un Building, le pasamos como
        /// parámetro un objeto de tipo IPrintable.
        /// </summary>
        public void PrintBuilding(IPrintable textPrintable)
        {
            Console.WriteLine(textPrintable.GetTextToPrint());
        }
    }
}