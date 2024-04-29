using System;
using System.Collections.Generic;

namespace LambdaExpression
{
    /// <summary>
    /// A simple program demonstrating the use of lambda expressions.
    /// </summary>
    internal class Program
    {
        static void Main(string[] args)
        {
            // Lambda expression with no parameters
            Action name = () => Console.WriteLine("Jeet-Sorathiya");
            name();

            // Lambda expression with parameters
            Func<int, int, long> add = (a, b) => a + b;
            Console.WriteLine("Sum: " + add(4, 4));

            // Lambda expression in a List
            List<int> employeeId = new List<int> { 365, 366, 367, 368, 369, 370 };
            int myId = employeeId.Find(id => id == 369);
            Console.WriteLine("my Id: " + myId);

        }
    }
}
