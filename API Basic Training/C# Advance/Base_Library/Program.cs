using MyList;
using System;

namespace Base_Library
{
    /// <summary>
    /// A demonstration program using the MyList class
    /// </summary>
    internal class Program
    {
        static void Main(string[] args)
        {
            // Creating an instance of MyList with integer elements
            MyList<int> list = new MyList<int>();

            // Adding elements to the list
            list.AddToList(1);
            list.AddToList(2);
            list.AddToList(3);
            list.AddToList(4);

            // Removing an element from the list
            list.RemoveToList(1);

            // Displaying the elements in the list using a foreach loop
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
        }
    }
}
