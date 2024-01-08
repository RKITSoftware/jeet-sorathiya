using System;

namespace _15_Namespace
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter Trainee Name : ");
            string name = Console.ReadLine();
            Trainee objofTrainee = new Trainee(name); // Trainee Class is in same namespace
        }
    }
}
