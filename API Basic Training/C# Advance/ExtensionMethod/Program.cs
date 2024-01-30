using System;
using System.Collections.Generic;

namespace ExtensionMethod
{
    /// <summary>
    /// A static class containing extension methods for the List
    /// </summary>
    public static class MyList
    {
        /// <summary>
        /// Prints each element of a List
        /// </summary>
        /// <param name="lst">List</param>
        public static void Print(this List<int> lst)
        {
            foreach (int i in lst)
            {
                Console.WriteLine(i);
            }
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> lst = new List<int> { 370, 380, 390, 400, 410, 420, 430 };
            // Using the custom extension method to print the list
            lst.Print();
        }
    }
}
