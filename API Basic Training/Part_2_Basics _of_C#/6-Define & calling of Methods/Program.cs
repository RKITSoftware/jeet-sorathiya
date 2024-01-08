using System;

namespace _6_Define___calling_of_Methods
{
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
        }
    }

}
