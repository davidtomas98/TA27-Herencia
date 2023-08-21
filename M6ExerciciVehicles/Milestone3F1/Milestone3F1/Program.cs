using System;
using System.Collections.Generic;

namespace Milestone3F1
{
    class Rueda
    {
        public string Marca { get; set; }
        public double Diametro { get; set; }
    }

    class Vehiculo
    {
        // Propiedades de un vehículo
        public string Matricula { get; set; }
        public string Marca { get; set; }
        public string Color { get; set; }
        public List<Rueda> Ruedas { get; set; }
        public Titular Titular { get; set; }
        public List<Conductor> Conductores { get; set; }

        // Constructor para crear un vehículo con matrícula, marca y color
        public Vehiculo(string matricula, string marca, string color)
        {
            Matricula = matricula;
            Marca = marca;
            Color = color;
            Ruedas = new List<Rueda>();
            Conductores = new List<Conductor>();
        }

        // Constructor sobrecargado para crear un vehículo con matrícula, marca, color y titular
        public Vehiculo(string matricula, string marca, string color, Titular titular)
            : this(matricula, marca, color) // Llamada al constructor anterior para inicializar propiedades básicas
        {
            Titular = titular;
        }

        // Método para agregar ruedas al vehículo
        public void AgregarRuedas(int cantidad)
        {
            for (int i = 0; i < cantidad; i++)
            {
                Console.Write($"Introduce la marca de la rueda {i + 1}: ");
                string marcaRueda = Console.ReadLine();

                double diametroRueda;
                do
                {
                    Console.Write($"Introduce el diámetro de la rueda {i + 1}: ");
                    diametroRueda = Convert.ToDouble(Console.ReadLine());
                } while (diametroRueda <= 0.4 || diametroRueda >= 4);

                Rueda rueda = new Rueda { Marca = marcaRueda, Diametro = diametroRueda };
                Ruedas.Add(rueda);
            }
        }
    }

    // Clase base para representar a una persona
    class Persona
    {
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public DateTime FechaNacimiento { get; set; }
    }

    // Clase para representar una licencia de conducir
    class Licencia
    {
        public int ID { get; set; }
        public string TipoLicencia { get; set; }
        public string NombreCompleto { get; set; }
        public DateTime FechaCaducidad { get; set; }
    }

    // Clase que hereda de Persona y representa a un conductor
    class Conductor : Persona
    {
        public Licencia LicenciaConducir { get; set; }
    }

    // Clase que hereda de Conductor y representa al titular del vehículo
    class Titular : Conductor
    {
        public bool TieneSeguro { get; set; }
        public bool TieneGarajePropio { get; set; }
    }

    class Program
    {
        // Función para crear un nuevo usuario titular
        static Titular CrearUsuario()
        {
            // Crear instancia de Titular
            Titular titular = new Titular();

            Console.WriteLine("Introduce los datos del titular:");
            titular.Nombre = SolicitarDatos("nombre");
            titular.Apellidos = SolicitarDatos("apellidos");
            titular.FechaNacimiento = SolicitarFechaNacimiento();

            Licencia licencia = new Licencia();
            licencia.ID = Convert.ToInt32(SolicitarDatos("ID de licencia"));
            licencia.TipoLicencia = SolicitarTipoLicencia();
            licencia.NombreCompleto = $"{titular.Nombre} {titular.Apellidos}";
            licencia.FechaCaducidad = SolicitarFechaCaducidad();
            titular.LicenciaConducir = licencia;

            Console.Write("¿Tiene seguro? (S/N): ");
            char seguroChar = Console.ReadLine()[0];
            titular.TieneSeguro = seguroChar == 'S' || seguroChar == 's';

            Console.Write("¿Tiene garaje propio? (S/N): ");
            char garajeChar = Console.ReadLine()[0];
            titular.TieneGarajePropio = garajeChar == 'S' || garajeChar == 's';

            return titular;
        }

        // Función para solicitar el tipo de licencia al usuario
        static string SolicitarTipoLicencia()
        {
            Console.WriteLine("Tipos de licencia disponibles:");
            Console.WriteLine("B - Coche");
            Console.WriteLine("A - Moto");
            Console.WriteLine("A1 - Moto");
            Console.WriteLine("C - Camión");

            Console.Write("Introduce el tipo de licencia (B/A/A1/C): ");
            string opcionLicencia = Console.ReadLine().ToUpper();

            switch (opcionLicencia)
            {
                case "B":
                case "A":
                case "A1":
                case "C":
                    return opcionLicencia;
                default:
                    return "Desconocido";
            }
        }

