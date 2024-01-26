using System;

namespace Debugging
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int value1 = 10, value2 = 20;

            int finalValue = value1 + value2;

            for(int i = 0; i < finalValue; i++)
            {
                Console.WriteLine(i);
            }
        }
    }
}
