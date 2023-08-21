# 🏢 Gestor de Nóminas de Empleados y Taller de Vehículos

Este proyecto tiene como objetivo el desarrollo de dos componentes esenciales: un software para administrar las nóminas de los empleados en una empresa y otro para gestionar un taller de vehículos. Ambos programas están implementados en C# y se encuentran detallados en los ejercicios **M5: Exercici Jobs** y **M6: Exercici Vehicles**.

## 📊 M5: Exercici Jobs - Gestor de Nóminas de Empleados

### Milestone 1 💰

En esta fase inicial, creamos un sistema de remuneración en función del tipo de empleado, que se divide en cuatro categorías:

- **Manager**: 💼 Recibe un 10% más de su salario mensual.
- **Boss**: 👑 Recibe un 50% más de su salario mensual.
- **Employee**: 🧑‍💼 Recibe su salario mensual aplicando una reducción del 15%.
- **Volunteer**: 🙋‍♂️ No recibe salario.

### Milestone 2 💼

En esta etapa, introducimos la herencia en tres categorías de empleados:

- **Junior**: 💼👶 Recibe entre 900€ y 1600€.
- **Mid**: 💼🧑‍🎓 Recibe entre 1800€ y 2500€.
- **Senior**: 💼👴 Recibe entre 2700€ y 4000€.

También implementamos excepciones para validar los salarios según la categoría.

### Milestone 3 💼

En esta fase, añadimos el cálculo del salario neto y bruto mensual y anual, descontando automáticamente el porcentaje de IRPF del salario bruto. Introducimos una "ayuda gubernamental" para los voluntarios, que les permite recibir hasta 300€ como ayuda.

Implementamos una función que otorga un bono del 10% del salario anual a todos los empleados, excepto a los voluntarios. El programa registra la cantidad de personas y vehículos creados y permite la creación continua de usuarios y vehículos.

## 🚗 M6: Exercici Vehicles - Taller de Vehículos

### Milestone 1 🚘

##### Fase 1

En esta fase, creamos un proyecto de consola en C# para gestionar vehículos en un taller. Los usuarios pueden realizar las siguientes acciones:

1. Ingresar la matrícula, marca y color del coche.
2. Crear un coche con los datos proporcionados.
3. Agregar dos ruedas traseras, proporcionando la marca y el diámetro.
4. Agregar dos ruedas delanteras, proporcionando la marca y el diámetro.

##### Fase 2

En esta fase, mejoramos las validaciones introducidas en la fase 1:

1. Una matrícula debe contener 4 números y 2 o 3 letras.
2. El diámetro de una rueda debe ser mayor a 0.4 y menor a 4.

##### Fase 3

En esta fase, introducimos la clase `Bike` (moto) y permitimos agregar ruedas delanteras y traseras a las motos. El programa ofrece la opción de crear un coche o una moto:

0. Preguntar al usuario si desea crear un coche o una moto.
1. Solicitar la matrícula, marca y color.
2. Crear el vehículo con los datos proporcionados.
3. Agregar las ruedas traseras correspondientes, proporcionando la marca y el diámetro.
4. Agregar las ruedas delanteras correspondientes, proporcionando la marca y el diámetro.

### Milestone 2 🚚

##### Fase 1

Ampliamos el taller de vehículos para incluir un nuevo tipo de vehículo: 🚚 Camión.

##### Fase 2

En esta fase, introducimos dos nuevas clases: `TitularDeVehicle` y `Conductor`. Estas clases expanden la funcionalidad para tener un manejo completo de los vehículos y sus conductores.

- `TitularDeVehicle`: Almacena información sobre los titulares de los vehículos, incluyendo detalles como si tienen seguro y garaje propio.

- `Conductor`: Representa a los conductores asociados a un vehículo. Almacena datos como nombre, apellidos, fecha de nacimiento y licencia de conducir. La licencia de conducir es una entidad separada con información detallada.

La inclusión de estas clases permite una gestión más completa de los usuarios y conductores asociados a los vehículos.

##### Fase 3

En esta fase, implementamos un flujo detallado para la creación de vehículos y sus conductores. Antes de seleccionar un vehículo, se crea un usuario del tipo `TitularDeVehicle` con todos los datos requeridos. Al crear un vehículo, se verifica si la persona tiene la licencia adecuada para conducirlo. Si no es así, se muestra una excepción.

Una vez completada la creación del vehículo, el programa pregunta si el titular será el conductor. Si no lo es, se puede crear un nuevo usuario `TitularDeVehicle`. Se verifica la licencia del conductor para asegurarse de que cumple con los requisitos.

### Milestone 3 🚚

##### Fase 1

En este fase, se registra la cantidad de personas y vehículos creados. La aplicación solo finaliza cuando lo decides, lo que permite crear múltiples vehículos y personas.


En el método `Main`, se incluyen listas para almacenar información sobre personas y vehículos. En la clase `Vehicle`, se añaden campos para asignar un titular al vehículo (de tipo `TitularDeVehicle`) y una lista de personas asociadas al vehículo (conductores).

Al crear un vehículo, se asocia un titular y se pueden agregar conductores adicionales, todos con la licencia adecuada.

### Ejecución del Programa 🚀

1. Asegúrate de tener un entorno de desarrollo compatible con C# instalado.
2. Abre el proyecto del ejercicio deseado.
3. Ejecuta el programa y sigue las instrucciones en la consola.

**¡Explora la gestión de nóminas y el taller de vehículos con diversión!** 🌟
