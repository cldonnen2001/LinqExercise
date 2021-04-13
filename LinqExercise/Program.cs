using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqExercise
{
    class Program
    {
        //Static array of integers
        private static int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 };

        static void Main(string[] args)
        {
            /*
             * Complete every task using Method OR Query syntax.
             * HINT: Use the List of Methods defined in the Lecture Material Google Doc ***********
             * You may find that Method syntax is easier to use since it is most like C#
             * Every one of these can be completed using Linq and then printing with a foreach loop.
             * Push to your github when completed!
             */

            //Print the Sum and Average of numbers  //  do not need foreach loop
            var sum = numbers.Sum();
            var avg = numbers.Average();
            Console.WriteLine($"Sum:\n {sum}\nAverage:\n {avg}");
            Console.WriteLine("-----");

            //Order numbers in ascending order and decsending order. Print each to console.
            var ascending = numbers.OrderBy(numa => numa);
            Console.WriteLine("Ascending:");

            foreach (var numa in ascending)
            {
                Console.WriteLine(numa);
            }
            Console.WriteLine("-----");

            var descending = numbers.OrderByDescending(numd => numd);
            Console.WriteLine("Descending:");

            foreach (var numd in descending)
            {
                Console.WriteLine(numd);
            }
            Console.WriteLine("-----");

            //Print to the console only the numbers greater than 6
            var numGreater6 = numbers.Where(num6 => num6 > 6);
            Console.WriteLine("Greater than 6:");

            foreach (var num6 in numGreater6)
            {
                Console.WriteLine(num6);
            }
            Console.WriteLine("-----");

            //Order numbers in any order (acsending or desc) but only print 4 of them **foreach loop only!**
            Console.WriteLine("Descending First 4 numbers:");

            foreach (var numd in descending.Take(4))
            {
                Console.WriteLine(numd);
            }
            Console.WriteLine("-----");

            //Change the value at index 4 to your age, then print the numbers in decsending order
            Console.WriteLine("Change value index 4 (5):");
            numbers[4] = 46;

            foreach (var item in numbers.OrderByDescending(numd =>numd))
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("-----");

            // List of employees ***Do not remove this***
            var employees = CreateEmployees();

            //Print all the employees' FullName properties to the console only if their FirstName starts with a C OR an S.
            //Order this in acesnding order by FirstName.
            var employeeFullName = employees.Where(nameFirst => nameFirst.FirstName.StartsWith("C") || nameFirst.FirstName.StartsWith("S"))
                .OrderBy(nameFirst => nameFirst.FirstName);

            Console.WriteLine("Employee Names start with C or S:");

            foreach (var employee in employeeFullName)
            {
                Console.WriteLine($" {employee.FirstName}");
            }
            Console.WriteLine("-----");

            //Print all the employees' FullName and Age who are over the age 26 to the console.
            //Order this by Age first and then by FirstName in the same result.
            var over26 = employees.Where(older26 => older26.Age > 26).OrderBy(older26 => older26.Age).ThenBy(older26 => older26.FirstName);
            Console.WriteLine("Employee over the age of 26:");

            foreach (var employee in over26)
            {
                Console.WriteLine($" {employee.FullName} age: {employee.Age}");
            }
            Console.WriteLine("-----");

            //Print the Sum and then the Average of the employees' YearsOfExperience
            //if their YOE is less than or equal to 10 AND Age is greater than 35
            var sumAvg35YOE = employees.Where(yoe35 => yoe35.YearsOfExperience <= 10 && yoe35.Age > 35);

            var sumOfYOE = sumAvg35YOE.Sum(sumYoe => sumYoe.YearsOfExperience);
            var avgOfYOE = sumAvg35YOE.Average(avgYoe => avgYoe.YearsOfExperience);

            Console.WriteLine("Average sum and aver years of experiece:");

            foreach (var employee in sumAvg35YOE)
            {
                Console.WriteLine($" {employee.FullName}\n   Sum of years {sumOfYOE}\n   Average of years {avgOfYOE}");
            }
            Console.WriteLine("-----");

            //Add an employee to the end of the list without using employees.Add()
            Console.WriteLine("Adding Jadeia to employee list:");
            employees = employees.Append(new Employee("Jadeia", "Lance", 23, 12)).ToList();

            foreach (var emp in employees)
            {
                Console.WriteLine($" {emp.FullName} {emp.Age}");
            }
            Console.WriteLine("-----");
           
            Console.WriteLine();
            Console.ReadLine();
        }

        #region CreateEmployeesMethod
        private static List<Employee> CreateEmployees()
        {
            List<Employee> employees = new List<Employee>();
            employees.Add(new Employee("Cruz", "Sanchez", 25, 10));
            employees.Add(new Employee("Steven", "Bustamento", 56, 5));
            employees.Add(new Employee("Micheal", "Doyle", 36, 8));
            employees.Add(new Employee("Daniel", "Walsh", 72, 22));
            employees.Add(new Employee("Jill", "Valentine", 32, 43));
            employees.Add(new Employee("Yusuke", "Urameshi", 14, 1));
            employees.Add(new Employee("Big", "Boss", 23, 14));
            employees.Add(new Employee("Solid", "Snake", 18, 3));
            employees.Add(new Employee("Chris", "Redfield", 44, 7));
            employees.Add(new Employee("Faye", "Valentine", 32, 10));

            return employees;
        }
        #endregion
    }
}