        // Función para solicitar la fecha de caducidad de la licencia al usuario
        static DateTime SolicitarFechaCaducidad()
        {
            Console.Write("Introduce la fecha de caducidad de la licencia (dd/mm/aaaa): ");
            string fechaCaducidadStr = Console.ReadLine();
            return DateTime.ParseExact(fechaCaducidadStr, "dd/MM/yyyy", null);
        }

        // Función para solicitar la fecha de nacimiento al usuario
        static DateTime SolicitarFechaNacimiento()
        {
            Console.Write("Introduce la fecha de nacimiento (dd/mm/aaaa): ");
            string fechaNacimientoStr = Console.ReadLine();
            return DateTime.ParseExact(fechaNacimientoStr, "dd/MM/yyyy", null);
        }

        // Función para solicitar información al usuario (nombre, apellidos, etc.)
        static string SolicitarDatos(string datos)
        {
            Console.Write($"Introduce {datos}: ");
            return Console.ReadLine();
        }

        // Función para mostrar información de una Persona
        static void MostrarPersona(Persona persona)
        {
            Console.WriteLine($"Nombre: {persona.Nombre}");
            Console.WriteLine($"Apellidos: {persona.Apellidos}");
            Console.WriteLine($"Fecha de Nacimiento: {persona.FechaNacimiento.ToShortDateString()}");
        }

        // Función para mostrar información de una Licencia
        static void MostrarLicencia(Licencia licencia)
        {
            Console.WriteLine($"ID: {licencia.ID}");
            Console.WriteLine($"Tipo de Licencia: {licencia.TipoLicencia}");
            Console.WriteLine($"Nombre Completo: {licencia.NombreCompleto}");
            Console.WriteLine($"Fecha de Caducidad: {licencia.FechaCaducidad.ToShortDateString()}");
        }

        // Función para mostrar información de un Vehículo y sus conductores
        static void MostrarVehiculo(Vehiculo vehiculo)
        {
            Console.WriteLine($"Matrícula: {vehiculo.Matricula}");
            Console.WriteLine($"Marca: {vehiculo.Marca}");
            Console.WriteLine($"Color: {vehiculo.Color}");

            Console.WriteLine("Ruedas del vehículo:");
            foreach (var rueda in vehiculo.Ruedas)
            {
                Console.WriteLine($"Marca: {rueda.Marca}, Diámetro: {rueda.Diametro}");
            }

            Console.WriteLine($"Titular del vehículo:");
            MostrarPersona(vehiculo.Titular);

            Console.WriteLine("Conductores del vehículo:");
            foreach (var conductor in vehiculo.Conductores)
            {
                MostrarPersona(conductor);
                MostrarLicencia(conductor.LicenciaConducir);
            }
        }

        // Función para crear un nuevo vehículo
        static Vehiculo CrearVehiculo(Titular titular)
        {
            Console.WriteLine("\nDatos del vehículo:");
            string matricula = SolicitarDatos("matrícula");
            string marca = SolicitarDatos("marca");
            string color = SolicitarDatos("color");

            Vehiculo vehiculo = new Vehiculo(matricula, marca, color, titular);
            vehiculo.AgregarRuedas(4);

            Console.Write("¿El titular será el conductor? (S/N): ");
            char respuesta = Console.ReadLine()[0];
            if (respuesta == 'N' || respuesta == 'n')
            {
                Console.WriteLine("Agregando conductor(es) adicional(es):");
                while (true)
                {
                    Console.Write("¿Desea agregar un conductor adicional? (S/N): ");
                    char respuestaConductor = Console.ReadLine()[0];
                    if (respuestaConductor == 'N' || respuestaConductor == 'n')
                        break;

                    Conductor conductor = CrearConductor();
                    if (EsLicenciaValida(conductor.LicenciaConducir, vehiculo))
                    {
                        vehiculo.Conductores.Add(conductor);
                    }
                    else
                    {
                        Console.WriteLine("El conductor no tiene la licencia adecuada para conducir este vehículo.");
                    }
                }
            }

            return vehiculo;
        }

