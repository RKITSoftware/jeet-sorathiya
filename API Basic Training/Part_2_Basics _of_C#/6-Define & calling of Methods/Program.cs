using System;

namespace _6_Define___calling_of_Methods
{
    /// <summary>
    /// method for reduce code
    ///     MyMethod()
    ///          return type : void
    ///          argument : no
    ///     GreetPerson(string)
    ///          return type : void
    ///          argument : string
    ///      AddNumbers(int,int)
    ///          return type : int
    ///          argument : int,int 
    /// </summary>
    internal class Program
    {
        // method with no parameters
        static void MyMethod()
        {
            Console.WriteLine("Hello, Jeet!");
        }

        // method with parameters
        static void GreetPerson(string name)
        {
            Console.WriteLine($"Hello, {name}!");
        }

        // method with a return value
        static int AddNumbers(int a, int b)
        {
            return a + b;
        }
        static void Main(string[] args)
        {
            // Call the method with no parameters
            MyMethod();

            // Call the method with parameters
            string personName = Console.ReadLine();
            GreetPerson(personName);

            // Call the method with a return value
            int result = AddNumbers(5, 7);
            Console.WriteLine($"The result of adding numbers is: {result}");
        }
    }
}
