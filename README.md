# PII Full GRASP and SOLID - Edificaciones

## Desafío1

➡️ Agregar la responsabilidad de calcular el costo total de producir un edificio:

```
double GetProductionCost()
```

El calculo de costo total es el siguiente:

Costo materiales = Sumatoria de costo unitario de los materiales,

Costo herramientas = Sumatoria de tiempo de uso x costo/hora del equipo para todos los pasos de la obra,

Costo total = costo materiales + costo herramientas

➡️ ¿Qué patrón o principio usan para asignar esta responsabilidad? Escriban la respuesta en comentarios en el código.

➡️ Agregar al final de la impresión de la edificación el costo total de producción que se obtiene usando el método recién agregado.

## Desafío 2
Para imprimir la información de un edificio, se necesita información del edificio pero también se necesita saber cómo y dónde imprimir.

➡️ Crear una clase ConsolePrinter para imprimir la información de los edificios en la consola en lugar que los edificios se impriman ellos mismos.

➡️ ¿Qué patrones o principios usan para determinar cómo implementar este cambio? Escriban la respuesta en comentarios en el código.
