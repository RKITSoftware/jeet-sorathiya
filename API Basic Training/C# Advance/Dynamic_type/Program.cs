using System;

namespace Dynamic_type
{
    /// <summary>
    ///  demonstration of using dynamic type
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Adds two dynamic items, allowing for flexibility in data types.
        /// </summary>
        /// <param name="item1">The first dynamic item</param>
        /// <param name="item2">The second dynamic item</param>
        /// <returns>The result of the addition operation</returns>
        public static dynamic Add(dynamic item1, dynamic item2)
        {
            return (item1 + item2);
            //return null;
        }
        static void Main(string[] args)
        {
            dynamic item1 = "Hello";
            dynamic item2 = 10;

            Console.WriteLine($"type of item1 : {item1.GetType()}");
            Console.WriteLine($"type of item1 : {item2.GetType()}");
            Console.WriteLine(Add(item2, item1));

            // change value type
            item1 = 20;
            Console.WriteLine($"type of item1 : {item1.GetType()}");
            Console.WriteLine(Add(item2, item1));
        }
    }
}
