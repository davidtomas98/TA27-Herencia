using System;

namespace Milestone3
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

                Console.WriteLine($"Boss Net Salary: {boss.CalculateNetSalary()}");
                Console.WriteLine($"Boss Bonus: {boss.CalculateBonus()}");

                Console.WriteLine($"Manager Net Salary: {manager.CalculateNetSalary()}");
                Console.WriteLine($"Manager Bonus: {manager.CalculateBonus()}");

                Console.WriteLine($"Senior Net Salary: {senior.CalculateNetSalary()}");
                Console.WriteLine($"Senior Bonus: {senior.CalculateBonus()}");

                Console.WriteLine($"Mid Net Salary: {mid.CalculateNetSalary()}");
                Console.WriteLine($"Mid Bonus: {mid.CalculateBonus()}");

                Console.WriteLine($"Junior Net Salary: {junior.CalculateNetSalary()}");
                Console.WriteLine($"Junior Bonus: {junior.CalculateBonus()}");

                Console.WriteLine($"Volunteer Net Salary: {volunteer.CalculateNetSalary()}");
                Console.WriteLine($"Volunteer Bonus: {volunteer.CalculateBonus()}");
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

        public double CalculateNetSalary()
        {
            double irpfPercentage = GetIRPFPercentage();

            double netSalary = BaseSalary * (1 - irpfPercentage);
            return netSalary;
        }

        public double CalculateAnnualNetSalary()
        {
            double annualNetSalary = CalculateNetSalary() * 12;
            return annualNetSalary;
        }

        public virtual double CalculateBonus()
        {
            return CalculateAnnualNetSalary() * 0.10;
        }

        private double GetIRPFPercentage()
        {
            if (Type == "Manager") return 0.26;
            else if (Type == "Boss") return 0.32;
            else if (Type == "Senior") return 0.24;
            else if (Type == "Mid") return 0.15;
            else if (Type == "Junior") return 0.02;
            else return 0;
        }
    }

    class Junior : Employee
    {
        public Junior(string type, double baseSalary) : base(type, baseSalary) { }

        public override double CalculateBonus()
        {
            // Els empleats Junior no reben bonus
            return 0;
        }
    }

    class Mid : Employee
    {
        public Mid(string type, double baseSalary) : base(type, baseSalary) { }
    }

    class Senior : Employee
    {
        public Senior(string type, double baseSalary) : base(type, baseSalary) { }
    }

    class Boss : Employee
    {
        public Boss(string type, double baseSalary) : base(type, baseSalary) { }
    }

    class Manager : Employee
    {
        public Manager(string type, double baseSalary) : base(type, baseSalary) { }
    }

    class Volunteer : Employee
    {
        public Volunteer(string type, double baseSalary) : base(type, baseSalary) { }
    }
}
