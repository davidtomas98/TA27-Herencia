using System;

namespace Milestone2F2
{
    // Classe base per emmagatzemar les característiques d'una persona
    class Persona
    {
        public string Nom { get; set; }
        public string Cognoms { get; set; }
        public DateTime DataNaixement { get; set; }
    }

    // Classe per emmagatzemar les característiques d'una llicència de conduir
    class Llicencia
    {
        public int ID { get; set; }
        public string TipusLlicencia { get; set; }
        public string NomComplet { get; set; }
        public DateTime DataCaducitat { get; set; }
    }

    // Classe per emmagatzemar les característiques d'un conductor
    class Conductor : Persona
    {
        public Llicencia LlicenciaConduir { get; set; }
    }

    // Classe per emmagatzemar les característiques d'un titular de vehicle
    class Titular : Persona
    {
        public bool Assegurança { get; set; }
        public bool GaratgePropi { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Benvingut al taller de vehicles!");

            // Crear un titular i un conductor
            Titular titular = CrearTitular();
            Conductor conductor = CrearConductor();

            Console.WriteLine("\nDades del titular:");
            MostrarPersona(titular);

            Console.WriteLine("\nDades del conductor:");
            MostrarConductor(conductor);

            Console.WriteLine("\nPremi una tecla per sortir...");
            Console.ReadKey();
        }

        static Titular CrearTitular()
        {
            Console.WriteLine("Introdueix les dades del titular:");
            Titular titular = new Titular();

            titular.Nom = DemanarDades("nom");
            titular.Cognoms = DemanarDades("cognoms");
            titular.DataNaixement = DemanarDataNaixement();

            Console.Write("Té assegurança? (S/N): ");
            char assegurancaChar = Console.ReadLine()[0];
            titular.Assegurança = assegurancaChar == 'S' || assegurancaChar == 's';

            Console.Write("Té garatge propi? (S/N): ");
            char garatgeChar = Console.ReadLine()[0];
            titular.GaratgePropi = garatgeChar == 'S' || garatgeChar == 's';

            return titular;
        }

        static Conductor CrearConductor()
        {
            Console.WriteLine("\nIntrodueix les dades del conductor:");
            Conductor conductor = new Conductor();

            conductor.Nom = DemanarDades("nom");
            conductor.Cognoms = DemanarDades("cognoms");
            conductor.DataNaixement = DemanarDataNaixement();

            conductor.LlicenciaConduir = CrearLlicencia();

            return conductor;
        }

        static Llicencia CrearLlicencia()
        {
            Llicencia llicencia = new Llicencia();

            Console.WriteLine("\nIntrodueix les dades de la llicència de conduir:");
            llicencia.ID = Convert.ToInt32(DemanarDades("ID de la llicència"));
            llicencia.TipusLlicencia = DemanarDades("tipus de llicència");
            llicencia.NomComplet = DemanarDades("nom complet");
            llicencia.DataCaducitat = DemanarDataCaducitat();

            return llicencia;
        }

        static DateTime DemanarDataNaixement()
        {
            Console.Write("Introdueix la data de naixement (dd/mm/aaaa): ");
            return DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", null);
        }

        static DateTime DemanarDataCaducitat()
        {
            Console.Write("Introdueix la data de caducitat (dd/mm/aaaa): ");
            return DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", null);
        }

        static string DemanarDades(string tipus)
        {
            Console.Write($"Introdueix el {tipus}: ");
            return Console.ReadLine();
        }

        static void MostrarPersona(Persona persona)
        {
            Console.WriteLine($"Nom: {persona.Nom}");
            Console.WriteLine($"Cognoms: {persona.Cognoms}");
            Console.WriteLine($"Data de Naixement: {persona.DataNaixement.ToShortDateString()}");
        }

        static void MostrarConductor(Conductor conductor)
        {
            MostrarPersona(conductor);
            Console.WriteLine($"ID de la Llicència: {conductor.LlicenciaConduir.ID}");
            Console.WriteLine($"Tipus de Llicència: {conductor.LlicenciaConduir.TipusLlicencia}");
            Console.WriteLine($"Nom Complet a la Llicència: {conductor.LlicenciaConduir.NomComplet}");
            Console.WriteLine($"Data de Caducitat de la Llicència: {conductor.LlicenciaConduir.DataCaducitat.ToShortDateString()}");
        }
    }
}