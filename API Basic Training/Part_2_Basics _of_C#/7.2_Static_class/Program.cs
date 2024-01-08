using System;

namespace _7._2_Static_class
{
    /// <summary>
    /// Demonstrates the use of a static class in C#.
    /// </summary>
    #region Static Class

    // Static Class
    public static class MathOperations
    {

        #region public method
        /// <summary>
        /// Adds two integers.
        /// </summary>
        /// <param name="a">The first integer.</param>
        /// <param name="b">The second integer.</param>
        /// <returns>The sum of the two integers.</returns>
        public static int Add(int a, int b)
        {
            return a + b;
        }

        /// <summary>
        /// Subtracts the second integer from the first integer.
        /// </summary>
        /// <param name="a">The first integer.</param>
        /// <param name="b">The second integer.</param>
        /// <returns>The result of subtracting the second integer from the first integer.</returns>
        public static int Subtract(int a, int b)
        {
            return a - b;
        }
        #endregion
    }

    #endregion

    internal class Program
    {
        static void Main(string[] args)
        {
            #region Static Class

            // Static Class
            Console.Write("Enter number 1: ");
            int num1 = int.Parse(Console.ReadLine());

            Console.Write("Enter number 2: ");
            int num2 = int.Parse(Console.ReadLine());

            // Use static methods from the MathOperations class
            int sum = MathOperations.Add(num1, num2);
            Console.WriteLine($"Sum: {sum}");

            #endregion
        }
    }

}
