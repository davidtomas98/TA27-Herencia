using System;

namespace Milestone1
{
    class Program
    {
        static void Main(string[] args)
        {
            // Creem instàncies d'empleats amb diferents tipus i sous base
            Employee manager = new Employee("Manager", 5000);
            Employee boss = new Employee("Boss", 10000);
            Employee employee = new Employee("Employee", 3000);
            Employee volunteer = new Employee("Volunteer", 0);

            // Calculem i mostrem els sous
            Console.WriteLine($"Manager: {manager.CalculateSalary()}");
            Console.WriteLine($"Boss: {boss.CalculateSalary()}");
            Console.WriteLine($"Employee: {employee.CalculateSalary()}");
            Console.WriteLine($"Volunteer: {volunteer.CalculateSalary()}");
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
            // Càlcul del sou en funció del tipus d'empleat
            if (Type == "Manager")
                return BaseSalary * 1.10;
            else if (Type == "Boss")
                return BaseSalary * 1.50;
            else if (Type == "Employee")
                return BaseSalary * 0.85;
            else
                return 0; // Els voluntaris no cobren
        }
    }
}
