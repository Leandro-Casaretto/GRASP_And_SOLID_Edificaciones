using System.Collections;
using System;

namespace Full_GRASP_And_SOLID.Library
{
    /// <summary>
    /// Creamos la excepción que intervendrá cuando no se encuentren tasks
    /// </summary>
    public class Empty : Exception
    {
        public Empty (string message) : base (message)
        {
            
        }
    }

}