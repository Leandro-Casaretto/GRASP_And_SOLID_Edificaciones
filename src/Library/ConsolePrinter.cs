using System;

namespace Full_GRASP_And_SOLID.Library
{
    
    public class ConsolePrinter : IPrinter
    {
        public void PrintBuilding(IPrintable textPrintable)
        {
            Console.WriteLine(textPrintable.GetTextToPrint());
        }
    }
}