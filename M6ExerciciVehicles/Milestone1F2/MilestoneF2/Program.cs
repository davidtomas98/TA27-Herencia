using System;
using System.Collections.Generic;

namespace Milestone1F2
{
    class Roda
    {
        public string Marca { get; set; }
        public double Diametre { get; set; }
    }

    class Vehicle
    {
        public string Matricula { get; set; }
        public string Marca { get; set; }
        public string Color { get; set; }
        public List<Roda> Rodes { get; set; }

        public Vehicle(string matricula, string marca, string color)
        {
            Matricula = matricula;
            Marca = marca;
            Color = color;
            Rodes = new List<Roda>();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Benvingut al taller de vehicles!");

            string matricula = DemanarMatricula();
            string marca = DemanarDades("marca");
            string color = DemanarDades("color");

            Vehicle cotxe = new Vehicle(matricula, marca, color);

            AfegirRodes(cotxe, "traseres");
            AfegirRodes(cotxe, "davanteres");

            Console.WriteLine("Cotxe creat amb les seves rodes!");

            // Mostrar les dades del cotxe i les seves rodes
            Console.WriteLine("\nDades del cotxe:");
            Console.WriteLine($"Matrícula: {cotxe.Matricula}");
            Console.WriteLine($"Marca: {cotxe.Marca}");
            Console.WriteLine($"Color: {cotxe.Color}");

            Console.WriteLine("\nRodes del cotxe:");
            foreach (var roda in cotxe.Rodes)
            {
                Console.WriteLine($"Marca: {roda.Marca}, Diàmetre: {roda.Diametre}");
            }

            // Esperar que l'usuari premi una tecla abans de sortir
            Console.WriteLine("\nPremi una tecla per sortir...");
            Console.ReadKey();
        }

        // Funció per demanar la matrícula i validar-la
        static string DemanarMatricula()
        {
            string matricula;
            do
            {
                Console.Write("Introdueix la matrícula del cotxe (4 números i 2-3 lletres): ");
                matricula = Console.ReadLine();
            } while (!EsMatriculaValida(matricula));
            return matricula;
        }

        // Funció per validar la matrícula
        static bool EsMatriculaValida(string matricula)
        {
            if (matricula.Length < 6 || matricula.Length > 7)
                return false;

            string numeros = matricula.Substring(0, 4);
            string lletres = matricula.Substring(4);

            if (!int.TryParse(numeros, out int numResult))
                return false;

            if (!lletres.All(char.IsLetter) || lletres.Length < 2 || lletres.Length > 3)
                return false;

            return true;
        }

        // Funció per demanar les dades (marca o color) del cotxe
        static string DemanarDades(string tipus)
        {
            Console.Write($"Introdueix la {tipus} del cotxe: ");
            return Console.ReadLine();
        }

        // Funció per afegir les rodes a un vehicle
        static void AfegirRodes(Vehicle vehicle, string tipusRodes)
        {
            for (int i = 0; i < 2; i++)
            {
                Console.Write($"Introdueix la marca de les rodes {tipusRodes} {i + 1}: ");
                string marcaRoda = Console.ReadLine();

                double diametreRoda;
                do
                {
                    Console.Write($"Introdueix el diàmetre de les rodes {tipusRodes} {i + 1} (0.4-4): ");
                    diametreRoda = Convert.ToDouble(Console.ReadLine());
                } while (diametreRoda < 0.4 || diametreRoda > 4);

                Roda roda = new Roda { Marca = marcaRoda, Diametre = diametreRoda };
                vehicle.Rodes.Add(roda);
            }
        }
    }
}
