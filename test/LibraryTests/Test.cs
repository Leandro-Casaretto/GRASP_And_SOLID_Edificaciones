using System;
using System.Linq;
using System.Collections;
using NUnit.Framework;
using Full_GRASP_And_SOLID.Library;

namespace Tests
{
    public class Test
    {

        [SetUp]
        public void Setup()
        {
        }

        private static ArrayList supplyCatalog = new ArrayList();
        private static ArrayList toolCatalog = new ArrayList();
        
        private static void AddProductToCatalog(string description, double unitCost)
        {
            supplyCatalog.Add(new Supply(description, unitCost));
        }

        private static void AddEquipmentToCatalog(string description, double hourlyCost)
        {
            toolCatalog.Add(new Tool(description, hourlyCost));
        }
        private static Supply GetProduct(string description)
        {
            var query = from Supply product in supplyCatalog where product.Description == description select product;
            return query.FirstOrDefault();
        }

        private static Tool GetEquipment(string description)
        {
            var query = from Tool equipment in toolCatalog where equipment.Description == description select equipment;
            return query.FirstOrDefault();
        }
        
        private static void PopulateCatalogs()
        {
            AddProductToCatalog("Cemento", 100);
            AddProductToCatalog("Arena", 200);
            AddProductToCatalog("Tabla", 300);

            AddEquipmentToCatalog("Hormigonera", 1000);
            AddEquipmentToCatalog("Martillo", 2000);
        }

        /// <summary>
        /// Realizamos el Test del método creado GetProductionCost
        /// </summary>

        [Test]
        public void ProductionCostTest()
        {   
            /// <summary>
            /// Actualizamos el Test integrando la interfaz que creamos (IPrinter)
            /// </summary>

            IPrinter printer;
            printer = new ConsolePrinter();

            Building tower = new Building("Tower");
            PopulateCatalogs();

            /// <summary>
            /// Instanciamos y agregamos las tasks (testeamos patrón implementación de Creator)
            /// </summary>

            tower.AddTask(GetProduct("Cemento"), 100, GetEquipment("Hormigonera"), 120);
            tower.AddTask(GetProduct("Arena"), 200, GetEquipment("Hormigonera"), 120);
            tower.AddTask(GetProduct("Tabla"), 50, GetEquipment("Martillo"), 15);
            
            Assert.AreEqual(tower.GetProductionCost(), 335000);
        }

        /// <summary>
        /// Realizamos el Test de la descripción del edificio
        /// </summary>

        [Test]
        public void DescriptionTest()
        {
            /// <summary>
            /// Actualizamos el Test integrando la interfaz que creamos (IPrinter)
            /// </summary>

            IPrinter printer;
            printer = new ConsolePrinter();

            Building tower = new Building("Tower");
            PopulateCatalogs();

            /// <summary>
            /// Instanciamos y agregamos las tasks (testeamos patrón implementación de Creator)
            /// </summary>

            tower.AddTask(GetProduct("Cemento"), 100, GetEquipment("Hormigonera"), 120);
            tower.AddTask(GetProduct("Arena"), 200, GetEquipment("Hormigonera"), 120);
            tower.AddTask(GetProduct("Tabla"), 50, GetEquipment("Martillo"), 15);

            Assert.AreEqual(tower.Description,"Tower");
                
        }
        
        /// <summary>
        /// Realizamos el Test de las Tasks
        /// </summary>

        [Test]
        public void TaskTest()
        {
            /// <summary>
            /// Actualizamos el Test integrando la interfaz que creamos (IPrinter)
            /// </summary>

            IPrinter printer;
            printer = new ConsolePrinter();

            Building tower = new Building("Tower");
            PopulateCatalogs();

            /// <summary>
            /// Instanciamos las tasks
            /// </summary>

            Task task1 = new Task(GetProduct("Cemento"), 100, GetEquipment("Hormigonera"), 120);
            Task task2 = new Task(GetProduct("Arena"), 200, GetEquipment("Hormigonera"), 120);
            Task task3 = new Task(GetProduct("Tabla"), 50, GetEquipment("Martillo"), 15);
            
            /// <summary>
            /// Instanciamos y agregamos las tasks (testeamos patrón implementación de Creator)
            /// </summary>

            tower.AddTask(GetProduct("Cemento"), 100, GetEquipment("Hormigonera"), 120);
            tower.AddTask(GetProduct("Arena"), 200, GetEquipment("Hormigonera"), 120);
            tower.AddTask(GetProduct("Tabla"), 50, GetEquipment("Martillo"), 15);
            
            Assert.AreEqual(task1.Quantity, 100);
            Assert.AreEqual(task1.Time, 120);
            
        }

        /// <summary>
        /// Realizamos el Test del supply final (null)
        /// </summary>

        [Test]
        public void FinalSupply()
        {
            /// <summary>
            /// Actualizamos el Test integrando la interfaz que creamos (IPrinter)
            /// </summary>

            IPrinter printer;
            printer = new ConsolePrinter();

            Building tower = new Building("Tower");
            PopulateCatalogs();

            /// <summary>
            /// Instanciamos y agregamos las tasks (testeamos patrón implementación de Creator)
            /// </summary>

            tower.AddTask(GetProduct("Cemento"), 100, GetEquipment("Hormigonera"), 120);
            tower.AddTask(GetProduct("Arena"), 200, GetEquipment("Hormigonera"), 120);
            tower.AddTask(GetProduct("Tabla"), 50, GetEquipment("Martillo"), 15);
            
            Assert.IsNull(tower.FinalSupply);
        }
        
        /// <summary>
        /// Testeamos la excepcion Empty (la cual intervendrá cuando no se encuentren tasks.)
        /// </summary>

        [Test]
        public void ExceptionTest()
        {
            /// <summary>
            /// Actualizamos el Test integrando la interfaz que creamos (IPrinter)
            /// </summary>

            IPrinter printer;
            printer = new ConsolePrinter();

            Building tower = new Building("");
            PopulateCatalogs();
            
            try
            {
                printer.PrintBuilding(tower);
                Assert.Fail();
            }
            
            catch(Empty)
            {
                Assert.Pass();
            }
        }      

    }    
}
