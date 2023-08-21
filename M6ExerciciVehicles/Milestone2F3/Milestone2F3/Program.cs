using System;
using System.Collections.Generic;

namespace Milestone2F3
{
    // Definición de la clase Rueda
    class Rueda
    {
        public string Marca { get; set; }
        public double Diametro { get; set; }
    }

    // Definición de la clase base Vehiculo
    class Vehiculo
    {
        public string Matricula { get; set; }
        public string Marca { get; set; }
        public string Color { get; set; }
        public List<Rueda> Ruedas { get; set; }

        public Vehiculo(string matricula, string marca, string color)
        {
            Matricula = matricula;
            Marca = marca;
            Color = color;
            Ruedas = new List<Rueda>();
        }

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

    // Definición de las clases derivadas Coche, Moto y Camion
    class Coche : Vehiculo
    {
        public Coche(string matricula, string marca, string color) : base(matricula, marca, color) { }
    }

    class Moto : Vehiculo
    {
        public Moto(string matricula, string marca, string color) : base(matricula, marca, color) { }
    }

    class Camion : Vehiculo
    {
        public Camion(string matricula, string marca, string color) : base(matricula, marca, color) { }
    }

    // Definición de la clase base Persona
    class Persona
    {
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public DateTime FechaNacimiento { get; set; }
    }

    // Definición de la clase Licencia
    class Licencia
    {
        public int ID { get; set; }
        public string TipoLicencia { get; set; }
        public string NombreCompleto { get; set; }
        public DateTime FechaCaducidad { get; set; }
    }

    // Definición de la clase Conductor derivada de Persona
    class Conductor : Persona
    {
        public Licencia LicenciaConducir { get; set; }
    }

    // Definición de la clase Titular derivada de Conductor
    class Titular : Conductor
    {
        public bool TieneSeguro { get; set; }
        public bool TieneGarajePropio { get; set; }
    }

    // Programa principal
    class Program
    {
        // Método para crear un nuevo usuario titular
        static Titular CrearUsuario()
        {
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

        // Método para solicitar el tipo de licencia
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
                    return "B";
                case "A":
                    return "A";
                case "A1":
                    return "A1";
                case "C":
                    return "C";
                default:
                    return "Desconocido";
            }
        }

        // Método para solicitar la fecha de caducidad de la licencia
        static DateTime SolicitarFechaCaducidad()
        {
            Console.Write("Introduce la fecha de caducidad de la licencia (dd/mm/aaaa): ");
            string fechaCaducidadStr = Console.ReadLine();
            return DateTime.ParseExact(fechaCaducidadStr, "dd/MM/yyyy", null);
        }

        // Método para solicitar la fecha de nacimiento
        static DateTime SolicitarFechaNacimiento()
        {
            Console.Write("Introduce la fecha de nacimiento (dd/mm/aaaa): ");
            string fechaNacimientoStr = Console.ReadLine();
            return DateTime.ParseExact(fechaNacimientoStr, "dd/MM/yyyy", null);
        }

        // Método para solicitar datos genéricos
        static string SolicitarDatos(string datos)
        {
            Console.Write($"Introduce {datos}: ");
            return Console.ReadLine();
        }

        // Método para mostrar los datos de una persona
        static void MostrarPersona(Persona persona)
        {
            Console.WriteLine($"Nombre: {persona.Nombre}");
            Console.WriteLine($"Apellidos: {persona.Apellidos}");
            Console.WriteLine($"Fecha de Nacimiento: {persona.FechaNacimiento.ToShortDateString()}");
        }

        // Método para mostrar los datos de una licencia
        static void MostrarLicencia(Licencia licencia)
        {
            Console.WriteLine($"ID: {licencia.ID}");
            Console.WriteLine($"Tipo de Licencia: {licencia.TipoLicencia}");
            Console.WriteLine($"Nombre Completo: {licencia.NombreCompleto}");
            Console.WriteLine($"Fecha de Caducidad: {licencia.FechaCaducidad.ToShortDateString()}");
        }

        // Método para mostrar los datos de un vehículo
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
        }

