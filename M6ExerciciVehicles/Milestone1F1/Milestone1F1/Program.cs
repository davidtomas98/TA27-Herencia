using System;
using System.Collections.Generic;

namespace Milestone1F1
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

            // Demanar dades del cotxe a l'usuari
            Console.Write("Introdueix la matrícula del cotxe: ");
            string matricula = Console.ReadLine();

            Console.Write("Introdueix la marca del cotxe: ");
            string marca = Console.ReadLine();

            Console.Write("Introdueix el color del cotxe: ");
            string color = Console.ReadLine();

            // Crear una instància de Vehicle amb les dades introduïdes
            Vehicle cotxe = new Vehicle(matricula, marca, color);

            // Afegir rodes traseres i davanteres
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
            Console.WriteLine("Premi una tecla per sortir...");
            Console.ReadKey();
        }

        // Mètode per afegir rodes a un vehicle
        static void AfegirRodes(Vehicle vehicle, string tipusRodes)
        {
            for (int i = 0; i < 2; i++)
            {
                Console.Write($"Introdueix la marca de les rodes {tipusRodes} {i + 1}: ");
                string marcaRoda = Console.ReadLine();

                Console.Write($"Introdueix el diàmetre de les rodes {tipusRodes} {i + 1}: ");
                double diametreRoda = Convert.ToDouble(Console.ReadLine());

                // Crear una instància de Roda amb les dades introduïdes i afegir-la al vehicle
                Roda roda = new Roda { Marca = marcaRoda, Diametre = diametreRoda };
                vehicle.Rodes.Add(roda);
            }
        }
    }
}
