//-------------------------------------------------------------------------
// <copyright file="Recipe.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
//-------------------------------------------------------------------------

using System;
using System.Collections;

namespace Full_GRASP_And_SOLID.Library
{
    public class Building
    {
        private ArrayList tasks = new ArrayList();

        /// <summary>
        /// Devolvemos las tasks
        /// </summary>
        public ArrayList getTasks()
        {
            return tasks;
        }
        public double FinalCost { get; set; }

        public Supply FinalSupply { get; set; }

        public Building(string name)
        {
            this.Description = name;
        }

        public string Description { get; set; }

        public void AddTask(Task task)
        {
            this.tasks.Add(task);
        }

        public void RemoveTask(Task task)
        {
            this.tasks.Remove(task);
        }

        /// <summary>
        /// Creamos método GetProductionCost
        /// Al ser Building la clase experta en información, le asignamos la responsabilidad de
        /// calcular el costo (Patrón Expert)
        /// </summary>
        public double GetProductionCost()
        {
            double materialCost = 0;   /// Costo de materiales
            double toolCost = 0;       /// Costo de herramientas
            
            foreach (Task task in this.tasks)
            {
                materialCost += task.Material.UnitCost * task.Quantity;
                toolCost += task.Equipment.HourlyCost * task.Time;
            }
            double totalCost = materialCost + toolCost;

            if (tasks.Count == 0)
            {
                throw new Empty("ERROR. NO EXSISTEN TAREAS");
            }
            
            /// <summary>
            /// -------------EN CASO DE QUE SEA CON LA OTRA HORA----------------
            /// double totalCost = task.Material.UnitCost * task.Quantity / 1000 
            /// + (task.Time/3600*(task.Equipment.HourlyCost));
            /// </summary>
            
            return totalCost;
        }

    }
}