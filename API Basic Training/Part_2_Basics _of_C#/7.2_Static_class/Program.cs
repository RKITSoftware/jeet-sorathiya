using System;

namespace _7._2_Static_class
{
    /// <summary>
    /// Class MathOperations
    ///         type : static
    ///         
    ///         Add()
    ///             type : static
    ///             <param>int</param>
    ///             <param>int</param>
    ///             <return>int</return>
    ///         Subtract()
    ///             type : static
    ///             <param>int</param>
    ///             <param>int</param>
    ///             <return>int</return>
    /// </summary>
    #region staic class
    // Static Class
    public static class MathOperations
    {
        public static int Add(int a, int b)
        {
            return a + b;
        }

        public static int Subtract(int a, int b)
        {
            return a - b;
        }
    }
    #endregion

    internal class Program
    {
        static void Main(string[] args)
        {
            #region staic class
            // Static Class
            Console.Write("Enter number 1: ");
            int num1 = int.Parse(Console.ReadLine());

            Console.Write("Enter number 2: ");
            int num2 = int.Parse(Console.ReadLine());

            int sum = MathOperations.Add(num1, num2);
            Console.WriteLine($"Sum: {sum}");

            #endregion
        }
    }
}
