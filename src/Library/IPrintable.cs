using System;

namespace Full_GRASP_And_SOLID.Library
{
    /// <summary>
    /// Para poder aplicar el principio de inversión de dependencias, 
    /// lo que hacemos es definir la abstracción de la que queremos que ConsolePrinter, FilePrinter
    /// y Building dependan. Para esto creamos la interfaz IPrintable cob el método
    /// GetTextToPrint()
    /// </summary>
    public interface IPrintable
    {
        string GetTextToPrint();
    }
}