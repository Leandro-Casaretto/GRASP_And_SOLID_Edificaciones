# PII Full GRASP and SOLID - Edificaciones

![](./docs/UML.png)

## Desafío 1

➡️ Agregar la responsabilidad de calcular el costo total de producir un edificio:

```
double GetProductionCost()
```

El calculo de costo total es el siguiente:

Costo materiales = Sumatoria de costo unitario de los materiales,

Costo herramientas = Sumatoria de tiempo de uso x costo/hora del equipo para todos los pasos de la obra,

Costo total = costo materiales + costo herramientas

➡️ ¿Qué patrón o principio usan para asignar esta responsabilidad? Escriban la respuesta en comentarios en el código

➡️ Agregar al final de la impresión de la edificación el costo total de producción que se obtiene usando el método recién agregado.

## Desafío 2
Para imprimir la información de un edificio, se necesita información del edificio pero también se necesita saber cómo y dónde imprimir.

➡️ Crear una clase ConsolePrinter para imprimir la información de los edificios en la consola en lugar que los edificios se impriman ellos mismos.

➡️ ¿Qué patrones o principios usan para determinar cómo implementar este cambio? Escriban la respuesta en comentarios en el código.

## Desafío 3

 ➡️ En una nueva branch llamada "Polimorfismo", modifiquen el código para evitar preguntar por el destino de la impresión en la clase AllInOnePrinter al imprimir en diferentes destinos -archivo o consola-.

➡️ ¿Qué patrón o principio usan para asignar esta responsabilidad? Escriban la respuesta en comentarios en el código. 

➡️ Crear un diagrama UML con el modelo actual.

## Desafío 4

➡️  En una nueva branch llamada "Creator", modifiquen el código para aplicar el patron Creator donde sea posible.

## Desafío 5

La clases que implementan IPrinter, como ConsolePrinter, dependen de la clase Building: un mensaje string GetTextToPrint() es enviado a una instancia de Building en el método void PrintBuilding(Building).

➡️ En una nueva branch llamada "DIP", apliquen el principio de inversión de dependencia para que la clase ConsolePrinter no dependa de la clase Building. Modifiquen el diagrama UML para incorporar las nuevas abstracciones.

# Fundamentación de patrones y principios

### EXPERT

En el Desafío 1 se pudo ver claramente el uso del patrón Expert, particularmente en la clase Building, en donde se le asigno la responsabilidad de calcular el costo de la producción. Esto se realizó ya que es la clase experta en esta información.
```
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
            return totalCost;
        }
```
### SRP
Por otro lado, el principio de resposabilidad única se vió reflejado tanto en la clase Building como en la nueva que creamos, Printer. En la clase Building se quitó el método para imprimir en consola
```
PrintBuilding()
```
En consecuencia, se le asignó esta responsabilidad a la nueva clase Printer. Esto nos permité (de ser necesario) cambiar el método y su funcionamiento desde esa misma clase y no teniendo que cambiar siempre la clase Building.
```
public class Printer
    {
        public void PrintBuilding (Building building)
        {
            Console.WriteLine($"Edificio: {building.Description}");
            foreach (Task task in building.getTasks())
            {
                Console.WriteLine($"{task.Quantity} de '{task.Material.Description}' " +
                    $"usando '{task.Equipment.Description}' durante {task.Time}");
            }
            Console.WriteLine($"El costo es de: ${building.GetProductionCost()}");
        }
    }
```
### CREATOR

El patrón Creator lo empleamos en el método AddTask, dentro de la clase Building. Nuestro objetivo era modificar este método, para así lograr que la clase Building tenga el control de todas las Tasks, es decir, le agregamos la responsabilidad a la clase de agregarlas, evitando que se le pasen por afuera.
Aplicando este patrón, nos aseguramos de que cuando se quieran agregar tasks al building, sea este también el mismo que las crea. A continuación, cómo quedó el método.
```
public void AddTask(Supply material, double quantity, Tool equipment, int time)
        {
            Task task = new Task(material, quantity, equipment, time);
            this.tasks.Add(task);
        }
```
Y su respectiva implementación en Program:
```
Building tower = new Building("Tower");

tower.AddTask(GetProduct("Cemento"), 100, GetEquipment("Hormigonera"), 120);
tower.AddTask(GetProduct("Arena"), 200, GetEquipment("Hormigonera"), 120);
tower.AddTask(GetProduct("Tabla"), 50, GetEquipment("Martillo"), 15);
```
### DIP
Para poder aplicar el Principio de Inversión de Dependencia, lo que hicimos fue definir una abstracción de la que queremos que ConsolePrinter, FilePrinter y Building dependan. Para esto creamos la interfaz IPrintable con el método GetTextToPrint().
```
public interface IPrintable
    {
        string GetTextToPrint();
    }
```
Anteriormente, a la clase FilePrinter le pasabamos un Building como parámetro.
```
public class FilePrinter : IPrinter
{
        public void PrintBuilding(Building building)
        {
            File.WriteAllText("Building.txt", building.GetTextToPrint());
        }
}
```

Ahora, lo que hacemos es pasarle un objeto de tipo IPrintable.
```
public class FilePrinter : IPrinter
{
        public void PrintBuilding(IPrintable filePrintable)
        {
            File.WriteAllText("Building.txt", filePrintable.GetTextToPrint());
        }
}
```
### ISP
Recordemos que el Principio de Segregación de la Interfaz establece que los objetos solo deberían conocer los métodos que realmente usan, y no aquellos que no necesitan usar. Para esto, creamos la interfaz ICostable
```
public interface ICostable
    {
        double GetProductionCost();
    }
```
Como vemos, esta interfaz tiene el método de calcular el costo de producción. La misma será posteriormente implementada por la clase Building.
```
public class Building : IPrintable, ICostable
    {
```
Teniendo todo esto en cuenta, sabemos que el principio está presente, ya que la interfaz solo tiene el método que la clase Building necesita, el de saber el costo de la producción, ningún otro.


## Test realizados
➡️ ProductionCostTest : Testea nuestro método GetProductionCost()
➡️ DescriptionTest:  Testea si la descripción es la correcta (para no testear todos los datos)
➡️ TaskTest  : Testea las tasks
➡️ FinalSupply: Testea el supply final (null)
➡️ ExceptionTest: Testea la excepción que creamos







