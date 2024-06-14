using System;

namespace Debugging
{
    public class Program
    {
        static void Main(string[] args)
        {
            int value1 = 10, value2 = 20;

            int finalValue = value1 + value2;

#if DEBUG
            Console.WriteLine($"Final value: {finalValue}");
#endif

            for (int i = 0; i < finalValue; i++)
            {
                Console.WriteLine(i);
            }
        }
    }
}
