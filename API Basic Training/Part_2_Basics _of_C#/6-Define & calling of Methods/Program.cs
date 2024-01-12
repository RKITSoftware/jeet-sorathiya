using System;

namespace _6_Define___calling_of_Methods
{
    /// <summary>
    /// Demonstartes Object passing method and Dynamic type method using this class
    /// </summary>
    public class Employee
    {
        // store employee name
        string employeeName;

        /// <summary>
        /// contructore that initialize employeeName
        /// </summary>
        /// <param name="name">Name of Employee</param>
        public Employee(string name) 
        {
             employeeName = name;
        }

        /// <summary>
        ///  public method that give who's reporting person
        /// </summary>
        /// <param name="senior">object of Employee class</param>
        public void ReportTo(Employee senior) 
        {
            Console.WriteLine($"{this.employeeName} have to report {senior.employeeName}");
        }

        /// <summary>
        /// return addition of two dynamic value
        /// </summary>
        /// <param name="val1">dynamic value one</param>
        /// <param name="val2">dynamic value two</param>
        /// <returns></returns>
        public dynamic DynamicMethod(dynamic val1, dynamic val2)
        {
            return val1 + val2;
        }

    }
    /// <summary>
    /// Demonstrates defining and calling methods in C#
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// Method with no parameters.
        /// </summary>
        static void MyMethod()
        {
            Console.WriteLine("Hello, Jeet!");
        }

        /// <summary>
        /// Method with a parameter.
        /// </summary>
        /// <param name="name">Name of the person</param>
        static void GreetPerson(string name)
        {
            Console.WriteLine($"Hello, {name}!");
        }

        /// <summary>
        /// Method with parameters and a return value.
        /// </summary>
        /// <param name="a">First number to add.</param>
        /// <param name="b">Second number to add.</param>
        /// <returns>The sum of the two numbers</returns>
        static int AddNumbers(int a, int b)
        {
            return a + b;
        }

        /// <summary>
        /// demonstate optional perameter method
        /// </summary>
        /// <param name="param1">integer param 1</param>
        /// <param name="param2">string 1</param>
        /// <param name="param3">optional integer</param>
        /// <param name="param5">optional string</param>
        /// <param name="param4">optional integer</param>
        static void DisplayNum(int param1, string param2, int param3=10, string param5 = "jeet",int param4 = 20)
        {
            Console.WriteLine($"param1 : {param1},param2 : {param2},param3 : {param3},param4 : {param4},param5 : {param5}");
        }

        /// <summary>
        /// Method with refrance type parameter 
        /// </summary>
        /// <param name="number">refrance of number</param>
        static void RefMethod(ref int number)
        {
            number++;
        }
        static void Main(string[] args)
        {
            // Call the method with no parameters
            MyMethod();

            // Call the method with parameters
            Console.WriteLine("Enter a name: ");
            string personName = Console.ReadLine();
            GreetPerson(personName);

            // Call the method with parameters and a return value
            int result = AddNumbers(5, 7);
            Console.WriteLine($"The result of adding numbers is: {result}");

            // Call the method RefMethod and pass refrance of value
            int num = 1;
            RefMethod(ref num);
            Console.WriteLine($"now num is : {num}");

           // create two object of Employee class
            Employee seniorEmployee = new Employee("Tony Stark");
            Employee juniorEmployee = new Employee("Spider Man");
            // Call the method ReportTo and pass objects
            juniorEmployee.ReportTo(seniorEmployee);

            // dynamic type variable
            dynamic val1 = 56, val2 = 10.2;
            Console.WriteLine($"{val1} + {val2} = {juniorEmployee.DynamicMethod(val1,val2)}");
            int num1 = 10, num2 = 20;
            Console.WriteLine($"{num1} + {num2} = {juniorEmployee.DynamicMethod(num1, num2)}");

            // optional perameters
            DisplayNum(1, "hello",2,"js",60);


        }
    }

}
