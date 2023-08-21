using System;
using System.Collections.Generic;

namespace Milestone1F3
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

    class Bike : Vehicle
    {
        public Bike(string matricula, string marca, string color)
            : base(matricula, marca, color)
        {
        }

        public void AfegirRodesBike()
        {
            for (int i = 0; i < 2; i++)
            {
                Console.Write($"Introdueix la marca de les rodes {i + 1}: ");
                string marcaRoda = Console.ReadLine();

                double diametreRoda;
                do
                {
                    Console.Write($"Introdueix el diàmetre de les rodes {i + 1} (0.4-4): ");
                    diametreRoda = Convert.ToDouble(Console.ReadLine());
                } while (diametreRoda < 0.4 || diametreRoda > 4);

                Roda roda = new Roda { Marca = marcaRoda, Diametre = diametreRoda };
                Rodes.Add(roda);
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Benvingut al taller de vehicles!");

            Console.Write("Vols crear un cotxe (C) o una moto (M)? ");
            char opcio = Console.ReadLine()[0];

            string matricula = DemanarMatricula();
            string marca = DemanarDades("marca");
            string color = DemanarDades("color");

            Vehicle vehicle;

            if (opcio == 'C' || opcio == 'c')
            {
                vehicle = new Vehicle(matricula, marca, color);

                AfegirRodes(vehicle, "traseres");
                AfegirRodes(vehicle, "davanteres");
            }
            else if (opcio == 'M' || opcio == 'm')
            {
                vehicle = new Bike(matricula, marca, color);

                ((Bike)vehicle).AfegirRodesBike();
            }
            else
            {
                Console.WriteLine("Opció no vàlida.");
                return;
            }

            Console.WriteLine("Vehicle creat amb les seves rodes!");

            // Mostrar les dades del vehicle i les seves rodes
            Console.WriteLine("\nDades del vehicle:");
            Console.WriteLine($"Matrícula: {vehicle.Matricula}");
            Console.WriteLine($"Marca: {vehicle.Marca}");
            Console.WriteLine($"Color: {vehicle.Color}");

            Console.WriteLine("\nRodes del vehicle:");
            foreach (var roda in vehicle.Rodes)
            {
                Console.WriteLine($"Marca: {roda.Marca}, Diàmetre: {roda.Diametre}");
            }

            // Esperar que l'usuari premi una tecla abans de sortir
            Console.WriteLine("\nPremi una tecla per sortir...");
            Console.ReadKey();
        }

        static string DemanarMatricula()
        {
            string matricula;
            do
            {
                Console.Write("Introdueix la matrícula del vehicle (4 números i 2-3 lletres): ");
                matricula = Console.ReadLine();
            } while (!EsMatriculaValida(matricula));
            return matricula;
        }

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

        static string DemanarDades(string tipus)
        {
            Console.Write($"Introdueix la {tipus} del vehicle: ");
            return Console.ReadLine();
        }

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
