using System;

namespace _3_Operators___Expressions
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int firstArg = 10;
            int secondArg = 20;

            // arithmetic 
            Console.WriteLine("firstArg + secondArg " + firstArg + secondArg);
            Console.WriteLine("firstArg - secondArg " + (firstArg - secondArg));
            Console.WriteLine("firstArg * secondArg " + firstArg * secondArg);
            Console.WriteLine("firstArg / secondArg " + firstArg / secondArg);
            Console.WriteLine("firstArg % secondArg " + firstArg % secondArg);

            // relational
            Console.WriteLine("firstArg < secondArg " + (firstArg < secondArg));
            Console.WriteLine("firstArg > secondArg " + (firstArg > secondArg));
            Console.WriteLine("firstArg >= secondArg " + (firstArg >= secondArg));
            Console.WriteLine("firstArg <= secondArg " + (firstArg <= secondArg));
            Console.WriteLine("firstArg != secondArg " + (firstArg != secondArg));
            Console.WriteLine("firstArg == secondArg " + (firstArg == secondArg));

            // logical
            Console.WriteLine("true && true " + (true && true));
            Console.WriteLine("true && false " + (true && false));
            Console.WriteLine("false && false " + (false && false));
            Console.WriteLine("false && true " + (false && true));
            Console.WriteLine("true || true " + (true || true));
            Console.WriteLine("true || false " + (true || false));
            Console.WriteLine("false || false " + (false || false));
            Console.WriteLine("false || true " + (false || true));
            Console.WriteLine("!false " + !false);
            Console.WriteLine("!true " + !true);

            // bitwise
            Console.WriteLine("1 & 1 " + (1 & 1));
            Console.WriteLine("true | false " + (true | false));
            Console.WriteLine("1 ^ 1 " + (1 ^ 1));
            Console.WriteLine("8 << 2 " + (8 << 2));
            Console.WriteLine("8 >> 2 " + (8 >> 2));

            // assignment
            Console.WriteLine("firstArg = secondArg " + (firstArg = secondArg));
            Console.WriteLine("firstArg += secondArg " + (firstArg += secondArg));
            Console.WriteLine("firstArg -= secondArg " + (firstArg -= secondArg));

            // conditional 
            Console.WriteLine("firstArg > secondArg " + (firstArg > secondArg ? "Yes" : "No"));
        }
    }
}