        // Función para verificar si una licencia es válida para el vehículo
        static bool EsLicenciaValida(Licencia licencia, Vehiculo vehiculo)
        {
            switch (vehiculo.Marca)
            {
                case "Coche":
                    return licencia.TipoLicencia == "B";
                case "Moto":
                    return licencia.TipoLicencia == "A" || licencia.TipoLicencia == "A1";
                case "Camión":
                    return licencia.TipoLicencia == "C";
                default:
                    return false;
            }
        }

        // Función para crear un nuevo conductor
        static Conductor CrearConductor()
        {
            Conductor conductor = new Conductor();

            Console.WriteLine("Introduce los datos del conductor:");
            conductor.Nombre = SolicitarDatos("nombre");
            conductor.Apellidos = SolicitarDatos("apellidos");
            conductor.FechaNacimiento = SolicitarFechaNacimiento();

            Licencia licencia = new Licencia();
            licencia.ID = Convert.ToInt32(SolicitarDatos("ID de licencia"));
            licencia.TipoLicencia = SolicitarTipoLicencia();
            licencia.NombreCompleto = $"{conductor.Nombre} {conductor.Apellidos}";
            licencia.FechaCaducidad = SolicitarFechaCaducidad();
            conductor.LicenciaConducir = licencia;

            return conductor;
        }

        static void Main(string[] args)
        {
            List<Titular> titulares = new List<Titular>();
            List<Vehiculo> vehiculos = new List<Vehiculo>();

            while (true)
            {
                Console.WriteLine("1. Crear usuario");
                Console.WriteLine("2. Crear vehículo");
                Console.WriteLine("3. Mostrar usuarios");
                Console.WriteLine("4. Mostrar vehículos");
                Console.WriteLine("5. Salir");
                Console.Write("Elige una opción: ");
                int opcion = Convert.ToInt32(Console.ReadLine());

                switch (opcion)
                {
                    case 1:
                        Titular titular = CrearUsuario();
                        titulares.Add(titular);
                        Console.WriteLine("\nUsuario titular creado:");
                        MostrarPersona(titular);
                        MostrarLicencia(titular.LicenciaConducir);
                        break;
                    case 2:
                        if (titulares.Count == 0)
                        {
                            Console.WriteLine("\nDebes crear al menos un usuario titular primero.");
                            break;
                        }

                        Console.WriteLine("Titulares disponibles:");
                        for (int i = 0; i < titulares.Count; i++)
                        {
                            Console.WriteLine($"{i + 1}. {titulares[i].Nombre} {titulares[i].Apellidos}");
                        }

                        int numTitular;

                        do
                        {
                            Console.Write("\nElige un titular para el vehículo (ingresa el número de usuario): ");
                            string input = Console.ReadLine();

                            if (int.TryParse(input, out numTitular))
                            {
                                numTitular -= 1; // Restamos 1 para obtener el índice en la lista

                                if (numTitular >= 0 && numTitular < titulares.Count)
                                {
                                    // Aquí puedes continuar con el código para asignar el titular al vehículo
                                    break; // Salir del bucle si el número es válido
                                }
                                else
                                {
                                    Console.WriteLine("Número de usuario incorrecto. Inténtalo de nuevo.");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Entrada inválida. Ingresa un número válido.");
                            }
                        } while (true);

                        Vehiculo vehiculo = CrearVehiculo(titulares[numTitular]);
                        vehiculos.Add(vehiculo);
                        Console.WriteLine("\nVehículo creado con sus ruedas!");
                        MostrarVehiculo(vehiculo);
                        break;
                    case 3:
                        Console.WriteLine("\nLista de usuarios:");
                        for (int i = 0; i < titulares.Count; i++)
                        {
                            Console.WriteLine($"Usuario {i + 1}: {titulares[i].Nombre} {titulares[i].Apellidos}");
                        }
                        break;
                    case 4:
                        Console.WriteLine("\nLista de vehículos:");
                        for (int i = 0; i < vehiculos.Count; i++)
                        {
                            Console.WriteLine($"Vehículo {i + 1}: Matrícula {vehiculos[i].Matricula}, Marca {vehiculos[i].Marca}");
                        }
                        break;
                    case 5:
                        Console.WriteLine("Saliendo del programa...");
                        return;
                    default:
                        Console.WriteLine("Opción no válida.");
                        break;
                }
            }
        }
    }
}