        // Método principal
        static void Main(string[] args)
        {
            Console.WriteLine("Bienvenido al taller de vehículos!");

            // Crear un nuevo usuario titular
            Titular titular = CrearUsuario();
            Console.WriteLine("\nUsuario titular creado:");
            MostrarPersona(titular);
            MostrarLicencia(titular.LicenciaConducir);

            // Solicitar qué tipo de vehículo crear
            Console.Write("\n¿Quieres crear un coche (C), una moto (M) o un camión (T)? ");
            char opcion = Console.ReadLine()[0];

            if (opcion == 'C' || opcion == 'c')
            {
                if (EsLicenciaValida(titular.LicenciaConducir, "Coche"))
                {
                    Vehiculo coche = CrearCoche(titular);
                    Console.WriteLine("\nCoche creado con sus ruedas!");
                    MostrarVehiculo(coche);
                }
                else
                {
                    Console.WriteLine("\nNo tienes la licencia adecuada para conducir un coche.");
                }
            }
            else if (opcion == 'M' || opcion == 'm')
            {
                if (EsLicenciaValida(titular.LicenciaConducir, "Moto"))
                {
                    Vehiculo moto = CrearMoto(titular);
                    Console.WriteLine("\nMoto creada con sus ruedas!");
                    MostrarVehiculo(moto);
                }
                else
                {
                    Console.WriteLine("\nNo tienes la licencia adecuada para conducir una moto.");
                }
            }
            else if (opcion == 'T' || opcion == 't')
            {
                if (EsLicenciaValida(titular.LicenciaConducir, "Camión"))
                {
                    Vehiculo camion = CrearCamion(titular);
                    Console.WriteLine("\nCamión creado con sus ruedas!");
                    MostrarVehiculo(camion);
                }
                else
                {
                    Console.WriteLine("\nNo tienes la licencia adecuada para conducir un camión.");
                }
            }
            else
            {
                Console.WriteLine("\nOpción no válida.");
            }

            Console.WriteLine("\nPulsa una tecla para salir...");
            Console.ReadKey();
        }

        // Método para verificar si una licencia es válida para un tipo de vehículo
        static bool EsLicenciaValida(Licencia licencia, string tipoVehiculo)
        {
            if (tipoVehiculo == "Coche" && licencia.TipoLicencia == "B")
                return true;
            else if (tipoVehiculo == "Moto" && (licencia.TipoLicencia == "A" || licencia.TipoLicencia == "A1"))
                return true;
            else if (tipoVehiculo == "Camión" && licencia.TipoLicencia == "C")
                return true;
            else
                return false;
        }

        // Método para crear un coche
        static Vehiculo CrearCoche(Titular titular)
        {
            Console.WriteLine("\nDatos del coche:");
            string matricula = SolicitarDatos("matrícula");
            string marca = SolicitarDatos("marca");
            string color = SolicitarDatos("color");

            Vehiculo coche = new Coche(matricula, marca, color);
            coche.AgregarRuedas(4);

            if (SolicitarSiEsConductor(titular))
            {
                coche.Marca = SolicitarDatos("marca");
                coche.Color = SolicitarDatos("color");
            }

            return coche;
        }

        // Método para crear una moto
        static Vehiculo CrearMoto(Titular titular)
        {
            Console.WriteLine("\nDatos de la moto:");
            string matricula = SolicitarDatos("matrícula");
            string marca = SolicitarDatos("marca");
            string color = SolicitarDatos("color");

            Vehiculo moto = new Moto(matricula, marca, color);
            moto.AgregarRuedas(2);

            if (SolicitarSiEsConductor(titular))
            {
                moto.Marca = SolicitarDatos("marca");
                moto.Color = SolicitarDatos("color");
            }

            return moto;
        }

        // Método para crear un camión
        static Vehiculo CrearCamion(Titular titular)
        {
            Console.WriteLine("\nDatos del camión:");
            string matricula = SolicitarDatos("matrícula");
            string marca = SolicitarDatos("marca");
            string color = SolicitarDatos("color");

            Vehiculo camion = new Camion(matricula, marca, color);
            camion.AgregarRuedas(6);

            if (SolicitarSiEsConductor(titular))
            {
                camion.Marca = SolicitarDatos("marca");
                camion.Color = SolicitarDatos("color");
            }

            return camion;
        }

        // Método para solicitar si el titular será el conductor
        static bool SolicitarSiEsConductor(Titular titular)
        {
            Console.Write("\n¿El titular será el conductor? (S/N): ");
            char respuesta = Console.ReadLine()[0];
            if (respuesta == 'S' || respuesta == 's')
            {
                return true;
            }
            else if (respuesta == 'N' || respuesta == 'n')
            {
                Console.Write("\nCreando nuevo usuario conductor...");
                Titular nuevoTitular = CrearUsuario();
                if (EsLicenciaValida(nuevoTitular.LicenciaConducir, titular.LicenciaConducir.TipoLicencia))
                {
                    titular = nuevoTitular;
                    return true;
                }
                else
                {
                    Console.WriteLine("\nEl nuevo conductor no tiene la licencia adecuada para conducir este vehículo.");
                    return false;
                }
            }
            else
            {
                Console.WriteLine("\nRespuesta no válida. Se asume que el titular será el conductor.");
                return true;
            }
        }
    }
}
