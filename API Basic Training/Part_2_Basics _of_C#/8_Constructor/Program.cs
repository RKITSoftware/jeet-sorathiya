using System;

namespace _8_Constructor
{
    /// <summary>
    ///  Class Person
    ///     field
    ///         string name
    ///         int age
    ///     Person()
    ///         <param></param>
    ///     Person()
    ///         <param>string</param>
    ///         <pram>int</pram>
    ///     Person()
    ///         <param>Person</param>
    ///     Display()
    ///         <param></param>
    ///         <return>void</return>
    /// </summary>
    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }

        // Default Constructor
        public Person()
        {
            Console.WriteLine("Default Constructor Called");
        }

        // Parameterized Constructor
        public Person(string name, int age)
        {
            Name = name;
            Age = age;
            Console.WriteLine("Parameterized Constructor Called");
        }

        //  Copy Constructor
        public Person(Person original)
        {
            Name = original.Name;
            Age = original.Age;
            Console.WriteLine("Simulated Copy Constructor Called");
        }

        public void Display()
        {
            Console.WriteLine($"Person Details: Name - {Name}, Age - {Age}");
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            // Creating an object with the default constructor
            Person person1 = new Person();
            person1.Display();

            // Creating an object with the parameterized constructor
            Person person2 = new Person("jeet", 20);
            person2.Display();

            // Using copy constructor to create a new object
            Person person3 = new Person(person2);
            person3.Display();
        }
    }
}
