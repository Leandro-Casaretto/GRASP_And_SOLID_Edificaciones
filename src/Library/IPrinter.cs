using System;
using System.Collections;

namespace Full_GRASP_And_SOLID.Library
{
    
    /// <summary>
    /// Al crear la interfaz IPrinter, lo que logramos es independizarnos de cualquier implementación.
    /// De esta manera, cramos clases que implementen la interfaz cada vez que querramos tener una nueva forma
    /// de impresión. (Patrón utilizado: Polimorfismo)
    /// </summary>
    public interface IPrinter
    {
        void PrintBuilding(IPrintable iprintable);
    }
}