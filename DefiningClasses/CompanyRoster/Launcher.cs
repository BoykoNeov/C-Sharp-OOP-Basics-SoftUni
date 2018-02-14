using System;
using System.Collections.Generic;
using System.Linq;

public class Launcher
{
    public static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        List<Employee> employees = new List<Employee>();

        for (int i = 0; i < n; i++)
        {
            string[] input = Console.ReadLine().Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries);
            Employee currentEmployee = new Employee(input[0], decimal.Parse(input[1]), input[2], input[3]);

            if (input.Length == 5)
            {
                bool parsedSuccessfully = int.TryParse(input[4], out int age);

                if (parsedSuccessfully)
                {
                    currentEmployee.Age = age;
                }
                else
                {
                    currentEmployee.Email = input[4];
                }
            }
            else if (input.Length == 6)
            {
                currentEmployee.Email = input[4];
                currentEmployee.Age = int.Parse(input[5]);
            }

            employees.Add(currentEmployee);
        }

        var highestAvgSalaryDepartment = employees.GroupBy(d => d.Department).OrderByDescending(d => d.Average(e => e.Salary)).ToList().First();

        Console.WriteLine($"Highest Average Salary: {highestAvgSalaryDepartment.Key}");

        foreach (Employee employee in highestAvgSalaryDepartment.OrderByDescending(e => e.Salary))
        {
            Console.WriteLine($"{employee.Name} {employee.Salary:F2} {employee.Email} {employee.Age}");
        }
    }
}