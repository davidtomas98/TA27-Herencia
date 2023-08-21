using System;

namespace Milestone2
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Boss boss = new Boss("Boss", 12000);
                Manager manager = new Manager("Manager", 4000);
                Senior senior = new Senior("Senior", 3000);
                Mid mid = new Mid("Mid", 2000);
                Junior junior = new Junior("Junior", 1000);
                Volunteer volunteer = new Volunteer("Volunteer", 0);

                Console.WriteLine($"Boss Salary: {boss.CalculateSalary()}");
                Console.WriteLine($"Manager Salary: {manager.CalculateSalary()}");
                Console.WriteLine($"Senior Salary: {senior.CalculateSalary()}");
                Console.WriteLine($"Mid Salary: {mid.CalculateSalary()}");
                Console.WriteLine($"Junior Salary: {junior.CalculateSalary()}");
                Console.WriteLine($"Volunteer Salary: {volunteer.CalculateSalary()}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }

    class Employee
    {
        public string Type { get; set; }
        public double BaseSalary { get; set; }

        public Employee(string type, double baseSalary)
        {
            Type = type;
            BaseSalary = baseSalary;
        }

        public virtual double CalculateSalary()
        {
            if (Type == "Manager")
                return BaseSalary * 1.10;
            else if (Type == "Boss")
                return BaseSalary * 1.50;
            else if (Type == "Employee")
                return BaseSalary * 0.85;
            else
                return 0; // Volunteer
        }
    }

    class Junior : Employee
    {
        public Junior(string type, double baseSalary) : base(type, baseSalary) { }

        public override double CalculateSalary()
        {
            double reductionPercentage = 0.15;
            return BaseSalary * (1 - reductionPercentage);
        }
    }

    class Mid : Employee
    {
        public Mid(string type, double baseSalary) : base(type, baseSalary) { }

        public override double CalculateSalary()
        {
            double reductionPercentage = 0.10;
            return BaseSalary * (1 - reductionPercentage);
        }
    }

    class Senior : Employee
    {
        public Senior(string type, double baseSalary) : base(type, baseSalary) { }

        public override double CalculateSalary()
        {
            double reductionPercentage = 0.05;
            return BaseSalary * (1 - reductionPercentage);
        }
    }

    class Boss : Employee
    {
        public Boss(string type, double baseSalary) : base(type, baseSalary) { }

        public override double CalculateSalary()
        {
            // Validar que el sou del Boss és superior a 8000€
            if (BaseSalary < 8000)
            {
                throw new InvalidOperationException("Boss salary must be at least 8000€.");
            }

            return BaseSalary * 1.50;
        }
    }

    class Manager : Employee
    {
        public Manager(string type, double baseSalary) : base(type, baseSalary) { }

        public override double CalculateSalary()
        {
            // Validar que el sou del Manager està entre 3000€ i 5000€
            if (BaseSalary < 3000 || BaseSalary > 5000)
            {
                throw new InvalidOperationException("Manager salary must be between 3000€ and 5000€.");
            }

            return BaseSalary * 1.10;
        }
    }

    class Volunteer : Employee
    {
        public Volunteer(string type, double baseSalary) : base(type, baseSalary) { }

        public override double CalculateSalary()
        {
            return 0; // Els voluntaris no cobren
        }
    }
}
