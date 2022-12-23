using System;
using System.Collections;

namespace Full_GRASP_And_SOLID.Library
{
    /// <summary>
    /// Creando esta interfaz, estamos aplicando el Principio de Segregación de la Interfaz, ya que
    /// esta solo tiene el método que la clase Building necesita, 
    /// el de saber el costo de la producción, ningún otro.
    /// </summary>
    
    public interface ICostable
    {
        double GetProductionCost();
    }
}